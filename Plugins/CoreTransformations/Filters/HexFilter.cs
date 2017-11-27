using System.Composition;
using LookAtApi.Interfaces;

namespace CoreTransformations.Filters
{
    [Export(typeof(ITransformation))]
    public class HexFilter : FilterBase
    {
        private const string AllowedCharacters = "0123456789abcdefABCDEF";

        #region ITransformation
        protected override string Characters => AllowedCharacters;
        public override string Name => "HEX filter";
        #endregion
    }
}