using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTUtilities
{
    public class RTChoicesAttribute : Attribute
    {
        public string Values { get; set; }

        public RTChoicesAttribute(string values)
        {
            Values = values;
        }
    }
}
