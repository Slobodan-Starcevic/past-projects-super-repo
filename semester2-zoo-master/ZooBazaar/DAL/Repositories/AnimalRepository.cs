using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Exceptions;
using BLL.Interfaces.Repositories;
using BLL.Models;
using BLL.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DAL.Repositories
{
    public class AnimalRepository : BaseRepository, IAnimalRepository
    {
        private SpeciesRepository speciesRepository;
        public AnimalRepository()
        {
            speciesRepository = new SpeciesRepository();
        }
        public void CreateAnimal(Animal animal)
        {
            string sql = "INSERT INTO animal (Animal_id, Animal_Name, Species_Id, BirthDate, weight, size, speed, sex, Arrival_Date, [Leave-date], show_on_web, pfp_url, url)" +
                            " VALUES (@Animal_id, @name, @speciesId, @birthdate, @weight, @size, @speed, @sex, @arrive_date, @leave_date, @show_on_web, @pfp_url, @url)";

            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@Animal_id", animal.AnimalId);
            cmd.Parameters.AddWithValue("@speciesId", animal.SpeciesId);
            cmd.Parameters.AddWithValue("@name", animal.AnimalName);
            cmd.Parameters.AddWithValue("@sex", animal.Sex);
            cmd.Parameters.AddWithValue("@birthdate", animal.Birthdate);
            cmd.Parameters.AddWithValue("@arrive_date", animal.ArrivalDate);
            cmd.Parameters.AddWithValue("@leave_date", animal.LeaveDate);
            cmd.Parameters.AddWithValue("@weight", animal.Weight);
            cmd.Parameters.AddWithValue("@size", animal.Size);
            cmd.Parameters.AddWithValue("@speed", animal.Speed);
            cmd.Parameters.AddWithValue("@show_on_web", 0);
            cmd.Parameters.AddWithValue("@pfp_url", $"/media/pfp/{animal.AnimalName}.png");
            cmd.Parameters.AddWithValue("@url", $"/animal?id={animal.AnimalId.ToString().ToUpper()}");

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();


        }

        public void DeleteAnimal(Guid id)
        {
            DeleteToDatabase("DELETE FROM note_animal WHERE animal_id = @id", new SqlParameter("@id", id));
            DeleteToDatabase("DELETE FROM task_animal WHERE animal_id = @id", new SqlParameter("@id", id));
            DeleteToDatabase("DELETE FROM Animal_Content WHERE animal_id = @id", new SqlParameter("@id", id));
            DeleteToDatabase("DELETE FROM Animal WHERE animal_id = @id", new SqlParameter("@id", id));
        }
        
        public Animal GetAnimal(Guid id)
		{
            string query =
                "SELECT animal_id, animal_name, species_id, birthdate, sex, arrival_date, [leave-date], show_on_web, pfp_url, weight, size, speed, url " +
                "FROM animal " +
                "WHERE animal_id = @id;";

            Animal? animal = null;

            using (SqlConnection connection = CreateAndOpenSql())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Guid animalGuid = reader.GetGuid(0);
                            string name = reader.GetString(1);
                            Species species = speciesRepository.GetSpeciesByInt(reader.GetGuid(2));
                            DateTime birthdate = reader.GetDateTime(3);
                            Sex sex = (Sex)reader.GetInt32(4);
                            DateTime arrivalDate = reader.GetDateTime(5);
                            DateTime leavedate = reader.GetDateTime(6);
                            bool onWeb = reader.GetBoolean(7);
                            string pfpURL = reader.GetString(8);
                            int weight = reader.GetInt32(9);
                            int size = reader.GetInt32(10);
                            int speed = reader.GetInt32(11);
                            string url = reader.GetString(12);

                            animal = new Animal(species, animalGuid, name, weight, size, speed, birthdate, sex, arrivalDate, leavedate, url, onWeb, pfpURL);
                        }
                    }
                }
            }
            return animal ?? throw new Exception("Animal not found");
        }


        List<Animal> IAnimalRepository.GetAnimalsFromTask(Guid task_id)
        {
            string sql = "SELECT a.id " +
                        "FROM Animal AS a, task_animal AS ta" +
                        "WHERE a.id = ta.animal_id AND ta.task_id = @task_id;";

            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@task_id", task_id);

            List<Animal> animals = new List<Animal>();
            List<Guid> Ids = new List<Guid>();
            cnn.Open();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Ids.Add(reader.GetGuid(0));
                }
            }

            cnn.Close();
            foreach (Guid id in Ids)
            {
                animals.Add(GetAnimal(id));
            }
            return animals;
        }

        public List<Animal> GetAllAnimalsBySpecies(Guid speciesId)
        {
            string query =
                "SELECT animal_id, animal_name, species_id, birthdate, sex, arrival_date, [leave-date], show_on_web, pfp_url, weight, size, speed, url " +
                "FROM animal " +
                "WHERE species_id = @species_id";

            List<Animal> animals = new List<Animal>();

            using (SqlConnection connection = CreateAndOpenSql())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@species_id", speciesId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Guid animalGuid = reader.GetGuid(0);
                            string name = reader.GetString(1);
                            Species species = speciesRepository.GetSpeciesByInt(reader.GetGuid(2));
                            DateTime birthdate = reader.GetDateTime(3);
                            Sex sex = (Sex)reader.GetInt32(4);
                            DateTime arrivalDate = reader.GetDateTime(5);
                            DateTime leavedate = reader.GetDateTime(6);
                            bool onWeb = reader.GetBoolean(7);
                            string pfpURL = reader.GetString(8);
                            int weight = reader.GetInt32(9);
                            int size = reader.GetInt32(10);
                            int speed = reader.GetInt32(11);
                            string url = reader.GetString(12);

                            Animal animal = new Animal(species, animalGuid, name, weight, size, speed, birthdate, sex, arrivalDate, leavedate, url, onWeb, pfpURL);

                            animals.Add(animal);
                        }
                    }
                }
            }
            return animals;
        }



        List<Animal> IAnimalRepository.GetAnimalsByEnclosure(Guid id, Guid enclosureId)
        {
            List<Animal> animals = new List<Animal>();
            List<Guid> Ids = new List<Guid>();

            string sql = "SELECT a.id " +
                         "FROM animal AS a, species AS s " +
                         "WHERE s.enclosure_id = @enclosure_id AND a.species_id = s.id; ";

            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.Parameters.AddWithValue("@enclosure_id", enclosureId);

            cnn.Open();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Ids.Add(reader.GetGuid(0));
                }
            }
            cnn.Close();

            foreach (Guid ID in Ids)
            {
                animals.Add(GetAnimal(ID));
            }
            return animals;

        }

        public List<Animal> GetAnimals()
        {
            string query =
                "SELECT animal_id, animal_name, species_id, birthdate, sex, arrival_date, [leave-date], show_on_web, pfp_url, weight, size, speed, url " +
                "FROM animal;";

            List<Animal> animals = new List<Animal>();

            using (SqlConnection connection = CreateAndOpenSql())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Guid animalGuid = reader.GetGuid(0);
                            string name = reader.GetString(1);
                            Species species = speciesRepository.GetSpeciesByInt(reader.GetGuid(2));
                            DateTime birthdate = reader.GetDateTime(3);
                            Sex sex = (Sex)reader.GetInt32(4);
                            DateTime arrivalDate = reader.GetDateTime(5);
                            DateTime leavedate = reader.GetDateTime(6);
                            bool onWeb = reader.GetBoolean(7);
                            string pfpURL = reader.GetString(8);
                            int weight = reader.GetInt32(9);
                            int size = reader.GetInt32(10);
                            int speed = reader.GetInt32(11);
                            string url = reader.GetString(12);

                            Animal animal = new Animal(species, animalGuid, name, weight, size, speed, birthdate, sex, arrivalDate, leavedate, url, onWeb, pfpURL);

                            animals.Add(animal);
                        }
                    }
                }
            }
            return animals;
        }



        public List<Animal> GetAnimalsFromTask(Guid task_id)
        {
            List<Animal> animals = new List<Animal>();
            List<Guid> Ids = new List<Guid>();

            string sql = "select a.Animal_id from Animal as a , Task_Animal  as t where Task_id = @TaskId a.Animal_id = t.Animal_id ";

            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("TaskId", task_id);

            cnn.Open();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Ids.Add(reader.GetGuid(0));
                }
            }
            cnn.Close();

            foreach (Guid ID in Ids)
            {
                animals.Add(GetAnimal(ID));
            }
            return animals;
        }

        public void EditAnimalSex(Guid id, Sex sex)
        {
            string sql = "UPDATE animal SET sex = @sex WHERE Animal_id = @id;";

            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.Parameters.AddWithValue("@sex", sex.ToString());
            cmd.Parameters.AddWithValue("@id", id);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public void EditAnimalBirthdate(Guid id, DateTime birthdate)
        {
            string sql = "UPDATE animal SET birthdate = @birthdate WHERE Animal_id = @id;";

            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.Parameters.AddWithValue("@birthdate", birthdate);
            cmd.Parameters.AddWithValue("@id", id);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void EditAnimalName(Guid id, string name)
        {
            string sql = "UPDATE animal SET name = @name WHERE Animal_id = @id;";

            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@id", id);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void EdditAnimalLeaveD(Guid animalId, DateOnly dateOnly)
        {
            string sql = "UPDATE animal SET leave_date = @leave_date WHERE Animal_id = @Animal_id";

            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@leave_date", dateOnly);
                    cmd.Parameters.AddWithValue("@Animal_id", animalId);

                    cnn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EdditAnimalArivalDate(Guid animalId, DateOnly dateOnly)
        {
            string sql = "UPDATE animal SET arrive_date = @arrive_date WHERE Animal_id = @Animal_id";

            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@arrive_date", dateOnly);
                    cmd.Parameters.AddWithValue("@Animal_id", animalId);

                    cnn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EditAnimalWeight(Guid id, int weight)
        {
            string sql = "UPDATE animal SET weight = @weight WHERE Animal_id = @Animal_id";

            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@weight", weight);
                    cmd.Parameters.AddWithValue("@Animal_id", id);

                    cnn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EditAnimalSize(Guid id, int size)
        {
            string sql = "UPDATE animal SET size = @size WHERE Animal_id = @Animal_id";

            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@size", size);
                    cmd.Parameters.AddWithValue("@Animal_id", id);

                    cnn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EditAnimalSpeed(Guid id, int speed)
        {
            string sql = "UPDATE animal SET speed = @speed WHERE Animal_id = @Animal_id";

            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@speed", speed);
                    cmd.Parameters.AddWithValue("@Animal_id", id);

                    cnn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EdditShowStatus(Guid Animal_id, bool v)
        {
            string sql = "Update animal set Show_On_Web = @Show_On_Web where Animal_id = @id";
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@Show_On_Web", v);
                    cmd.Parameters.AddWithValue("@id",Animal_id );

                    cnn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Animal> GetAllAnimalNamesBySpeciesId(string speciesId)
        {
            string query =
                "SELECT animal_id, animal_name " +
                "FROM Animal " +
                "WHERE species_id = @speciesId;";

            List<Animal> animalList = new List<Animal>();

            using (SqlConnection connection = CreateAndOpenSql())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@speciesId", speciesId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Guid id = reader.GetGuid(0);
                            string animalName = reader.GetString(1);

                            Animal animal = new Animal(id, animalName);

                            animalList.Add(animal);
                        }
                    }
                }
            }
            if (animalList.Count == 0)
            {
                throw new NoAnimalsFoundException("No animals found for the specified species");
            }
            return animalList;
        }
    }
}
