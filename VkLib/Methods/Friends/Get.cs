using System;
using System.Collections.Generic;
using VkLib.Abstraction;
using VkLib.Objects;

namespace VkLib.Methods.Friends
{
    public class Get: IVkMethod<List<User>>
    {
        #region In
        [VkParam("user_id")]
        public String UserId { get; set; }
        [VkParam("order")]
        public String Order { get; set; }
        [VkParam("list_id")]
        public List<String> Lists { get; set; }
        [VkParam("count")]
        public Int32? Count { get; set; }
        [VkParam("offset")]
        public Int32? Offset { get; set; }
        [VkParam("fields")]
        public List<String> Fields { get; set; }
        [VkParam("name_case")]
        public String NameCase { get; set; }
        #endregion

        public List<User> Accept<T>(VkMethodVisitor<T> visitor, T data)
        {
            return visitor.VisitFriendsGet(this, data);
        }

        public String Name
        {
            get { return "friends.get"; }
        }

        public Boolean NeedAuthentication
        {
            get { return true; }
        }

    }
}