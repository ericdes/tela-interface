using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITela.Gc
{
    public interface IGcCodeValueCollection<TCODE, TVALUE> : IDictionary<TCODE, TVALUE>
    {
        /// <summary>
        /// Name of the field that holds the codes.
        /// </summary>
        string CodeField { get; }

        /// <summary>
        /// Name of the field that holds the values.
        /// </summary>
        string ValueField { get; }
    }
}
