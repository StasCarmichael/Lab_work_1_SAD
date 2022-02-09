
namespace DataService.Interface
{
    public interface IEntityService<T>
    {

        void ClearData();
        T GetData();
        bool UpdateData(T obj);
        bool AddNewData(T obj);

    }
}
