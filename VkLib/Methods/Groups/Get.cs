using System;
using System.Collections.Generic;
using VkLib.Abstraction;
using VkLib.Objects;

namespace VkLib.Methods.Groups
{
    public class Get: IVkMethod<List<Group>>
    {
        #region in
        [VkParam("user_id")]
        public String UserId { get; set; }
        [VkParam("extended")]
        public Boolean? Extended { get; set; }
        [VkParam("filter")]
        public String Filter { get; set; }
        [VkParam("fields")]
        public List<String> Fields { get; set; }
        [VkParam("count")]
        public Int32? Count { get; set; }
        [VkParam("offset")]
        public Int32? Offset { get; set; }
        #endregion

        #region Overrides of BaseVkMethod<Group>

        public List<Group> Accept<T>(VkMethodVisitor<T> visitor, T data)
        {
            return visitor.VisitGroupsGet(this, data);
        }

        public String Name
        {
            get { return "groups.get"; }
        }

        public Boolean NeedAuthentication
        {
            get { return true; }
        }

        #endregion
    }
}