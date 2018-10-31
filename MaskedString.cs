namespace Util
{
    public class MaskedString
    {
        private string _value;
        public char MaskChar { get; set; } = '*';
        public int NumberOfCharsToShow { get; set; } = 4;

        public int MaskLength =>
            _value.Length > NumberOfCharsToShow
                ? TotalDisplayLength > NumberOfCharsToShow
                    ? TotalDisplayLength - NumberOfCharsToShow
                    : _value.Length - NumberOfCharsToShow
            : 0;

        public int TotalDisplayLength { get; set; }

        public string Value
        {
            get =>
                _value.Length > NumberOfCharsToShow
                    ? string.Concat(string.Empty.PadLeft(MaskLength, MaskChar), _value.Substring(_value.Length - NumberOfCharsToShow))
                    : _value;

            set => _value = value;
        }

        public int Length => _value.Length;

        public MaskedString()
        {
            Value = string.Empty;
        }

        public MaskedString(string value)
        {
            Value = value ?? string.Empty;
        }

        public MaskedString(string value, int numberOfCharsToShow)
        {
            Value = value ?? string.Empty;
            NumberOfCharsToShow = numberOfCharsToShow;
        }

        public MaskedString(string value, int numberOfCharsToShow, char maskChar)
        {
            Value = value;
            NumberOfCharsToShow = numberOfCharsToShow;
            MaskChar = maskChar;
        }

        public MaskedString(string value, int numberOfCharsToShow, char maskChar, int totalDisplayLength)
        {
            Value = value;
            NumberOfCharsToShow = numberOfCharsToShow;
            MaskChar = maskChar;
            TotalDisplayLength = totalDisplayLength;
        }

        public MaskedString(string value, int numberOfCharsToShow, int totalDisplayLength)
        {
            Value = value;
            NumberOfCharsToShow = numberOfCharsToShow;
            TotalDisplayLength = totalDisplayLength;
        }

        #region Overrides and equality implementation

        public static implicit operator MaskedString(string obj)
        {
            var result = new MaskedString(obj ?? string.Empty);
            return result;
        }

        public static implicit operator string(MaskedString obj)
        {
            var result = obj?._value;
            return result;
        }

        public static bool operator ==(MaskedString str1, string str2)
        {
            return str1?._value == str2;
        }

        public static bool operator !=(MaskedString str1, string str2)
        {
            return str1?._value != str2;
        }

        public static bool operator ==(MaskedString str1, MaskedString str2)
        {
            return str1?._value == str2?._value;
        }

        public static bool operator !=(MaskedString str1, MaskedString str2)
        {
            return str1?._value != str2?._value;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (_value.GetType() == obj.GetType() || obj.GetType() == GetType()) return obj.Equals(_value);
            return false;
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public override string ToString()
        {
            return Value ?? string.Empty;
        }        

        #endregion
    }
}