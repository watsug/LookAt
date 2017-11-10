using System;
using System.Collections.Generic;
using LookAtApi.Interfaces;
using Smartcards.Iso7816;

namespace Smartcards
{
    public class SmartcardsPlugin : IPlugin
    {
        #region private
        private static List<ITransformation> _transformations;
        SmartcardsPlugin()
        {
            _transformations = new List<ITransformation>();
            _transformations.Add(new StatusWord());
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
