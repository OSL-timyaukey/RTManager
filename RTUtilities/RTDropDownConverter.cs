using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTUtilities
{
    public class RTDropDownConverter : System.ComponentModel.StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            PropertyDescriptor descriptor = context.PropertyDescriptor;
            List<string> values = new List<string>();
            RTChoicesAttribute choicesAttrib = (RTChoicesAttribute)descriptor.Attributes[typeof(RTChoicesAttribute)];
            RTChoiceLoaderAttribute loaderAttrib = (RTChoiceLoaderAttribute)descriptor.Attributes[typeof(RTChoiceLoaderAttribute)];
            if (choicesAttrib != null)
            {
                foreach (string value in choicesAttrib.Values.Split('|'))
                {
                    values.Add(value);
                }
            }
            else if (loaderAttrib != null)
            {
                RTChoiceLoaderBase loader = (RTChoiceLoaderBase)Activator.CreateInstance(loaderAttrib.Loader);
                foreach (string value in loader.Load((RTEmail)context.Instance))
                {
                    values.Add(value);
                }
            }
            else
                throw new InvalidOperationException("Missing attribute");
            return new StandardValuesCollection(values);
        }
    }
}
