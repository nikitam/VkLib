using System;
using VkLib.Abstraction;

namespace VkLib.Methods.Friends
{
    public class Add: IVkMethod<String>
    {
        #region In
        [VkParam("user_id")]
        public String UserId { get; set; }
        [VkParam("text")]
        public String Text { get; set; }
        [VkParam("follow")]
        public Boolean? Follow { get; set; }
        #endregion

        public String Accept<T>(VkMethodVisitor<T> visitor, T data)
        {
            return visitor.VisitFriendsAdd(this, data);
        }

        public String Name
        {
            get { return "friends.add"; }
        }

        public Boolean NeedAuthentication
        {
            get { return true; }
        }
    }
}