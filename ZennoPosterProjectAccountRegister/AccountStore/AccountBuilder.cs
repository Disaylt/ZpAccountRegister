using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterProjectAccountRegister.AccountStore
{
    internal class AccountBuilder : Account
    {
        protected readonly Random Random;

        public override string FirstName { get; }

        public override string LastName { get; }

        public override string MiddleName { get; }

        public override DateTime BirthDate { get; }

        public override string Gender { get; }

        internal AccountBuilder(GenderOptions genderOptions)
        {
            Random = new Random();
            Gender = GetGender();
            BirthDate = GetBirthDate();
            var personalInfo = genderOptions.GetGenderPersonalInfo(Gender);
            FirstName = ChoosePersonalInfo(personalInfo.FirstNames);
            LastName = ChoosePersonalInfo(personalInfo.LastNames);
            MiddleName = ChoosePersonalInfo(personalInfo.MiddleNames);
        }

        public virtual string ChoosePersonalInfo(string[] names)
        {
            if(names != null && names.Length > 0)
            {
                int sumFirstNames = names.Length;
                int indexFirstName = Random.Next(sumFirstNames);
                return names[indexFirstName];
            }
            else
            {
                return string.Empty;
            }
        }

        public virtual DateTime GetBirthDate()
        {
            int rangeDay = (Project.Settings.MaxRegisterBirthDate - Project.Settings.MinRegisterBirthDate).Days;
            return Project.Settings.MinRegisterBirthDate.AddDays(Random.Next(rangeDay));
        }

        public virtual string GetGender()
        {
            switch (Project.Settings.GenderRegister)
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
            int randomNum = Random.Next(2);
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
