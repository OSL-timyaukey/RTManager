using System;

namespace RTUtilities
{
    public class RTChoiceLoaderAttribute : Attribute
    {
        public Type Loader;

        public RTChoiceLoaderAttribute(Type loader)
        {
            Loader = loader;
        }
    }
}
