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
    public class StakeholderRepository : BaseRepository, IStakeholderRepository
    {
        public EntityBaseResponse GetListStakeholder(int id_proyecto)
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {

                    var stakeholder = new List<EntityStakeholder>();

                    const string sql = "usp_Listar_Interesados";

                    var p = new DynamicParameters();
                    p.Add(name: "@id_proyecto", value: id_proyecto, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    stakeholder = db.Query<EntityStakeholder>(
                            sql: sql,
                            param: p,
                            commandType: CommandType.StoredProcedure
                        ).ToList();

                    if (stakeholder.Count > 0)
                    {

                        response.isuccess = true;
                        response.errorcode = "0000";
                        response.errormessage = string.Empty;
                        response.data = stakeholder;
                    }
                    else
                    {
                        response.isuccess = false;
                        response.errorcode = "0000";
                        response.errormessage = string.Empty;
                        response.data = null;

                    }
                }
            }
            catch (Exception ex)
            {
                response.isuccess = true;
                response.errorcode = "0000";
                response.errormessage = ex.Message;
                response.data = null;
            }

            return response;

        }

        public EntityBaseResponse GetListUsuarios()
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {

                    var stakeholder = new List<EntityStakeholder>();

                    const string sql = "usp_Listar_Usuarios";

                    stakeholder = db.Query<EntityStakeholder>(
                            sql: sql,
                            commandType: CommandType.StoredProcedure
                        ).ToList();

                    if (stakeholder.Count > 0)
                    {

                        response.isuccess = true;
                        response.errorcode = "0000";
                        response.errormessage = string.Empty;
                        response.data = stakeholder;
                    }
                    else
                    {
                        response.isuccess = false;
                        response.errorcode = "0000";
                        response.errormessage = string.Empty;
                        response.data = null;

                    }
                }
            }
            catch (Exception ex)
            {
                response.isuccess = true;
                response.errorcode = "0000";
                response.errormessage = ex.Message;
                response.data = null;
            }

            return response;
        }

        public EntityBaseResponse InsertStakeholder(EntityStakeholder stakeholder)
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_Insertar_Interesados";

                    var p = new DynamicParameters();

                    p.Add(name: "@id_interesados_proyecto", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    p.Add(name: "@id_proyecto", value: stakeholder.id_proyecto, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@id_usuario", value: stakeholder.id_usuario, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@tipo", value: stakeholder.tipo, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@auditoria_usuario_ingreso", value: stakeholder.auditoria_usuario_ingreso, dbType: DbType.String, direction: ParameterDirection.Input);

                    db.Query<EntityCostProject>(
                            sql: sql,
                            param: p,
                            commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();

                    var idinteresadosproyecto = p.Get<int>("@id_interesados_proyecto");

                    if (idinteresadosproyecto > 0)
                    {
                        response.isuccess = true;
                        response.errorcode = "0000";
                        response.errormessage = string.Empty;
                        response.data = new
                        {
                            id = idinteresadosproyecto
                        };
                    }
                    else
                    {
                        response.isuccess = false;
                        response.errorcode = "0000";
                        response.errormessage = string.Empty;
                        response.data = null;
                    }

                }
            }
            catch (Exception ex)
            {
                response.isuccess = false;
                response.errorcode = "0000";
                response.errormessage = ex.Message;
                response.data = null;
            }

            return response;

        }
    }
}
