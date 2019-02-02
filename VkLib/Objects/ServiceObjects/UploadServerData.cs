using System;
using VkLib.Abstraction.Domain;

namespace VkLib.Objects.ServiceObjects
{
    public class UploadServerData: ServiceObject
    {
        public String UploadUrl { get; set; }
        public String AlbumId { get; set; }
        public String UserId { get; set; }

        public override void Accept<T>(IVkObjectVisitor<T> visitor, T data)
        {
            visitor.VisitUploadServerData(this, data);
        }
    }
}