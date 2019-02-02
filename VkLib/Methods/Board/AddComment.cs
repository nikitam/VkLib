using System;
using System.Collections.Generic;
using VkLib.Abstraction;

namespace VkLib.Methods.Board
{
    public class AddComment: IVkMethod<String>
    {
        #region In
        [VkParam("group_id")]
        public String GroupId { get; set; }
        [VkParam("topic_id")]
        public String TopicId { get; set; }
        [VkParam("text")]
        public String Text { get; set; }
        [VkParam("attachments")]
        public List<String> Attachments { get; set; }
        [VkParam("from_group")]
        public Boolean? FromGroup { get; set; }
        [VkParam("sticker_id")]
        public Int32? StickerId { get; set; }
        [VkParam("guid")]
        public String GuidComment { get; set; }

        #endregion

        public String Name
        {
            get
            {
                return "board.addComment";
            }
        }

        public Boolean NeedAuthentication
        {
            get
            {
                return true;
            }
        }

        public String Accept<T>(VkMethodVisitor<T> visitor, T data)
        {
            return visitor.VisitAddComment(this, data);
        }
    }
}
