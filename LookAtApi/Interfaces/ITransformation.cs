using System;
using System.Collections.Generic;
using System.Text;

namespace LookAtApi.Interfaces
{
    interface ITransformation
    {
        string Name { get; }
        IVisibleObject DoTransformation(IVisibleObject obj);
    }
}
