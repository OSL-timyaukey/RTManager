using System;

namespace RTUtilities
{
    public class RTFieldFormatterAttribute : System.Attribute
    {
        public readonly Type FormatterType;

        public RTFieldFormatterAttribute(Type formatterType)
        {
            FormatterType = formatterType;
        }
    }
}
