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

namespace WindowsFormsApp11
{
    public partial class Client : Form
    {
        TcpClient client ;
        NetworkStream stream;
        Thread thread;
        string _Path;
       
        
        string clientNum = "";

        ///ppt
        const int maxPPT = 4;
        Button[] ButtonPPT = new Button[maxPPT];
        Label[] LabelPPT = new Label[maxPPT];
        Panel[] PanelPPT = new Panel[maxPPT];
        TextBox[] TextBoxPage = new TextBox[maxPPT];

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

            PanelPPT[0] = ppt1_panel;
            PanelPPT[1] = ppt2_panel;
            PanelPPT[2] = ppt3_panel;

            TextBoxPage[0] = ppt1pagenum;
            TextBoxPage[1] = ppt2pagenum;
            TextBoxPage[2] = ppt3pagenum;


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
                { /**/
                    if (clientNum == "")
                    {
                        byte[] ReadByte2;
                        ReadByte2 = new byte[client.ReceiveBufferSize];
                        int BytesRead2 = stream.Read(ReadByte2, 0, (int)ReadByte2.Length);
                        clientNum = Encoding.GetEncoding("utf-8").GetString(ReadByte2, 0, BytesRead2);
                        Console.WriteLine(clientNum);
                    } /**/

                    byte[] ReadByte;
                    ReadByte = new byte[client.ReceiveBufferSize];

                    int BytesRead = stream.Read(ReadByte, 0, (int)ReadByte.Length);
                    filename = Encoding.GetEncoding("utf-8").GetString(ReadByte, 0, BytesRead);
                    if (filename != "")
                    {
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


                        if (Directory.Exists(_Path + @"\" + clientNum))
                        {
                            Console.WriteLine("That path exists already.");
                        }
                        else
                        {
                            DirectoryInfo di = Directory.CreateDirectory(_Path + @"\" + clientNum);
                        }

                        FileStream fs = new FileStream(_Path + @"\"+clientNum + @"\" + filename, FileMode.Create, FileAccess.Write, FileShare.None);
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
                            ButtonPPT[IdxPPT].Tag = _Path + @"\" + clientNum + @"\" + filename;
                            LabelPPT[IdxPPT].Visible = true;
                            LabelPPT[IdxPPT].Text = Path.GetFileNameWithoutExtension(filename);
                            PanelPPT[IdxPPT].Visible = false;
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
            TextBoxPage[pptNum].Text = pagenum.ToString();

            //Send to Server
            try
            {
                byte[] buffer = new byte[1024 * 4];

                PageNum page = new PageNum();
                page.packet_Type = (int)PacketType.PAGENUM;
                page.pageNum = pagenum;

                Packet.Serialize(page).CopyTo(buffer, 0);

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
           
        }

        private void selectBtn1_Click(object sender, EventArgs e)
        {
            SelectPage(0);
        }

        private void saveBtn1_Click(object sender, EventArgs e)
        {
            savePage(0);
        }

        private void selectBtn2_Click(object sender, EventArgs e)
        {
            SelectPage(1);
        }

        private void saveBtn2_Click(object sender, EventArgs e)
        {
            savePage(1);
        }

        private void selectBtn3_Click(object sender, EventArgs e)
        {
            SelectPage(2);
        }

        private void saveBtn3_Click(object sender, EventArgs e)
        {
            savePage(2);
        }
    }
}
