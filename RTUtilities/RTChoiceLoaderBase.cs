using System;
using System.Collections.Generic;

namespace RTUtilities
{
    public abstract class RTChoiceLoaderBase
    {
        public abstract IEnumerable<string> Load(RTEmail rtEmail);
    }
}
