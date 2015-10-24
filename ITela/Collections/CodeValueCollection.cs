using System;
using System.Collections.Generic;
using System.Linq;


namespace ITela
{
    /// <summary>
    /// Class to conveniently hold a collection of code values.
    /// </summary>
    public class CodeValueCollection<TCODE, TVALUE> : Dictionary<TCODE, TVALUE>, ICodeValueCollection<TCODE, TVALUE>
        where TCODE : IComparable<TCODE>
    {
        public void Add(ICodeValue<TCODE, TVALUE> codeValue)
        {
            this.Add(codeValue.Code, codeValue.Value);
        }

        public CodeValueCollection()
        {

        }

        public CodeValueCollection(Dictionary<TCODE, TVALUE> dict)
        {
            foreach (var item in dict)
            {
                this.Add(item.Key, item.Value);
            }
        }

        public ICodeValueCollection ToCodeValueCollection(Func<ICodeValue<TCODE, TVALUE>, string> keySelector, Func<ICodeValue<TCODE, TVALUE>, string> elementSelector, IEqualityComparer<TCODE> comparer = null)
        {
            CodeValueCollection list = new CodeValueCollection();
            foreach (KeyValuePair<TCODE, TVALUE> kvPair in this)
            {
                var codeValue = new CodeValue<TCODE, TVALUE>(kvPair.Key, kvPair.Value);
                list.Add(keySelector(codeValue), elementSelector(codeValue));
            }
            return list;
        }

        public ICodeValueCollection ToCodeValueCollection()
        {
            CodeValueCollection list = new CodeValueCollection();
            foreach (KeyValuePair<TCODE, TVALUE> codeValue in this)
            {
                list.Add(codeValue.Key.ToString(), codeValue.Value.ToString());
            }
            return list;
        }
    }

    public class CodeValueCollection : CodeValueCollection<string, string>, ICodeValueCollection
    {
        public CodeValueCollection() : base()
        {

        }

        public CodeValueCollection(Dictionary<string, string> dict) : base(dict)
        {

        }
    }

    /// <summary>
    /// Class to conveniently hold a collection of code values,
    /// along with a possibly restricted list of associated enum fields (hard-coded values).
    /// </summary>
    /// <typeparam name="ECODE">Enum representing associated hard-coded codes</typeparam>
    public class CodeValueCollection<ECODE, TCODE, TVALUE> : CodeValueCollection<TCODE, TVALUE>
        where ECODE : struct
        where TCODE : IComparable<TCODE>
    {
        internal Dictionary<ECODE, TCODE> _enumCodes = new Dictionary<ECODE,TCODE>();

        /// eCode -> approached string tCode values
        internal List<KeyValuePair<ECODE, string>> _enumMatchingCodes = new List<KeyValuePair<ECODE, string>>();

        public void Add(ECODE enumCode, ICodeValue<TCODE, TVALUE> codeValue)
        {
            base.Add(codeValue.Code, codeValue.Value);
            _enumCodes.Add(enumCode, codeValue.Code);
        }

        // Keep it private (enumCode is mandatory).
        //private override void Add(TCODE key, TVALUE value)
        //{
        //    base.Add(key, value);
        //}

        public TVALUE this[ECODE code]
        {
            get
            {
                return this[_enumCodes[code]];
            }
        }

        public void AddMatchingCode(ECODE code, params string[] matchingCode)
        {
            foreach (var mCode in matchingCode)
            {
                _enumMatchingCodes.Add(new KeyValuePair<ECODE, string>(code, mCode));
            }
        }        
        
        public bool TryGetEnumCodeValue(string inputCode, out EnumCodeValue<ECODE, TCODE, TVALUE> enumCodeValue, out bool matchingCodeUsed)
        {
            enumCodeValue = null;

            // https://msdn.microsoft.com/en-us/library/dd783499(v=vs.110).aspx
            // If value is a name that does not correspond to a named constant of TEnum, the method returns false. 
            // If value is the string representation of an integer that does not represent an underlying value 
            // of the TEnum enumeration, the method returns an enumeration member whose underlying value is value 
            // converted to an integral type. 
            // If this behavior is undesirable, call the IsDefined method to ensure that a particular string representation of an integer is actually a member of TEnum.
            if (_enumCodes.ToDictionary(x => x.Key, x => x.Key.ToString()).Values.Contains(inputCode, StringComparer.OrdinalIgnoreCase))
            {
                matchingCodeUsed = false; // It's an exact match
                KeyValuePair<ECODE, TCODE> result = _enumCodes.First(x => x.Key.ToString().Equals(inputCode, StringComparison.OrdinalIgnoreCase));
                enumCodeValue = new EnumCodeValue<ECODE,TCODE,TVALUE>(result.Key, result.Value, this[result.Key]);
                return true;
            }
            else if (_enumMatchingCodes.Any(x => x.Value.Equals(inputCode, StringComparison.OrdinalIgnoreCase)))
            {
                matchingCodeUsed = true; // It's an approaching match
                ECODE eCode = _enumMatchingCodes.First(x => x.Value.Equals(inputCode, StringComparison.OrdinalIgnoreCase)).Key;
                TCODE code = _enumCodes[eCode];
                enumCodeValue = new EnumCodeValue<ECODE, TCODE, TVALUE>(eCode, _enumCodes[eCode], this[eCode]);
                return true;
            }
            matchingCodeUsed = true;
            return false;
        }

    }

    public class CodeValueCollection<ECODE> : CodeValueCollection<ECODE, string, string>
        where ECODE : struct
    {
        public static CodeValueCollection<E> BuildFrom<E>()
            where E : struct
        {
            throw new NotImplementedException("Trying to put this method to Gc because of dependence to GcCodeValueAnnotationReader");
            //CodeValueCollection<E> collection = new CodeValueCollection<E>();
            //foreach (E field in Enum.GetValues(typeof(E)))
            //{
            //    GcCodeValueAttribute gcAnnotation = GcCodeValueAnnotationReader.GetGcCodeValueAttribute<E>(field);
            //    collection.Add(field, new CodeValue<string, string>(gcAnnotation.GcCode, gcAnnotation.GcValue));
            //}
            //return collection;
        }

        // Build from enum is the only secure way of building it (no constraints on strings).
        private CodeValueCollection()
        {
              
        }

        public bool TryGetEnumCodeValue(string inputCode, out EnumCodeValue<ECODE> enumCodeValue, out bool matchingCodeUsed)
        {
            enumCodeValue = null;

            // https://msdn.microsoft.com/en-us/library/dd783499(v=vs.110).aspx
            // If value is a name that does not correspond to a named constant of TEnum, the method returns false. 
            // If value is the string representation of an integer that does not represent an underlying value 
            // of the TEnum enumeration, the method returns an enumeration member whose underlying value is value 
            // converted to an integral type. 
            // If this behavior is undesirable, call the IsDefined method to ensure that a particular string representation of an integer is actually a member of TEnum.
            if (this._enumCodes.ToDictionary(x => x.Key, x => x.Key.ToString()).Values.Contains(inputCode, StringComparer.OrdinalIgnoreCase))
            {
                matchingCodeUsed = false; // It's an exact match.
                KeyValuePair<ECODE, string> result = _enumCodes.First(x => x.Key.ToString().Equals(inputCode, StringComparison.OrdinalIgnoreCase));
                enumCodeValue = EnumCodeValue<ECODE>.BuildFrom(result.Key);
                return true;
            }
            else if (_enumMatchingCodes.Any(x => x.Value.Equals(inputCode, StringComparison.OrdinalIgnoreCase)))
            {
                matchingCodeUsed = true; // It's an approaching match
                ECODE eCode = _enumMatchingCodes.First(x => x.Value.Equals(inputCode, StringComparison.OrdinalIgnoreCase)).Key;
                enumCodeValue = EnumCodeValue<ECODE>.BuildFrom(eCode);
                return true;
            }
            matchingCodeUsed = true;
            return false;
        }

    }

}
