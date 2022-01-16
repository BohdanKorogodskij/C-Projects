using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AkzonobelScript.Infrastructure.Entity
{
    public class Email
    {
        public bool IsCancel { get; set; }
        public string Address { get; set; }
        public string Fio { get; set; }
        public string FioTxt { get; set; }
        public string Company { get; set; }
        public string CompanyTxt { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public string Login { get; set; }
    }
}