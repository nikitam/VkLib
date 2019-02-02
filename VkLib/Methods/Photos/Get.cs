using System;
using System.Collections.Generic;
using VkLib.Abstraction;
using VkLib.Objects;

namespace VkLib.Methods.Photos
{
    public class Get: IVkMethod<List<Photo>>
    {
        #region In
        [VkParam("owner_id")]
        public String OwnerId { get; set; }
        [VkParam("album_id")]
        public String AlbumId { get; set; }
        [VkParam("photo_ids")]
        public List<String> PhotoIds { get; set; }
        [VkParam("rev")]
        public Boolean? Rev { get; set; }
        [VkParam("extended")]
        public Boolean? Extended { get; set; }
        [VkParam("feed_type")]
        public String FeedType { get; set; }
        [VkParam("feed")]
        public DateTime? Feed { get; set; }
        [VkParam("photo_sizes")]
        public Boolean? PhotoSizes { get; set; }
        [VkParam("offset")]
        public Int32? Offset { get; set; }
        [VkParam("count")]
        public Int32? Count { get; set; }
        #endregion

        public List<Photo> Accept<T>(VkMethodVisitor<T> visitor, T data)
        {
            return visitor.VisitPhotosGet(this, data);
        }

        public String Name
        {
            get
            {
                return "photos.get";
            }
        }

        public Boolean NeedAuthentication
        {
            get
            {
                return true;
            }
        }

    }
}