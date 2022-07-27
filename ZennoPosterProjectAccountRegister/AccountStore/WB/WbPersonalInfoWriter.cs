using SmartProxyV2_ZennoLabVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ZennoLab.CommandCenter;
using ZennoLab.InterfacesLibrary.ProjectModel;
using ZennoPosterProjectAccountRegister.Http.WB;
using ZennoPosterProjectAccountRegister.Models.Json.WB;
using ZennoPosterProjectAccountRegister.Models.Objects.WB;

namespace ZennoPosterProjectAccountRegister.AccountStore.WB
{
    class WbPersonalInfoWriter : IPersonalInfoWriter
    {
        private readonly Account _account;
        private readonly WbPersonalInfoHttpSender _httpClient;

        public WbPersonalInfoWriter(Account account, ProxyModel proxy, IZennoPosterProjectModel project)
        {
            _account = account;
            _httpClient = new WbPersonalInfoHttpSender(project, proxy);
        }

        public void UpdatePersonalInfo()
        {
            SetGender();
            SetBirthDate();
            SetPersonalInfo();
        }

        private void SetGender()
        {
            GenderRequestModel genderRequest = new GenderRequestModel(_account.Gender);
            _httpClient.SetGender(genderRequest).Wait();
        }

        private void SetBirthDate()
        {
            BirthdayRequestModel birthdayRequest = new BirthdayRequestModel(_account.BirthDate);
            _httpClient.SetBirthDateAsync(birthdayRequest).Wait();
        }

        private void SetPersonalInfo()
        {
            PersonalInfoModel personalInfo = new PersonalInfoModel
            {
                FirstName = _account.FirstName,
                LastName = _account.LastName,
                MiddleName = _account.MiddleName
            };
            _httpClient.SetPersonalInfoAsync(personalInfo).Wait();
        }
    }
}
