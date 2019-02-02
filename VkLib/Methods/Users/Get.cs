using System;
using System.Collections.Generic;
using VkLib.Abstraction;
using VkLib.Objects;

namespace VkLib.Methods.Users
{
    public class Get: IVkMethod<User>
    {
        #region In
        [VkParam("user_ids")]
        public List<String> UserIds { get; set; }
        [VkParam("fields")]
        public List<String> Fields { get; set; }
        [VkParam("name_case")]
        public String NameCase { get; set; }
        #endregion

        public User Accept<T>(VkMethodVisitor<T> visitor, T data)
        {
            return visitor.VisitUsersGet(this, data);
        }

        public String Name
        {
            get { return "users.get"; }
        }

        public Boolean NeedAuthentication
        {
            get { return true; }
        }

    }
}