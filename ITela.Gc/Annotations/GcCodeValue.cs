using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITela.Gc
{
    /// <summary>
    /// Represents a code/value pair in a genericode file.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class GcCodeValueAttribute : Attribute
    {
        /// <summary>
        /// Code (or key).
        /// </summary>
        public string GcCode { get; private set; }

        /// <summary>
        /// Value (or name).
        /// </summary>
        public string GcValue { get; private set; }

        /// <summary>
        /// Creates a new instance code/value pair.
        /// </summary>
        /// <param name="gcCode">Code (or key).</param>
        /// <param name="gcValue">Value (or name).</param>
        /// <exception cref="ArgumentNullException">Code and value must not be null or empty.</exception>
        public GcCodeValueAttribute(string gcCode, string gcValue)
        {
            if (string.IsNullOrWhiteSpace(gcCode)) throw new ArgumentNullException("gcCode");
            if (string.IsNullOrWhiteSpace(gcValue)) throw new ArgumentNullException("gcValue");
            this.GcCode = gcCode;
            this.GcValue = gcValue;
        }

    }

}
