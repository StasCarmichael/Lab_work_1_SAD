namespace DAL.Interface
{
    public interface IDataProvider<T> : IDataSerializeable<T>
    {
        string Path { get; set; }

        void ClearDataFile();

        bool IsHere();

        bool IsHereOrCreate();
    }
}
