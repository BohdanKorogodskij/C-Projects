using Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Dapper;

namespace Concrete
{
    public class QuestionOperator : IQuestionOperator
    {
        private string _connection;
        public QuestionOperator(string connection)
        {
            _connection = connection;
        }

        public void AddQuestionOperator(string connid_, string slogin_, string sbody_)
        {
            using (var conn = new SqlConnection(_connection))
            {
                int rowsAffected = conn.Execute($@" INSERT INTO PROJECTS.AKZONOBEL_QUESTIONOPERATOR (CONNID, SLOGIN, SBODY) 
                 VALUES ('{connid_}', '{slogin_}', '{sbody_}') ");
            }
        }
    }
}
