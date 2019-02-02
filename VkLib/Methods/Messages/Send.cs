using System;
using System.Collections.Generic;
using VkLib.Abstraction;

namespace VkLib.Methods.Messages
{
    public class Send: IVkMethod<String>
    {
        #region In
        [VkParam("user_id")]
        public String UserId { get; set; }
        [VkParam("domain")]
        public String Domain { get; set; }
        [VkParam("chat_id")]
        public String ChatId { get; set; }
        [VkParam("user_ids")]
        public List<String> UserIds { get; set; }
        [VkParam("message")]
        public String Message { get; set; }
        [VkParam("guid")]
        public Guid? Unique { get; set; }
        [VkParam("lat")]
        public Double? Lat { get; set; }
        [VkParam("long")]
        public Double? Long { get; set; }
        [VkParam("attachment")]
        public List<String> Attachment { get; set; }
        #endregion

        public String Accept<T>(VkMethodVisitor<T> visitor, T data)
        {
            return visitor.VisitMessageSend(this, data);
        }

        public String Name
        {
            get
            {
                return "messages.send";
            }
        }

        public Boolean NeedAuthentication
        {
            get { return true; }
        }
    }
}