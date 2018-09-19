using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Configuration;
using System.IO;
using System.Threading;
using Microsoft.Office.Core;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using ClassLibrary;

namespace WindowsFormsApp11
{
    public partial class Client : Form
    {
        TcpClient client ;
        NetworkStream stream;
        Thread thread;
        string _Path;
       
        
        string clientNum = "";

        ///packet
        public UploadPacket uploadPacket;
        public LockPacket lockPacket;
        public ListPacket listPacket;

        ///ppt
        const int maxPPT = 4;
        Button[] ButtonPPT = new Button[maxPPT];
        Label[] LabelPPT = new Label[maxPPT];
        Panel[] PanelPPT = new Panel[maxPPT];

        int IdxPPT = 0;
        PowerPoint.Application[] ppt = new PowerPoint.Application[maxPPT];
        PowerPoint.Presentations[] presentations = new PowerPoint.Presentations[maxPPT];
        PowerPoint.Presentation[] presentation = new PowerPoint.Presentation[maxPPT];

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
            //ButtonPPT[3] = button_ppt3;
            LabelPPT[0] = label_ppt0;
            LabelPPT[1] = label_ppt1;
            LabelPPT[2] = label_ppt2;
            // LabelPPT[3] = label_ppt3;

            


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
            
        }

        private void button_Enter_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.Enabled = true;
            panel2.Parent = panel1;
            panel2.Visible = true;
            panel2.Enabled = true;
            

            string IP = textBox1_IP.Text;
            int port = Convert.ToInt32(textBox_Port.Text);
            client = new TcpClient();
            client.Connect(IP, port);
            stream = client.GetStream();


            //자신이름리스트에등록
            ListViewItem li1 = new ListViewItem();
            li1.Text = textBox_name.Text;
            li1.SubItems.Add("");
            li1.SubItems.Add("");
            listView1.Items.Add(li1);

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
            Console.WriteLine("Socket_C");
            while (true)
            {
                string filename;
                if (stream.CanRead && stream.CanWrite)
                {
                    byte[] ReadByte;
                    ReadByte = new byte[client.ReceiveBufferSize];
                    int BytesRead = stream.Read(ReadByte, 0, (int)ReadByte.Length);
                    string str = Encoding.UTF8.GetString(ReadByte);
                    filename = Encoding.GetEncoding("utf-8").GetString(ReadByte, 0, BytesRead);

                    if (str[0] == '#')
                    {

                        //이름리스트에등록
                        Console.WriteLine("add servername " + str);
                        string[] names = str.Split('/');
                        for (int i = 0; i < names.Length-1; i++)
                        {
                            ListViewItem li = new ListViewItem();
                            if (i == 0)
                                li.Text = names[i].Substring(1, names[i].Length - 1);
                            else
                                li.Text = names[i];
                            li.SubItems.Add("");
                            li.SubItems.Add("");

                            Invoke((MethodInvoker)delegate
                            {
                                listView1.Items.Add(li);
                            });

                           
                        }

                    }
                    else if(str[0] == '*'){
                        ///추가된client이름등록
                        ListViewItem li = new ListViewItem();
                        li.Text = str.Substring(1,str.Length-1);
                        li.SubItems.Add("");
                        li.SubItems.Add("");
                        listView1.Items.Add(li);
                    }
                    else if(str[0]== 'c')
                    {
                        string[] info = str.Split('/');
                        string name = info[0].Substring(1, info[0].Length - 1);
                        string pptnum = info[1];
                        string pagenum = info[2];
                        
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
                    }
                    else if (filename != "")
                    {


                        ///packet.type = upload
                        byte[] buffer = new byte[1024 * 4];
                        uploadPacket = new UploadPacket();
                        uploadPacket.type = (int)PacketType.UPLOAD;
                        uploadPacket.isup = true;
                        Packet.Serialize(uploadPacket).CopyTo(buffer, 0);
                        stream.Write(buffer, 0, buffer.Length);
                        Console.WriteLine("uploadpacket");

                        MessageBox.Show(filename);
                        Byte[] sendBytes = Encoding.GetEncoding("utf-8").GetBytes(_Path + @"\" + filename);
                        stream.Write(sendBytes, 0, sendBytes.Length);

                        int ByteSize = 0;
                        Byte[] FileSizeBytes = new byte[client.ReceiveBufferSize];
                        ByteSize = stream.Read(FileSizeBytes, 0, FileSizeBytes.Length);
                        int MaxFileLength = Convert.ToInt32(Encoding.UTF8.GetString(FileSizeBytes, 0, ByteSize));

                        /*전송준비작업을 완료했다고 서버에 전해줌*/
                        byte[] ReadyTransBytes = new byte[client.ReceiveBufferSize];
                        ReadyTransBytes = Encoding.UTF8.GetBytes("READY");
                        stream.Write(ReadyTransBytes, 0, ReadyTransBytes.Length);

                        FileStream fs = new FileStream(_Path + @"\" + filename, FileMode.Create, FileAccess.Write, FileShare.None);

                        if (filename != string.Empty)
                        {

                            byte[] myReadBuffer = new byte[1024];
                            int numberOfBytesRead = 0;

                            do
                            {
                                numberOfBytesRead = stream.Read(myReadBuffer, 0, myReadBuffer.Length);
                                fs.Write(myReadBuffer, 0, numberOfBytesRead);
                            }
                            //while (fs.Length < MaxFileLength);
                            while (stream.DataAvailable);
                        }
                        fs.Flush();
                        fs.Close();
                        stream.Flush();

                        Invoke((MethodInvoker)delegate
                        {
                            ButtonPPT[IdxPPT].Visible = true;
                            ButtonPPT[IdxPPT].Enabled = true;
                            ButtonPPT[IdxPPT].Tag = _Path + @"\" + filename;
                            LabelPPT[IdxPPT].Visible = true;
                            LabelPPT[IdxPPT].Text = Path.GetFileNameWithoutExtension(filename);

                            IdxPPT++;
                        });


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
            int pagenum = ppt[pptNum].ActiveWindow.Selection.SlideRange.SlideNumber;
            
            //Send to Server
            try
            {
                Console.WriteLine("select");
                byte[] buffer = new byte[1024 * 4];
                lockPacket = new LockPacket();
                lockPacket.type = (int)PacketType.LOCK;
                lockPacket.pptNum = pptNum;
                lockPacket.pageNum = pagenum ;

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
        {/*
            if (TextBoxPage[pptNum].Text == "")
                MessageBox.Show("수정할 페이지를 선택후 저장해주세요.");
            else
            {
                int pagenum = Int32.Parse(TextBoxPage[pptNum].Text);
                try
                {
                    byte[] buffer = new byte[1024 * 4];

                    SlidePacket pSlide = new SlidePacket();
                    pSlide.packet_Type = (int)PacketType.SAVESLIDE;
                    pSlide.pptNum = pptNum;
                    pSlide.pageNum = pagenum;
                    pSlide.slide = presentation[pptNum].Slides[pagenum];

                    Packet.Serialize(pSlide).CopyTo(buffer, 0);

                    stream.Write(buffer, 0, buffer.Length);
                    stream.Flush();

                    TextBoxPage[pptNum].Text = "";

                }
                catch (Exception e)
                {
                    Console.WriteLine("savePage() 에러 : " + e.Message);
                }
            }
           */
        }
          
        private void button_lock_Click(object sender, EventArgs e)
        {
            SelectPage(0);
        }
        
    }
}
