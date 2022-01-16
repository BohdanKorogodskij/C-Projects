using Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Dapper;
using AkzonobelScript.Infrastructure.Entity;

namespace Concrete
{
    public class Session : ISession
    {
        private string _connection;
        public Session(string connection)
        {
            _connection = connection;
        }
        public void UpdateSession(AkzonobelDetail detail)
        {
            var query = $@"DECLARE @connid_ VARCHAR(64); 
                   BEGIN 
                       SELECT 
                        @CONNID_ = COUNT(CONNID) 
                        FROM PROJECTS.AKZONOBEL_SESSION WHERE CONNID = '{detail.connid}';    
                       IF (@connid_ > 0) 
                            BEGIN
                              UPDATE PROJECTS.AKZONOBEL_SESSION    
                              SET AN_CALLHISTORY = '{detail.an_callhistory}', AN_TIME_WORK = '{detail.an_time_work}', AN_TEMP_UNDER = '{detail.an_temp_under}', AN_TEMP_COUNT = '{detail.an_temp_count}', AN_TEMP_ARRAYQUESTION = '{detail.an_temp_arrayQuestion}', AN_TEMP_ANSWERSPATH = '{detail.an_temp_AnswersPath}', AN_TEMP_LEVEL_TXT = '{detail.an_temp_level_txt}'
                              where connid = '{detail.connid}';  
                            END
                       ELSE 
                            BEGIN
                             INSERT INTO PROJECTS.AKZONOBEL_SESSION (connid, user_login,  ani, dnis, attempt, unicid, callresult, callsubject, 
                             an_callhistory, an_time_work, an_temp_under, an_temp_count, an_temp_arrayQuestion, an_temp_AnswersPath, an_temp_level_txt ) 
                             VALUES ( '{detail.connid}', '{detail.user_login}', '{detail.ani}', '{detail.dnis}', '{detail.attempt}', '{detail.unicid}', '{detail.callresult}', '{detail.callsubject}',  
                             '{detail.an_callhistory}', '{detail.an_time_work}', '{detail.an_temp_under}', '{detail.an_temp_count}', '{detail.an_temp_arrayQuestion}', '{detail.an_temp_AnswersPath}', '{detail.an_temp_level_txt}'); 
                            END
                       END";

            using (var conn = new SqlConnection(_connection))
            {
                int rowsAffected = conn.Execute(query);
            }
        }
    }
}
