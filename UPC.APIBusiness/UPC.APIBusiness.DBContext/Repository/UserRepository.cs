using Dapper;
using DBEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DBContext
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public EntityBaseResponse Insert(EntityUser user)
        {
            var response = new EntityBaseResponse();

            return response;

        }

        public EntityBaseResponse Login(EntitiyLogin login)
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    var user = new EntityLoginResponse();

                    const string sql = "usp_Obtener_Login";

                    var p = new DynamicParameters();

                    p.Add(name: "@login", value: login.login, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@password", value: login.password, dbType: DbType.String, direction: ParameterDirection.Input);

                    user = db.Query<EntityLoginResponse>(
                        sql: sql,
                        param: p,
                        commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();

                    if (user!= null)
                    {
                        response.isuccess = true;
                        response.errorcode = "0000";
                        response.errormessage = string.Empty;
                        response.data = user;
                    }
                    else
                    {
                        response.isuccess = false;
                        response.errorcode = "0001";
                        response.errormessage = string.Empty;
                        response.data = null;
                    }

                }
            }
            catch(Exception ex)
            {
                response.isuccess = false;
                response.errorcode = "0001";
                response.errormessage = ex.Message;
                response.data = null;
            }

            return response;
        }
    }
}
