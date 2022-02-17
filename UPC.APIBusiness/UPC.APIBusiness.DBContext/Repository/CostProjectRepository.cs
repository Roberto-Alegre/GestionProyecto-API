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
    public class CostProjectRepository : BaseRepository, ICostProjectRepository
    {
        public EntityBaseResponse GetListCostProject(int id)
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {

                    var costproject = new List<EntityCostProject>();

                    const string sql = "usp_Obtener_Lista_Costo_Proyecto";

                    var p = new DynamicParameters();
                    p.Add(name: "@id_proyecto", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    costproject = db.Query<EntityCostProject>(
                            sql: sql,
                            param: p,
                            commandType: CommandType.StoredProcedure
                        ).ToList();

                    if (costproject.Count > 0)
                    {

                        response.isuccess = true;
                        response.errorcode = "0000";
                        response.errormessage = string.Empty;
                        response.data = costproject;
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

        public EntityBaseResponse GetCostProject(int id_costo)
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {

                    var costproject = new EntityCostProject();

                    const string sql = "usp_Obtener_Costo_Proyecto";

                    var p = new DynamicParameters();
                    p.Add(name: "@id_costo_proyecto", value: id_costo, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    costproject = db.Query<EntityCostProject>(
                            sql: sql,
                            param: p,
                            commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();

                    if (costproject != null)
                    {

                        response.isuccess = true;
                        response.errorcode = "0000";
                        response.errormessage = string.Empty;
                        response.data = costproject;
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

        public EntityBaseResponse InsertCostProject(EntityCostProject costproject)
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_Insertar_Costo_Proyecto";

                    var p = new DynamicParameters();

                    p.Add(name: "@id_costo_proyecto", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    p.Add(name: "@id_proyecto", value: costproject.id_proyecto, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@id_costo", value: int.Parse(costproject.id_costo), dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@moneda", value: costproject.moneda, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@monto", value: costproject.monto, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                    p.Add(name: "@auditoria_usuario_ingreso", value: costproject.auditoria_usuario_ingreso, dbType: DbType.String, direction: ParameterDirection.Input);
                    
                    db.Query<EntityCostProject>(
                            sql: sql,
                            param: p,
                            commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();

                    var idcostproject = p.Get<int>("@id_costo_proyecto");

                    if (idcostproject > 0)
                    {
                        response.isuccess = true;
                        response.errorcode = "0000";
                        response.errormessage = string.Empty;
                        response.data = new
                        {
                            id = idcostproject,
                            id_proyecto = costproject.id_proyecto,
                            monto = costproject.monto
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

        public EntityBaseResponse UpdateCostProject(EntityCostProject costproject)
        {
            var response = new EntityBaseResponse();

            try
            {

                using (var db = GetSqlConnection())
                {

                    const string sql = "usp_Actualizar_Costo_Proyecto";

                    var p = new DynamicParameters();

                    p.Add(name: "@id_costo_proyecto", value: costproject.id_costo_proyecto, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@moneda", value: costproject.moneda, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@monto", value: costproject.monto, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                    p.Add(name: "@auditoria_usuario_modificacion", value: costproject.auditoria_usuario_modificacion, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@filas_afectadas", dbType: DbType.Int32, direction: ParameterDirection.Output);


                    db.Query<EntityCostProject>(
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
                            id = costproject.id_costo_proyecto,
                            nombre = costproject.monto
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
