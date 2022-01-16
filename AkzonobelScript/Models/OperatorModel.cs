using Concrete;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AkzonobelScript.Models
{
    public class OperatorModel
    {
        public IEnumerable<QuestionBase> question { get; set; }
    }
}