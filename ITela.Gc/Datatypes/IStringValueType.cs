using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;


namespace ITela.Gc
{
    /// <summary>
    /// Represents a string value.
    /// Null value is not allowed.
    /// </summary>
    public interface IStringValueType
    {
        /// <summary>
        /// Returns the string value.
        /// </summary>
        string ToString();
    }



}
