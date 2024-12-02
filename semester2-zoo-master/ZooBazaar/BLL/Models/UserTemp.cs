using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class UserTemp
    {
        private Guid userId;
        private string username;
        private string password;
        /*private string passwordHash;
        private string salt;*/

        public UserTemp(string username, string password)
        {
            this.userId = Guid.NewGuid();
            this.username = username;
            this.password = password;
            /*this.passwordHash = passwordHash;
            this.salt = new Random().Next().ToString();
            this.PasswordHash = PasswordHash*/
        }

        public Guid UserId { get { return userId; } }
        public string Username { get { return username; } }
        public string Password { get { return password; } }
    }
}
