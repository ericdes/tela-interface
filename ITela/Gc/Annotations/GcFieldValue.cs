using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tela.Core.Gc
{
    /// <summary>
    /// Represents a field value in a genericode file.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class GcFieldValueAttribute : Attribute
    {
        /// <summary>
        /// Name of the field.
        /// </summary>
        public string Fieldname { get; private set; }

        /// <summary>
        /// Value.
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// Creates a new instance of field value.
        /// </summary>
        /// <param name="fieldname">Name of the field.</param>
        /// <param name="value">Value (or Name).</param>
        /// <exception cref="ArgumentNullException">Fieldname and value must not be null, fieldname must not be empty.</exception>
        public GcFieldValueAttribute(string fieldname, string value)
        {
            if (string.IsNullOrWhiteSpace(fieldname)) throw new ArgumentNullException("fieldname");
            if (value == null) throw new ArgumentNullException("value");
            this.Fieldname = fieldname;
            this.Value = value;
        }

    }

}
