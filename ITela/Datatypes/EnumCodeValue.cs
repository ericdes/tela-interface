using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#if DEBUG
using System.Reflection;
#endif

namespace ITela
{
    public class EnumCodeValue<ECODE, TCODE, TVALUE> : CodeValue<TCODE, TVALUE>
        where ECODE: struct
    {
        private ECODE _field;
        public ECODE Field { get { return _field; } }

        internal EnumCodeValue() { }

        public EnumCodeValue(ECODE field, TCODE code, TVALUE value) : base(code, value)
        {
            _field = field;
        }

        public override string ToString()
        {
            return string.Format("{2}[{0}]: {1}", this.Code.ToString(), this.Value.ToString(), this.Field.ToString());
        }
    }


    public class EnumCodeValue<ECODE> : EnumCodeValue<ECODE, string, string>
        where ECODE: struct
    {
        private EnumCodeValue(ECODE field, string code, string value) : base(field, code, value)
        {
        }

        public static EnumCodeValue<ECODE> BuildFrom(ECODE field)
        {
            throw new NotImplementedException("Trying to put this method to Gc because of dependence to GcCodeValueAnnotationReader");
//#if DEBUG
//            if (!(typeof(ECODE).GetTypeInfo().IsEnum)) throw new InvalidOperationException("Expecting E to be an Enum.");
//#endif
//            GcCodeValueAttribute gcAnnotation = GcCodeValueAnnotationReader.GetGcCodeValueAttribute<ECODE>(field);
//            return new EnumCodeValue<ECODE>(field, gcAnnotation.GcCode, gcAnnotation.GcValue);
        }
    }

}
