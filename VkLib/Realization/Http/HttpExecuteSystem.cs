using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;
using VkLib.Abstraction;

namespace VkLib.Realization.Http
{
    public class HttpExecuteSystem : ByAttributeExecuteSystem<String>
    {
        private const String WithAccessTokenTemlate = "https://api.vk.com/method/{0}?{1}&access_token={2}&v=5.27";
        private const String WithoutAccessTokenTemlate = "https://api.vk.com/method/{0}?{1}&v=5.27";

        protected HttpExecuteSystem(IAuthenticationProvider provider = null)
            : base(provider)
        {
        }

        protected override String CreateRequest(Dictionary<String, String> requestParameters, IVkMethod method, ExecuteEnvironment ee)
        {
            if (requestParameters.Count == 0)
            {
                throw new Exception($"При формировании запроса для метода {method.Name} не были заданы входные параметры");
            }

            var sb = new StringBuilder();
            int i = 1;
            foreach (var pair in requestParameters)
            {
                sb.Append(pair.Key).Append("=").Append(pair.Value);

                if (i < requestParameters.Count)
                {
                    sb.Append("&");
                }

                i++;
            }

            var queryString = sb.ToString();

            if (this.AuthenticationProvider.IsAuthenticated)
            {
                if (method.NeedAuthentication)
                {
                    var r = String.Format(WithAccessTokenTemlate, method.Name, queryString, this.AuthenticationProvider.AccessToken);
                    //this.Log.WriteInfo(String.Format("Id: {0}; Запрос: {1}", ee.Id, r));
                    return r;
                }

                var r2 = String.Format(WithoutAccessTokenTemlate, method.Name, queryString);
                //this.Log.WriteInfo(String.Format("Id: {0}; Запрос: {1}", ee.Id, r2));
                return r2;
            }

            if (method.NeedAuthentication)
            {
                throw new Exception($"Метод {method.Name} нельзя вызывать без проведенной аутентификации");
            }

            var r3 = String.Format(WithoutAccessTokenTemlate, method.Name, queryString);
            //this.Log.WriteInfo(String.Format("Id: {0}; Запрос: {1}", ee.Id, r3));
            return r3;
        }

        protected override String TransmitRequest(String request, ExecuteEnvironment ee)
        {
            Exception lastException = null;
            for (Byte i = 0; i < 3; i++)
            {
                try
                {
                    var req = WebRequest.Create(request);
                    req.Timeout = 5000;
                    var resp = req.GetResponse();

                    String data = null;
                    using (var stream = resp.GetResponseStream())
                    {
                        if (stream != null)
                        {
                            var streamReader = new StreamReader(stream, true);
                            try
                            {
                                data = streamReader.ReadToEnd();
                            }
                            finally
                            {
                                streamReader.Close();
                            }
                        }
                    }

                    // Максимальная частота обращений к АПИ 5 раза в секунду, пока примитивное решение
                    // после каждого запроса ждем 1/3 секунды
                    System.Threading.Thread.Sleep(333);


                    if (!String.IsNullOrEmpty(data))
                    {
                        //this.Log.WriteDebug(String.Format("Id: {0}; Ответ: {1}", ee.Id, data));
                        if (data.Length > 100)
                        {
                            //this.Log.WriteOnlyInfo(String.Format("Id: {0}; Ответ: {1}", ee.Id, data.Substring(0, 100)));
                        }
                        else
                        {
                            //this.Log.WriteOnlyInfo(String.Format("Id: {0}; Ответ: {1}", ee.Id, data));
                        }
                    }
                    {
                        //this.Log.WriteDebug(String.Format("Id: {0}; Ответ: {1}", ee.Id, "<null>"));
                    }

                    return data;
                }
                catch (WebException ex)
                {
                    //this.Log.WriteError(String.Format("Id: {0}; Попытка: {1}; Ошибка: {2}", ee.Id, i, ex.ToString()));
                    lastException = ex;
                }
            }

            //this.Log.WriteError(String.Format("Произошла ошибка при передаче запроса {0}; Ошибка: {1}", request, lastException));
            throw new Exception($"Произошла ошибка при передаче запроса {request}", lastException);
        }

        protected override VkMethodVisitor<JToken> CreateMethodVisitor(String data, ExecuteEnvironment environment)
        {
            return new JsonMethodResponseParser(data, environment);
        }

        protected override ExecuteEnvironment CreateEnvironment()
        {
            return new SimpleExecuteEnvironment(CultureInfo.CurrentUICulture);
        }

        public override Object UploadFile(Object address, Byte[] file)
        {
            var cl = new WebClient();

            var tmpDir = System.IO.Path.GetTempPath();
            var fullFileName = System.IO.Path.Combine(tmpDir, "file1.jpg");

            try
            {
                System.IO.File.WriteAllBytes(fullFileName, file);
                var response = cl.UploadFile((String) address, fullFileName);
                return Encoding.UTF8.GetString(response);
            }
            finally
            {
                System.IO.File.Delete(fullFileName);
            }
        }
    }
}