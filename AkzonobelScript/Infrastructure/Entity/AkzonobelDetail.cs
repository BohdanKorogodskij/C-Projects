using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AkzonobelScript.Infrastructure.Entity
{
    public class AkzonobelDetail
    {
        public string user_login { get; set; }
        public string connid { get; set; }
        public int unicid { get; set; }
        public string ani { get; set; }
        public string dnis { get; set; }
        public string callsubject { get; set; }
        public string callresult { get; set; }
        public string an_callhistory { get; set; }
        public int an_time_work { get; set; }
        public string an_temp_under { get; set; }
        public int an_temp_count { get; set; }
        public string an_temp_arrayQuestion { get; set; }
        public string an_temp_AnswersPath { get; set; }
        public string an_temp_level_txt { get; set; }
        public int attempt { get; set; }

    }
}