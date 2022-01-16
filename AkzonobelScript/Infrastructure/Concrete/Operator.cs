using AkzonobelScript.Infrastructure.Abstract;
using AkzonobelScript.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;

namespace AkzonobelScript.Infrastructure.Concrete
{
    public class Operator : IOperator
    {
        private string _connection;
        public Operator(string connection)
        {
            _connection = connection;
        }

        public OperatorData GetOperatorLogin(string peripheralNumber)
        {
            var query = string.Empty;
            query = $@"SELECT LoginName FROM Beer.dbo.Agent
                            WHERE PeripheralNumber = '{peripheralNumber}'";

            using (var conn = new SqlConnection(_connection))
            {
                conn.Open();
                return conn.Query<OperatorData>(query).FirstOrDefault();
            }
        }
    }
}