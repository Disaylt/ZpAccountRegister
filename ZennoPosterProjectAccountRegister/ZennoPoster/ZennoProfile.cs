using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoLab.InterfacesLibrary.ProjectModel.Collections;

namespace ZennoPosterProjectAccountRegister.ZennoPoster
{
    internal class ZennoProfile
    {
        private readonly IProfile _profile;
        private readonly string _name;
        public ZennoProfile(string profileName)
        {
            _profile = Program.ZennoPosterProject.Profile;
            _name = profileName;
        }

        public void SaveProfile(string pathFolder)
        {
            string path = $@"{pathFolder}\{_name}.zpprofile";
            _profile.Save(path,
                false,
                true,
                true,
                true,
                true,
                true,
                true,
                true,
                true);
        }
    }
}
