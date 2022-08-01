using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterProjectAccountRegister.AccountStore.WB;
using ZennoPosterProjectAccountRegister.WB;
using Global;

namespace ZennoPosterProjectAccountRegister.AccountStore
{
    internal class AccountBuilder : Account
    {
        protected Configuration Config { get; }
        public override string FirstName { get; }

        public override string LastName { get; }

        public override string MiddleName { get; }

        public override DateTime BirthDate { get; }

        public override string Gender { get; }

        public override string Email { get; }

        internal AccountBuilder(GenderOptions genderOptions)
        {
            Config = Configuration.Instance;
            Gender = GetGender();
            BirthDate = GetBirthDate();
            var personalInfo = genderOptions.GetGenderPersonalInfo(Gender);
            FirstName = ChoosePersonalInfo(personalInfo.FirstNames);
            LastName = ChoosePersonalInfo(personalInfo.LastNames);
            MiddleName = ChoosePersonalInfo(personalInfo.MiddleNames);
            Email = string.Empty;
            Logger.Info($"Create account - Gender: {Gender}, Birth: {BirthDate}, FirstName: {FirstName}, LastName: {LastName}, MiddleName: {MiddleName}");
        }

        internal AccountBuilder(GenderOptions genderOptions, IEmailCreator emailCreator) : this(genderOptions)
        {
            Email = emailCreator.CreateEmail();
            Logger.Info($"Create email - {Email}");
        }

        public virtual string ChoosePersonalInfo(string[] names)
        {
            if(names != null && names.Length > 0)
            {
                int sumFirstNames = names.Length;
                int indexFirstName = Classes.rnd.Next(sumFirstNames);
                return names[indexFirstName];
            }
            else
            {
                return string.Empty;
            }
        }

        public virtual DateTime GetBirthDate()
        {
            int rangeDay = (Config.Settings.MaxRegisterBirthDate - Config.Settings.MinRegisterBirthDate).Days;
            return Config.Settings.MinRegisterBirthDate.AddDays(Classes.rnd.Next(rangeDay));
        }

        public virtual string GetGender()
        {
            switch (Config.Settings.GenderRegister)
            {
                case "male":
                    return "male";
                case "female":
                    return "female";
                default:
                    string randomGender = ChooseRandomGender();
                    return randomGender;
            }
        }

        private string ChooseRandomGender()
        {
            int randomNum = Classes.rnd.Next(2);
            if (randomNum == 0)
            {
                return "male";
            }
            else
            {
                return "female";
            }
        }
    }
}
