using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITela.Gc
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class GcEnumFieldAttribute : Attribute
    {
        /// <summary>
        /// Reference to the column that contains this field values
        /// </summary>
        public string GcColumnRef { get; private set; }

        /// <summary>
        /// The system value type we use internally for this field values.
        /// </summary>
        public string DataType { get; set; }

        public int Min { get; set; }
        public int Max { get; set; }

        public GcEnumPart[] EnumPosition { get; set; } 

        public GcEnumFieldAttribute(string gcColumnRef, params GcEnumPart[] enumPosition)
        {
            this.GcColumnRef = gcColumnRef;
            this.EnumPosition = enumPosition;
        }
    }
}
