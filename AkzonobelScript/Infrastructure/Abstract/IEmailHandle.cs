using AkzonobelScript.Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkzonobelScript.Infrastructure.Abstract
{
    public interface IEmailHandle
    {
        void Send(Email email);
        void SendQuestion(string operatorName, string question);
    }
}
