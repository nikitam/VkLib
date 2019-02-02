using System;
using VkLib.Abstraction.Domain;

namespace VkLib.Objects
{
    public class Photo: VkObject
    {
        public String Id { get; set; }

        public String AlbumId { get; set; }

        public String OwnerId { get; set; }

        public String Photo75 { get; set; }

        public String Photo130 { get; set; }

        public String Photo604 { get; set; }

        public String Photo807 { get; set; }

        public String Photo1280 { get; set; }

        public String Photo2560 { get; set; }

        public DateTime InsertDate { get; set; }

        public String Text { get; set; }

        public Int32? Comments { get; set; }

        public override void Accept<T>(IVkObjectVisitor<T> visitor, T data)
        {
            visitor.VisitPhoto(this, data);
        }

        public String GetNearestNormalSizePhoto()
        {
            if (String.IsNullOrEmpty(this.Photo807))
            {
                if (String.IsNullOrEmpty(this.Photo604))
                {
                    if (String.IsNullOrEmpty(this.Photo130))
                    {
                        return this.Photo75;
                    }
                    return this.Photo130;
                }
                return this.Photo604;
            }
            return this.Photo807;
        }
    }
}