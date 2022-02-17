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
    public class ActivityTrackRepository : BaseRepository, IActivityTrackRepository
    {
        public EntityBaseResponse GetActivityTrack(int id)
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {

                    var activity = new List<EntityActivityTrack>();

                    const string sql = "usp_Obtener_Seguimiento_Actividad";

                    var p = new DynamicParameters();
                    p.Add(name: "@id_seguimiento_actividad", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    activity = db.Query<EntityActivityTrack>(
                            sql: sql,
                            param: p,
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

        public EntityBaseResponse GetListActivityTrack(int id)
        {
            var response = new EntityBaseResponse();

            try
            {

                using (var db = GetSqlConnection())
                {

                    var activity = new List<EntityActivityTrack>();

                    const string sql = "usp_Listar_Seguimiento_Actividad";

                    var p = new DynamicParameters();

                    p.Add(name: "@id_proyecto", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    activity = db.Query<EntityActivityTrack>(
                            sql: sql,
                            param: p,
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

        public EntityBaseResponse InsertActivityTrack(EntityActivityTrack activitytrack)
        {
            var response = new EntityBaseResponse();

            try
            {

                using (var db = GetSqlConnection())
                {

                    const string sql = "usp_Insertar_Seguimiento_Actividad";

                    var p = new DynamicParameters();

                    p.Add(name: "@id_seguimiento_actividad", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    p.Add(name: "@id_actividad_proyecto", value: activitytrack.id_actividad_proyecto, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@fecha_inicio_real", value: activitytrack.fecha_inicio_real, dbType: DbType.Date, direction: ParameterDirection.Input);
                    p.Add(name: "@fecha_termino_real", value: activitytrack.fecha_termino_real, dbType: DbType.Date, direction: ParameterDirection.Input);
                    p.Add(name: "@auditoria_usuario_ingreso", value: activitytrack.auditoria_usuario_ingreso, dbType: DbType.String, direction: ParameterDirection.Input);

                    db.Query<EntityActivityTrack>(
                            sql: sql,
                            param: p,
                            commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();

                    var idseguimientoactividad = p.Get<int>("@id_seguimiento_actividad");

                    if (idseguimientoactividad > 0)
                    {
                        response.isuccess = true;
                        response.errorcode = "0000";
                        response.errormessage = string.Empty;
                        response.data = new
                        {
                            id = idseguimientoactividad
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

        public EntityBaseResponse UpdateActivityTrack(EntityActivityTrack activitytrack)
        {
            var response = new EntityBaseResponse();

            try
            {

                using (var db = GetSqlConnection())
                {

                    const string sql = "usp_Actualizar_Seguimiento_Actividad";

                    var p = new DynamicParameters();

                    p.Add(name: "@id_seguimiento_actividad", value: activitytrack.id_seguimiento_actividad, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@fecha_inicio_real", value: activitytrack.fecha_inicio_real, dbType: DbType.Date, direction: ParameterDirection.Input);
                    p.Add(name: "@fecha_termino_real", value: activitytrack.fecha_termino_real, dbType: DbType.Date, direction: ParameterDirection.Input);
                    p.Add(name: "@auditoria_usuario_modificacion", value: activitytrack.auditoria_usuario_modificacion, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@filas_afectadas", dbType: DbType.Int32, direction: ParameterDirection.Output);

                    db.Query<EntityCost>(
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
                            id = activitytrack.id_seguimiento_actividad                        };
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
