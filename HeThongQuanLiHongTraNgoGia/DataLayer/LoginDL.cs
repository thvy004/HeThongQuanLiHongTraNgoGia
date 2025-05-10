using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TransferObject;

namespace DataLayer
{
    public class LoginDL
    {
        public bool Login(Account acc)
        {
            var conn = DataProvider.Connect();
            string query = "SELECT COUNT(*) FROM Users WHERE Username = @u AND Password = @p";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@u", acc.Username);
            cmd.Parameters.AddWithValue("@p", acc.Password);

            conn.Open();
            int count = (int)cmd.ExecuteScalar();
            conn.Close();

            return count > 0;
        }
    }
}
