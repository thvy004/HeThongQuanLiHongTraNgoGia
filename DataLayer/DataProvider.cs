using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DataProvider
    {
        private SqlConnection cn;
        SqlCommand cmd;
        private string connectionString = V;

        public static string V { get; private set; }

        public DataProvider()
        {
            string cnStr = @"Data Source=.;Initial Catalog=HongTraNgoGia;Integrated Security=True";
            cn = new SqlConnection(cnStr);
        }

        public void Connect()
        {
            try
            {
                if (cn != null && cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void DisConnect()
        {
            try
            {
                if (cn != null && cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        // cmd.ExecuteScalar
        public object MyExecuteScalar(string sql, CommandType type)
        {
            try
            {
                Connect();
                cmd = new SqlCommand(sql, cn);
                cmd.CommandType = type;
                cmd.CommandTimeout = 60;

                return (cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }

        public SqlDataReader MyExecuteReader(string sql, CommandType type)
        {
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.CommandType = type;
            try
            {
                return (cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public int MyExecuteNonQuery(string sql, CommandType type)
        {
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.CommandType = type;
            try
            {
                return (cmd.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        // Phương thức thực thi câu lệnh SQL không trả về giá trị (INSERT, UPDATE, DELETE)
        public int MyExecuteNonQuery(string sql, CommandType type, SqlParameter[] parameters)
        {
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.CommandType = type;
                // Thêm tham số vào câu lệnh SQL
                cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteNonQuery();  // Trả về số bản ghi bị ảnh hưởng
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }
        public DataTable MyExecuteQuery(string sql, CommandType type, SqlParameter[] parameters = null)
        {
            try
            {
                Connect();
                using (var cmd = new SqlCommand(sql, cn) { CommandType = type })
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        var dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }
    }
}
