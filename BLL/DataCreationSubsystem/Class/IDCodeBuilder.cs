﻿using System;
using System.Collections.Generic;
using System.Linq;

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


        private IDCodeBuilder() { }
        private void CreateEntityService(string path)
        {
            dataProvider = new BinaryProvider<LinkedList<string>>(path);
            entityService = new EntityService<LinkedList<string>>(dataProvider);
        }



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

            } while (generateIdСodes.All(str => str == code));


            return code;
        }


        public static IDCodeBuilder GetUniqueIDBuilder(string path)
        {
            if (codeBuilder == null)
            {
                codeBuilder = new IDCodeBuilder();
                try
                {
                    codeBuilder.CreateEntityService(path);
                    codeBuilder.generateIdСodes = codeBuilder.entityService.GetData();
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
