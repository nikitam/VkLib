using System;
using System.Collections.Generic;
using VkLib.Abstraction;

namespace VkLib.Methods.Board
{
    public class AddTopic : IVkMethod<String>
    {
        [VkParam("group_id")]
        public String GroupId { get; set; }
        [VkParam("title")]
        public String Title { get; set; }
        [VkParam("text")]
        public String Text { get; set; }
        [VkParam("from_group")]
        public Boolean? FromGroup { get; set; }
        [VkParam("attachments")]
        public List<String> Attachments { get; set; }

        public String Accept<T>(VkMethodVisitor<T> visitor, T data)
        {
            return visitor.VisitAddTopic(this, data);
        }

        public String Name
        {
            get
            {
                return "board.addTopic";
            }
        }

        public  Boolean NeedAuthentication
        {
            get
            {
                return true;
            }
        }
        
    }
}
