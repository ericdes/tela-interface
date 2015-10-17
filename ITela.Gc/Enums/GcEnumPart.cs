using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITela.Gc
{
    public enum GcEnumPart
    {
        /// <summary>
        /// Enum field.
        /// </summary>
        Field,

        /// <summary>
        /// Code in annotation GcCodeValue. 
        /// </summary>
        Code,

        /// <summary>
        /// Value in annotation GcCodeValue.
        /// </summary>
        Value,

        /// <summary>
        /// Comments on enum field.
        /// </summary>
        Comments,

        /// <summary>
        /// Additional comments on enum field.
        /// </summary>
        CommentsAdditional,

    }
}
