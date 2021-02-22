using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITela
{
    public interface IRecordKey<out TKey>
    {
        /// <summary>
        /// Record's key.
        /// </summary>
        TKey GetKey();

        bool IsKeyValid();
    }
}
