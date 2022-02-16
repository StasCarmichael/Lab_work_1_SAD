using System;
using BLL.DataFunctionalSubsystem.Interface;
using BLL.RegExpressions;

namespace BLL.DataFunctionalSubsystem.Class
{
    [Serializable]
    public sealed class IDCode : IIDCode
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


        public string GetUniqueIdCode { get { return code; } }
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
