using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LxDashboard.BE.Data.Entities
{
    public class User
    {
        private string _password;

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password
        {
            get { return _password; }
            set
            {
                var provider = MD5CryptoServiceProvider.Create();
                _password = Convert.ToString(provider.ComputeHash(System.Text.UTF8Encoding.UTF8.GetBytes(value)));
            }
        }

    }
}
