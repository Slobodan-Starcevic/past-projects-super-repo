using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BLL.Exceptions;
using BLL.Interfaces.Repositories;
using BLL.Models;
using BLL.Services;
using Microsoft.VisualBasic;

namespace DAL.Repositories
{
    public class SpeciesRepository : BaseRepository, ISpeciesRepository
    {
        private EnclosureRepository enclosureRepository;

        public SpeciesRepository()
        {
            enclosureRepository = new EnclosureRepository();
        }
        public void CreateSpecies(Species species)
        {
            string sql = "INSERT INTO species (Id, species_name,Weight,Size,Lifespan,Species_Speed,Incubationtime,endangeredlevel,Enclosure_id,Url,Show_On_Web, pfp_url) " +
                         "VALUES (@Id, @name,@weight,@size,@lifespan,@species_speed,@incubationtime,@endangeredlevel,@enclosure_id,@url,@show_on_web, @pfp_url );";

            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.Parameters.AddWithValue("@Id", species.SpeciesId);
            cmd.Parameters.AddWithValue("@name", species.SpeciesName);
            cmd.Parameters.AddWithValue("@weight", species.Weight);
            cmd.Parameters.AddWithValue("@size", species.Size);
            cmd.Parameters.AddWithValue("@lifespan", species.SpeciesLifespan);
            cmd.Parameters.AddWithValue("@species_speed", species.Speed);
            cmd.Parameters.AddWithValue("@incubationtime", species.SpeciesIncubationTime);
            cmd.Parameters.AddWithValue("@endangeredlevel", ((int)species.SpeciesEndangeredLevel));
            cmd.Parameters.AddWithValue("@enclosure_id", species.SpeciesEnclosure.Id);
            cmd.Parameters.AddWithValue("@url", species.Url);
            cmd.Parameters.AddWithValue("@show_on_web",species.ShowOnWeb);
            cmd.Parameters.AddWithValue("@pfp_url", $"/media/pfp/{species.SpeciesName}.png");

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void DeleteSpecies(Guid id)
        {
            DeleteToDatabase("DELETE FROM note_species WHERE species_id = @id", new SqlParameter("@id", id));
            DeleteToDatabase("DELETE FROM species_content WHERE species_id = @id", new SqlParameter("@id", id));
            DeleteToDatabase("DELETE FROM task_species WHERE species_id = @id", new SqlParameter("@id", id));
            DeleteToDatabase("DELETE FROM Species WHERE id = @id", new SqlParameter("@id", id));
        }

        public void EdditShowStatus(Guid id, bool v)
        {
            string sql = "UPDATE species SET Show_On_Web = @show_on_web WHERE Id = @id";
            using (SqlConnection cnn = CreateAndOpenSql())
            {
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@show_on_web", v);
                    cmd.Parameters.AddWithValue("@id", id);

                   
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EdditSpeciesEnclosure(Guid id, Enclosure? enclosure)
        {
            string sql = "UPDATE species SET Enclosure_id = @enclosure_id WHERE Id = @id";
            using (SqlConnection cnn = CreateAndOpenSql())
            {
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    SqlParameter enclosureIdParam = new SqlParameter("@enclosure_id", SqlDbType.UniqueIdentifier);
                    enclosureIdParam.Value = (object)enclosure?.Id ?? DBNull.Value;
                    cmd.Parameters.Add(enclosureIdParam);

                    cmd.Parameters.AddWithValue("@id", id);

                    
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void EdditSpeciesIncubationTime(Guid id, int v)
        {
            string sql = "UPDATE species SET Incubationtime = @incubation_time WHERE Id = @id";
            using (SqlConnection cnn = CreateAndOpenSql())
            {
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@incubation_time", v);
                    cmd.Parameters.AddWithValue("@id", id);

                    
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EdditSpeciesLifeSpan(Guid id, int v)
        {
            string sql = "UPDATE species SET Lifespan = @lifespan WHERE Id = @id";
            using (SqlConnection cnn = CreateAndOpenSql())
            {
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@lifespan", v);
                    cmd.Parameters.AddWithValue("@id", id);

                    
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EdditSpeciesShowStatus(Guid id, bool v)
        {
            string sql = "UPDATE species SET Show_On_Web = @show_on_web WHERE Id = @id";
            using (SqlConnection cnn = CreateAndOpenSql())
            {
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@show_on_web", v);
                    cmd.Parameters.AddWithValue("@id", id);

                    
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EdditSpeciesSize(Guid id, int v)
        {
            string sql = "UPDATE species SET Size = @size WHERE Id = @id";
            using (SqlConnection cnn = CreateAndOpenSql())
            {
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@size", v);
                    cmd.Parameters.AddWithValue("@id", id);

                    
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EdditSpeciesSpeed(Guid id, int v)
        {
            string sql = "UPDATE species SET Species_Speed = @species_speed WHERE Id = @id";
            using (SqlConnection cnn = CreateAndOpenSql())
            {
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@species_speed", v);
                    cmd.Parameters.AddWithValue("@id", id);

                    
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EdditSpeciesWeight(Guid id, int v)
        {
            string sql = "UPDATE species SET Weight = @weight WHERE Id = @id";
            using (SqlConnection cnn = CreateAndOpenSql())
            {
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@weight", v);
                    cmd.Parameters.AddWithValue("@id", id);

                    
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EditEnclosure(Guid id, Enclosure enclosure)
        {
            string sql = "UPDATE enclosure SET Enclosure_name = @enclosure_name WHERE Id = @id";
            using (SqlConnection cnn = CreateAndOpenSql())
            {
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@enclosure_name", enclosure.Name);
                    cmd.Parameters.AddWithValue("@id", id);

                    
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EditEndangered(Guid id, Endangered endangered)
        {
            string sql = "UPDATE species SET endangeredlevel = @endangered_level WHERE Id = @id";
            using (SqlConnection cnn = CreateAndOpenSql())
            {
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@endangered_level", (int)endangered);
                    cmd.Parameters.AddWithValue("@id", id);

                    
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void EditSpecies(Species species, Guid id)
        {
            string sql = "Update Species set Species_name = @species_name,Weight = @weight,Size = @size,Lifespan = @lifespan,Species_Speed= @species_speed,Incubationtime =@incubationtime,endangeredlevel = @endangeredlevel,Enclosure_id = @enclosure_id,Url = @url, Show_On_Web = @show_on_web where Id = @id";

            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@name", species.SpeciesName);
            cmd.Parameters.AddWithValue("@weight", species.Weight);
            cmd.Parameters.AddWithValue("@size", species.Size);
            cmd.Parameters.AddWithValue("@lifespan", species.SpeciesLifespan);
            cmd.Parameters.AddWithValue("@species_speed", species.Speed);
            cmd.Parameters.AddWithValue("@incuabtiontime", species.SpeciesIncubationTime);
            cmd.Parameters.AddWithValue("@endangeredlevel", ((int)species.SpeciesEndangeredLevel));
            cmd.Parameters.AddWithValue("@enclosure_id", species.SpeciesEnclosure.Id);
            cmd.Parameters.AddWithValue("@url", species.Url);
            cmd.Parameters.AddWithValue("@show_on_web", species.ShowOnWeb);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

		public void EditSpeciesMaxAge(Guid id, string MaxAge)
		{
			string sql = "UPDATE Species SET Max_Age = @MaxAge WHERE id = @id;";

			SqlCommand cmd = new SqlCommand(sql, cnn);

			cmd.Parameters.AddWithValue("@MaxAge", MaxAge);
			cmd.Parameters.AddWithValue("@id", id);

			cnn.Open();
			cmd.ExecuteNonQuery();
			cnn.Close();
		}

		public void EditSpeciesName(Guid id, string SpeciesName)
		{
			string sql = "UPDATE Species SET species_name = @Speciesname WHERE id = @id;";

			SqlCommand cmd = new SqlCommand(sql, cnn);

			cmd.Parameters.AddWithValue("@Speciesname", SpeciesName);
			cmd.Parameters.AddWithValue("@id", id);

			cnn.Open();
			cmd.ExecuteNonQuery();
			cnn.Close();
		}

        public List<Species> GetSpecies()
        {
            string query =
                "SELECT id, species_name, weight, size, lifespan, species_speed, incubationtime, endangeredlevel, enclosure_id, url, show_on_web, pfp_url " +
                "FROM species;";

            List<Species> speciesList = new List<Species>();

            using (SqlConnection connection = CreateAndOpenSql())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Guid speciesId = reader.GetGuid(0);
                            string name = reader.GetString(1);
                            int weight = reader.GetInt32(2);
                            int size = reader.GetInt32(3);
                            int lifespan = reader.GetInt32(4);
                            int speed = reader.GetInt32(5);
                            int incubationtime = reader.GetInt32(6);
                            Endangered endLevel = (Endangered)reader.GetInt32(7);
                            Enclosure enclosure = enclosureRepository.GetEnclosure(reader.GetGuid(8));
                            string url = reader.GetString(9);
                            bool onWeb = reader.GetBoolean(10);
                            string pfpURL = reader.GetString(11);

                            Species newSpecies = new Species(speciesId, name, weight, size, lifespan, speed, incubationtime, endLevel, enclosure, url, onWeb, pfpURL);

                            speciesList.Add(newSpecies);
                        }
                    }
                }
            }
            return speciesList;
        }

        public Species GetSpeciesByAnimalid(Guid animal_id)
        {
            string sql = "select sp.Id, sp.species_name, sp.Weight, sp.Size, sp.Lifespan, sp.Species_Speed, sp.Incubationtime, sp.endangeredlevel, sp.Url, sp.Show_On_Web, sp.Enclosure_id from Species sp" +
				" inner join Animal AS AN on AN.Species_Id = Species_Id where Animal_id = @id";

            Enclosure enclosure;
            string EnclosureQuery = "select Enclosure_id from Species where Id =@id";
            List<Species> list = new List<Species>();
            SqlCommand command = new SqlCommand(EnclosureQuery, cnn);
            SqlCommand cmd = new SqlCommand(sql, cnn);
            EnclosureRepository enclosureRepository = new EnclosureRepository();
			cmd.Parameters.AddWithValue("@id", animal_id );		
            
            cnn.Open();
			Guid Id;
			string name;
			int weight;
			int size;
			int lifespan;
			int speed;
			int incubationtime;
			Endangered endangered;
			string url;
			bool showOnWeb;



            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    Id = reader.GetGuid(0);
                    name = reader.GetString(1);
                    weight = reader.GetInt32(2);
                    size = reader.GetInt32(3);
                    lifespan = reader.GetInt32(4);
                    speed = reader.GetInt32(5);
                    incubationtime = reader.GetInt32(6);
                    endangered = ((Endangered)reader.GetInt32(7));
                    url = reader.GetString(8);
                    showOnWeb = reader.GetBoolean(9);
                }
                else
                {
                    throw new Exception("sqlquerry went  wrong");
                }
            }

			command.Parameters.AddWithValue("@id", Id);
			using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    enclosure = enclosureRepository.GetEnclosure(reader.GetGuid(0));
                }     
                else
                {
                    throw new Exception("error no enclosure for animal");
                }
            }
            cnn.Close();
            return new Species(Id, name, weight, size, lifespan, speed, incubationtime, endangered, enclosure, url);
        }
                
        

        public Species GetSpeciesByInt(Guid id)
        {
            string query = 
                "SELECT Id, species_name,Weight,Size,Lifespan,Species_Speed,Incubationtime,endangeredlevel,Url,Show_On_Web, enclosure_id, pfp_url " +
                "FROM Species WHERE Id = @id";

            Species? species = null;

            using (SqlConnection connection = CreateAndOpenSql())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Guid speciesId = reader.GetGuid(0);
                            string name = reader.GetString(1);
                            int weight = reader.GetInt32(2);
                            int size = reader.GetInt32(3);
                            int lifespan = reader.GetInt32(4);
                            int speed = reader.GetInt32(5);
                            int incubation = reader.GetInt32(6);
                            Endangered endLevel = (Endangered)reader.GetInt32(7);
                            string url = reader.GetString(8);
                            bool onWeb = reader.GetBoolean(9);
                            Enclosure enclosure = enclosureRepository.GetEnclosure(reader.GetGuid(10));
                            string pfpURL = reader.GetString(11);

                            species = new Species(speciesId, name, weight, size, lifespan, speed, incubation, endLevel, enclosure, url, onWeb, pfpURL);
                        }
                    }
                }
            }
            return species ?? throw new Exception("No Animal Found");
        }

     

        public List<Species> GetSpeciesFromEnclosure(Guid enclosure_id)
        {
            string query =
                "SELECT Id, species_name,Weight,Size,Lifespan,Species_Speed,Incubationtime,endangeredlevel, enclosure_id,Url,Show_On_Web, pfp_url " +
                "FROM species " +
                "WHERE enclosure_id = @enclosure_id;";

            List<Species> species = new List<Species>();

            using (SqlConnection connection = CreateAndOpenSql())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@enclosure_id", enclosure_id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Guid id = reader.GetGuid(0);
                            string animalName = reader.GetString(1);
                            int weight = reader.GetInt32(2);
                            int size = reader.GetInt32(3);
                            int lifespan = reader.GetInt32(4);
                            int speed = reader.GetInt32(5);
                            int incubationTime = reader.GetInt32(6);
                            Endangered endangered = (Endangered)reader.GetInt32(7);
                            Enclosure enclosure = enclosureRepository.GetEnclosure(reader.GetGuid(8));
                            string url = reader.GetString(9);
                            bool showOnWeb = reader.GetBoolean(10);
                            string pfpURL = reader.GetString(11);

                            Species newSpecies = new Species(id, animalName, weight, size, lifespan, speed, incubationTime, endangered, enclosure, url, showOnWeb, pfpURL);

                            species.Add(newSpecies);
                        }
                    }
                }
            }
            return species;
        }

     

        public List<Species> GetSpeciesFromTask(Guid task_id)
        {
            

            string sql = "SELECT s.id FROM species AS s, task_species AS ts WHERE s.id = ts.species_id AND ts.task_id = @task_id";

            List<Species> species = new List<Species>();
            List<Guid> ids = new List<Guid>();
            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.Parameters.AddWithValue("@task_id", task_id);

            cnn.Open();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    ids.Add(reader.GetGuid(0));
                }
            }
            cnn.Close();

            foreach (Guid id in ids)
            {
                species.Add(GetSpeciesByInt(id));
            }

            return species;
        }

        public List<Species> GetAllSpeciesNames()
        {
            string query =
                "SELECT id, species_name " +
                "FROM Species; ";

            List<Species> speciesList = new List<Species>();

            using (SqlConnection connection = CreateAndOpenSql())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Guid id = reader.GetGuid(0);
                            string speciesName = reader.GetString(1);

                            Species species = new Species(id, speciesName);

                            speciesList.Add(species);
                        }
                    }
                }
            }
            if (speciesList.Count == 0)
            {
                throw new NoSpeciesFoundException("No species found in the database");
            }
            return speciesList;
        }

    }
}