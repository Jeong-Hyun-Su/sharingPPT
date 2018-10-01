using ClassLibrary;
using Microsoft.Office.Core;
using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;

namespace WindowsFormsApp11
{
    public partial class Client : Form
    {
        TcpClient client;
        NetworkStream stream;
        Thread thread;
        string _Path;
        string _namePath;


        string clientNum = "";

        ///packet
        public UploadPacket uploadPacket;
        public LockPacket lockPacket;
        public ListPacket listPacket;
        public SavePacket savePacket;

        ///ppt
        const int maxPPT = 3;
        int savePageNum, lockPageNum, savePptNum, lockPptNum;
        Button[] ButtonPPT = new Button[maxPPT];
        Label[] LabelPPT = new Label[maxPPT];
        Panel[] PanelPPT = new Panel[maxPPT];

        int IdxPPT = 0;
        PowerPoint.Application[] ppt = new PowerPoint.Application[maxPPT];
        PowerPoint.Presentations[] presentations = new PowerPoint.Presentations[maxPPT];
        PowerPoint.Presentation[] presentation = new PowerPoint.Presentation[maxPPT];
        int[] slideCnt = new int[maxPPT];

        public Client()
        {
            InitializeComponent();
        }


        private void Client_Load(object sender, EventArgs e)
        {
            _Path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            ButtonPPT[0] = button_ppt0;
            ButtonPPT[1] = button_ppt1;
            ButtonPPT[2] = button_ppt2;
            LabelPPT[0] = label_ppt0;
            LabelPPT[1] = label_ppt1;
            LabelPPT[2] = label_ppt2;


        }

        void ButtonPPT_Click(object sender, EventArgs e)
        {
            int idx = -1;
            for (int i = 0; i < maxPPT; i++)
            {
                if (ButtonPPT[i] == sender)
                    idx = i;
            }

            ppt[idx] = new PowerPoint.Application();
            presentations[idx] = ppt[idx].Presentations;
            presentation[idx] = presentations[idx].Open(ButtonPPT[idx].Tag.ToString(), MsoTriState.msoFalse, MsoTriState.msoFalse, MsoTriState.msoCTrue);
            slideCnt[idx] = presentation[idx].Slides.Count;
        }

        private void button_Enter_Click(object sender, EventArgs e)
        {
            if (string.Equals(textBox1_IP.Text, string.Empty))
                return;
            if (string.Equals(textBox_Port.Text, string.Empty))
                return;
            if (string.Equals(textBox_name.Text, string.Empty))
                return;
            
            try
            {
                string IP = textBox1_IP.Text;
                int port = Convert.ToInt32(textBox_Port.Text);
                client = new TcpClient();
                client.Connect(IP, port);
                stream = client.GetStream();
            }
            catch(Exception ex)
            {
                MessageBox.Show("IP 와 PORT 를 확인해주세요.");
                return;
            }


            panel1.Visible = true;
            panel1.Enabled = true;
            panel2.Parent = panel1;
            panel2.Visible = true;
            panel2.Enabled = true;

            ///자신이름리스트에등록
            ListViewItem li1 = new ListViewItem();
            li1.Text = textBox_name.Text;
            li1.SubItems.Add("");
            li1.SubItems.Add("");
            listView1.Items.Add(li1);

            /// 자신name 서버로 전송  //packetType = LISTVIEW
            byte[] buffer = new byte[1024 * 4];
            listPacket = new ListPacket();
            listPacket.type = (int)PacketType.LISTVIEW;
            listPacket.listName = textBox_name.Text;
            Packet.Serialize(listPacket).CopyTo(buffer, 0);
            stream.Write(buffer, 0, buffer.Length);



            thread = new Thread(Socket_C);
            thread.Start();


        }

        private void Socket_C()
        {
            Console.WriteLine("**** Socket_C ****");
            while (true)
            {
                string filename;
                if (stream.CanRead && stream.CanWrite)
                {
                    ///서버로부터 전송된 data 읽음
                    byte[] ReadByte;
                    ReadByte = new byte[client.ReceiveBufferSize];
                    int BytesRead = stream.Read(ReadByte, 0, (int)ReadByte.Length);
                    string str = Encoding.UTF8.GetString(ReadByte);
                    filename = Encoding.GetEncoding("utf-8").GetString(ReadByte, 0, BytesRead);

                    ///server와 연결되있는client의 name들 리스트뷰에 등록
                    if (str.Substring(0, 5) == "NAME#")
                    {
                        Console.WriteLine("add servername " + str);
                        string[] names = str.Split('/');
                        for (int i = 1; i < names.Length - 1; i++)
                        {
                            ListViewItem li = new ListViewItem();
                            li.Text = names[i];
                            li.SubItems.Add("");
                            li.SubItems.Add("");

                            Invoke((MethodInvoker)delegate
                            {
                                listView1.Items.Add(li);
                            });


                        }

                    }
                    ///추가로 연결되는 client의 name 리스트뷰에 등록
                    else if (str.Substring(0, 5) == "NAME*")
                    {
                        ListViewItem li = new ListViewItem();
                        li.Text = str.Substring(5, str.Length - 5);
                        li.SubItems.Add("");
                        li.SubItems.Add("");
                        Invoke((MethodInvoker)delegate
                        {
                            listView1.Items.Add(li);
                        });
                    }
                    ///다른 클라이언트의 lock값 변경
                    else if (str.Substring(0, 7) == "CHANGE@")
                    {
                        string[] info = str.Split('/');
                        string name = info[1];
                        string pptnum = info[2];
                        string pagenum = info[3];

                        Invoke((MethodInvoker)delegate
                        {
                            for (int i = 0; i < listView1.Items.Count; i++)
                            {
                                ListViewItem item = listView1.Items[i];
                                bool isContains = item.SubItems[0].Text.Contains(name);
                                if (isContains)
                                {
                                    item.SubItems[1].Text = pptnum;
                                    item.SubItems[2].Text = pagenum;
                                    break;
                                }
                            }
                        });
                    }
                    ///lock실패했을경우
                    else if (str.Substring(0, 5) == "FAIL@")
                    {
                        MessageBox.Show("다른사용자가 편집중인 슬라이드입니다");
                    }
                    ///다른 사용자가 피피티를 편집했을 경우
                    else if (str.Substring(0, 5) == "EDIT@")
                    {
                        string[] info = str.Split('/');
                        int fileSize = Convert.ToInt32(info[1]);
                        int pptnum = Convert.ToInt32(info[2]);
                        int pagenum = Convert.ToInt32(info[3]);
                        bool isadd;
                        if (info[4].CompareTo("True") == 0)
                            isadd = true;
                        else
                            isadd = false;


                        //변경할슬라이드가있는 피피티파일을 읽어와 'edit.pptx'생성후 저장
                        byte[] myReadBuffer = new byte[1024];
                        int numberOfBytesRead = 0;
                        string path = _namePath + @"\" + "edit.pptx";
                        FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
                        
                        do
                        {
                            numberOfBytesRead = stream.Read(myReadBuffer, 0, myReadBuffer.Length);
                            fs.Write(myReadBuffer, 0, numberOfBytesRead);
                        }
                        while (fs.Length < fileSize);

                        fs.Close();

                        PowerPoint.Slides tempSlides = presentation[pptnum].Slides;
                        if (isadd)
                        {
                            tempSlides.InsertFromFile(path, pagenum - 1, 1, 1);
                        }
                        else
                        {
                            tempSlides.InsertFromFile(path, pagenum, 1, 1);
                            tempSlides[pagenum].Delete();
                        }

                        File.Delete(path);

                    }
                    else if (str.Substring(0, 7) == "UPLOAD@")
                    {

                        if (filename != "")
                        {
                            ///upload시작한다고 server에게 전달 ///packetType = upload
                            byte[] buffer = new byte[1024 * 4];
                            uploadPacket = new UploadPacket();
                            uploadPacket.type = (int)PacketType.UPLOAD;
                            uploadPacket.isup = true;
                            Packet.Serialize(uploadPacket).CopyTo(buffer, 0);
                            stream.Write(buffer, 0, buffer.Length);
                            Console.WriteLine("uploadpacket");

                            _namePath = _Path + @"\" + textBox_name.Text;
                            filename = filename.Substring(7, filename.Length - 7);
                            Byte[] sendBytes = Encoding.GetEncoding("utf-8").GetBytes(_namePath + @"\" + filename);
                            stream.Write(sendBytes, 0, sendBytes.Length);

                            int ByteSize = 0;
                            Byte[] FileSizeBytes = new byte[client.ReceiveBufferSize];
                            ByteSize = stream.Read(FileSizeBytes, 0, FileSizeBytes.Length);
                            int MaxFileLength = Convert.ToInt32(Encoding.UTF8.GetString(FileSizeBytes, 0, ByteSize));

                            ///전송준비작업을 완료했다고 서버에 전해줌
                            byte[] ReadyTransBytes = new byte[client.ReceiveBufferSize];
                            ReadyTransBytes = Encoding.UTF8.GetBytes("READY");
                            stream.Write(ReadyTransBytes, 0, ReadyTransBytes.Length);


                            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(_namePath);
                            if (di.Exists == false)
                                di.Create();
                            FileStream fs = new FileStream(_namePath + @"\" + filename, FileMode.Create, FileAccess.Write, FileShare.None);

                            if (filename != string.Empty)
                            {
                                byte[] myReadBuffer = new byte[1024];
                                int numberOfBytesRead = 0;

                                do
                                {
                                    Console.WriteLine("FFFFF");
                                    numberOfBytesRead = stream.Read(myReadBuffer, 0, myReadBuffer.Length);
                                    fs.Write(myReadBuffer, 0, numberOfBytesRead);
                                }
                                while (fs.Length < MaxFileLength);
                                //while (stream.DataAvailable);
                            }
                            fs.Flush();
                            fs.Close();
                            stream.Flush();

                            Invoke((MethodInvoker)delegate
                            {
                                ButtonPPT[IdxPPT].Visible = true;
                                ButtonPPT[IdxPPT].Enabled = true;
                                ButtonPPT[IdxPPT].Tag = _namePath + @"\" + filename;
                                LabelPPT[IdxPPT].Visible = true;
                                LabelPPT[IdxPPT].Text = Path.GetFileNameWithoutExtension(filename);

                                IdxPPT++;
                            });


                        }
                    }
                }
            }
        }

        private void Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            client.Close();
            thread.Abort();
        }


        private void SelectPage(int pptNum)
        {
            lockPptNum = pptNum;
            lockPageNum = ppt[pptNum].ActiveWindow.Selection.SlideRange.SlideNumber;

            ///lock한 ppt와page 넘버 서버에게전송 //packetType = LOCK
            try
            {
                Console.WriteLine("select");
                byte[] buffer = new byte[1024 * 4];
                lockPacket = new LockPacket();
                lockPacket.type = (int)PacketType.LOCK;
                lockPacket.pptNum = pptNum;
                lockPacket.pageNum = lockPageNum;

                Packet.Serialize(lockPacket).CopyTo(buffer, 0);
                stream.Write(buffer, 0, buffer.Length);

                stream.Flush();

            }
            catch (Exception e)
            {
                Console.WriteLine("SelectPage() 에러 : " + e.Message);
            }

        }

        private void savePage(int pptNum)
        {
            savePptNum = pptNum;
            savePageNum = ppt[pptNum].ActiveWindow.Selection.SlideRange.SlideNumber;

            //save와lock다른경우
            if ((savePageNum != lockPageNum) || (savePptNum != lockPptNum))
            {
                MessageBox.Show(lockPageNum + "의 slide를 수정완료먼저해주세요");
                return;
            }
            
            try
            {
                //save slide복사해서 새로운피피티 생성
                presentation[pptNum].Save();
                PowerPoint.Application tempPpt = new PowerPoint.Application();
                PowerPoint.Presentation tempPresentation = tempPpt.Presentations.Add(MsoTriState.msoFalse);
                PowerPoint.Slides tempSlides = tempPresentation.Slides;
                tempSlides.InsertFromFile(ButtonPPT[pptNum].Tag.ToString(), 0, savePageNum, savePageNum);
                tempPresentation.SaveAs(_namePath + @"\" + "slide");
                FileInfo file = new FileInfo(_namePath + @"\" + "slide.pptx");

                //savePacket
                Console.WriteLine("client : save");
                byte[] buffer = new byte[1024 * 4];
                savePacket = new SavePacket();
                savePacket.type = (int)PacketType.SAVE;
                savePacket.pptNum = pptNum;
                savePacket.pageNum = savePageNum;
                savePacket.isSave = true;
                savePacket.fileSize =file.Length;
                if (presentation[pptNum].Slides.Count == slideCnt[pptNum])  //추가된슬라이드인가
                    savePacket.isAdd = false;
                else
                    savePacket.isAdd = true;
                slideCnt[pptNum] = presentation[pptNum].Slides.Count;

                Packet.Serialize(savePacket).CopyTo(buffer, 0);
                stream.Write(buffer, 0, buffer.Length);

               
                //새로운피피티 server로보냄
                FileStream fs = file.OpenRead();
                byte[] bytes =  new byte[fs.Length];
                fs.Read(bytes, 0, bytes.Length);
                stream.Write(bytes, 0, bytes.Length);
                
                tempPresentation.Close();
                fs.Close();
                stream.Flush();

                File.Delete(_namePath + @"\" + "slide.pptx");



            }
            catch (Exception e)
            {
                Console.WriteLine("savePage() 에러 : " + e.Message);
            }


        }

        private void button_lock_Click(object sender, EventArgs e)
        {
            SelectPage(0);
        }

        private void button_unlock_Click(object sender, EventArgs e)
        {
            savePage(0);
        }
    }
}