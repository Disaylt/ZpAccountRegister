using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterProjectAccountRegister.Http;
using ZennoPosterProjectAccountRegister.Models.Json.OnlineSim;

namespace ZennoPosterProjectAccountRegister.OnlineSim
{
    internal class OnlineSimHttpRequest : HttpSenderClient
    {
        private readonly string _token;
        public OnlineSimHttpRequest(string token)
        {
            _token = token;
        }

        internal async Task<CountryNumbersStateModel> RequestGetRussianNumbersStateAsync()
        {
            CountryNumbersStateModel countryNumbersState = await SendRequestAsync<CountryNumbersStateModel>(HttpMethod.Get, $"https://onlinesim.ru/api/getNumbersStats.php?apikey={_token}");
            return countryNumbersState;
        }
        internal async Task<TzModel> RequestForGetTzIdAsync(string serviceName)
        {
            TzModel tzModel = await SendRequestAsync<TzModel>(HttpMethod.Post, $"https://onlinesim.ru/api/getNum.php?apikey={_token}&service={serviceName}");
            return tzModel;
        }

        internal async Task<TzModel> RequestForClosePhoneNumberAsync(int tzId)
        {
            TzModel tzModel = await SendRequestAsync<TzModel>(HttpMethod.Get, $"https://onlinesim.ru/api/setOperationOk.php?apikey={_token}&tzid={tzId}");
            return tzModel;
        }

        internal async Task<List<PhoneModel>> RequestForGetNumberDataAsync()
        {
            List<PhoneModel> phones = await SendRequestAsync<List<PhoneModel>>(HttpMethod.Get, $"https://onlinesim.ru/api/getState.php?apikey={_token}");
            return phones;
        }

        protected override void SetHeaders(HttpRequestMessage requestMessage)
        {
            requestMessage.Headers.TryAddWithoutValidation("Accept-Encoding", "UTF-8");
            requestMessage.Headers.TryAddWithoutValidation("Content-Type", "application/json");
        }
    }
}
