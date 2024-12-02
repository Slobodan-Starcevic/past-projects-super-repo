using BLL.Interfaces.Repositories;
using BLL.Models;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Task = BLL.Models.Task;

namespace DAL.Repositories
{
    public class TaskRepository : BaseRepository, ITaskRepository
    {
        public void Create(Task task)
        {
            string sql = "INSERT INTO task (id,Shift_id, title, description,Date_Task) " +
                         "VALUES (@id,@time_slot, @title, @description,@Date);";

            DateTime time = new DateTime(task.Date.Year, task.Date.Month, task.Date.Day);
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@id", task.Id);
            cmd.Parameters.AddWithValue("@time_slot", task.ShiftId);
            cmd.Parameters.AddWithValue("@title", task.Title);
            cmd.Parameters.AddWithValue("@description", task.Description);
            cmd.Parameters.AddWithValue("@Date",time);

            cnn.Open();
           cmd.ExecuteNonQuery();

            if(task.AssignedEmployees.Count > 0)
            {
                foreach(Employee employee in task.AssignedEmployees)
                {
                    sql = "INSERT INTO employee_task (task_id, employee_id) VALUES (@task_id, (SELECT id FROM employee WHERE Work_email = @c_email));";

                    cmd = new SqlCommand(sql, cnn);
                    cmd.Parameters.AddWithValue("@task_id", task.Id);
                    cmd.Parameters.AddWithValue("@c_email", employee.WorkEmail);

                    cmd.ExecuteNonQuery();
                }
            }

            if (task.Species.Count > 0)
            {
                foreach (var item in task.Species)
                {
                    if (item is Animal animal)
                    {
                        sql = "INSERT INTO task_animal (task_id, animal_id) VALUES (@task_id, " +
                              "@Animal_id);";

                        cmd = new SqlCommand(sql, cnn);
                        cmd.Parameters.AddWithValue("@task_id", task.Id);
                        cmd.Parameters.AddWithValue("@Animal_id", animal.AnimalId);
                    

                        cmd.ExecuteNonQuery();
                    }

                    if (item is Species)
                    {
                        sql = "INSERT INTO task_species (task_id, species_id) VALUES (@task_id, @s_id);";

                        cmd = new SqlCommand(sql, cnn);
                        cmd.Parameters.AddWithValue("@task_id", task.Id);
                        cmd.Parameters.AddWithValue("@s_id", item.SpeciesId);

                        cmd.ExecuteNonQuery();
                    }
                }
            }

            cnn.Close();
        }

        public void Delete(Guid id)
        {
            string sql = "DELETE FROM employee_task WHERE task_id = @id; " +
                         "DELETE FROM task_animal WHERE task_id = @id; " +
                         "DELETE FROM task_species WHERE task_id = @id; " +
                         "DELETE FROM task WHERE id = @id;";

            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.Parameters.AddWithValue("@id", id);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void Edit(Guid id, string new_description)
        {
            string sql = "UPDATE task " +
                         "SET description = @description " +
                         "WHERE id = @id;";

            cnn.Open();
            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@description", new_description);

            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void Edit(Guid id, List<Species> species)
        {
            string sql;

            int speciesCount = 0;
            int animalCount = 0;

            // Loop over the list and count species and animals
            foreach (var item in species)
            {
                if (item is Species)
                {
                    speciesCount++;
                }
                if (item is Animal)
                {
                    animalCount++;
                }
            }

            cnn.Open();

            if (speciesCount > 0)
            {
                sql = "DELETE FROM task_species WHERE task_id = @id;";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }

            if (animalCount > 0)
            {
                sql = "DELETE FROM task_animal WHERE task_id = @id;";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }

            foreach (var item in species)
            {
                if (item is Animal animal)
                {
                    sql = "INSERT INTO task_animal (task_id, animal_id) VALUES (@task_id, " +
						  "@animal_id)";

                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    cmd.Parameters.AddWithValue("@animal_id", animal.AnimalId);
                    cmd.Parameters.AddWithValue("@task_id", id);
                    cmd.Parameters.AddWithValue("@s_id", animal.SpeciesId);
                    cmd.Parameters.AddWithValue("@name", animal.AnimalName);
                    cmd.Parameters.AddWithValue("@sex", animal.Sex.ToString());

                    cmd.ExecuteNonQuery();
                }

                if (item is Species)
                {
                    sql = "INSERT INTO task_species (task_id, species_id) VALUES (@task_id, @s_id);";

                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    cmd.Parameters.AddWithValue("@task_id", id);
                    cmd.Parameters.AddWithValue("@s_id", item.SpeciesId);

                    cmd.ExecuteNonQuery();
                }
            }

            cnn.Close();
        }

        public void Edit(Guid id, List<Employee> employees)
        {
            string sql = string.Empty;
            SqlCommand cmd;
            cnn.Open();

            if (employees.Count > 0)
            {
                sql = "DELETE FROM employee_task WHERE task_id = @id; ";
                cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

                foreach (Employee employee in employees)
                {
                    sql = "INSERT INTO employee_task (task_id, employee_id) VALUES (@task_id, (SELECT id FROM employee WHERE Work_Email = @c_email));";

                    cmd = new SqlCommand(sql, cnn);
                    cmd.Parameters.AddWithValue("@task_id", id);
                    cmd.Parameters.AddWithValue("@c_email", employee.WorkEmail);

                    cmd.ExecuteNonQuery();
                }
            }

            cnn.Close();
        }

        public void Edit(Guid id, int shift_id)
        {
            string sql = "UPDATE task " +
                         "SET Shift_id = @timeslot " +
                         "WHERE id = @id;";

            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@timeslot", shift_id);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public List<Task> GetAllTasks()
        {
            List<Task> tasks = new List<Task>();

            string sql = "SELECT id FROM task;";
            List<Guid>Ids = new List<Guid>();

            SqlCommand cmd = new SqlCommand(sql, cnn);

            cnn.Open();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Ids.Add(reader.GetGuid(0));
                }
            }
            cnn.Close();
            foreach(Guid id in Ids)
            {
                tasks.Add(GetTask(id)); 
            }

            return tasks;
        }

        public Task? GetTask(Guid id)
        {
            string title; string description; int shift_id;
            Task task = null;

            EmployeeRepository employeeRepository = new EmployeeRepository();
            SpeciesRepository speciesRepository = new SpeciesRepository();

            var returnSpecies = new List<Species>();

            List<Employee> employees = employeeRepository.GetEmployeesFromTask(id);
            List<Species> species = speciesRepository.GetSpeciesFromTask(id);
            List<Animal> animals = GetTaskAnimals(id);
            foreach(var a in animals)
            {
                returnSpecies.Add(a);
            }
            foreach (var s in species)
                if (returnSpecies.FirstOrDefault(x => x.SpeciesId == s.SpeciesId) == null)
            {
                returnSpecies.Add(s);
            }

            string sql = "SELECT Shift_id, title, description,Date_Task FROM task WHERE id = @id;";

            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@id", id);

            cnn.Open();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    title = reader.GetString(1);
                    description = reader.GetString(2);
                    shift_id = reader.GetInt32(0);
                    DateTime date = reader.GetDateTime(3);
                    DateOnly dateOnly = new DateOnly(date.Year,date.Month,date.Day);

                    task = new Task(id, title, description, shift_id, returnSpecies,dateOnly, employees);
                }
            }
            cnn.Close();
            return task;
        }

        public List<Task> GetEmployeeTasks(Guid employee_id)
        {
            List<Task> tasks = new List<Task>();
            string sql = "SELECT t.id FROM task AS t, employee_task AS et " +
                         "WHERE t.id = et.task_id AND et.employee_id = @employee_id; ";

            SqlCommand cmd = new SqlCommand(sql, cnn);

            List<Guid> Ids = new List<Guid>();

            cmd.Parameters.AddWithValue("@employee_id", employee_id);
            try
            {
				cnn.Open();
				using (var reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
                        Ids.Add(reader.GetGuid(0));
					}
				}
				
				
			}
            catch(Exception ex)
            {
              
            }
            finally
            {
				cnn.Close();
                foreach(var id in Ids)
                {
                    tasks.Add(GetTask(id));
                }
			}
            return tasks;
		}

		public List<TaskOptions> GetTaskOptions()
		{
			var Options = new List<TaskOptions>();

			string sql = "select id,title,description from[dbo].[Task_Options]";

			SqlCommand cmd = new SqlCommand(sql, cnn);
			cnn.Open();
			using (var reader = cmd.ExecuteReader())
			{
				while (reader.Read())
				{
					 Options.Add(new TaskOptions(reader.GetGuid(0),reader.GetString(1),reader.GetString(2)));
					
				}
			}
			cnn.Close();
            return Options;
		}

		public void CreateTaskOption(Guid id,string title, string description)
		{
			string sql = "insert into Task_Options (id,title,Description)" +
						"VALUES (@id,@title, @description);";

		
			SqlCommand cmd = new SqlCommand(sql, cnn);
			cmd.Parameters.AddWithValue("@id", id);
			cmd.Parameters.AddWithValue("@title", title);
			cmd.Parameters.AddWithValue("@description", description);
		
			cnn.Open();
			cmd.ExecuteNonQuery();
            cnn.Close() ;
		}

		public void DeleteTaskOption(Guid id)
		{
            string sql = "delete from Task_Options where id = @id";

			SqlCommand cmd = new SqlCommand(sql, cnn);

			cmd.Parameters.AddWithValue("@id", id);
			cnn.Open();
			cmd.ExecuteNonQuery();
			cnn.Close();
		}
        public List<Animal> GetTaskAnimals(Guid taskid)
        {
            string query = "select Animal.Animal_id, Animal.Animal_Name, S.Weight, S.Size, S.Species_Speed, Animal.BirthDate, Animal.Sex, Animal.Arrival_Date, Animal.[Leave-date], s.Url, Animal.Show_On_Web,"+
             "s.Id,s.Species_Name,s.Weight,s.Size,s.Species_Speed,s.Incubationtime,s.Endangeredlevel,s.Url,s.Show_On_Web,s.Lifespan," +
             "e.Id,e.Name,e.Url,e.show_on_web,e.pfp_url from Animal " +
             "inner join Species as s on Animal.Species_Id = s.Id inner join Task_Animal on Animal.animal_id = Task_Animal.animal_id inner join Enclosure as e on s.Enclosure_id = e.Id where Task_id = @id";
 			SqlCommand cmd = new SqlCommand(query, cnn);
			cmd.Parameters.AddWithValue("@id", taskid);
            
			SpeciesRepository speciesRepository = new SpeciesRepository();
			

			var Animals = new List<Animal>();

	
			cnn.Open();
			using (var reader = cmd.ExecuteReader())
			{
				if (reader.Read())
				{
                    if (reader.IsDBNull(0))
                    {
                        return Animals;
                    }
					Guid Animalid = reader.GetGuid(0);
					string name = reader.GetString(1);
					int weight = reader.GetInt32(2);
					int size = reader.GetInt32(3);
					int speed = reader.GetInt32(4);
					DateTime BirthDate = reader.GetDateTime(5);
					Sex sex = ((Sex)reader.GetInt32(6));
					DateTime ArriveDate = reader.GetDateTime(7);
					DateTime? LeaveDate = reader.GetDateTime(8);
					string url = reader.GetString(9);
					bool ShowOnWeb = reader.GetBoolean(10);

					Guid Id = reader.GetGuid(11);
					string speciesName = reader.GetString(12);
					int speciesWeight = reader.GetInt32(13);
					int specuesSize = reader.GetInt32(14);
					int speciesLifespan = reader.GetInt32(15);
					int speciesSpeed = reader.GetInt32(15);
					int speciesIncubationtime = reader.GetInt32(16);
					Endangered endangered = ((Endangered)reader.GetInt32(17));
					string speciesUrl = reader.GetString(18);
					bool speciesShowOnWeb = reader.GetBoolean(19);

                    Guid enclosureId = reader.GetGuid(21);
                    string enlcosureName = reader.GetString(22);
                    string enclosureUrl = reader.GetString(23);
                    bool enclosureShowOnWeb = reader.GetBoolean(24);
                    string profileUrl = reader.GetString(25);

                    Enclosure enclosure = new Enclosure(enclosureId,enlcosureName,enclosureUrl);

					Species species = new Species(Id,speciesName,speciesWeight,specuesSize,speciesLifespan,speciesSpeed,speciesIncubationtime,endangered,enclosure,speciesUrl);
					Animals.Add( new Animal(species, Animalid, name, weight, size, speed, BirthDate, sex, ArriveDate, LeaveDate, url));

				}
				
			}

			cnn.Close();
			return Animals;
		}

		public void UpdateTaskOption(Guid id,string title,string description)
		{
			string sql = "update Task_Options set title = @title,Description = @description where id = @id";

			SqlCommand cmd = new SqlCommand(sql, cnn);
			cmd.Parameters.AddWithValue("@id", id);
			cmd.Parameters.AddWithValue("@title", title);
			cmd.Parameters.AddWithValue("@description", description);

		
			cnn.Open();
			cmd.ExecuteNonQuery();
			cnn.Close();
		}
	}
}
