using System;
using System.Collections.Generic;

namespace RTUtilities
{
    public class RTChoiceLoaderSubActivity : RTChoiceLoaderBase
    {
        public override IEnumerable<string> Load(RTEmail rtEmail)
        {
            List<string> output = new List<string>();
            if (rtEmail.Activity == "Miscellaneous Admin")
            {
                output.AddRange(new string[] {
                    "Leave (VA, SL, PB, etc)",
                    "Other"
                });
            }
            else if (rtEmail.Activity == "Service Enhancements")
            {
                output.AddRange(RTFileLoader.GetFileContents("ServiceEnhancements.txt"));
            }
            else if (rtEmail.Activity == "Enterprise Projects")
            {
                output.AddRange(RTFileLoader.GetFileContents("EnterpriseProjects.txt"));
            }
            else if (rtEmail.Activity == "IT Projects")
            {
                output.AddRange(RTFileLoader.GetFileContents("ITProjects.txt"));
            }
            else
            {
                output.Add("");
            }
            return output;
        }
    }
}
