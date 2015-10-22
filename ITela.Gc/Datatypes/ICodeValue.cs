using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ITela.Gc
{
    /// <summary>
    /// A strongly typed code value, to use when populating data from an external source, e.g. a genericode file.
    /// We expect the contructors of TCODE and TVALUE to check against all constraints.
    /// </summary>
    /// <typeparam name="TCODE">Type of the code.</typeparam>
    /// <typeparam name="TVALUE">Type of the value.</typeparam>
    public interface ICodeValue<out TCODE, out TVALUE> : ICode<TCODE>, IValue<TVALUE>
    {
    }    

    //public interface ICodeValue<TCODE, TVALUE> : ICode<TCODE>, IValue<TVALUE>
    //{
    //    //ICodeValue<TCODE, TVALUE> WithUpdatedValue(TVALUE newValue);
    //    string ToString();
    //}



    /// <summary>
    /// A strongly typed code, to use when populating data from an external source, e.g. a genericode file.
    /// We expect the contructor of TCODE to check against all constraints.
    /// </summary>
    /// <typeparam name="TCODE">Type of the code.</typeparam>
    public interface ICode<out TCODE>
    {
        TCODE Code { get; }
    }

    /// <summary>
    /// A strongly typed value, to use when populating data from an external source, e.g. a genericode file.
    /// We expect the contructor of TVALUE to check against all constraints.
    /// </summary>
    /// <typeparam name="TVALUE">Type of the value.</typeparam>
    public interface IValue<out TVALUE>
    {
        TVALUE Value { get; }
    }



}
