using BLL.DataFunctionalSubsystem.Interface;
using BLL.RegExpressions;
using BLL.ServiceInterface;

namespace BLL.DataFunctionalSubsystem.Class
{
    public sealed class IDCode : IIDCode, IValidable
    {
        private string code;
        private bool isCodeCreated;


        internal IDCode()
        {
            code = string.Empty;
            isCodeCreated = false;
        }
        internal bool CreateCode(string uniqueCode)
        {
            if (RegEx.IDCode.IsMatch(uniqueCode))
            {
                code = uniqueCode;
                isCodeCreated = true;
                return true;
            }

            return false;
        }


        public string GetUniqueIdCode()
        {
            return code;
        }
        public bool CodeCreated() => isCodeCreated;
        public bool isValid()
        {
            if (RegEx.IDCode.IsMatch(code))
            {
                return true;
            }

            return false;
        }
    }
}
