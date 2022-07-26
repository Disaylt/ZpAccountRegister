using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoLab.InterfacesLibrary.ProjectModel.Collections;

namespace ZennoPosterProjectAccountRegister.AccountStore
{
    internal class YandexEmailCreator : IEmailCreator
    {
        private readonly IProfile _profile;
        public YandexEmailCreator(IProfile profile)
        {
            _profile = profile;
        }

        public string CreateEmail()
        {
            string email = $"{_profile.NickName}@yandex.ru";
            return email;
        }
    }
}
