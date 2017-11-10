using System.Collections.Generic;
using LookAtApi.Interfaces;

namespace CoreTransformations
{
    public class CorePlugin : IPlugin
    {
        #region private
        private static List<ITransformation> _transformations;
        CorePlugin()
        {
            _transformations = new List<ITransformation>();
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
