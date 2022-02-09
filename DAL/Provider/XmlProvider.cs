using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;


namespace DAL.Provider
{
    public class XmlProvider<T> : DataProvider<T>
    {
        XmlSerializer formatter;


        public XmlProvider(string dataPath)
            : base(dataPath)
        {
            formatter = new XmlSerializer(typeof(T));
        }


        public override T Deserialize()
        {
            if (IsHere() == false) { throw new SerializationException("Deserialize не можлива немає файла."); }

            using (FileStream fs = new FileStream(Path, FileMode.Open))
            {
                return (T)formatter.Deserialize(fs);
            }
        }
        public override bool Serialize(T obj)
        {
            if (IsHere() == false) { return false; }

            using (FileStream fs = new FileStream(Path, FileMode.Open))
            {
                formatter.Serialize(fs, obj);

                fs.Dispose();
                fs.Close();
            }

            return true;
        }
    }
}
