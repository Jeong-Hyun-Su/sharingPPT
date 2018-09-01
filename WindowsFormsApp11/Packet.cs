using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Microsoft.Office.Core;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;

namespace WindowsFormsApp11
{
    public enum PacketType : int
    {
        
        PAGENUM=0,
        SAVESLIDE,
        PAGENUM_RESULT
    }

    [Serializable]
    public class Packet
    {
        public int packet_Type;
        public int packet_Length;

        public Packet()
        {
            this.packet_Type = 0;
            this.packet_Length = 0;
        }

        public static byte[] Serialize(Object data)
        {
            try
            {
                MemoryStream ms = new MemoryStream(1024 * 4); 
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, data);
                return ms.ToArray();
            }
            catch
            {
                return null;
            }
        }

        public static Object Deserialize(byte[] data)
        {
            try
            {
                MemoryStream ms = new MemoryStream(1024 * 4);
                ms.Write(data, 0, data.Length);

                ms.Position = 0;
                BinaryFormatter bf = new BinaryFormatter();
                Object obj = bf.Deserialize(ms);
                ms.Close();
                return obj;
            }
            catch
            {
                return null;
            }
        }
        
    }
    

    [Serializable]
    public class PageNum : Packet
    {
        public int pageNum
        {
            get;
            set;
        }
        public int pptNum
        {
            get;
            set;
        }
    }

    [Serializable]
    public class SlidePacket : Packet
    {
        public PowerPoint.Slide slide
        {
            get;
            set;
        }
        public int pptNum
        {
            get;
            set;
        }
        public int pageNum
        {
            get;
            set;
        }
    }
}
