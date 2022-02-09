namespace DAL.Interface
{
    public interface IDataSerializeable<T> 
    {
        bool Serialize(T obj);

        T Deserialize();
    }
}
