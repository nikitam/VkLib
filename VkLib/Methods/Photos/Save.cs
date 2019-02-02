using System;
using System.Collections.Generic;
using VkLib.Abstraction;
using VkLib.Objects;

namespace VkLib.Methods.Photos
{
    public class Save: IVkMethod<List<Photo>>
    {
        #region In
        [VkParam("album_id")]
        public String AlbumId { get; set; }
        [VkParam("group_id")]
        public String GroupId { get; set; }
        [VkParam("server")]
        public String Server { get; set; }
        [VkParam("photos_list")]
        public String PhotosList { get; set; }
        [VkParam("hash")]
        public String Hash { get; set; }
        [VkParam("latitude")]
        public Double? Latitude { get; set; }
        [VkParam("longitude")]
        public Double? Longitude { get; set; }
        [VkParam("caption")]
        public String Caption { get; set; }
        #endregion

        public List<Photo> Accept<T>(VkMethodVisitor<T> visitor, T data)
        {
            return visitor.VisitPhotosSave(this, data);
        }

        public String Name
        {
            get { return "photos.save"; }
        }

        public Boolean NeedAuthentication
        {
            get { return true; }
        }


    }
}