using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterProjectAccountRegister.OnlineSim
{
    public enum MessageTypes
    {
        PhoneNumber,
        Text,
        Unknown
    }

    public class MessageDefiner
    {
        public string MessageText { get; }

        public MessageDefiner(string message)
        {
            MessageText = message;
        }

        public virtual MessageTypes DefineType()
        {
            if (IsPhoneNumber()) return MessageTypes.PhoneNumber;
            else return MessageTypes.Text;
        }

        private bool IsPhoneNumber()
        {
            if(int.TryParse(MessageText, out int result))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
