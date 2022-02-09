using System.IO;
using DAL.Interface;


namespace DAL.Provider
{
    public abstract class DataProvider<T> : IDataProvider<T>
    {
        string path;


        public DataProvider(string dataPath)
        {
            path = dataPath;

            IsHereOrCreate();
        }


        public string Path
        {
            get { return path; }
            set
            {
                path = value;
                IsHereOrCreate();
            }
        }
        public void ClearDataFile()
        {
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                fs.Dispose();
                fs.Close();
            }
        }
        public bool IsHere()
        {
            if (File.Exists(path))
            {
                return true;
            }
            return false;
        }
        public bool IsHereOrCreate()
        {
            if (IsHere() == false)
            {
                //create new file
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    fs.Dispose();
                    fs.Close();
                }

                return false;
            }

            return true;
        }



        public abstract T Deserialize();
        public abstract bool Serialize(T obj);

    }
}
