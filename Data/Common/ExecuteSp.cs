using Constants;
using DTO.common;
using Microsoft.Data.SqlClient;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Data.Common
{
    public class ExecuteSp
    {
        private readonly string _connectionString;
        public ExecuteSp()
        {
            _connectionString = Variable.STRINGCONNECTION;
        }
        public SpGenericResult ExecuteStoredProcedure(string sp_name,List<SpParamGeneric> paramList = null)
        {
            var spResult = new SpGenericResult();
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(sp_name, connection))
                {

                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter param;
                    if (paramList.Count > 0)
                    {
                        paramList.ForEach(item =>
                        {
                            
                            if (item.Type == SqlDbType.VarChar)
                            {
                                param = command.Parameters.Add(item.Name, item.Type, item.Size);
                            }
                            else
                            {
                                param = command.Parameters.Add(item.Name, item.Type);
                            }
                            param.Value = item.Value;
                        });
                    }
                    param = command.Parameters.Add("@Status", SqlDbType.VarChar,200);
                    param.Direction = ParameterDirection.Output;
                    param = command.Parameters.Add("@Mensaje", SqlDbType.VarChar,200);
                    param.Direction = ParameterDirection.Output;
                    connection.Open();
                    int i = command.ExecuteNonQuery();
                    spResult.Status = Convert.ToString(command.Parameters["@Status"].Value) ?? "";
                    spResult.Message = Convert.ToString(command.Parameters["@Mensaje"].Value) ?? "";
                }
            }
            return spResult;
        }
        public DataTable ExecuteStoredProcedureList(string sp_name, List<SpParamGeneric> paramList = null)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sp_name))
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param;
                    if (paramList.Count > 0)
                    {
                        paramList.ForEach(item =>
                        {
                            if (item.Type == SqlDbType.VarChar)
                            {
                                param = cmd.Parameters.Add(item.Name, item.Type, item.Size);
                            }
                            else
                            {
                                param = cmd.Parameters.Add(item.Name, item.Type);
                            }
                            param.Value = item.Value;
                        });
                    }
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }


    }
}
