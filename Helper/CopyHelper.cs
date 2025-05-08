using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace 设备管理系统.Helper
{
    internal class CopyHelper
    {
        public static T DeepCopy<T>(T obj)
        {
            object result;
            using(MemoryStream ms = new MemoryStream())
            {
                XmlSerializer xml = new XmlSerializer(typeof(T));
                xml.Serialize(ms, obj);
                ms.Seek(0, SeekOrigin.Begin);
                result = xml.Deserialize(ms);
                ms.Close();
            }

            return (T)result;
        }
    }
}
