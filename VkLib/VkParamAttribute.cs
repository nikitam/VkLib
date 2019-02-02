using System;

namespace VkLib
{
    public class VkParamAttribute : Attribute
    {
        public String Name { get; }

        public VkParamAttribute(String name)
        {
            this.Name = name;
        }
    }
}