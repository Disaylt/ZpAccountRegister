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
        private readonly SessionNameBuilder _sessionName;
        public YandexEmailCreator()
        {
            _sessionName = new SessionNameBuilder(true, false);
        }

        public string CreateEmail()
        {
            string email = $"{_sessionName.CreateSessionName(10)}@yandex.ru";
            return email;
        }
    }
}
