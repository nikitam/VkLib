using VkLib.Abstraction.Domain;

namespace VkLib.Abstraction.Visitors
{
    public abstract class BaseMethodsVisitor<T>
    {
        protected IVkObjectVisitor<T> ObjectParser { get; }

        protected BaseMethodsVisitor(IVkObjectVisitor<T> v)
        {
            this.ObjectParser = v;
        }
    }
}