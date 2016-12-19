using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTUtilities
{
    public class RTFieldNameAttribute : Attribute
    {
        public string Value { get; set; }

        public RTFieldNameAttribute(string value)
        {
            Value = value;
        }
    }
}
