using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace DAL.Provider
{
    public class BinaryProvider<T> : DataProvider<T>
    {
        IFormatter formatter;


        public BinaryProvider(string dataPath)
            :base(dataPath)
        {
            formatter = new BinaryFormatter();
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
