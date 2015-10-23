using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITela.Gc
{
    public static class GcCodeValueAnnotationReader
    {
        /// <summary>
        /// Get the genericode code of this enum field decorated with a GCodeValue attribute.
        /// </summary>
        public static string ReadCode(this Enum e)
        {
            return GetGcCodeValueAttribute(e).GcCode;

        }

        /// <summary>
        /// Get the genericode value of this enum field decorated with a GCodeValue attribute.
        /// </summary>
        public static string ReadValue(this Enum e)
        {
            return GetGcCodeValueAttribute(e).GcValue;
        }

        public static GcCodeValueAttribute GetGcCodeValueAttribute<E>(E e)
        {
            FieldInfo fieldInfo = typeof(E).GetRuntimeField(e.ToString());
            var attributes = fieldInfo.GetCustomAttributes<GcCodeValueAttribute>();
            var attribute = attributes.FirstOrDefault();
            if (attribute == null) throw new ArgumentException(string.Format("Enum field '{0}' must be decorated with attribute 'GcCodeValue'.", e.ToString()));
            return attributes.FirstOrDefault();
        }
        
        internal static GcCodeValueAttribute GetGcCodeValueAttribute(Enum e)
        {
            Type t = e.GetType();
            FieldInfo fieldInfo = t.GetRuntimeField(e.ToString());
            var attributes = fieldInfo.GetCustomAttributes<GcCodeValueAttribute>();
            var attribute = attributes.FirstOrDefault();
            if (attribute == null) throw new ArgumentException(string.Format("Enum field '{0}' must be decorated with attribute 'GcCodeValue'.", e.ToString()));
            return attributes.FirstOrDefault();
        }


    }
}
