using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelData.Core.Data.Ado.Net
{
    public class BaseConnectionHelper
    {
        public string ConnectionString { get; set; }
        public bool SetData(string cmdText, CommandType cmdType = CommandType.Text, List<SqlParameter> parameters = null)
        {
            bool result = false;
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(cmdText, con))
                    {
                        cmd.CommandType = cmdType;
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters.ToArray());
                        }
                        con.Open();
                        result = cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public SqlDataReader GetData(string cmdText, CommandType cmdType = CommandType.Text, params SqlParameter[] parameters)
        {
            SqlDataReader reader = null;
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand(cmdText, con);
                cmd.CommandType = cmdType;
                cmd.Parameters.AddRange(parameters);
                con.Open();
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return reader;

        }
    }
}
