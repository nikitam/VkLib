using System;
using System.Collections.Generic;
using VkLib.Abstraction;
using VkLib.Objects;

namespace VkLib.Methods.Photos
{
    public class GetComments : IVkMethod<List<PhotoComment>>
    {
        #region In
        [VkParam("owner_id")]
        public string OwnerId { get; set; }
        [VkParam("photo_id")]
        public string PhotoId { get; set; }
        [VkParam("need_likes")]
        public bool? NeedLikes { get; set; }
        [VkParam("offset")]
        public int? Offset { get; set; }
        [VkParam("count")]
        public int? Count { get; set; }
        [VkParam("sort")]
        public string Sort { get; set; }
        [VkParam("access_key")]
        public string AccessKey { get; set; }
        [VkParam("extended")]
        public bool? Extended { get; set; }
        #endregion

        public List<PhotoComment> Accept<T>(VkMethodVisitor<T> visitor, T data)
        {
            return visitor.VisitPhotoGetComments(this, data);
        }

        public String Name
        {
            get
            {
                return "photos.getComments";
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