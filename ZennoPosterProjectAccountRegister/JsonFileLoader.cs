using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ZennoPosterProjectAccountRegister
{
    internal static class JsonFileLoader
    {
        internal static T LoadJson<T>(string filePath)
        {
            try
            {
                string content = File.ReadAllText(filePath);
                T jsonObject = JToken.Parse(content).ToObject<T>();
                return jsonObject;
            }
            catch
            {
                return default;
            }
        }
    }
}
