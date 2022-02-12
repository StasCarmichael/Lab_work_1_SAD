﻿using BLL.DataFunctionalSubsystem.Interface;
using BLL.RegExpressions;
using BLL.ServiceInterface;

namespace BLL.DataFunctionalSubsystem.Class
{
    public sealed class IDCode : IIDCode, IValidable
    {
        private string code;


        internal IDCode()
        {
            code = string.Empty;
        }
        internal bool CreateCode(string uniqueCode)
        {
            if (RegEx.IDCode.IsMatch(uniqueCode))
            {
                code = uniqueCode;
                return true;
            }

            return false;
        }


        public string GetUniqueIdCode()
        {
            return code;
        }
        public bool IsValid()
        {
            if (RegEx.IDCode.IsMatch(code))
            {
                return true;
            }

            return false;
        }
    }
}
