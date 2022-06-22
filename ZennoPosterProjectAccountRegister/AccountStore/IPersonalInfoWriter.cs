using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterProjectAccountRegister.AccountStore
{
    internal interface IPersonalInfoWriter
    {
        void SetEmail();
        void SetPersonalInfo();
        void SetBirthDate();
        void SetGender();
    }
}
