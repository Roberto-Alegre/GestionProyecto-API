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
    public class ActivityProjectRepository : BaseRepository, IActivityProjectRepository
    {
        public EntityBaseResponse GetListActivityProject(int id)
        {
            var response = new EntityBaseResponse();

            try
            {

                using (var db = GetSqlConnection())
                {
                    var activityprojects = new List<EntityActivityProject>();
                    
                    const string sql = "usp_Obtener_Lista_Actividad_Proyecto";

                    var p = new DynamicParameters();
                    p.Add(name: "@id_proyecto", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    activityprojects = db.Query<EntityActivityProject>(
                            sql: sql,
                            param:p,
                            commandType: CommandType.StoredProcedure
                        ).ToList();

                    if (activityprojects.Count > 0)
                    {
                        response.isuccess = true;
                        response.errorcode = "0000";
                        response.errormessage = string.Empty;
                        response.data = activityprojects;
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

        public EntityBaseResponse GetActivityProject(int id)
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {

                    var activityproject = new EntityActivityProject();

                    const string sql = "usp_Obtener_Actividad_Proyecto";

                    var p = new DynamicParameters();
                    p.Add(name: "@id_actividad_proyecto", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    activityproject = db.Query<EntityActivityProject>(
                            sql: sql,
                            param: p,
                            commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();

                    if (activityproject != null)
                    {
                        response.isuccess = true;
                        response.errorcode = "0000";
                        response.errormessage = string.Empty;
                        response.data = activityproject;
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

        public EntityBaseResponse InsertActivityProject(EntityActivityProject activityproject)
        {
            var response = new EntityBaseResponse();

            try
            {

                using (var db = GetSqlConnection())
                {

                    const string sql = "usp_Insertar_Actividad_Proyecto";

                    var p = new DynamicParameters();

                    p.Add(name: "@id_actividad_proyecto", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    p.Add(name: "@id_proyecto", value: activityproject.id_proyecto, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@id_actividad", value: activityproject.id_actividad, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@fecha_inicio", value: activityproject.fecha_inicio, dbType: DbType.Date, direction: ParameterDirection.Input);
                    p.Add(name: "@fecha_termino", value: activityproject.fecha_termino, dbType: DbType.Date, direction: ParameterDirection.Input);
                    p.Add(name: "@auditoria_usuario_ingreso", value: activityproject.auditoria_usuario_ingreso, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    db.Query<EntityActivityProject>(
                            sql: sql,
                            param: p,
                            commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();

                    var id_actividad_proyecto = p.Get<int>("@id_actividad_proyecto");

                    if (id_actividad_proyecto > 0)
                    {
                        response.isuccess = true;
                        response.errorcode = "0000";
                        response.errormessage = string.Empty;
                        response.data = new
                        {
                            id = id_actividad_proyecto,
                            nombre = activityproject.actividad
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

        public EntityBaseResponse UpdateActivityProject(EntityActivityProject activityproject)
        {
            var response = new EntityBaseResponse();

            try
            {

                using (var db = GetSqlConnection())
                {

                    const string sql = "usp_Actualizar_Actividad_Proyecto";

                    var p = new DynamicParameters();

                    p.Add(name: "@id_actividad_proyecto", value: activityproject.id_actividad_proyecto, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@id_proyecto", value: activityproject.id_proyecto, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@id_actividad", value: activityproject.id_actividad, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@fecha_inicio", value: activityproject.fecha_inicio, dbType: DbType.Date, direction: ParameterDirection.Input);
                    p.Add(name: "@fecha_termino", value: activityproject.fecha_termino, dbType: DbType.Date, direction: ParameterDirection.Input);
                    p.Add(name: "@auditoria_usuario_modificacion", value: activityproject.auditoria_usuario_modificacion, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@filas_afectadas", dbType: DbType.Int32, direction: ParameterDirection.Output);

                    db.Query<EntityProject>(
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
                            id = activityproject.id_actividad_proyecto,
                            nombre = activityproject.actividad
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
