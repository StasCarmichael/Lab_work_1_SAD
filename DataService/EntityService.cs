using System;
using DataService.Interface;
using DAL.Interface;

namespace DataService
{
    public class EntityService<T> : IEntityService<T>
    {
        //Serialarizer  
        private IDataProvider<T> provider;

        //ctor
        public EntityService(IDataProvider<T> provider)
        {
            if (provider == null) { throw new NullReferenceException(); }

            this.provider = provider;
        }


        //Agregation
        public IDataProvider<T> Provider
        {
            get { return provider; }
            set
            {
                if (value == null) { throw new NullReferenceException(); }

                provider = value;
            }
        }


        public bool AddNewData(T obj) { ClearData(); return UpdateData(obj); }
        public void ClearData() { provider.ClearDataFile(); }
        public T GetData() { return provider.Deserialize(); }
        public bool UpdateData(T obj) { return provider.Serialize(obj); }

    }
}
