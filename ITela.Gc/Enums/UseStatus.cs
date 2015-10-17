using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITela.Gc
{
    /// <summary>
    /// Status regarding the use of a record, an item, etc.
    /// TODO: Must derive from a gemericode file
    /// </summary>
    public enum UseStatus
    {
        /// <summary>
        /// May be used.
        /// </summary>
        [GcCodeValue("Active", "Active")]
        Active,

        /// <summary>
        /// Must not be use -- no longer used or required, but kept to avoid breaking existing links.
        /// </summary>
        [GcCodeValue("Inactive", "Inactive")]
        Inactive,

        /// <summary>
        /// Should not be used -- to be inactivated or deleted in the future.
        /// </summary>
        [GcCodeValue("Deprecated", "Deprecated")]
        Deprecated,
    }
}
