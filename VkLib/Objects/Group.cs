using System;
using VkLib.Abstraction.Domain;

namespace VkLib.Objects
{
    public class Group: VkPrincipal
    {
        public String Name { get; set; }

        public Boolean IsClosed { get; set; }

        public String Type { get; set; }

        public Boolean IsAdmin { get; set; }

        public String AdminLevel { get; set; }

        public Boolean IsMember { get; set; }

        public override void Accept<T>(IVkObjectVisitor<T> visitor, T data)
        {
            visitor.VisitGroup(this, data);
        }

        public override String DisplayName
        {
            get
            {
                return this.Name;
            }
        }
    }
}