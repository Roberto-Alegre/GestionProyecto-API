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
    public class ProjectRepository : BaseRepository, IProjectRepository
    {
        public EntityBaseResponse GetProject(int id)
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    //var img = new ImageRepository();
                    
                    var project = new EntityProject();
                    
                    const string sql = "usp_Obtener_Proyecto";

                    var p = new DynamicParameters();
                    p.Add( name: "@id_proyecto", value:id, dbType:DbType.Int32, direction:ParameterDirection.Input);

                    project = db.Query<EntityProject>(
                            sql: sql,
                            param: p,
                            commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();

                    if (project != null)
                    {
                        //project.images = img.GetImages(project.idproyecto, "P").data as List<EntityImage>;

                        response.isuccess = true;
                        response.errorcode = "0000";
                        response.errormessage = string.Empty;
                        response.data = project;
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

        public EntityBaseResponse GetListProjects()
        {

            var response = new EntityBaseResponse();

            try
            {

                using (var db = GetSqlConnection())
                {
                    var projects = new List<EntityProject>();
                    const string sql = "usp_Obtener_Lista_Proyecto";
                    projects = db.Query<EntityProject>(
                            sql: sql,
                            commandType: CommandType.StoredProcedure
                        ).ToList();

                    if (projects.Count > 0)
                    {
                        response.isuccess = true;
                        response.errorcode = "0000";
                        response.errormessage = string.Empty;
                        response.data = projects;
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

        public EntityBaseResponse InsertProject(EntityProject project)
        {
            var response = new EntityBaseResponse();

            try
            {

                using(var db = GetSqlConnection())
                {

                    const string sql = "usp_Insertar_Proyecto";

                    var p = new DynamicParameters();

                    p.Add(name: "@id_proyecto", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    p.Add(name: "@nombre_proyecto", value: project.nombre_proyecto, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@fecha_inicio", value: project.fecha_inicio, dbType: DbType.Date, direction: ParameterDirection.Input);
                    p.Add(name: "@fecha_termino", value: project.fecha_termino, dbType: DbType.Date, direction: ParameterDirection.Input);
                    p.Add(name: "@descripcion_proyecto", value: project.descripcion_proyecto, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@auditoria_usuario_ingreso", value: project.auditoria_usuario_ingreso, dbType: DbType.String, direction: ParameterDirection.Input);

                    db.Query<EntityProject>(
                            sql: sql,
                            param: p,
                            commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();

                    var idproyecto = p.Get<int>("@id_proyecto");

                    if (idproyecto > 0)
                    {
                        response.isuccess = true;
                        response.errorcode = "0000";
                        response.errormessage = string.Empty;
                        response.data = new
                        {
                            id = idproyecto,
                            nombre = project.nombre_proyecto
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

        public EntityBaseResponse UpdateProject(EntityProject project)
        {
            var response = new EntityBaseResponse();

            try
            {

                using (var db = GetSqlConnection())
                {

                    const string sql = "usp_Actualizar_Proyecto";

                    var p = new DynamicParameters();

                    p.Add(name: "@id_proyecto", value: project.id_proyecto, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@nombre_proyecto", value: project.nombre_proyecto, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@fecha_inicio", value: project.fecha_inicio, dbType: DbType.Date, direction: ParameterDirection.Input);
                    p.Add(name: "@fecha_termino", value: project.fecha_termino, dbType: DbType.Date, direction: ParameterDirection.Input);
                    p.Add(name: "@descripcion_proyecto", value: project.descripcion_proyecto, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@auditoria_usuario_modificacion", value: project.auditoria_usuario_ingreso, dbType: DbType.String, direction: ParameterDirection.Input);
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
                            id = project.id_proyecto,
                            nombre = project.nombre_proyecto
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
