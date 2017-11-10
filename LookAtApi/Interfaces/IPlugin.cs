using System.Collections.Generic;

namespace LookAtApi.Interfaces
{
    interface IPlugin
    {
        string Category { get; }
        string Name { get; }
        string Author { get; }

        List<ITransformation> Transformations { get; }
    }
}
