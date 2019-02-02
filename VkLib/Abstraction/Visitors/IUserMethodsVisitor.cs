using VkLib.Methods.Users;
using VkLib.Objects;

namespace VkLib.Abstraction.Visitors
{
    public interface IUserMethodsVisitor<T>
    {
        User VisitUsersGet(Get method, T data);
    }
}