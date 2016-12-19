using System;
using System.Collections.Generic;

namespace RTUtilities
{
    public class RTChoiceLoaderITEmailAddresses : RTChoiceLoaderBase
    {
        public override IEnumerable<string> Load(RTEmail rtEmail)
        {
            return RTActiveDirectory.ITEmailAddresses;
        }
    }
}
