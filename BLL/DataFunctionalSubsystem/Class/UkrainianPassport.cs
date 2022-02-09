using BLL.DataFunctionalSubsystem.Interface;
using BLL.MyException;
using BLL.RegExpressions;
using BLL.ServiceInterface;


namespace BLL.DataFunctionalSubsystem.Class
{
    public class UkrainianPassport : IPassport, IValidable
    {
        private string name;
        private string surname;
        private int age;
        private string passportNumber;


        #region Prop

        public string Name
        {
            get { return name; }
           internal set
            {
                if (RegEx.Name.IsMatch(value))
                {
                    name = value;
                }
                else { throw new RegException("Властивість Name введена неправильно!"); }
            }
        }
        public string Surname
        {
            get { return surname; }
           internal set
            {
                if (RegEx.Surname.IsMatch(value))
                {
                    surname = value;
                }
                else { throw new RegException("Властивість Surname введена неправильно!"); }
            }
        }
        public int Age
        {
            get { return age; }
          internal  set
            {
                if (RegEx.Age(value))
                {
                    age = value;
                }
                else { throw new RegException("Властивість Age введена неправильно!"); }
            }
        }
        public string PassportNumber
        {
            get { return passportNumber; }
         internal   set
            {
                if (RegEx.PassportNumber.IsMatch(value))
                {
                    passportNumber = value;
                }
                else { throw new RegException("Властивість PassportNumber введена неправильно!"); }
            }
        }

        #endregion


        public bool isValid()
        {
            if (RegEx.Name.IsMatch(name))
                if (RegEx.Surname.IsMatch(surname))
                    if (RegEx.Age(age))
                        if (RegEx.PassportNumber.IsMatch(passportNumber))
                            return true;

            return false;
        }
    }
}
