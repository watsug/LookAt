using System.Composition;
using LookAtApi.Interfaces;

namespace CoreTransformations.Filters
{
    [Export(typeof(ITransformation))]
    public class Base64Filter : FilterBase
    {
        private const string AllowedCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";

        #region FilterBase
        protected override string Characters => AllowedCharacters;
        public override string Name => "Base64 filter";
        #endregion
    }
}