using System;
using System.Collections.Generic;
using VkLib.Abstraction;

namespace VkLib.Methods.Photos
{
    public class CreateComment : IVkMethod<String>
    {
        #region In
        [VkParam("owner_id")]
        public String OwnerId { get; set; }
        [VkParam("photo_id")]
        public String PhotoId { get; set; }
        [VkParam("message")]
        public String Message { get; set; }
        [VkParam("attachments")]
        public List<String> Attachments { get; set; }
        [VkParam("from_group")]
        public Boolean? FromGroup { get; set; }
        [VkParam("reply_to_comment")]
        public String ReplyToComment { get; set; }
        [VkParam("sticker_id")]
        public String StickerId { get; set; }
        #endregion

        public String Accept<T>(VkMethodVisitor<T> visitor, T data)
        {
            return visitor.VisistPhotoCreateComment(this, data);
        }

        public String Name
        {
            get { return "photos.createComment"; }
        }

        public Boolean NeedAuthentication
        {
            get { return true; }
        }


    }
}