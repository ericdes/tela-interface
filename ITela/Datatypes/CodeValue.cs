using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITela
{
    #region ----- CodeValue<TCODE,TVALUE>
    /// <summary>
    /// A class to hold a code value, like a lookup value, a code generated name, etc...
    /// We expect the contructors of TCODE and TVALUE to check against all constraints.
    /// </summary>
    /// <typeparam name="TCODE">Type of the code.</typeparam>
    /// <typeparam name="TVALUE">Type of the value.</typeparam>
    //public class CodeValue<TCODE, TVALUE> : ICodeValue<TCODE, TVALUE>
    //{
    //    public TCODE Code { get; private set; }
    //    public TVALUE Value { get; private set; }

    //    public CodeValue(TCODE code, TVALUE value)
    //    {
    //        this.Code = code;
    //        this.Value = value;
    //    }

    //    public ICodeValue<TCODE, TVALUE> WithUpdatedValue(TVALUE newValue)
    //    {
    //        return new CodeValue<TCODE, TVALUE>(this.Code, newValue);
    //    }

    //    public new string ToString()
    //    {
    //        return string.Format("{0}: {1}", this.Code.ToString(), this.Value.ToString());
    //    }
    //}
    #endregion



    /// <summary>
    /// A class to hold a code value, like a lookup value, a code generated name, etc...
    /// We expect the contructors of TCODE and TVALUE to check against all constraints.
    /// </summary>
    /// <typeparam name="TCODE">Type of the code.</typeparam>
    /// <typeparam name="TVALUE">Type of the value.</typeparam>
    public class CodeValue<TCODE, TVALUE> : ICodeValue<TCODE, TVALUE>
    {
        private TCODE _code;
        private TVALUE _value;

        public TCODE Code { get { return _code; } }
        public TVALUE Value { get { return _value; } }

        internal CodeValue() {  }

        public CodeValue(TCODE code, TVALUE value) {
            _code = code;
            _value = value; 
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", this.Code.ToString(), this.Value.ToString());
        }
    }

}
