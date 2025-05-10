using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Account(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }   
    }
}
