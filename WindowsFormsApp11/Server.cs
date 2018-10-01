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
using System.Runtime.InteropServices;

namespace WindowsFormsApp11
{
    public partial class Server : Form
    {

        ///socket
        TcpListener listener;
        List<HandleClient> clientList;  
        int nClient = 0;                //연결된클라이언트갯수
        Thread thread;
        Socket socket;
        

        ///ppt
        const int maxPPT = 3;
        Button []ButtonPPT = new Button[maxPPT];
        Label[] LabelPPT = new Label[maxPPT];
        int IdxPPT = 0, curIdxPPT=0;
        PowerPoint.Application []ppt = new PowerPoint.Application[maxPPT];
        PowerPoint.Presentations []presentations = new PowerPoint.Presentations[maxPPT];
        PowerPoint.Presentation []presentation = new PowerPoint.Presentation[maxPPT];
        List<List<int>> pptLockInfo = new List<List<int>>(maxPPT);

        ///server lock관련 변수
        bool askLock;
        int lockPptNum;
        int lockPageNum;
        string name;

        ///server unlock관련 변수
        bool isAddSlide;
        bool askSave;
        int savePptNum;
        int savepageNum;
        string saveFileName;

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
            LabelPPT[0] = label_ppt0;
            LabelPPT[1] = label_ppt1;
            LabelPPT[2] = label_ppt2;

        }

        private void button_Make_Click(object sender, EventArgs e)
        {
            if (string.Equals(textBox_Port.Text, string.Empty))
                return;
            if (string.Equals(textBox_name.Text, string.Empty))
                return;
            panel1.Visible = true;
            panel1.Enabled = true;
           
            //리스트뷰에 자신(서버)name 추가
            ListViewItem li = new ListViewItem();
            li.Text = textBox_name.Text;
            li.SubItems.Add("");
            li.SubItems.Add("");
            listView1.Items.Add(li);

            this.name = textBox_name.Text;

            //스레드시작
            thread = new Thread(StartServer);
            thread.Start();

            Thread lockThread = new Thread(checkLock);
            lockThread.Start();
        }
        

        private void StartServer()
        {
          
            int port = Convert.ToInt32(textBox_Port.Text);
            listener = new TcpListener(IPAddress.Any, port);
            TcpClient client ;
            listener.Start();

            while (true)
            {
                try
                {
                    ///client 연결
                    client = listener.AcceptTcpClient();
                    HandleClient handleClient = new HandleClient();

                    ///연결된 클라이언트 전 까지 연결된 클라이언트의 name들
                    string names=textBox_name.Text+"/";
                    for(int i=0; i<nClient; i++)
                    {
                        names = names + clientList[i].name + "/";
                    }

                    ///clientList에 추가
                    handleClient.newClient(client, nClient,names);
                    clientList.Add(handleClient);

                    ///전에 업로드된 ppt갯수 값 설정
                    if (IdxPPT > 0)
                    {
                        clientList[nClient].beforeUploadNum = IdxPPT;
                    }
                    else
                    {
                        clientList[nClient].beforeUploadNum = 0;
                    }

                    ///연결된 클라이언트의 name 리스트뷰에추가 & 다른클라이언트들에게 보냄
                    while (true)
                    {
                        if(clientList[nClient].isAddName == true)
                        {
                            ListViewItem li = new ListViewItem();
                            li.Text = clientList[nClient].name;
                            li.SubItems.Add("");
                            li.SubItems.Add("");

                            Invoke((MethodInvoker)delegate
                            {
                                listView1.Items.Add(li);
                            });

                            for(int i=0; i<nClient; i++)
                            {
                                if (clientList[i].isConnect)
                                    clientList[i].AddList(clientList[nClient].name);
                            }
                            break;
                        }
                        
                    }
                    ///늦게들어온 클라이언트 파일 전송
                    while (true)
                    {
                        if (clientList[nClient].beforeUploadNum > 0)
                        {
                            int num = clientList[nClient].beforeUploadNum;
                            for (int j = 0; j < num; j++)
                            {
                                if (clientList[nClient].isConnect == true)
                                {
                                    clientList[nClient].fName = ButtonPPT[j].Tag.ToString();
                                    clientList[nClient].isUpload = true;
                                    clientList[nClient].Upload(1);

                                    while (clientList[nClient].isUpload) //클라이언트가 받고있는중
                                        ;
                                    Thread.Sleep(500);
                                }
                            }
                            clientList[nClient].beforeUploadNum = 0;
                            break;
                        }
                        else
                            break;
                    }

                    nClient++;
                    Invoke((MethodInvoker)delegate
                    {
                        label1.Text = nClient.ToString();
                    });
                    

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void Server_FormClosed(object sender, FormClosedEventArgs e)
        {
            listener.Stop();
            thread.Abort();
        }
        
        ///// PPT업로드 /////
        private void button_Upload_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ButtonPPT[IdxPPT].Visible = true;
                ButtonPPT[IdxPPT].Enabled = true;
                ButtonPPT[IdxPPT].Tag = openFileDialog1.FileName;
                LabelPPT[IdxPPT].Visible = true;
                LabelPPT[IdxPPT].Text = Path.GetFileNameWithoutExtension(openFileDialog1.SafeFileName);
               
                pptLockInfo.Add(new List<int>());
               
                //리스트 초기화 -> 피피티 슬라이드 수만큼 초기화하도록 바꿔야함
                for (int i=0;i<30;i++)
                {
                    pptLockInfo[IdxPPT].Add(-1);
                }

                IdxPPT++;

                for (int i=0; i<nClient; i++)
                {
                    if (clientList[i].isConnect == true)
                    {
                        clientList[i].fName = openFileDialog1.FileName;
                        clientList[i].isUpload = true;
                        clientList[i].Upload(1);
                    }
                }
            }
        }
        
        /////PPT클릭하여 열기/////
        void ButtonPPT_Click(object sender, EventArgs e)
        {
            int idx = -1;
            for(int i=0; i<maxPPT; i++)
            {
                if (ButtonPPT[i] == sender)
                    idx = i;
            }
            curIdxPPT = idx;
            ppt[idx] = new PowerPoint.Application();
            presentations[idx] = ppt[idx].Presentations;
            presentation[idx] = presentations[idx].Open(ButtonPPT[idx].Tag.ToString(), MsoTriState.msoFalse, MsoTriState.msoFalse, MsoTriState.msoCTrue);

        }


        /////lock버튼///// 
        private void button_lock_Click(object sender, EventArgs e)
        {
            this.lockPptNum = 0;
            this.lockPageNum = ppt[0].ActiveWindow.Selection.SlideRange.SlideNumber;
            this.askLock = true;
        }


        private void button_unlock_Click(object sender, EventArgs e)
        {
            this.savePptNum = 0;
            this.savepageNum = ppt[0].ActiveWindow.Selection.SlideRange.SlideNumber;
            
            //save와lock다른경우
            if ((this.savepageNum != this.lockPageNum) || (this.savePptNum != this.lockPptNum))
            {
                MessageBox.Show(lockPageNum + "의 slide를 수정완료먼저해주세요");
            }
            else
            {
                string _Path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                presentation[this.savePptNum].Save();
                PowerPoint.Application tempPpt = new PowerPoint.Application();
                PowerPoint.Presentation tempPresentation = tempPpt.Presentations.Add(MsoTriState.msoFalse);
                PowerPoint.Slides tempSlides = tempPresentation.Slides;
                tempSlides.InsertFromFile(ButtonPPT[this.savePptNum].Tag.ToString(), 0, this.savepageNum, this.savepageNum);

                saveFileName = _Path + @"\" + "slide.pptx";
                FileInfo fileInfo = new FileInfo(saveFileName);
                if(fileInfo.Exists == true)
                    File.Delete(this.saveFileName);
                tempPresentation.SaveAs(_Path + @"\" + "slide");


                this.askSave = true;
            }
        }


        ////각 ppt의 locking 제어///
        private void checkLock()
        {
            while (true)
            {
                for (int i = 0; i < nClient; i++)
                {
                    string name, pptN;
                    int pptNum, pageNum;

                    ///lock을 요청한 클라이언트
                    if (clientList[i].askLock == true)
                    {
                        Console.WriteLine(i + ": " + clientList[i].lockPageNum);

                        name = clientList[i].name;
                        pptN = LabelPPT[clientList[i].lockPptNum].Text;
                        pptNum = clientList[i].lockPptNum;
                        pageNum = clientList[i].lockPageNum;
                        

                        if (pptLockInfo[pptNum][pageNum] == -1)//해당 ppt의 page가 unlock일 경우
                        {
                            pptLockInfo[pptNum][pageNum] = i;
                            clientList[i].askLock = false;

                            this.ChangeList(name, pptN, pageNum);
                            for (int j = 0; j < nClient; j++)
                            {
                                if(clientList[j].isConnect)
                                    clientList[j].ChangeList(name, pptN, pageNum.ToString());
                            }
                        }
                        else //해당 ppt의 page가  lock일 경우 초기화
                        {
                            clientList[i].askLock = false;
                            clientList[i].lockPageNum = -1;
                            clientList[i].lockPptNum = -1;
                            clientList[i].LockFail();
                        }

                    }
                    if( this.askLock == true ) //서버자신이 lock을 요청했을 경우
                    {
                        Console.WriteLine(this.name + ": " + this.lockPageNum);
                        name = this.name;
                        pptN = LabelPPT[this.lockPptNum].Text;
                        pptNum = this.lockPptNum;
                        pageNum = this.lockPageNum;

                        if (pptLockInfo[pptNum][pageNum] == -1)//해당 ppt의 page가 unlock일 경우
                        {
                            pptLockInfo[pptNum][pageNum] = i;
                            this.askLock = false;

                            this.ChangeList(name, pptN, pageNum);
                            for (int j = 0; j < nClient; j++)
                            {
                                if (clientList[j].isConnect)
                                    clientList[j].ChangeList(name, pptN, pageNum.ToString()); 
                            }
                        }
                        else //해당 ppt의 page가  lock일 경우 초기화
                        {
                            this.askLock = false;
                            this.lockPageNum = -1;
                            this.lockPptNum = -1;
                            MessageBox.Show("다른사용자가 편집중인 슬라이드입니다");
                        }
                    }

                    ///save요청한클라이언트
                    if(clientList[i].askSave == true)
                    {
                        
                        int pptnum = clientList[i].savePptNum;
                        int pagenum = clientList[i].savePageNum;

                        Console.WriteLine("client -> server  : askSave");

                        //int curSlideIdx = ppt[savePptNum].ActiveWindow.Selection.SlideRange.SlideNumber;
                        PowerPoint.Slides tempSlides = presentation[pptnum].Slides;

                        if (clientList[i].isAddSlide)
                        {

                            tempSlides.InsertFromFile(clientList[i].saveFileName, pagenum-1 , 1, 1);
                        }
                        else
                        {
                            tempSlides.InsertFromFile(clientList[i].saveFileName, pagenum, 1, 1);
                            tempSlides[pagenum].Delete();
                        }

                        //tempSlides[curSlideIdx].Select();
                        //Console.WriteLine("FFFFFFFFF" + curSlideIdx);

                        ChangeList(clientList[i].name, "", -1);
                        clientList[i].ChangeList(clientList[i].name, "", "");

                        //다른클라이언트들에게변경된파일을보냄
                        for (int j=0; j<nClient; j++)
                        {
                            if (i == j)
                                ;
                            else
                            {
                                if (clientList[j].isConnect)
                                {
                                    clientList[j].SendSaveFile(clientList[i].saveFileName, pptnum, pagenum, clientList[i].isAddSlide);
                                    clientList[j].ChangeList(clientList[i].name, "", "");
                                }
                            }
                        }

                        File.Delete(clientList[i].saveFileName);

                        clientList[i].lockPageNum = -1;
                        clientList[i].lockPptNum = -1;
                        pptLockInfo[pptnum][pagenum] = -1; //save후 lock info배열에서 lock해제
                        clientList[i].askSave = false;

                    }
                    if(this.askSave) //서버가 save요청했을 경우
                    {
                        
                        int pptnum = this.savePptNum;
                        int pagenum = this.savepageNum;

                        PowerPoint.Slides tempSlides = presentation[pptnum].Slides;

                        if (this.isAddSlide)
                        {
                            if (pagenum == 1)
                                tempSlides.InsertFromFile(clientList[i].saveFileName, pagenum, 1, 1);
                            else
                                tempSlides.InsertFromFile(clientList[i].saveFileName, pagenum - 1, 1, 1);
                        }
                        else
                        {
                            tempSlides.InsertFromFile(this.saveFileName, pagenum, 1, 1);
                            tempSlides[pagenum].Delete();
                        }
                        
                        ChangeList(this.name, "", -1);

                        //다른클라이언트들에게 변경된파일을보냄
                        for (int j = 0; j < nClient; j++)
                        {
                            if (clientList[j].isConnect)
                            {
                                clientList[j].ChangeList(this.name, "", "");
                                clientList[j].SendSaveFile(this.saveFileName, pptnum, pagenum, this.isAddSlide);
                            }
                        }
                        
                        this.lockPageNum = -1;
                        this.lockPptNum = -1;
                        pptLockInfo[pptnum][pagenum] = -1; //save후 lock info배열에서 lock해제
                        this.askSave = false;

                        int saveCnt = 0;

                        //클라이언트에게 전송이완료됫는가
                        for (int j = 0; j < nClient; j++)
                        {
                            if (clientList[j].isConnect)
                            {
                                while(!clientList[j].isSaveEnd)
                                {
                                    ;
                                }
                                clientList[j].isSaveEnd = false;
                            }
                        }
                        
                        
                    }

                
                }

            }

        }

        public void ChangeList(string name, string pptname, int pagenum)
        {
            Invoke((MethodInvoker)delegate
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    ListViewItem item = listView1.Items[i];
                    bool isContains = item.SubItems[0].Text.Contains(name);
                    if (isContains)
                    {
                        item.SubItems[1].Text = pptname;
                        if (pagenum == -1)
                            item.SubItems[2].Text = "";
                        else
                            item.SubItems[2].Text = pagenum.ToString();
                        break;
                    }
                }
            });
        }
    }
}
