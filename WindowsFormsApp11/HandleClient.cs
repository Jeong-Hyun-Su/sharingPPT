using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;
using System.Configuration;
using System.IO;
using Microsoft.Office.Core;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using ClassLibrary;

namespace WindowsFormsApp11
{
    class HandleClient
    {
        public int clientNum { get; set; }      //클라이언트번호

        public TcpClient client { get; set; }   //연결된client

        public bool isConnect { get; set; }

        public bool isUpload { get; set; }

        public string fName { get; set; }       //ppt파일명

        public string name { get; set; }        //사용자이름

        public bool isAddName { get; set; }

        public int lockPptNum { get; set; }

        public int lockPageNum { get; set; }

        public int savePptNum { get; set; }

        public int savePageNum { get; set; }

        public bool askLock { get; set; }

        public bool askSave { get; set; }

        public bool isSaveEnd { get; set; }

        public bool isAddSlide { get; set; }

        public string saveFileName { get; set; } //클라이언트로부터받은 저장할슬라이드가있는ppt파일이름 ->서버에게보낼것

        public int beforeUploadNum { get; set; }
        

        public NetworkStream networkStream { get; set; }

        public LockPacket lockPacket;
        public ListPacket listPacket;
        public SavePacket savePacket;

        public Thread thread;

        public void newClient(TcpClient client, int clientNum, string names)
        {
            this.client = client;
            this.clientNum = clientNum;
            this.isConnect = true;
            networkStream = client.GetStream();

            ///현재 이전의 연결된client의 name들 을 client로 전송
            Byte[] sendBytes = Encoding.UTF8.GetBytes("NAME#/" + names);
            networkStream.Write(sendBytes, 0, sendBytes.Length);
            networkStream.Flush();

            thread = new Thread(handle);
            thread.IsBackground = true;
            thread.Start();
        }

        /////추가로연결된 client의 name client로 전송/////
        public void AddList(string addName)
        {
            Byte[] sendBytes = Encoding.UTF8.GetBytes("NAME*" + addName);
            networkStream.Write(sendBytes, 0, sendBytes.Length);
        }

        public void ChangeList(string name, string pptname, string pagenum)
        {
            Byte[] sendBytes = Encoding.UTF8.GetBytes("CHANGE@/" + name + "/" + pptname + "/" + pagenum);
            networkStream.Write(sendBytes, 0, sendBytes.Length);
        }

        public void Upload(int flag)
        {
            FileInfo file = new FileInfo(fName);
            FileStream fs = file.OpenRead();
            networkStream.Flush();

            if (networkStream.CanWrite && networkStream.CanRead)
            {
                ///파일이름 client에게 전송
                if (flag == 1)
                {
                    string[] filenames = fName.Split('\\');
                    string filename = filenames[filenames.Length - 1];

                    Byte[] sendBytes = Encoding.UTF8.GetBytes("UPLOAD@"+filename);
                    networkStream.Write(sendBytes, 0, sendBytes.Length);
                    Console.WriteLine("upload1 complete");
                }
                ///파일 client에게 전송
                else if (flag == 2)
                {
                    byte[] ReadByte;
                    ReadByte = new byte[client.ReceiveBufferSize];
                    int BytesRead = networkStream.Read(ReadByte, 0, (int)ReadByte.Length);
                    string serverFileName = Encoding.GetEncoding("utf-8").GetString(ReadByte, 0, BytesRead);
                    Console.WriteLine("###" + serverFileName);

                    ///파일 사이즈를 클라이언트로 전달
                    networkStream.Write(Encoding.UTF8.GetBytes(file.Length.ToString()), 0, Encoding.UTF8.GetBytes(file.Length.ToString()).Length);

                    ///클라이언트 측에서 준비되었는지 확인하고 준비되었다면 파일전송
                    int BytesRead2 = 0;
                    byte[] ConfirmByte = new byte[client.ReceiveBufferSize];
                    BytesRead2 = networkStream.Read(ConfirmByte, 0, (int)ConfirmByte.Length);


                    if (serverFileName.Length > 0 && BytesRead2 > 0)
                    {
                        byte[] FileBytes;
                        FileBytes = new byte[fs.Length];
                        fs.Read(FileBytes, 0, FileBytes.Length);
                        networkStream.Write(FileBytes, 0, FileBytes.Length);
                    }
                    Console.WriteLine("upload2 complete");
                   
                    //파일 전송이 모두 끝났음
                    this.isUpload = false; 
                }
                fs.Flush();
                fs.Close();
            }
            networkStream.Flush();
            // networkStream.Close();

        }
        public void handle()
        {
            try
            {
                int nRead = 0;
                byte[] buffer = new byte[1024 * 4];
                while (true)
                {
                    networkStream.Flush();
                    nRead = 0;
                    nRead = networkStream.Read(buffer, 0, buffer.Length);

                    Packet packet = (Packet)Packet.Desserialize(buffer);
                    if (packet == null)
                        Console.WriteLine("handle null ");

                    switch ((int)packet.type)
                    {
                        case (int)PacketType.LISTVIEW:
                            {
                                listPacket = (ListPacket)Packet.Desserialize(buffer);
                                this.name = listPacket.listName;
                                isAddName = true;
                                Console.WriteLine("handle listviewtype " + listPacket.listName);
                                break;
                            }
                        case (int)PacketType.UPLOAD:
                            {
                                Console.WriteLine("handle upload type");
                                Upload(2);
                                break;
                            }
                        case (int)PacketType.LOCK:
                            {
                                lockPacket = (LockPacket)Packet.Desserialize(buffer);
                                lockPageNum = lockPacket.pageNum;
                                lockPptNum = lockPacket.pptNum;
                                Console.WriteLine("handle lock type" + lockPacket.pageNum);

                                askLock = true;

                                break;
                            }
                        case (int)PacketType.SAVE:
                            {
                                Console.WriteLine("handle client : save ");
                                savePacket = (SavePacket)Packet.Desserialize(buffer);
                                isAddSlide = savePacket.isAdd;
                                savePptNum = savePacket.pptNum;
                                savePageNum = savePacket.pageNum;
                                long fileSize = savePacket.fileSize;


                                //저장할슬라이드가있는 피피티파일을 읽어와 'slide_handle.pptx'생성후 저장
                                string _Path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                                byte[] myReadBuffer = new byte[1024];
                                int numberOfBytesRead = 0;

                                saveFileName = _Path + @"\" + "slide_handle.pptx";
                                FileInfo fileInfo = new FileInfo(saveFileName);
                                if (fileInfo.Exists == true)
                                    File.Delete(this.saveFileName);

                                FileStream fs = new FileStream(saveFileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);

                                do
                                {
                                    numberOfBytesRead = networkStream.Read(myReadBuffer, 0, myReadBuffer.Length);
                                    fs.Write(myReadBuffer, 0, numberOfBytesRead);
                                }
                                while (fs.Length < fileSize);

                                fs.Close();
                                askSave = true;

                                break;
                            }
                    }


                }
            }
            catch
            {
                if (client.Connected == false)
                {
                    Console.WriteLine("connected end");
                    isConnect = false;
                    thread.Abort();
                    client.Close();
                }
            }
        }

        //다른클라이언트가 lock하고있는경우 lockfail이라고클라이언트에게알림
        public void LockFail()
        {
            Byte[] sendBytes = Encoding.UTF8.GetBytes("FAIL@" + "fail");
            networkStream.Write(sendBytes, 0, sendBytes.Length);
        }
        
        public void SendSaveFile(string sendFileName,int pptNum, int pageNum, bool isAdd)
        {
            FileInfo file = new FileInfo(sendFileName);

            Byte[] sendBytes = Encoding.UTF8.GetBytes("EDIT@/"+file.Length.ToString()+"/" + pptNum + "/" + pageNum+"/"+ isAdd);
            networkStream.Write(sendBytes, 0, sendBytes.Length);

            Thread.Sleep(500);
            
            FileStream fs = file.OpenRead();
            byte[] bytes = new byte[fs.Length];
            fs.Read(bytes, 0, bytes.Length);
            networkStream.Write(bytes, 0, bytes.Length);
            
            fs.Close();

            isSaveEnd = true;
        }
    }
}