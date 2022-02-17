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
    public class ActivityRepository : BaseRepository, IActivityRepository
    {
        public EntityBaseResponse GetActivity(int id)
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {

                    var activity = new EntityActivity();

                    const string sql = "usp_Obtener_Actividad";

                    var p = new DynamicParameters();

                    p.Add(name: "@id_actividad", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    activity = db.Query<EntityActivity>(
                            sql: sql,
                            param: p,
                            commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();

                    if (activity != null)
                    {

                        response.isuccess = true;
                        response.errorcode = "0000";
                        response.errormessage = string.Empty;
                        response.data = activity;
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

        public EntityBaseResponse GetListActivity()
        {
            var response = new EntityBaseResponse();

            try
            {

                using (var db = GetSqlConnection())
                {
                    var activity = new List<EntityActivity>();

                    const string sql = "usp_Obtener_Lista_Actividad";

                    activity = db.Query<EntityActivity>(
                            sql: sql,
                            commandType: CommandType.StoredProcedure
                        ).ToList();

                    if (activity.Count > 0)
                    {
                        response.isuccess = true;
                        response.errorcode = "0000";
                        response.errormessage = string.Empty;
                        response.data = activity;
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

        public EntityBaseResponse InsertActivity(EntityActivity activity)
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_Insertar_Actividad";

                    var p = new DynamicParameters();

                    p.Add(name: "@id_actividad", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    p.Add(name: "@actividad", value: activity.actividad, dbType: DbType.String, direction: ParameterDirection.Input);

                    db.Query<EntityActivity>(
                            sql: sql,
                            param: p,
                            commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();

                    var idactividad = p.Get<int>("@id_actividad");

                    if (idactividad > 0)
                    {
                        response.isuccess = true;
                        response.errorcode = "0000";
                        response.errormessage = string.Empty;
                        response.data = new
                        {
                            id = idactividad,
                            nombre = activity.actividad
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

        public EntityBaseResponse UpdateActivity(EntityActivity activity)
        {
            var response = new EntityBaseResponse();

            try
            {

                using (var db = GetSqlConnection())
                {

                    const string sql = "usp_Actualizar_Actividad";

                    var p = new DynamicParameters();

                    p.Add(name: "@id_actividad", value: activity.id_actividad, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@actividad", value: activity.actividad, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@auditoria_usuario_modificacion", value: activity.auditoria_usuario_modificacion, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@filas_afectadas", dbType: DbType.Int32, direction: ParameterDirection.Output);

                    db.Query<EntityActivity>(
                            sql: sql,
                            param: p,
                            commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();

                    var filas_afectadas = p.Get<int>("@filas_afectadas");

                    if (filas_afectadas > 0)
                    {
                        response.isuccess = true;
                        response.errorcode = "0000";
                        response.errormessage = string.Empty;
                        response.data = new
                        {
                            id = activity.id_actividad,
                            nombre = activity.actividad
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
