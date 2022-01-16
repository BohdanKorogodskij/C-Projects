using Entity;
using Interface;
using System;
using System.Collections.Generic;
using System.Text;


namespace Concrete
{
    public class Reception : IReception
    {
        public IEnumerable<ReceptionBase> ProfKnowledgeByRequest(int requestId)
        {
            var list = new List<ReceptionBase>();
            using (var conn = new SqlConnection(_connectionString))
            {
                string query = string.Format("Select * from v_KnowledgeByRequest where RequestId={0}", requestId);
                conn.Open();
                using (var cmd = new SqlCommand(String.Empty, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.CommandTimeout = int.MaxValue;
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ProfKnowledge x = new ProfKnowledge
                            {
                                Id = ReaderFieldToInt(dr["Id"]),
                                Name = ReaderFieldToString(dr["Name"]),
                                AgentDate = ReaderFieldToDate(dr["AgentDate"]),
                                IsPrimary = ReaderFieldToBool(dr["IsPrimary"]),
                                IsActive = true,
                                Project = new Project
                                {
                                    Id = ReaderFieldToInt(dr["ProjectId"]),
                                    Name = ReaderFieldToString(dr["ProjectName"])
                                }

                            };
                            list.Add(x);
                        }

                    }
                }
            }
            return list.Where(w => w.Id != 0);
        }
    }
}
