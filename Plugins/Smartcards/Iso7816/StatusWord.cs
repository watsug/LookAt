namespace Smartcards.Iso7816
{
    public class StatusWord
    {
        private ushort _val;
        public StatusWord(ushort val, string desc)
        {
            _val = val;
            Description = desc;
        }

        public string Value { get => _val.ToString("X4") + "h"; }
        public string Description { get; private set; }
    }
}