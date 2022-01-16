using Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Dapper;

namespace Concrete
{
    public class SendMessage : ISendMessage
    {
        private string _connection;
        public SendMessage(string connection)
        {
            _connection = connection;
        }
        public void AddMessage(string CONNID_, string SEMAIL_, string STEMA_, string SFIO_, string SCOMPANY_, string SNUMBER_, string SBODY_, string slogin_, string personalData_)
        {
            using (var conn = new SqlConnection(_connection))
            {
                int rowsAffected = conn.Execute($@"insert into projects.AKZONOBEL_SENDMESSAGE (CONNID, SEMAIL, STEMA, SFIO, SCOMPANY, SNUMBER, SBODY, slogin, PERSONAL_DATA) 
                 values ('{CONNID_}', '{SEMAIL_}', '{STEMA_}', '{SFIO_}', '{SCOMPANY_}', '{SNUMBER_}', '{SBODY_}', '{slogin_}', '{personalData_}') ");
            }
        }
    }
}
