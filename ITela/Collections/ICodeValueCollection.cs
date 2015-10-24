using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITela
{
    /// <summary>
    /// Class to conveniently hold a collection of codes with corresponding values.
    /// </summary>
    public interface ICodeValueCollection<TCODE, TVALUE> : IDictionary<TCODE, TVALUE>
    {
        void Add(ICodeValue<TCODE, TVALUE> codeValue);
        ICodeValueCollection ToCodeValueCollection(Func<ICodeValue<TCODE, TVALUE>, string> keySelector, Func<ICodeValue<TCODE, TVALUE>, string> elementSelector, IEqualityComparer<TCODE> comparer = null);
        ICodeValueCollection ToCodeValueCollection();
    }

    public interface ICodeValueCollection : ICodeValueCollection<string, string>
    {

    }
}
