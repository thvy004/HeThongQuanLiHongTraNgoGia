using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using TransferObject;

namespace BusinessLayer
{
    public class LoginBL
    {
        private LoginDL loginDL = new LoginDL();

        public bool Login(Account acc)
        {
            return loginDL.Login(acc);
        }
    }
}
