using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class UserServiceTemp
    {
        private static UserServiceTemp? instance;

        public static UserServiceTemp Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserServiceTemp();
                }
                return instance;
            }
        }

        private List<UserTemp> _users;


        public UserServiceTemp()
        {
            _users = new List<UserTemp>
            {
                new UserTemp("1", "1"),
                new UserTemp("2", "2"),
                new UserTemp("3", "3")
            };
        }

        public bool RegisterUser(string username, string password)
        {
            if (ContainsUserWithUsername(username))
            {
                throw new AuthenticationException("Username already in use");
            }
            UserTemp newUser = new UserTemp(username, password);
            _users.Add(newUser);
            return true;
        }

        public List<UserTemp> GetUsers()
        {
            return _users;
        }

        public UserTemp GetUserByUsername(string usernameToFind)
        {
            UserTemp user = _users.SingleOrDefault(u => u.Username == usernameToFind) ?? throw new Exception($"User with username '{usernameToFind}' not found.");
            return user;
        }

        public bool ContainsUserWithUsername(string username)
        {
            return _users.Any(u => u.Username == username);
        }

        public bool ContainsUserWithId(Guid userId)
        {
            return _users.Any(u => u.UserId == userId);
        }

        public bool AuthenticateLogin(string username, string password)
        {
            UserTemp authUser = _users.SingleOrDefault(u => u.Username == username && u.Password == password) ?? throw new Exception("Failed to authenticate user.");
            return true;
        }
    }
}
