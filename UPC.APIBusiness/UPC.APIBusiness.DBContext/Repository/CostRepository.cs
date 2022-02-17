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
    public class CostRepository : BaseRepository, ICostRepository
    {
        public EntityBaseResponse GetCost(int id)
        {

            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {

                    var cost = new EntityCost();

                    const string sql = "usp_Obtener_Costo";

                    var p = new DynamicParameters();
                    p.Add(name: "@id_costo", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    cost = db.Query<EntityCost>(
                            sql: sql,
                            param: p,
                            commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();

                    if (cost != null)
                    {

                        response.isuccess = true;
                        response.errorcode = "0000";
                        response.errormessage = string.Empty;
                        response.data = cost;
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

        public EntityBaseResponse GetListCost()
        {
            var response = new EntityBaseResponse();

            try
            {

                using (var db = GetSqlConnection())
                {
                    var cost = new List<EntityCost>();

                    const string sql = "usp_Obtener_Lista_Costo";

                    cost = db.Query<EntityCost>(
                            sql: sql,
                            commandType: CommandType.StoredProcedure
                        ).ToList();

                    if (cost.Count > 0)
                    {
                        response.isuccess = true;
                        response.errorcode = "0000";
                        response.errormessage = string.Empty;
                        response.data = cost;
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

        public EntityBaseResponse InsertCost(EntityCost cost)
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_Insertar_Costo";

                    var p = new DynamicParameters();

                    p.Add(name: "@id_costo", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    p.Add(name: "@concepto", value: cost.concepto, dbType: DbType.String, direction: ParameterDirection.Input);

                    db.Query<EntityCost>(
                            sql: sql,
                            param: p,
                            commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();

                    var idcosto = p.Get<int>("@id_cost");

                    if (idcosto > 0)
                    {
                        response.isuccess = true;
                        response.errorcode = "0000";
                        response.errormessage = string.Empty;
                        response.data = new
                        {
                            id = idcosto,
                            nombre = cost.concepto
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
            catch(Exception ex)
            {
                response.isuccess = false;
                response.errorcode = "0000";
                response.errormessage = ex.Message;
                response.data = null;
            }

            return response;

        }

        public EntityBaseResponse UpdateCost(EntityCost cost)
        {
            var response = new EntityBaseResponse();

            try
            {

                using (var db = GetSqlConnection())
                {

                    const string sql = "usp_Actualizar_Costo";

                    var p = new DynamicParameters();

                    p.Add(name: "@id_actividad", value: cost.id_costo, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@actividad", value: cost.concepto, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@auditoria_usuario_modificacion", value: cost.auditoria_usuario_modificacion, dbType: DbType.String, direction: ParameterDirection.Input);
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
                            id = cost.id_costo,
                            nombre = cost.concepto
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
