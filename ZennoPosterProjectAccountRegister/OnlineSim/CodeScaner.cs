using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterProjectAccountRegister.OnlineSim
{
    public class CodeScaner : MessageDefiner
    {
        public CodeScaner(string message) : base(message) { }

        public virtual string GetCode()
        {
            var messageType = base.DefineType();
            string code = string.Empty;
            switch (messageType)
            {
                case MessageTypes.PhoneNumber:
                    code = GetLastFourNum();
                    return code;
                case MessageTypes.Text:
                    code = FindCode();
                    return code;
                default:
                    return code;
            }
        }

        private string GetLastFourNum()
        {
            string code = MessageText
                .Substring(MessageText.Length - 4);
            return code;
        }

        private string FindCode()
        {
            char[] nums = MessageText
                .Where(x => Char.IsDigit(x))
                .ToArray();
            string code = new string(nums);
            return code;
        }
    }
}
