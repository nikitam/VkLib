using System.Collections.Generic;
using VkLib.Methods.Groups;
using VkLib.Objects;

namespace VkLib.Abstraction.Visitors
{
    public interface IGroupMethodsVisitor<T>
    {
        List<Group> VisitGroupsGet(Get method, T data);
        List<IsMemberResult> VisitGroupsIsMember(IsMember method, T data);
    }
}