using System;

namespace BLL.MyException
{
    public class RegException : Exception
    {
        public RegException(string message) : base(message) { }
    }
}
