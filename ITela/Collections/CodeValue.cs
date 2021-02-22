using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITela
{
    public class CodeValue : ICodeValue<string, string>
    {
        public string Code { get; private set; }

        public string Value { get; private set; }

        public CodeValue(string code, string value)
        {
            this.Code = code;
            this.Value = value;
        }
    }
}
