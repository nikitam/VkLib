using System;
using VkLib.Abstraction.Domain;

namespace VkLib.Objects
{
    public class PhotoComment: VkObject
    {
        public String Id { get; set; }

        public String FromId { get; set; }

        public Boolean CanEdit { get; set; }

        public DateTime Date { get; set; }

        public String Text { get; set; }

        public VkPrincipal Creator { get; set; }

        public override void Accept<T>(IVkObjectVisitor<T> visitor, T data)
        {
            visitor.VisitPhotoComment(this, data);
        }
    }
}