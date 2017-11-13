using System.Composition;
using System.Globalization;
using System.Collections.Generic;
using LookAtApi.Core;
using LookAtApi.Interfaces;

namespace Smartcards.Iso7816
{
    [Export(typeof(ITransformation))]
    public class StatusWord : ITransformation
    {
        #region private
        private static Dictionary<ushort, string> _map;
        static StatusWord()
        {
            _map = new Dictionary<ushort, string>();

            _map[0x6200] = "Warning - No information given";
            _map[0x6281] = "Part of returned data may be corrupted";
            _map[0x6282] = "End of file or record reached before reading Ne bytes";
            _map[0x6283] = "Selected file deactivated";
            _map[0x6284] = "File control information not formatted according to 5.3.3";
            _map[0x6285] = "Selected file in termination state";
            _map[0x6286] = "No input data available from a sensor on the card";

            _map[0x6300] = "Warning - No information given";
            _map[0x6381] = "File filled up by the last write";

            _map[0x6400] = "Execution error";
            _map[0x6401] = "Immediate response required by the card";

            _map[0x6500] = "Error - No information given";
            _map[0x6501] = "Memory failure";

            _map[0x6800] = "Error - No information given";
            _map[0x6881] = "Logical channel not supported";
            _map[0x6882] = "Secure messaging not supported";
            _map[0x6883] = "Last command of the chain expected";
            _map[0x6884] = "Command chaining not supported";

            _map[0x6900] = "Error - No information given";
            _map[0x6981] = "Command incompatible with file structure";
            _map[0x6982] = "Security status not satisfied";
            _map[0x6983] = "Authentication method blocked";
            _map[0x6984] = "Reference data not usable";
            _map[0x6985] = "Conditions of use not satisfied";
            _map[0x6986] = "Command not allowed (no current EF)";
            _map[0x6988] = "Incorrect secure messaging data objects";

            _map[0x6A00] = "Error - No information given";
            _map[0x6A80] = "Incorrect parameters in the command data field";
            _map[0x6A81] = "Function not supported";
            _map[0x6A82] = "File or application not found";
            _map[0x6A83] = "Record not found";
            _map[0x6A84] = "Not enough memory space in the file";
            _map[0x6A85] = "Nc inconsistent with TLV structure";
            _map[0x6A86] = "Incorrect parameters P1-P2";
            _map[0x6A87] = "Nc inconsistent with parameters P1-P2";
            _map[0x6A88] = "Referenced data or reference data not found (exact meaning depending on the command)";
            _map[0x6A89] = "File already exists";
            _map[0x6A8A] = "DF name already exists";

            _map[0x9000] = "OK";
        }
        #endregion

        #region ITransformation
        public string Name => "StatusWord";

        public IVisibleObject DoTransformation(IVisibleObject obj)
        {
            string tmp = obj.Value.ToString();
            ushort val;
            if (ushort.TryParse(tmp, NumberStyles.HexNumber, null, out val))
            {
                if (_map.ContainsKey(val))
                {
                    return new StringVisibleObject(_map[val], obj);
                }
            }
            return null;
        }
        #endregion
    }
}
