using System;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;
using System.Configuration;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Office.Core;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;

namespace ClassLibrary
{
    public enum PacketType : int
    {
        UPLOAD = 0,
        LOCK,
        LISTVIEW,
        SLIDE
    }

    [Serializable]
    public class Packet
    {
        public int type;
        public int length;

        public Packet()
        {
            this.type = 0;
            this.length = 0;
        }
        public static byte[] Serialize(Object o)
        {
            MemoryStream ms = new MemoryStream(1024 * 4);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, o);
            return ms.ToArray();
        }
        public static object Desserialize(byte[] bt)
        {
            MemoryStream ms = new MemoryStream(1024 * 4);
            ms.Write(bt, 0, bt.Length);
            ms.Position = 0;
            BinaryFormatter bf = new BinaryFormatter();
            Object obj = bf.Deserialize(ms);
            ms.Close();
            return obj;
        }
    }

    [Serializable]
    public class LockPacket : Packet
    {
        public int pageNum { get; set; }
        public int pptNum { get; set; }
    }


    [Serializable]
    public class SlidePacket : Packet
    {
        public PowerPoint.Slide slideObject { get; set; }
        
    }

    [Serializable]
    public class UploadPacket : Packet
    {
        public bool isup { get; set; }
    }

    [Serializable] 
    public class ListPacket : Packet
    {
        public string listName { get; set; }
    }
}
