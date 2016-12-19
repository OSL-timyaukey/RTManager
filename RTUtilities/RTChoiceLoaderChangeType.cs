using System;
using System.Collections.Generic;

namespace RTUtilities
{
    public class RTChoiceLoaderChangeType : RTChoiceLoaderBase
    {
        public override IEnumerable<string> Load(RTEmail rtEmail)
        {
            List<string> output = new List<string>();
            if (rtEmail.TicketType == "Change")
            {
                output.AddRange(new string[] { "Standard", "Normal", "Emergency" });
            }
            else
            {
                output.Add("");
            }
            return output;
        }
    }
}
