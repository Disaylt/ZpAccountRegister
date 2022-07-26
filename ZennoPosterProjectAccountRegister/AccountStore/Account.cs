using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterProjectAccountRegister.Logger;

namespace ZennoPosterProjectAccountRegister.AccountStore
{
    internal abstract class Account
    {
        public abstract string FirstName { get; }
        public abstract string LastName { get; }
        public abstract string MiddleName { get; }
        public abstract DateTime BirthDate { get; }
        public abstract string Gender { get; }
        public abstract string Email { get; }
        protected ProjectLogger Logger { get; }

        public Account()
        {
            Logger = new ProjectLogger();
        }
    }
}
