using BLL.Exceptions;
using BLL.Interfaces.Repositories;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Task = BLL.Models.Task;

namespace DAL.Repositories
{
	public class EmployeeRepository : BaseRepository, IEmployeeRepository
	{
		public void Create(Employee employee)
		{
			string sql = @"INSERT INTO employee (Id, First_Name, Last_Name, Personal_email, [Work_email], Password, Adress, Snn, Bankaccount, Birthdate, Gender, Role, HourlyRate,  Profile_Picture)" +
						 @"VALUES(@id, @fname, @lname, @p_email, @c_email, @password, @address, @ssn, @bank, @bdate, @gender, @role, @hourly, @profile_pic)";


            SqlCommand cmd = new SqlCommand(sql, cnn);
			cmd.Parameters.AddWithValue("@id", employee.Id);
            cmd.Parameters.AddWithValue("@fname", employee.FirstName);
            cmd.Parameters.AddWithValue("@lname", employee.LastName);
			cmd.Parameters.AddWithValue("@p_email", employee.PersonalEmail);
			cmd.Parameters.AddWithValue("@c_email", employee.WorkEmail);
			cmd.Parameters.AddWithValue("@password", employee.Password);
			cmd.Parameters.AddWithValue("@address", employee.Address);
			cmd.Parameters.AddWithValue("@ssn", employee.Ssn);
			cmd.Parameters.AddWithValue("@bank", employee.BankAccount);
			cmd.Parameters.AddWithValue("@bdate", employee.BirthDate.ToDateTime(TimeOnly.MinValue));
			cmd.Parameters.AddWithValue("@gender", employee.Gender);
			cmd.Parameters.AddWithValue("@role", employee.Role);
			cmd.Parameters.AddWithValue("@hourly", employee.HourlyRate * 100); //CONVERTING TO CENTS TO STORE IN DATABASE
			cmd.Parameters.AddWithValue("@profile_pic", employee.PhotoURL);

			cnn.Open();
			cmd.ExecuteNonQuery();
			cnn.Close();
		}

		public void EdditAdress(Guid id, string text)
		{
            SqlConnection cnn = new SqlConnection(ConnectionString);
            string sql = "UPDATE employee SET Adress = @adress WHERE id = @id;";
			SqlCommand cmd = new SqlCommand(sql, cnn);

			cmd.Parameters.AddWithValue("@adress", text);
			cmd.Parameters.AddWithValue("@id", id);

			cnn.Open();
			cmd.ExecuteNonQuery();
			cnn.Close();
		}

		public void EdditBirthDate(Guid id, DateTime date)
		{
            SqlConnection cnn = new SqlConnection(ConnectionString);
            string sql = "UPDATE employee SET Birthdate = @birth_date WHERE id = @id;";
			SqlCommand cmd = new SqlCommand(sql, cnn);

			cmd.Parameters.AddWithValue("@birth_date", date);
			cmd.Parameters.AddWithValue("@id", id);

			cnn.Open();
			cmd.ExecuteNonQuery();
			cnn.Close();
		}

		public void EdditEmployeeBankAccount(Guid id, string text)
		{
            SqlConnection cnn = new SqlConnection(ConnectionString);
            string sql = "UPDATE employee SET Bankaccount = @bank_nr WHERE id = @id;";
			SqlCommand cmd = new SqlCommand(sql, cnn);

			cmd.Parameters.AddWithValue("@bank_nr", text);
			cmd.Parameters.AddWithValue("@id", id);

			cnn.Open();
			cmd.ExecuteNonQuery();
			cnn.Close();
		}

		public void EdditGender(Guid id, Gender gender)
		{
            SqlConnection cnn = new SqlConnection(ConnectionString);
            string sql = "UPDATE employee SET Gender = @gender WHERE id = @id;";
			SqlCommand cmd = new SqlCommand(sql, cnn);

			cmd.Parameters.AddWithValue("@gender", gender);
			cmd.Parameters.AddWithValue("@id", id);

			cnn.Open();
			cmd.ExecuteNonQuery();
			cnn.Close();
		}

		public void EdditLastname(Guid id, string text)
		{
            SqlConnection cnn = new SqlConnection(ConnectionString);
            string sql = "UPDATE employee SET Last_Name = @last_name WHERE id = @id;";
			SqlCommand cmd = new SqlCommand(sql, cnn);

			cmd.Parameters.AddWithValue("@last_name", text);
			cmd.Parameters.AddWithValue("@id", id);

			cnn.Open();
			cmd.ExecuteNonQuery();
			cnn.Close();
		}

		public void EdditPhotoUrl(Guid id, string text)
		{
            SqlConnection cnn = new SqlConnection(ConnectionString);
            string sql = "UPDATE employee SET Profile_Picture = @profile_picture WHERE id = @id;";
			SqlCommand cmd = new SqlCommand(sql, cnn);

            int photoInt = 0;
            if(text != "default-pfp.png")
            {
                photoInt = 1;
            }

			cmd.Parameters.AddWithValue("@profile_picture", photoInt);
			cmd.Parameters.AddWithValue("@id", id);

			cnn.Open();
			cmd.ExecuteNonQuery();
			cnn.Close();
		}

		public void EdditSSn(Guid id, string sSN)
		{
            SqlConnection cnn = new SqlConnection(ConnectionString);
            string sql = "UPDATE employee SET Snn = @social_security_number WHERE id = @id;";
			SqlCommand cmd = new SqlCommand(sql, cnn);

			cmd.Parameters.AddWithValue("@social_security_number", sSN);
			cmd.Parameters.AddWithValue("@id", id);

			cnn.Open();
			cmd.ExecuteNonQuery();
			cnn.Close();
		}

		public void EdditWorkEmail(Guid id, string text)
		{
            SqlConnection cnn = new SqlConnection(ConnectionString);
            string sql = "UPDATE employee SET Work_email = @company_email WHERE id = @id;";
			SqlCommand cmd = new SqlCommand(sql, cnn);

			cmd.Parameters.AddWithValue("@company_email", text);
			cmd.Parameters.AddWithValue("@id", id);

			cnn.Open();
			cmd.ExecuteNonQuery();
			cnn.Close();
		}

		public void EditEmail(Guid id, string new_personal_email)
		{
            SqlConnection cnn = new SqlConnection(ConnectionString);
            string sql = "UPDATE employee SET Personal_email = @p_email WHERE id = @id;";

			SqlCommand cmd = new SqlCommand(sql, cnn);

			cmd.Parameters.AddWithValue("@p_email", new_personal_email);
			cmd.Parameters.AddWithValue("@id", id);

			cnn.Open();
			cmd.ExecuteNonQuery();
			cnn.Close();
		}

		public void EditFname(Guid id, string text)
		{
            SqlConnection cnn = new SqlConnection(ConnectionString);
            string sql = "UPDATE employee SET First_Name = @first_name WHERE id = @id;";

			SqlCommand cmd = new SqlCommand(sql, cnn);

			cmd.Parameters.AddWithValue("@first_name", text);
			cmd.Parameters.AddWithValue("@id", id);

			cnn.Open();
			cmd.ExecuteNonQuery();
			cnn.Close();
		}

		public void EditPassword(Guid id, string password)
		{
            SqlConnection cnn = new SqlConnection(ConnectionString);
            string sql = "UPDATE employee SET Password = @password WHERE id = @id;";

			SqlCommand cmd = new SqlCommand(sql, cnn);

			cmd.Parameters.AddWithValue("@password", password);
			cmd.Parameters.AddWithValue("@id", id);

			cnn.Open();
			cmd.ExecuteNonQuery();
			cnn.Close();
		}
	
		public void EditRole(Guid id, Role role)
		{
            SqlConnection cnn = new SqlConnection(ConnectionString);
            string sql = "UPDATE employee SET Role = @role WHERE id = @id;";

			SqlCommand cmd = new SqlCommand(sql, cnn);

			cmd.Parameters.AddWithValue("@role", role);
			cmd.Parameters.AddWithValue("@id", id);

			cnn.Open();
			cmd.ExecuteNonQuery();
			cnn.Close();
		}

		public List<Employee> GetAllEmployees()
		{
            SqlConnection cnn = new SqlConnection(ConnectionString);
            List<Employee> employees = new List<Employee>();
			string Sql = "select id,First_Name,Last_Name,Personal_email,Work_email,Password,Adress,Snn,Bankaccount,Birthdate,Gender,Role,HourlyRate,Profile_Picture from Employee ";

            using (cnn)
			{
				SqlCommand command = new SqlCommand(Sql, cnn);
				try
				{
					cnn.Open();

					SqlDataReader reader = command.ExecuteReader();
					if (reader.HasRows)
					{
						while (reader.Read())
						{
							Guid _id = reader.GetGuid(0);
							string fname = reader.GetString(1);
							string lname = reader.GetString(2);
							string PersonalEmail = reader.GetString(3);
							string WorkEmail = reader.GetString(4);
                            string password = reader.GetString(5);
							string adress = reader.GetString(6);
							string snn = reader.GetString(7);
							string Bankaccount = reader.GetString(8);
							DateTime d = reader.GetDateTime(9);
							DateOnly BirthDate = new DateOnly(d.Year, d.Month, d.Day);
							Gender gender = (Gender)reader.GetInt32(10);
                            Role role =  (Role)reader.GetInt32(11);
							decimal HourlyRate = reader.GetDecimal(12) / 100;
							int profile_url = reader.GetInt32(13);

							Employee employee = new Employee(_id, fname, lname, PersonalEmail, WorkEmail,password, adress, snn, Bankaccount, BirthDate, gender, role, HourlyRate, profile_url);
                            employees.Add(employee);
						}
					}
					else
					{
						cnn.Close();
						throw new Exception("no employees in database");
					}
				}
				catch(Exception ex)
				{

				}			
				finally
				{
					cnn.Close();
				}
				return employees;
			}
		}

        public Employee GetEmployeeWorkMail(string company_email)
        {
            
            Employee employee = null;
            string sql = "SELECT id, First_Name, Last_Name, Personal_email, Work_email, Password, Adress, Snn, Bankaccount, Birthdate, Gender, Role, HourlyRate, Profile_Picture " +
                         "FROM employee " +
						 "WHERE Work_email = @company_email ;";  // Update the query to use [Work-email] column and parameter

            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(sql, cnn);
                command.Parameters.AddWithValue("@company_email", company_email);// Set the @company_email parameter value
                cnn.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // Extract data from the reader
                        Guid _id = reader.GetGuid(0);
                        string fname = reader.GetString(1);
                        string lname = reader.GetString(2);
                        string PersonalEmail = reader.GetString(3);
                        string WorkEmail = reader.GetString(4);
                        string password =  reader.GetString(5);
                        string adress = reader.GetString(6);
                        string snn = reader.GetString(7);
                        string Bankaccount = reader.GetString(8);
                        DateTime d = reader.GetDateTime(9);
                        DateOnly BirthDate = new DateOnly(d.Year, d.Month, d.Day);
                        Gender gender = (Gender)reader.GetInt32(10);
                        Role role = (Role)reader.GetInt32(11);
                        decimal HourlyRate = reader.GetDecimal(12) /100;
                        int profile_url = reader.GetInt32(13);

                        employee = new Employee(_id, fname, lname, PersonalEmail, WorkEmail,password, adress, snn, Bankaccount, BirthDate, gender, role, HourlyRate, profile_url);
                        return employee;
                    }
                }
                else
                {
                    throw new Exception("No employees in the database with the provided company email.");
                }

                return employee;
            }
        }




        public void RemoveEmployee(Guid id)
        {
            SqlConnection cnn = new SqlConnection(ConnectionString);
            string sql = "DELETE FROM employee  WHERE Id = @id;";

			SqlCommand cmd = new SqlCommand(sql, cnn);

			cmd.Parameters.AddWithValue("@id", id);

			cnn.Open();
			cmd.ExecuteNonQuery();
			cnn.Close();
		}


		public Employee GetEmployeeID(Guid id)
		{
            SqlConnection cnn = new SqlConnection(ConnectionString);
            Employee employee = null;
			TaskRepository taskRepository = new TaskRepository();
			NoteRepository noteRepository = new NoteRepository();

			List<Task> tasks = taskRepository.GetEmployeeTasks(id).ToList();
			List<Note> notes = noteRepository.GetEmployeeNotes(id).ToList();

			string sql = "select id,First_Name,Last_Name,Personal_email,[Work_email],Password,Adress,Snn,Bankaccount,Birthdate,Gender,Role,HourlyRate,Profile_Picture " +
						 "FROM employee " +
						 "WHERE id = @id;";

			SqlCommand cmd = new SqlCommand(sql, cnn);

			cmd.Parameters.AddWithValue("@id", id);
			try
			{
				cnn.Open();
				using (var reader = cmd.ExecuteReader())
				{
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Guid _id = reader.GetGuid(0);
                            string fname = reader.GetString(1);
                            string lname = reader.GetString(2);
                            string PersonalEmail = reader.GetString(3);
                            string WorkEmail = reader.GetString(4);
                            string password = reader.GetString(5);
                            string adress = reader.GetString(6);
                            string snn = reader.GetString(7);
                            string Bankaccount = reader.GetString(8);
                            DateTime d = reader.GetDateTime(9);
                            DateOnly BirthDate = new DateOnly(d.Year, d.Month, d.Day);
                            Gender gender = (Gender)reader.GetInt32(10);
                            Role role = (Role)reader.GetInt32(11);
                            decimal HourlyRate = reader.GetDecimal(12) / 100;
                            int profile_url = reader.GetInt32(13);

                            employee = new Employee(_id, fname, lname, PersonalEmail, WorkEmail,password , adress, snn, Bankaccount, BirthDate, gender, role, HourlyRate, profile_url);
                        }
                    }
                }
				
			}catch(Exception ex)
			{

			}
			finally
			{
				cnn.Close();
			}				

				return employee;
			}
		

		public List<Employee> GetEmployeesFromTask(Guid task_id)
		{
            SqlConnection cnn = new SqlConnection(ConnectionString);
            List<Employee> employees = new List<Employee>();

			string sql = "select id,First_Name,Last_Name,Personal_email,Work_email,Password,Adress,Snn,Bankaccount,Birthdate,Gender,Role,HourlyRate,Profile_Picture " +
                         "FROM employee , Employee_Task " +
						 "WHERE employee.id = employee_task.employee_id AND employee_Task.task_id = @task_id;";

			SqlCommand cmd = new SqlCommand(sql, cnn);

			cmd.Parameters.AddWithValue("@task_id", task_id);

			cnn.Open();
			using (var reader = cmd.ExecuteReader())
			{
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Guid _id = reader.GetGuid(0);
                        string fname = reader.GetString(1);
                        string lname = reader.GetString(2);
                        string PersonalEmail = reader.GetString(3);
                        string WorkEmail = reader.GetString(4);
                        string password = reader.GetString(5);
                        string adress = reader.GetString(6);
                        string snn = reader.GetString(7);
                        string Bankaccount = reader.GetString(8);
                        DateTime d = reader.GetDateTime(9);
                        DateOnly BirthDate = new DateOnly(d.Year, d.Month, d.Day);
                        Gender gender = (Gender)reader.GetInt32(10);
                        Role role = (Role)reader.GetInt32(11);
                        decimal HourlyRate = reader.GetDecimal(12) / 100;
                        int profile_url = reader.GetInt32(13);

                        employees.Add( new Employee(_id, fname, lname, PersonalEmail, WorkEmail,password, adress, snn, Bankaccount, BirthDate, gender, role, HourlyRate, profile_url));
                    }
                }
            }
			cnn.Close();

			return employees;
		}

		public void EdditHourlyRate(Guid id, decimal value)
		{
            SqlConnection cnn = new SqlConnection(ConnectionString);
            string sql = "UPDATE employee SET HourlyRate = @hourly_rate WHERE id = @id;";

			SqlCommand cmd = new SqlCommand(sql, cnn);

			cmd.Parameters.AddWithValue("@hourly_rate", Convert.ToInt32(value) * 100);
			cmd.Parameters.AddWithValue("@id", id);

			cnn.Open();
			cmd.ExecuteNonQuery();
			cnn.Close();
		}

        public Employee AuthenticateLogin(string email, string password)
        {
            string query =
                "SELECT COUNT(*) " +
                "FROM Employee " +
                "WHERE work_email = @email " +
                "AND password = @password";

            using (SqlConnection connection = CreateAndOpenSql())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@password", password);

                    int count = (int)command.ExecuteScalar();

                    if (count == 0)
                    {
                        throw new UserNotFoundException("User not found");
                    }
                    else
                    {
                        return GetEmployeeByWorkEmail(email);
                    }
                }
            }
        }

        public Employee GetEmployeeById(Guid idToFind)
        {
            string query =
				"SELECT id, first_name, last_name, personal_email, work_email, Password, adress, snn, bankaccount, birthdate, gender, role, hourlyrate, profile_picture " +
                "FROM Employee " +
                "WHERE id = @id";

            Employee? employee = null;

            using (SqlConnection connection = CreateAndOpenSql())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", idToFind);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Guid id = reader.GetGuid(0);
                            string firstName = reader.GetString(1);
                            string lastName = reader.GetString(2);
                            string personalEmail = reader.GetString(3);
                            string workEmail = reader.GetString(4);
                            string password = reader.GetString(5);
                            string address = reader.GetString(6);
                            string ssn = reader.GetString(7);
                            string bankAccount = reader.GetString(8);
                            DateOnly birthdate = reader.IsDBNull(9) ? default(DateOnly) : DateOnly.FromDateTime(reader.GetDateTime(9));
                            Gender gender = (Gender)Enum.Parse(typeof(Gender), reader.GetValue(10).ToString());
                            Role role = (Role)Enum.Parse(typeof(Role), reader.GetValue(11).ToString());
                            decimal hourlyRate = reader.GetDecimal(12);
                            int photoURL = reader.GetInt32(13);

                            employee = new Employee(id, firstName, lastName, personalEmail, workEmail, password, address, ssn, bankAccount,
                                birthdate, gender, role, hourlyRate, photoURL);
                        }
                    }
                }
            }

            return employee ?? throw new UserNotFoundException("User not in database");
        }

        public Employee GetEmployeeByWorkEmail(string emailToFind)
        {
            string query =
				"SELECT id, first_name, last_name, personal_email, work_email, Password, adress, snn, bankaccount, birthdate, gender, role, hourlyrate, profile_picture " +
                "FROM Employee " +
                "WHERE work_email = @email";

            Employee? employee = null;

            using (SqlConnection connection = CreateAndOpenSql())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@email", emailToFind);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Guid id = reader.GetGuid(0);
                            string firstName = reader.GetString(1);
                            string lastName = reader.GetString(2);
                            string personalEmail = reader.GetString(3);
                            string workEmail = reader.GetString(4);
                            string password = reader.GetString(5);
                            string address = reader.GetString(6);
                            string ssn = reader.GetString(7);
                            string bankAccount = reader.GetString(8);
                            DateOnly birthdate = reader.IsDBNull(9) ? default(DateOnly) : DateOnly.FromDateTime(reader.GetDateTime(9));
							Gender gender = (Gender)Enum.Parse(typeof(Gender), reader.GetValue(10).ToString());
                            Role role = (Role)Enum.Parse(typeof(Role), reader.GetValue(11).ToString());
                            decimal hourlyRate = reader.GetDecimal(12);
							int photoURL = reader.GetInt32(13);

                            employee = new Employee(id, firstName, lastName, personalEmail, workEmail, password, address, ssn, bankAccount, 
								birthdate, gender, role, hourlyRate, photoURL);
                        }
                    }
                }
            }

            return employee ?? throw new UserNotFoundException("User not in database");
        }

        public Employee UpdateEmployee(Employee employee)
        {
            string query =
                "UPDATE Employee " +
                "SET First_Name = @firstName, " +
                "Last_Name = @lastName, " +
                "Personal_Email = @personalEmail, " +
                "Adress = @address, " +
                "Gender = @gender " +
                "WHERE Id = @id;";

			int genderValue = Convert.ToInt32(employee.Gender);
			int photoURL = 1;

			if(employee.PhotoURL == "~/media/pfp/default-pfp.png")
			{
				photoURL = 0;
			}

            using (SqlConnection connection = CreateAndOpenSql())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@firstName", employee.FirstName);
                    command.Parameters.AddWithValue("@lastName", employee.LastName);
                    command.Parameters.AddWithValue("@personalEmail", employee.PersonalEmail);
                    command.Parameters.AddWithValue("@address", employee.Address);
                    command.Parameters.AddWithValue("@gender", genderValue);
                    command.Parameters.AddWithValue("@id", employee.Id);

					UpdateInDatabase(command);

					return GetEmployeeById(employee.Id);
                }
            }
        }
    }
}

