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
                    
                    const string sql = "usp_ObtenerProyecto";

                    var p = new DynamicParameters();
                    p.Add( name:"@IDPROYECTO", value:id, dbType:DbType.Int32, direction:ParameterDirection.Input);

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
            throw new NotImplementedException();
        }
    }
}
