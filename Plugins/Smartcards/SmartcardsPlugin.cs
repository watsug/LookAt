using System.Reflection;
using System.Composition;
using System.Composition.Hosting;
using System.Collections.Generic;
using LookAtApi.Interfaces;

namespace Smartcards
{
    [Export(typeof(IPlugin))]
    public class SmartcardsPlugin : IPlugin
    {
        #region private
        private static List<ITransformation> _transformations;
        static SmartcardsPlugin()
        {
            var configuration = new ContainerConfiguration()
                .WithAssembly(typeof(SmartcardsPlugin).GetTypeInfo().Assembly);
            using (var container = configuration.CreateContainer())
            {
                var transformations = container.GetExports<ITransformation>();
                _transformations = new List<ITransformation>(transformations);
            }
        }
        #endregion

        #region ctor
        public SmartcardsPlugin()
        {
        }
        #endregion

        #region IPlugin
        public string Category => "Security";

        public string Name => "Smartcards";

        public string Author => "Adam Augustyn";

        public List<ITransformation> Transformations => _transformations;
        #endregion
    }
}
