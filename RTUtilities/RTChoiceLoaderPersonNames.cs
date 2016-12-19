using System;
using System.Collections.Generic;

namespace RTUtilities
{
    public class RTChoiceLoaderPersonNames : RTChoiceLoaderBase
    {
        public override IEnumerable<string> Load(RTEmail rtEmail)
        {
            return RTActiveDirectory.ITPersonNames;
        }
    }
}
