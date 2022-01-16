using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
    public interface ISendMessage
    {
        void AddMessage(string CONNID_, string SEMAIL_, string STEMA_, string SFIO_, string SCOMPANY_, string SNUMBER_, string SBODY_, string slogin_, string personalData_);
    }
}
