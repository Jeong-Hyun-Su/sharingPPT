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

        public bool askLock { get; set; }

        public int beforeUploadNum { get; set; }

        public NetworkStream networkStream { get; set; }

        public LockPacket lockPacket;
        public ListPacket listPacket;

        public Thread thread;

        public void newClient(TcpClient client, int clientNum, string names)
        {
            this.client = client;
            this.clientNum = clientNum;
            this.isConnect = true;
            networkStream = client.GetStream();

            ///현재 이전의 연결된client의 name들 을 client로 전송
            Byte[] sendBytes = Encoding.UTF8.GetBytes("#" + names);
            networkStream.Write(sendBytes, 0, sendBytes.Length);
            networkStream.Flush();

            thread = new Thread(handle);
            thread.IsBackground = true;
            thread.Start();
        }

        /////추가로연결된 client의 name client로 전송/////
        public void AddList(string addName)
        {
            Byte[] sendBytes = Encoding.UTF8.GetBytes("*" + addName);
            networkStream.Write(sendBytes, 0, sendBytes.Length);
        }

        public void ChangeList(string name, string pptname, int pagenum)
        {
            Byte[] sendBytes = Encoding.UTF8.GetBytes("c" + name + "/" + pptname + "/" + pagenum);
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

                    Byte[] sendBytes = Encoding.UTF8.GetBytes(filename);
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

        public void LockFail()
        {
            Byte[] sendBytes = Encoding.UTF8.GetBytes("f" + "fail");
            networkStream.Write(sendBytes, 0, sendBytes.Length);
        }
    }
}