// File: IsMember.cs
// Author: nikitam
// Created: 23

using System;
using System.Collections.Generic;
using VkLib.Abstraction;

namespace VkLib.Methods.Groups
{
    public class IsMember: IVkMethod<List<IsMemberResult>>
    {
        [VkParam("group_id")]
        public String GroupId { get; set; }

        [VkParam("user_ids")]
        public List<String> UserIds { get; set; }

        public List<IsMemberResult> Accept<T>(VkMethodVisitor<T> visitor, T data)
        {
            return visitor.VisitGroupsIsMember(this, data);
        }

        public String Name
        {
            get { return "groups.isMember"; }
        }

        public Boolean NeedAuthentication
        {
            get { return true; }
        }
    }

    public class IsMemberResult
    {
        public String UserId { get; set; }
        public Boolean IsMember { get; set; }
        public Boolean HaveRequest { get; set; }
        public Boolean Invited { get; set; }
    }
}