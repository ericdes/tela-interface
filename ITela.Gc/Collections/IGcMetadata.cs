using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITela.Gc
{
    public interface IGcMetadata
    {
        string GenericodeVersion { get;  }

        /// <summary>
        /// Metadata code (i.e. "gc")
        /// </summary>
        string Code { get; }

        /// <summary>
        /// Must be identical to the value in section "Identification | ShortName" of the code list.
        /// E.g. TransportEquipmentTypeCode
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Must be identical to the value in section "Identification | Version" of the code list.
        /// E.g. D10B
        /// </summary>
        string Version { get; }

        GcMetadataAttribute Information { get; }

    }

}
