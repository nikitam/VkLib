using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using VkLib.Realization;

namespace VkLib.Abstraction
{
    public abstract class BaseExecuteSystem<TTransportData> : IExecuteSystem
    {
        protected IAuthenticationProvider AuthenticationProvider { get; }

        public String PrincipalId { get; }

        protected BaseExecuteSystem(IAuthenticationProvider provider = null)
        {
            if (provider == null)
            {
                this.AuthenticationProvider = new ImpersonateAuthProvider();
            }
            else
            {
                this.AuthenticationProvider = provider;
            }

            this.PrincipalId = this.AuthenticationProvider.PrincipalId;
        }

        protected abstract Dictionary<String, String> PrepareRequestParameters(IVkMethod method, ExecuteEnvironment environment);

        protected abstract TTransportData CreateRequest(Dictionary<String, String> requestParameters, IVkMethod method, ExecuteEnvironment ee);

        protected abstract TTransportData TransmitRequest(TTransportData request, ExecuteEnvironment ee);

        protected TOutput ParseResponse<TOutput>(TTransportData response, IVkMethod<TOutput> method, ExecuteEnvironment environment)
        {
            var methodVisitor = this.CreateMethodVisitor(response, environment);
            var error = methodVisitor.GetError();
            if (error != null)
            {
                throw new Exception($"An error with code {error.ErrorCode} was occured during method {method.Name} execution. Error text: {error.ErrorMsg}");
            }

            return method.Accept(methodVisitor, methodVisitor.Data);
        }

        public TOutput Execute<TOutput>(IVkMethod<TOutput> method)
        {
            var env = this.CreateEnvironment();

            TOutput result;
            do
            {
                env.NeedResend = false;

                var parameters = this.PrepareRequestParameters(method, env);
                var request = this.CreateRequest(parameters, method, env);
                var response = this.TransmitRequest(request, env);
                result = this.ParseResponse(response, method, env);

            } while (env.NeedResend);

            return result;
        }

        #region DI

        protected abstract VkMethodVisitor<JToken> CreateMethodVisitor(TTransportData data, ExecuteEnvironment environment);

        protected abstract ExecuteEnvironment CreateEnvironment();

        #endregion

        #region Uploading

        public abstract Object UploadFile(Object address, Byte[] file);
        

        #endregion
    }
}