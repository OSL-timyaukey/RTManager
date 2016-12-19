using System;
using System.Collections.Generic;

namespace RTUtilities
{
    public class RTChoiceLoaderQueue : RTChoiceLoaderBase
    {
        public override IEnumerable<string> Load(RTEmail rtEmail)
        {
            List<string> output = new List<string>();
            output.AddRange(RTFileLoader.GetFileContents("Queues.txt"));
            return output;
        }
    }
}
