using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ZennoPosterProjectAccountRegister.OnlineSim
{
    class OnlineSimMessageChecker
    {
        private readonly int _maxIterationsNum;
        public readonly int MaxTimeOut;
        internal OnlineSimMessageChecker(int maxTimeOut)
        {
            MaxTimeOut = maxTimeOut;
            _maxIterationsNum = maxTimeOut / 10;
        }

        public async Task<string> GetMessageAsync(IPhoneNumberActions phoneNumberActions)
        {
            for(int iteration = 0; iteration < _maxIterationsNum; iteration++)
            {
                Thread.Sleep(10 * 1000);
                var result = await phoneNumberActions.GetPhoneDataAsync();
                string message = result.Message;
                if(message != null)
                {
                    return message;
                }
            }
            return string.Empty;
        }
    }
}
