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

namespace WindowsFormsApp11
{
    class HandleClient
    {
        //TcpClient client;
        public int clientNum
        {
            get;
            set;
        }
        
        public TcpClient client
        {
            get;
            set;
        }
        public bool isConnect
        {
            get;
            set;
        }
        public bool isUpload
        {
            get;
            set;
        }

        public string fName
        {
            get;
            set;
        }

        public NetworkStream networkStream
        {
            get;
            set;
        }
        public void newClient(TcpClient client, int clientNum)
        {
            this.client = client;
            this.clientNum = clientNum;
            this.isConnect = true;

            networkStream = client.GetStream();
            Thread thread = new Thread(handle);
            thread.IsBackground = true;
            thread.Start();
        }
        public void handle()
        {
            try
            {
                while (true)
                {

                    if (isUpload == true)
                    {

                        FileInfo file = new FileInfo(fName);
                        FileStream fs = file.OpenRead();

                        if (networkStream.CanWrite && networkStream.CanRead)
                        {
                            string[] filenames = fName.Split('\\');
                            string filename = filenames[filenames.Length - 1];

                            Byte[] sendBytes = Encoding.UTF8.GetBytes(filename);
                            networkStream.Write(sendBytes, 0, sendBytes.Length);

                            byte[] ReadByte;
                            ReadByte = new byte[client.ReceiveBufferSize];
                            int BytesRead = networkStream.Read(ReadByte, 0, (int)ReadByte.Length);
                            string serverFileName = Encoding.GetEncoding("utf-8").GetString(ReadByte, 0, BytesRead);
                            Console.WriteLine(serverFileName);

                            /*파일 사이즈를 클라이언트로 전달*/
                            networkStream.Write(Encoding.ASCII.GetBytes(file.Length.ToString()), 0, Encoding.ASCII.GetBytes(file.Length.ToString()).Length);

                            /*클라이언트 측에서 준비되었는지 확인하고 준비되었다면 파일전송*/
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

                            fs.Flush();
                            fs.Close();
                        }
                        networkStream.Flush();
                       // networkStream.Close();
                        isUpload = false;
                    }
                }
            }
            catch
            {
                if(client.Connected == false)
                {
                    isConnect = false;
                }
            }
        }
    }
}
