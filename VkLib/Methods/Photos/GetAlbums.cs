using System;
using System.Collections.Generic;
using VkLib.Abstraction;
using VkLib.Objects;

namespace VkLib.Methods.Photos
{
    public class GetAlbums: IVkMethod<List<Album>>
    {
        #region In
        [VkParam("owner_id")]
        public String OwnerId { get; set; }
        [VkParam("album_ids")]
        public List<String> AlbumIds { get; set; }
        [VkParam("offset")]
        public UInt32? Offset { get; set; }
        [VkParam("count")]
        public UInt32? Count { get; set; }
        [VkParam("need_system")]
        public Boolean? NeedSystem { get; set; }
        [VkParam("need_covers")]
        public Boolean? NeedCovers { get; set; }
        [VkParam("photo_sizes")]
        public Boolean? PhotoSizes { get; set; }
        #endregion

        public List<Album> Accept<T>(VkMethodVisitor<T> visitor, T data)
        {
            return visitor.VisitPhotosGetAlbums(this, data);
        }

        public String Name
        {
            get { return "photos.getAlbums"; }
        }

        public Boolean NeedAuthentication
        {
            get { return false; }
        }

    }
}