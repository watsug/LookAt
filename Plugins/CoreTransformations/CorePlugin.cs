using System.Composition;
using System.Composition.Hosting;
using System.Collections.Generic;
using LookAtApi.Interfaces;
using System.Reflection;

namespace CoreTransformations
{
    [Export(typeof(IPlugin))]
    public class CorePlugin : IPlugin
    {
        #region private
        private static List<ITransformation> _transformations;
        static CorePlugin()
        {
            var configuration = new ContainerConfiguration()
                .WithAssembly(typeof(CorePlugin).GetTypeInfo().Assembly);
            using (var container = configuration.CreateContainer())
            {
                var transformations = container.GetExports<ITransformation>();
                _transformations = new List<ITransformation>(transformations);
            }
        }
        #endregion

        #region IPlugin
        public string Category => "Core";

        public string Name => "Typical transformations";

        public string Author => "Adam Augustyn";

        public List<ITransformation> Transformations => _transformations;
        #endregion
    }
}
