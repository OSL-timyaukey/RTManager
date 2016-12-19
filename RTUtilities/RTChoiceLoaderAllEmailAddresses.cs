using System;
using System.Collections.Generic;

namespace RTUtilities
{
    public class RTChoiceLoaderAllEmailAddresses : RTChoiceLoaderBase
    {
        public override IEnumerable<string> Load(RTEmail rtEmail)
        {
            return RTActiveDirectory.AllEmailAddresses;
        }
    }
}
