using System;
using VkLib.Abstraction;
using VkLib.Objects.ServiceObjects;

namespace VkLib.Methods.Photos
{

    public class GetUploadServer: IVkMethod<UploadServerData>
    {
        #region In
        [VkParam("album_id")]
        public String AlbumId { get; set; }
        [VkParam("group_id")]
        public String GroupId { get; set; }
        #endregion

        public UploadServerData Accept<T>(VkMethodVisitor<T> visitor, T data)
        {
            return visitor.VisitPhotosGetUploadServer(this, data);
        }

        public String Name
        {
            get { return "photos.getUploadServer"; }
        }

        public Boolean NeedAuthentication
        {
            get { return true; }
        }


    }
}