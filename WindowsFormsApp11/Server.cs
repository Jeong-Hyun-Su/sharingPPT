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
using System.Threading;
using System.Diagnostics;
using System.Configuration;
using System.IO;
using Microsoft.Office.Core;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;

namespace WindowsFormsApp11
{
    public partial class Server : Form
    {
        ///socet
        //Listener_Class listener;
        //List<Client_Class> ClientList;

        TcpListener listener;
        List<HandleClient> clientList;
        int nClient = 0;      //연결된클라이언트갯수
        Thread thread;
        Socket socket;
        

        ///ppt
        const int maxPPT = 4;
        Button []ButtonPPT = new Button[maxPPT];
        Label[] LabelPPT = new Label[maxPPT];
        int IdxPPT = 0;
        PowerPoint.Application []ppt = new PowerPoint.Application[maxPPT];
        PowerPoint.Presentations []presentations = new PowerPoint.Presentations[maxPPT];
        PowerPoint.Presentation []presentation = new PowerPoint.Presentation[maxPPT];
        //PowerPoint.Slides slides;
        //PowerPoint.Slide slide;

        public Server()
        {
            InitializeComponent();
        }

        private void Server_Load(object sender, EventArgs e)
        {
            label_IP.Text = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
            
            clientList = new List<HandleClient>();
            

            ButtonPPT[0] = button_ppt0;
            ButtonPPT[1] = button_ppt1;
            ButtonPPT[2] = button_ppt2;
            //ButtonPPT[3] = button_ppt3;
            LabelPPT[0] = label_ppt0;
            LabelPPT[1] = label_ppt1;
            LabelPPT[2] = label_ppt2;
           // LabelPPT[3] = label_ppt3;

        }

        private void button_Make_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.Enabled = true;
           
            thread = new Thread(StartServer);
            thread.Start();
        }

        private void StartServer()
        {
            /////client 연결
            int port = Convert.ToInt32(textBox_Port.Text);
            listener = new TcpListener(IPAddress.Any, port);
            TcpClient client ;
            listener.Start();

            while (true)
            {
                try
                {
                    client = listener.AcceptTcpClient();

                    HandleClient handleClient = new HandleClient();
                    handleClient.newClient(client, nClient);

                    clientList.Add(handleClient);
                    nClient++;
                    Invoke((MethodInvoker)delegate
                    {
                        label1.Text = nClient.ToString();
                    });
                }
                catch(Exception ex)
                {
                    return;
                }
            }
        }

        private void Server_FormClosed(object sender, FormClosedEventArgs e)
        {
            listener.Stop();
            thread.Abort();
        }

        private void button_Upload_Click(object sender, EventArgs e)
        {
            ////ppt 업로드 버튼
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ButtonPPT[IdxPPT].Visible = true;
                ButtonPPT[IdxPPT].Enabled = true;
                ButtonPPT[IdxPPT].Tag = openFileDialog1.FileName;
                LabelPPT[IdxPPT].Visible = true;
                LabelPPT[IdxPPT].Text = Path.GetFileNameWithoutExtension(openFileDialog1.SafeFileName);
                IdxPPT++;
                
                for(int i=0; i<nClient; i++)
                {
                    if (clientList[i].isConnect == true)
                    {
                        clientList[i].fName = openFileDialog1.FileName;
                        clientList[i].isUpload = true;
                    }
                }
            }
        }

        void ButtonPPT_Click(object sender, EventArgs e)
        {
            int idx = -1;
            for(int i=0; i<maxPPT; i++)
            {
                if (ButtonPPT[i] == sender)
                    idx = i;
            }
            ppt[idx] = new PowerPoint.Application();
            presentations[idx] = ppt[idx].Presentations;
            presentation[idx] = presentations[idx].Open(ButtonPPT[idx].Tag.ToString(), MsoTriState.msoFalse, MsoTriState.msoFalse, MsoTriState.msoCTrue);

        }
    }
}
