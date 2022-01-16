using Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using System.Data.SqlClient;
using Dapper;

namespace Concrete
{
    public class Question : IQuestion
    {
        private string _connection;
        public Question(string connection)
        {
            _connection = connection;
        }
        public IEnumerable<QuestionBase> GetQuestion
        {
            get
            {
                using (var conn = new SqlConnection(_connection))
                {
                    var query = "SELECT SNAME, KODID FROM PROJECTS.AKZONOBEL_QUESTION WHERE IACTIVE = 1";
                    conn.Open();
                    return conn.Query<QuestionBase>(query);
                }
            }
        }
        public void UpdateQuestion(int kodid_, string sQuestion_, string sBottom_)
        {
            using (var conn = new SqlConnection(_connection))
            {
                int rowsAffected = conn.Execute($@"UPDATE PROJECTS.AKZONOBEL_QUESTION SET sQuestion = '{sQuestion_}', sBottom = '{sBottom_}' where kodid = '{kodid_}'");
            }
        }
    }
}
