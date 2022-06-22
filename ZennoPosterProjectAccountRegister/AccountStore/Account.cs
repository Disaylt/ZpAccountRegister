using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterProjectAccountRegister.AccountStore
{
    internal abstract class Account
    {
        public abstract string FirstName { get; }
        public abstract string LastName { get; }
        public abstract string MiddleName { get; }
        public abstract DateTime BirthDate { get; }
        public abstract string Gender { get; }
    }
}
