using LookAtApi.Interfaces;

namespace LookAtApi.Core
{
    class StringVisibleObject : IVisibleObject
    {
        string _val = "";
        public string Value => _val;
    }
}
