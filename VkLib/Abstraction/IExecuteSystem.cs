using System;

namespace VkLib.Abstraction
{
    public interface IExecuteSystem
    {
        TOutput Execute<TOutput>(IVkMethod<TOutput> method);

        Object UploadFile(Object address, Byte[] file);

        String PrincipalId { get; }
    }
}