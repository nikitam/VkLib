using System;
using VkLib.Abstraction.Domain;

namespace VkLib.Objects
{
    public class City: VkObject
    {
        public String Id { get; set; }

        public String Title { get; set; }

        public override void Accept<T>(IVkObjectVisitor<T> visitor, T data)
        {
            visitor.VisitCity(this, data);
        }
    }
}