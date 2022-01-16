using AkzonobelScript.Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
    public interface ISession
    {
        //void UpdateSession(string id_, string user_login_, string ani_, string dnis_, int attempt_, string unicid_, string callresult_, string callsubject_, string an_callhistory_, int an_time_work_, string an_temp_under_, int an_temp_count_, string an_temp_arrayQuestion_, string an_temp_AnswersPath_, string an_temp_level_txt_);
        void UpdateSession(AkzonobelDetail detail);
    }
}
