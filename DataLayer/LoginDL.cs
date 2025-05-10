using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class LoginDL : DataProvider
    {
        private const string TxtTaiKhoanParameter = "@txtTaiKhoan";
        
        //private readonly string connectionString = "YourConnectionStringHere"; // Add this field to define the connection string  
        //private SqlConnection connection;   
        public bool Login(Account account)
        {
            string sql = "SELECT COUNT(txtTaiKhoan) FROM TaiKhoan WHERE txtTaiKhoan = '" + account.Username + "' AND txtMatKhau = '" + account.Password + "'";
            try
            {
                return (int)MyExecuteScalar(sql, CommandType.Text) > 0;
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public bool Register(Account account)
        {
            string sql = "INSERT INTO TaiKhoan(txtTaiKhoan,txtMatKhau) VALUES (@txtTaiKhoan, @txtMatKhau)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                   new SqlParameter("@txtTaiKhoan", account.Username),
                   new SqlParameter("@txtMatKhau", account.Password),
            };

            try
            {
                int result = MyExecuteNonQuery(sql, CommandType.Text, parameters);
                return result > 0;
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public DataTable DisplayUsers()
        {
            string sql = "SELECT * FROM TaiKhoan";
            try
            {
                return MyExecuteQuery(sql, CommandType.Text);
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public DataTable SearchUsers(string keyword)
        {
            string sql = "SELECT * FROM TaiKhoan WHERE txtTaiKhoan LIKE @keyword ";
            SqlParameter[] parameters = new SqlParameter[]
            {
                   new SqlParameter("@keyword", "%" + keyword + "%")
            };

            try
            {
                return MyExecuteQuery(sql, CommandType.Text, parameters);
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public bool UpdateUser(Account account)
        {
            string sql = "UPDATE  TaiKhoan SET txtTaiKhoan=@txtTaiKhoan, txtMatKhau=@txtMatKhau WHERE txtTaiKhoan=@txtTaiKhoan";
            SqlParameter[] parameters = new SqlParameter[]
            {
                   new SqlParameter("@txtTaiKhoan", account.Username),
                   new SqlParameter("@txtMatKhau", account.Password),
            };
            try
            {
                int result = MyExecuteNonQuery(sql, CommandType.Text, parameters);
                return result > 0;
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public bool DeleteUser(Account account)
        {
            string sql = "Delete FROM TaiKhoan WHERE txtTaiKhoan=@txtTaiKhoan";
            SqlParameter[] parameters = new SqlParameter[]
            {
                    new SqlParameter(TxtTaiKhoanParameter, account.Username),
            };

            try
            {
                int result = MyExecuteNonQuery(sql, CommandType.Text, parameters);
                return result > 0;
            }
            catch (SqlException)
            {
                throw;
            }
        }

       
    }
}
