using AkzonobelScript.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkzonobelScript.Infrastructure.Abstract
{
    public interface IOperator
    {
        OperatorData GetOperatorLogin(string peripheralNumber);
    }
}
