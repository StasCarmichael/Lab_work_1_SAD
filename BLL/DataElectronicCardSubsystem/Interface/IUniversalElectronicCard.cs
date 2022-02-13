using BLL.DataFunctionalSubsystem.Interface;
using BLL.ServiceInterface;

namespace BLL.DataElectronicCardSubsystem.Interface
{
    public interface IUniversalElectronicCard : INameable, ISurname, IBankData, IIDCode, ISubsystemable, IValidable
    {
         IIDCode IDCode { get; }
    }
}
