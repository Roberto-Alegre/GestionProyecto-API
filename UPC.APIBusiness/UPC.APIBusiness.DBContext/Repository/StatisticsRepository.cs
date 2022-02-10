using System;
using System.Collections.Generic;
using System.Text;
//Agregar estas 4 referencias
using System.Data;
using System.Linq;
using DBEntity;
using Dapper;

namespace DBContext
{
    public class StatisticsRespoitory : BaseRepository, IStatisticsRepository
    {
        public EntityBaseResponse GetListStatistics()
        {
            var response = new EntityBaseResponse();

            try
            {
                using(var db = GetSqlConnection())
                {
                    var oStatistics = new List<EntityStatistics>();

                    const string sql = "usp_Obtener_Lista_Statistics";

                    oStatistics = db.Query<EntityStatistics>(
                        sql: sql,
                        commandType: CommandType.StoredProcedure
                        ).ToList();

                    if(oStatistics.Count>0)
                    {
                        response.isuccess = true;
                        response.errorcode = "0000";
                        response.errormessage = string.Empty;
                        response.data = oStatistics;
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
            catch (Exception ex)
            {
                response.isuccess = false;
                response.errorcode = "0001";
                response.errormessage = ex.Message;
                response.data = null;
            }

            return response;

        }

        public EntityBaseResponse InsertStatistics()
        {
            throw new NotImplementedException();
        }
    }
}
