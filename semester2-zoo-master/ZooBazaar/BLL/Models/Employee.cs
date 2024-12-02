using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{

    public class Employee
    {
        private Guid id;
        private string firstName;
        private string lastName;
        private string personalEmail;
        private string workEmail;
        private string password;
        private string address;
        private string ssn;
        private string bankAccount;
        private string photoURL;
        private DateOnly birthDate;
        private Gender gender;
        private Role role;
        private decimal hourlyRate;
        private List<Note>? notes;
        private List<Task>? tasks;

        //Constructor for new employee creation without id
        public Employee(string firstName, string lastName, string personalEmail, string workEmail, string password, 
            string address, string ssn, string bankAccount, string photoURL, DateOnly birthDate, Gender gender, Role role, decimal hourlyRate)
        {
            this.Id = Guid.NewGuid();
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PersonalEmail = personalEmail;
            this.WorkEmail = workEmail;
            this.Password = password;
            this.Address = address;
            this.Ssn = ssn;
            this.BankAccount = bankAccount;
            this.BirthDate = birthDate;
            this.Gender = gender;
            this.Role = role;
            this.HourlyRate = hourlyRate;
            this.PhotoURL = "0";
        }

        //Constructor for employee retrieval from database
        public Employee(Guid id, string firstName, string lastName, string personalEmail, string workEmail,string password, string address, string ssn, 
            string bankAccount, DateOnly birthDate, Gender gender, Role role, decimal hourlyRate, int photoURL)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PersonalEmail = personalEmail;
            this.WorkEmail = workEmail;
            this.password = password;
            this.Address = address;
            this.Ssn = ssn;
            this.BankAccount = bankAccount;
            this.BirthDate = birthDate;
            this.Gender = gender;
            this.Role = role;
            this.HourlyRate = hourlyRate;
            this.Tasks = new List<Task>();
            this.Notes = new List<Note>();

            if (photoURL == 0)
            {
                this.PhotoURL = "default-pfp";
            }
            else if(photoURL == 1)
            {
                this.PhotoURL = $"{id}-pfp";
            }
        }

        //FOR WEB Constructor for Employee info updating FOR WEB
        public Employee(Guid id, string firstName, string lastName, string personalEmail,
            string address, Gender gender)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PersonalEmail = personalEmail;
            this.Address = address;
            this.Gender = gender;
        }

        public void AddTask(Task t)
        {
            Tasks?.Add(t);
        }

        public void AddNote(Note n)
        {
            Notes?.Add(n);
        }


        public Guid Id { get => id; private set => id = value; }
        public string FirstName { get => firstName; private set => firstName = value; }
        public string LastName { get => lastName; private set => lastName = value; }
        public string PersonalEmail { get => personalEmail; private set => personalEmail = value; }
        public string WorkEmail { get => workEmail; private set => workEmail = value; }
        public string Password { get => password; private set => password = value; }
        public string Address { get => address; private set => address = value; }
        public string Ssn { get => ssn; private set => ssn = value; }
        public string BankAccount { get => bankAccount; private set => bankAccount = value; }
        public string PhotoURL { get => photoURL; private set => photoURL = value; }
        public DateOnly BirthDate { get => birthDate; private set => birthDate = value; }
        public Gender Gender { get => gender; private set => gender = value; }
        public Role Role { get => role; private set => role = value; }
        public decimal HourlyRate { get => hourlyRate; private set => hourlyRate = value; }
        public List<Note>? Notes { get => notes; private set => notes = value; }
        public List<Task>? Tasks { get => tasks; private set => tasks = value; }

        public override string ToString()
        {
            return $"{FirstName} {LastName[0]}.";
        }

        /*private void GenerateSalt()
        {
            Random random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            this.salt = new string(Enumerable.Repeat(chars, SALT_LENGTH).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public void GeneratePassword(string new_password)
        {
            GenerateSalt();

            new_password += this.salt;

            using (var sha256 = SHA256.Create())
            {
                password += this.salt;

                // convert the password string to a byte array
                var passwordBytes = Encoding.UTF8.GetBytes(password);

                // compute the hash of the password
                var hashBytes = sha256.ComputeHash(passwordBytes);

                // convert the hash byte array to a string
                var hashedPassword = Convert.ToBase64String(hashBytes);

                this.password = hashedPassword;
            }*/
    }
}
