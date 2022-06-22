using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterProjectAccountRegister.OnlineSim
{
    public class OnlineSimHttpRequest
    {
        private readonly string _token;
        public OnlineSimHttpRequest(string token)
        {
            _token = token;
        }

        internal async Task<string> RequestForGetTzIdAsync(string serviceName)
        {
            HttpResponseMessage response;
            using(var client = new HttpClient())
            {
                using(var request = new HttpRequestMessage(HttpMethod.Post, $"https://onlinesim.ru/api/getNum.php?apikey={_token}&service={serviceName}"))
                {
                    SetHeaders(request);
                    response = await client.SendAsync(request);
                    return await response.Content.ReadAsStringAsync();
                }
            }
        }

        internal async Task<string> RequestForClosePhoneNumberAsync(int tzId)
        {
            HttpResponseMessage response;
            using(var client = new HttpClient())
            {
                using(var request = new HttpRequestMessage(HttpMethod.Get, $"https://onlinesim.ru/api/setOperationOk.php?apikey={_token}&tzid={tzId}"))
                {
                    SetHeaders(request);
                    response = await client.SendAsync(request);
                    return await response.Content.ReadAsStringAsync();
                }
            }
        }

        internal async Task<string> RequestForGetNumberDataAsync()
        {
            HttpResponseMessage httpResponseMessage;
            using(var client = new HttpClient())
            {
                using(var request = new HttpRequestMessage(HttpMethod.Get, $"https://onlinesim.ru/api/getState.php?apikey={_token}"))
                {
                    SetHeaders(request);
                    httpResponseMessage = await client.SendAsync(request);
                    return await httpResponseMessage.Content.ReadAsStringAsync();
                }
            }
        }

        private void SetHeaders(HttpRequestMessage requestMessage)
        {
            requestMessage.Headers.TryAddWithoutValidation("Accept-Encoding", "UTF-8");
            requestMessage.Headers.TryAddWithoutValidation("Content-Type", "application/json");
        }
    }
}
