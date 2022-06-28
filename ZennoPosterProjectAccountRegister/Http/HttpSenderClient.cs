using SmartProxyV2_ZennoLabVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ZennoLab.InterfacesLibrary.ProjectModel;
using ZennoLab.InterfacesLibrary.ProjectModel.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ZennoPosterProjectAccountRegister.Models.Objects;
using ZennoPosterProjectAccountRegister.Logger;

namespace ZennoPosterProjectAccountRegister.Http
{
    public delegate void SetHeaders(HttpRequestMessage requestMessage);
    public delegate void SetBody<RequestBodyType>(RequestBodyType jsonBodyContent, HttpRequestMessage requestMessage);
    internal class HttpSenderClient
    {
        protected HttpClientHandler HttpClientHandler { get; }
        protected IProfile Profile { get; }
        protected ProjectLogger Logger { get; }

        public HttpSenderClient(IZennoPosterProjectModel project, ProxyModel proxyModel)
        {
            HttpClientHandler = new HttpClientHandler();
            Profile = project.Profile;
            SetCookies();
            SetProxy(proxyModel);
            Logger = new ProjectLogger();
        }

        protected async Task<T> SendRequestAsync<T>(HttpMethod httpMethod, string url, SetHeaders setHeaders)
        {
            try
            {
                T responceBody;
                HttpClient httpClient = new HttpClient(HttpClientHandler);
                using (var request = new HttpRequestMessage(httpMethod, url))
                {
                    setHeaders.Invoke(request);
                    var response = await httpClient.SendAsync(request);
                    responceBody = WriteResponse<T>(response);
                    Logger.Info($"HTTP request - URL: {url}, Method: {httpMethod.Method}\r\n ResponseBody: {response.Content.ReadAsStringAsync().Result}");
                }
                return responceBody;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, $"HTTP request - URL: {url}, Method: {httpMethod.Method}");
                return default(T);
            }
        }

        protected async Task<T> SendRequestAsync<T>(HttpMethod httpMethod, string url)
        {
            T responceBody = await SendRequestAsync<T>(httpMethod, url, SetHeaders);
            return responceBody;
        }

        protected async Task<T> SendRequestAsync<T, K>(HttpMethod httpMethod, string url, K jsonBodyContent)
        {
            T responceBody = await SendRequestAsync<T, K>(httpMethod, url, jsonBodyContent, SetHeaders, SetJsonRequestContent);
            return responceBody;
        }

        protected async Task<T> SendRequestAsync<T, K>(HttpMethod httpMethod, string url, K jsonBodyContent, SetHeaders setHeaders)
        {
            T responceBody = await SendRequestAsync<T, K>(httpMethod, url, jsonBodyContent, setHeaders, SetJsonRequestContent);
            return responceBody;
        }

        protected async Task<T> SendRequestAsync<T>(HttpMethod httpMethod, string url, IBodyStringConverter bodyContent)
        {
            T responceBody = await SendRequestAsync<T, IBodyStringConverter>(httpMethod, url, bodyContent, SetHeaders, SetObjectRequestContent);
            return responceBody;
        }

        protected async Task<T> SendRequestAsync<T>(HttpMethod httpMethod, string url, IBodyStringConverter bodyContent, SetHeaders setHeaders)
        {
            T responceBody = await SendRequestAsync<T, IBodyStringConverter>(httpMethod, url, bodyContent, setHeaders, SetObjectRequestContent);
            return responceBody;
        }

        private async Task<T> SendRequestAsync<T, K>(HttpMethod httpMethod, string url, K bodyContent, SetHeaders setHeaders, SetBody<K> setBody)
        {
            try
            {
                T responceBody;
                HttpClient httpClient = new HttpClient(HttpClientHandler);
                using (var request = new HttpRequestMessage(httpMethod, url))
                {
                    setHeaders.Invoke(request);
                    setBody.Invoke(bodyContent, request);
                    string requestBody = request.Content.ReadAsStringAsync().Result;
                    var response = await httpClient.SendAsync(request);
                    responceBody = WriteResponse<T>(response);
                    Logger.Info($"HTTP request - URL: {url}, Method: {httpMethod.Method}\r\nRequestBody: {requestBody}\r\nResponseBody: {response.Content.ReadAsStringAsync().Result}");
                }
                return responceBody;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, $"HTTP request - URL: {url}, Method: {httpMethod.Method}");
                return default(T);
            }
        }

        protected virtual void SetHeaders(HttpRequestMessage requestMessage)
        {
            requestMessage.Headers.TryAddWithoutValidation("User-Agent", Profile.UserAgent);
        }

        private T WriteResponse<T>(HttpResponseMessage responseMessage)
        {
            string bodyResponse = responseMessage.Content.ReadAsStringAsync().Result;
            T responceBody = JToken.Parse(bodyResponse).ToObject<T>();
            return responceBody;
        }

        private void SetObjectRequestContent<T>(T bodyContent, HttpRequestMessage requestMessage)
        {
            if(bodyContent is IBodyStringConverter stringConverter)
            {
                requestMessage.Content = stringConverter.ConvertToStringContent();
                requestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded; charset=UTF-8");
            }
        }

        private void SetJsonRequestContent<T>(T jsonBodyContent, HttpRequestMessage requestMessage)
        {
            string bodyContent = JsonConvert.SerializeObject(jsonBodyContent);
            requestMessage.Content = new StringContent(bodyContent);
            requestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
        }

        private void SetCookies()
        {
            HttpClientHandler.UseCookies = true;
            ZennoCookieContainer cookieContainer = new ZennoCookieContainer(Profile.CookieContainer);
            HttpClientHandler.CookieContainer = cookieContainer;
        }

        private void SetProxy(ProxyModel proxyModel)
        {
            HttpClientHandler.UseProxy = true;
            WebProxy webProxy = new WebProxy(proxyModel.Ip, proxyModel.PortData.PortNum);
            ICredentials credentialsProxy = new NetworkCredential(proxyModel.User, proxyModel.Password);
            webProxy.Credentials = credentialsProxy;
            HttpClientHandler.Proxy = webProxy;
        }
    }
}
