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
using ZennoPosterProjectAccountRegister.AccountStore;
using ZennoPosterProjectAccountRegister.Models.Json.WB;
using Newtonsoft.Json;
using ZennoPosterProjectAccountRegister.Models.Objects.WB;

namespace ZennoPosterProjectAccountRegister.Http.WB
{
    class WbPersonalInfoHttpSender : HttpSenderClient
    {
        public WbPersonalInfoHttpSender(IZennoPosterProjectModel project, ProxyModel proxyModel) : base(project, proxyModel) { }

        public async Task SetBirthDateAsync(BirthdayRequestModel birthday)
        {
            string url = "https://www.wildberries.ru/webapi/personalinfo/birthday";
            HttpMethod httpMethod = new HttpMethod("PATCH");
            await SendRequestAsync<object>(httpMethod, url, birthday);
        }

        public async Task SetPersonalInfoAsync(PersonalInfoModel personalInfo)
        {
            string url = "https://www.wildberries.ru/webapi/personalinfo/fio";
            HttpMethod httpMethod = new HttpMethod("PATCH");
            await SendRequestAsync<object, PersonalInfoModel>(httpMethod, url, personalInfo);
        }

        public async Task<T> GetAccountDataAsync<T>() where T : class
        {
            string url = "https://www.wildberries.ru/webapi/lk/details/data";
            HttpMethod httpMethod = HttpMethod.Post;
            T response = await SendRequestAsync<T>(httpMethod, url);
            return response;
        }

        public async Task SetGender(GenderRequestModel gender)
        {
            string url = "https://www.wildberries.ru/webapi/personalinfo/sex";
            HttpMethod httpMethod = new HttpMethod("PATCH");
            await SendRequestAsync<object>(httpMethod, url, gender);
        }
 
        protected override void SetHeaders(HttpRequestMessage requestMessage)
        {
            requestMessage.Headers.TryAddWithoutValidation("User-Agent", Profile.UserAgent);
            requestMessage.Headers.TryAddWithoutValidation("Accept", "*/*");
            requestMessage.Headers.TryAddWithoutValidation("Accept-Language", "ru-RU,ru;q=0.8,en-US;q=0.5,en;q=0.3");
            requestMessage.Headers.TryAddWithoutValidation("Accept-Encoding", "UTF-8");
            requestMessage.Headers.TryAddWithoutValidation("x-requested-with", "XMLHttpRequest");
            requestMessage.Headers.TryAddWithoutValidation("x-spa-version", "9.2.32.2");
            requestMessage.Headers.TryAddWithoutValidation("Origin", "https://www.wildberries.ru");
            requestMessage.Headers.TryAddWithoutValidation("Connection", "keep-alive");
            requestMessage.Headers.TryAddWithoutValidation("Sec-Fetch-Dest", "empty");
            requestMessage.Headers.TryAddWithoutValidation("Sec-Fetch-Mode", "cors");
            requestMessage.Headers.TryAddWithoutValidation("Sec-Fetch-Site", "same-origin");
            requestMessage.Headers.TryAddWithoutValidation("Pragma", "no-cache");
            requestMessage.Headers.TryAddWithoutValidation("Cache-Control", "no-cache");
            requestMessage.Headers.TryAddWithoutValidation("TE", "trailers");
        }
    }
}
