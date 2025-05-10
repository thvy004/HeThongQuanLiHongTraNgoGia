using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace BusinessLayer
{
    public class LoginBL
    {
        private LoginDL loginDL;
        public LoginBL()
        {
            loginDL = new LoginDL();
        }
        //LOGIN
        public bool Login(Account account)
        {

            return loginDL.Login(account);
        }
        //ADD
        public bool Register(Account account)
        {

            return loginDL.Register(account); // Gọi phương thức AddUser trong Data Layer

        }
        //SEARCH
        public DataTable DisplayUsers()
        {
            return loginDL.DisplayUsers();
        }

        public DataTable SearchUsers(string keyword)
        {
            return loginDL.SearchUsers(keyword);
        }
        //UPDATE
        public bool UpdateUser(Account account)
        {
            return loginDL.UpdateUser(account);
        }
        //DELETE
        public bool DeleteUser(Account account)
        {
            return loginDL.DeleteUser(account);
        }
    
    }
}
