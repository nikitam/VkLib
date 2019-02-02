using System;
using VkLib.Abstraction;
using VkLib.Objects;

namespace VkLib.Methods.Photos
{
    public class CreateAlbum: IVkMethod<Album>
    {
        #region In
        [VkParam("title")]
        public String Title { get; set; }
        [VkParam("group_id")]
        public String GroupId { get; set; }
        [VkParam("description")]
        public String Description { get; set; }
        [VkParam("privacy_view")]
        public String PrivacyView { get; set; }
        [VkParam(("privacy_comment"))]
        public String PrivacyComment { get; set; }
        [VkParam("upload_by_admins_only")]
        public Boolean? UploadByAdmins { get; set; }
        [VkParam("comments_disabled")]
        public Boolean? CommentsDisabled { get; set; }
        #endregion

        public Album Accept<T>(VkMethodVisitor<T> visitor, T data)
        {
            return visitor.VisitPhotosCreateAlbum(this, data);
        }

        public String Name
        {
            get { return "photos.createAlbum"; }
        }

        public Boolean NeedAuthentication
        {
            get { return true; }
        }

    }
}