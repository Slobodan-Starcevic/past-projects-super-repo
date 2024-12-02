using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BLL.Interfaces.Repositories;
using BLL.Models;
using Microsoft.VisualBasic;

namespace DAL.Repositories
{
	public class EnclosureRepository : BaseRepository, IEnclosureRepository
    {
        public void CreateEnclosure(Enclosure enclosure)
        {
            string sql = "INSERT INTO Enclosure (id,name,url, show_on_web, pfp_url) VALUES(@Id,@name,@url, @show_on_web, @pfp_url)";

            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.Parameters.AddWithValue("@name", enclosure.Name);
            cmd.Parameters.AddWithValue("@Id", enclosure.Id);
            cmd.Parameters.AddWithValue("@url", enclosure.Url);
            cmd.Parameters.AddWithValue("@show_on_web", 0);
            cmd.Parameters.AddWithValue("@pfp_url", $"/media/pfp/{enclosure.Name}-pfp.png");
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

         
        }

        public void DeleteEnclosure(Guid id)
        {
            string sql = "DELETE FROM Enclosure WHERE id = @id";

            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.Parameters.AddWithValue("@id", id);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

		public void EditEnclosure(Enclosure enclosure)
		{
			string sql = "Update enclosure set Name = @Name WHERE id = @id";
			using (SqlConnection cnn = new SqlConnection(ConnectionString))
			{
				using (SqlCommand cmd = new SqlCommand(sql, cnn))
				{
					cmd.Parameters.AddWithValue("@Name", enclosure.Name);
					cmd.Parameters.AddWithValue("@id", enclosure.Id);

					cnn.Open();
					cmd.ExecuteNonQuery();
					cnn.Close();
				}
			}
		}

		public void EditShowOnWeb(Enclosure enclosure, bool showOnWeb)
        {
            string sql = "Update enclosure set Show_On_Web = @Show_On_Web WHERE id = @id";
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@Show_On_Web", showOnWeb);
                    cmd.Parameters.AddWithValue("@id", enclosure.Id);

                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
        }

        public Enclosure GetEnclosure(Guid id)
        {
            ContentRepository contentRepository = new ContentRepository();
            SpeciesRepository speciesRepository = new SpeciesRepository();
            Enclosure enclosure = null;

            string sql = "SELECT e.id,e.name,e.url, e.show_on_web, e.pfp_url FROM enclosure AS e WHERE e.id = @id";


			SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.Parameters.AddWithValue("@id", id);

            //List<Species> species = speciesRepository.GetSpeciesFromEnclosure(id);
            //List<Content> contents = contentRepository.GetEnclosureContents(id); 

            cnn.Open();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Guid Id = reader.GetGuid(0);
                    string name = reader.GetString(1);
                    string url = reader.GetString(2);
                    bool showOnWeb = reader.GetBoolean(3);
                    string pfp = reader.GetString(4);
                    enclosure = new Enclosure(Id,name,url, showOnWeb, pfp);
                }
            }
            cnn.Close();

            if (enclosure == null)
            {
                throw new Exception("GetEnclosure method failed!");
            }

            return enclosure;
        }

        public List<Enclosure> GetEnclosures()
        {
            string query =
                "SELECT id, name, url, show_on_web, pfp_url " +
                "FROM enclosure;";

            List<Enclosure> enclosures = new List<Enclosure>();

            using (SqlConnection connection = CreateAndOpenSql())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Guid id = reader.GetGuid(0);
                            string name = reader.GetString(1);
                            string url = reader.GetString(2);
                            bool onWeb = reader.GetBoolean(3);
                            string pfpURL = reader.GetString(4);

                            Enclosure enclosure = new Enclosure(id, name, url, onWeb, pfpURL);

                            enclosures.Add(enclosure);
                        }
                    }
                }
            }
            return enclosures;
        }
    }

}

