using Entity;
using Interface;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using AkzonobelScript.Infrastructure.Entity.Enum;

namespace Concrete
{
    public class Reception : IReception
    {
        private string _connection;
        public Reception(string connection)
        {
            _connection = connection;
        }

        public IEnumerable<ReceptionBase> GetReception(FieldReception? orderBy, AD? ad, string txt = "")
        {
            var query = "SELECT * FROM PROJECTS.AKZONOBEL_RECEPTION";
            if (txt != "")
            {
                query += $@" WHERE SFIO LIKE '%{txt}%' OR SOTDEL LIKE '%{txt}%' OR Akzonobel.dbo.StripHtml(SCOMMENT) LIKE '%{txt}%'";
            }
            if(orderBy.HasValue)
            {
                query += $@" ORDER BY {orderBy.ToString()}";
            }
            if(ad.HasValue)
            {
                query += $@" {ad.ToString()}";
            }
            using (var conn = new SqlConnection(_connection))
            {
                conn.Open();
                return conn.Query<ReceptionBase>(query);
            }
        }

        public void UpdateReception(int id_, string sfio_, string sotdel_, string snumber_, string sdopnumber_, string semail_, string scomment_)
        {
            var query = $@"DECLARE @iCount_ number int; 
                            BEGIN 
                            if ('{id_}' <> 0) then 
                                    update projects.akzonobel_reception    
                                    set sfio = '{sfio_}', sotdel = '{sotdel_}', snumber = '{snumber_}', sdopnumber = '{sdopnumber_}', semail = '{semail_}', scomment = '{scomment_}'
                                    where kodid = '{id_}'; 
                                else 
                                    select max(kodid) into iCount_ from projects.akzonobel_reception; 
                                    @iCount_ += 1; 
                                    insert into projects.akzonobel_reception(kodid, sfio, sotdel, snumber, sdopnumber, semail, scomment) 
                                    values(@iCount_, '{sfio_}', '{sotdel_}', '{snumber_}', '{sdopnumber_}', '{semail_}', '{scomment_}');
                            end if;
                        end;";

            using (var conn = new SqlConnection(_connection))
            {
                int rowsAffected = conn.Execute(query);
            }
        }

        public void DeleteReception(int kodid_)
        {
            var query = $@"DELETE PROJECTS.AKZONOBEL_RECEPTION WHERE KODID = '{kodid_}'";
            using (var conn = new SqlConnection(_connection))
            {
                int rowsAffected = conn.Execute(query);
            }
        }
    }
}
