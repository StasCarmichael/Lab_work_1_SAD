using System;
using System.Collections.Generic;

using BLL.DataFunctionalSubsystem.Class;
using BLL.DataFunctionalSubsystem.Interface;

namespace BLL.DataElectronicCardSubsystem.Interface
{
    public interface IUniversalElectronicCard :  INameable, ISurname, IBankData , IIDCode , ISubsystemable
    {

    }
}
