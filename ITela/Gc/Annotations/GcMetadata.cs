using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITela.Gc
{
    /// <summary>
    /// Represents information about a genericode file to annotate on codevalue collection.
    /// </summary>
    public class GcMetadataAttribute : Attribute
    {
        /// <summary>
        /// Must be identical to the URI in section "Identification | LocationUri" of the code list.
        /// E.g. http://docs.oasis-open.org/ubl/os-UBL-2.1/cl/gc/default/TransportEquipmentTypeCode-2.1.gc
        /// </summary>
        public string LocationUri { get; set; }

        /// <summary>
        /// Specify if this enumeration consists of a restricted list of values.
        /// </summary>
        public bool IsRestriction { get; set; }

        /// <summary>
        /// The file name.
        /// E.g. TransportEquipmentTypeCode-2.1.gc
        /// </summary>
        public string Filename
        {
            get
            {
                var filename = this.LocationUri.Substring(this.LocationUri.LastIndexOf('/') + 1);
                return filename;
            }
        }

        /// <summary>
        /// Creates a new instance of this GC enum metadata.
        /// </summary>
        /// <param name="filename">Genericode filename</param>
        public GcMetadataAttribute(string locationUri)
        {
            if (string.IsNullOrWhiteSpace(locationUri)) throw new ArgumentNullException("locationUri");
            var uri = new Uri(locationUri); // will throw if not a uri.
            this.LocationUri = locationUri;
        }

    }

}
