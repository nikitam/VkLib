using System;
using System.Collections.Generic;
using VkLib.Methods.Friends;
using VkLib.Objects;

namespace VkLib.Abstraction.Visitors
{
    public interface IFriendMethodsVisitor<T>
    {
        List<User> VisitFriendsGet(Get method, T data);
        String VisitFriendsAdd(Add method, T data);
    }
}