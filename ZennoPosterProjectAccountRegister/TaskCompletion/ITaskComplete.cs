using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterProjectAccountRegister.TaskCompletion
{
    internal interface ITaskComplete
    {
        void GoodEnd();
        void BadEnd();
    }
}
