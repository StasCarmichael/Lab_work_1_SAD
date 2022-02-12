using System;
using System.Collections.Generic;

using DAL.Interface;
using DAL.Provider;
using DataService.Interface;
using DataService;

using BLL.DataFunctionalSubsystem.Class;
using BLL.DataFunctionalSubsystem.Interface;

namespace BLL.DataCreationSubsystem.Class
{
    //Singleton
    public class IDCodeBuilder
    {
        private static IDCodeBuilder codeBuilder;
        private const int MAX_INDEX = 10;
        private const int MIN_FIRST_INDEX = 1;
        private const int ZERO = 0;


        LinkedList<string> generateIdСodes;

        IDataProvider<LinkedList<string>> dataProvider;
        IEntityService<LinkedList<string>> entityService;


        //privat ctor
        private IDCodeBuilder() { }
        ~IDCodeBuilder()
        {
            SaveChange();
        }


        private void CreateEntityService(string path)
        {
            dataProvider = new BinaryProvider<LinkedList<string>>(path);
            entityService = new EntityService<LinkedList<string>>(dataProvider);
        }
        private string GetUniqueCode()
        {
            Random random;
            string code;

            do
            {
                random = new Random();
                code = string.Empty;


                for (int i = 0; i < MAX_INDEX; i++)
                {
                    if (i == 0) { code += random.Next(MIN_FIRST_INDEX, MAX_INDEX); }
                    else { code += random.Next(ZERO, MAX_INDEX); }
                }

            } while (generateIdСodes.Contains(code));

            generateIdСodes.AddLast(code);

            return code;
        }


        //Open Interface (API)
        public bool SaveChange()
        {
            return codeBuilder.entityService.AddNewData(generateIdСodes);
        }
        public IIDCode GetUniqueID()
        {
            IDCode idCode = new IDCode();

            while (!idCode.CreateCode(GetUniqueCode())) { }

            return idCode;
        }


        public static IDCodeBuilder GetUniqueIDBuilder(string path)
        {
            if (codeBuilder == null)
            {
                codeBuilder = new IDCodeBuilder();
                try
                {
                    codeBuilder.CreateEntityService(path);

                    try
                    {
                        codeBuilder.generateIdСodes = codeBuilder.entityService.GetData();
                    }
                    catch (Exception)
                    {
                        codeBuilder.generateIdСodes = new LinkedList<string>();
                        codeBuilder.entityService.AddNewData(codeBuilder.generateIdСodes);
                    }

                }
                catch (Exception ex)
                {
                    codeBuilder = null;
                    throw ex;
                }
            }

            return codeBuilder;
        }

    }
}
