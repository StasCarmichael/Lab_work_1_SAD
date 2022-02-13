using BLL.ServiceInterface;

namespace BLL.DataFunctionalSubsystem.Interface
{
    public interface IIDCode: IValidable
    {
        string GetUniqueIdCode();
    }
}
