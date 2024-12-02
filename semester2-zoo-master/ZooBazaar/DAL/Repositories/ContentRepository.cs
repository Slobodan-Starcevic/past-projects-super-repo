using BLL.Interfaces.Repositories;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ContentRepository : BaseRepository, IContentRepository
    {
        public List<Content> GetAnimalContents(Guid animal_id)
        {
            string sql = "SELECT c.id, c.Web_Order, c.title, c.Text, c.image_url " +
                         "FROM content AS c, animal_content AS ac " +
                         "WHERE ac.animal_id = @animal_id AND ac.content_id = c.id;";

            IAnimalRepository animalRepository = new AnimalRepository();
            Animal animal = animalRepository.GetAnimal(animal_id);
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@animal_id", animal_id);

            Guid id; int order;
            string title; string body; string image_url;
            List<Content> contents = new List<Content>();

            cnn.Open();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    id = reader.GetGuid(0);
                    order = reader.GetInt32(1);
                    title = reader.GetString(2);
                    body = reader.GetString(3);
                    image_url = reader.GetString(4);

                    var content = new Content(id, animal,((WebContentOrder)order),title,body, image_url);

                    int index = order;
                    if (index >= contents.Count)
                    {
                        contents.Add(content);
                    }
                    else
                    {
                        contents.Insert(index, content);
                    }
                }
            }

            cnn.Close();
            return contents;
        }

        public List<Content> GetSpeciesContents(Guid species_id)
        {
            string sql = "SELECT c.id, c.Web_Order, c.title, c.Text, c.image_url " +
                         "FROM content AS c, species_content AS sc " +
                         "WHERE c.id = sc.content_id AND sc.species_id = @species_id";

            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@species_id", species_id);

            ISpeciesRepository species_repository = new SpeciesRepository();
            Species species = species_repository.GetSpeciesByInt(species_id);

            Guid id; int order;
            string title; string body; string image_url;
            List<Content> contents = new List<Content>();

            cnn.Open();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    id = reader.GetGuid(0);
                    order = reader.GetInt32(1);
                    title = reader.GetString(2);
                    body = reader.GetString(3);
                    image_url = reader.GetString(4);

                    var content = new Content(species,((WebContentOrder)order),title,body,image_url);

                    int index = order;
                    if (index >= contents.Count)
                    {
                        contents.Add(content);
                    }
                    else
                    {
                        contents.Insert(index, content);
                    }
                }
            }

            cnn.Close();
            return contents;
        }

        public List<Content> GetEnclosureContents(Guid enclosure_id)
        {
            string sql = "SELECT c.id, c.Web_Order, c.title, c.Text, c.image_url " +
                         "FROM content AS c, enclosure_content AS ec " +
                         "WHERE c.id = ec.content_id AND ec.enclosure_id = @enclosure_id";

            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@enclosure_id", enclosure_id);

            IEnclosureRepository enclosureRepository = new EnclosureRepository();
            Enclosure enclosure = enclosureRepository.GetEnclosure(enclosure_id);

            Guid id; int order;
            string title; string body; string image_url;
            List<Content> contents = new List<Content>();

            cnn.Open();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    id = reader.GetGuid(0);
                    order = reader.GetInt32(1);
                    title = reader.GetString(2);
                    body = reader.GetString(3);
                    image_url = reader.GetString(4);

                    var content = new Content(enclosure, ((WebContentOrder)order), title, body, image_url);

                    int index = order;
                    if (index >= contents.Count)
                    {
                        contents.Add(content);
                    }
                    else
                    {
                        contents.Insert(index, content);
                    }
                }
            }

            cnn.Close();
            return contents;
        }

        public void UpdateAnimalContent(Guid animal_id, Content content)
        {
            string sql = "UPDATE content SET content_order = @content_order, title = @title, body = @body, image_url = @image_url " +
                         "WHERE content.id = animal_content.content_id AND animal_content.animal_id = @animal_id;";

            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@animal_id", animal_id);
            cmd.Parameters.AddWithValue("@content_order", content.Order);
            cmd.Parameters.AddWithValue("@title", content.Title);
            cmd.Parameters.AddWithValue("@body", content.Text);
            cmd.Parameters.AddWithValue("@image_url", content.ImageUrl);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void UpdateSpeciesContent(Guid species_id, Content content)
        {
            string sql = "UPDATE content SET content_order = @content_order, title = @title, body = @body, image_url = @image_url " +
                         "WHERE content.id = species_content.content_id AND species_content.species_id = @species_id;";

            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@species_id", species_id);
            cmd.Parameters.AddWithValue("@content_order", content.Order);
            cmd.Parameters.AddWithValue("@title", content.Title);
            cmd.Parameters.AddWithValue("@body", content.Text);
            cmd.Parameters.AddWithValue("@image_url", content.ImageUrl);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void UpdateEnclosureContent(Guid enclosure_id, Content content)
        {
            string sql = "UPDATE content SET content_order = @content_order, title = @title, body = @body, image_url = @image_url " +
                         "WHERE content.id = enclosure_content.content_id AND enclosure_content.enclosure_id = @enclosure_id;";

            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@enclosure_id", enclosure_id);
            cmd.Parameters.AddWithValue("@content_order", content.Order);
            cmd.Parameters.AddWithValue("@title", content.Title);
            cmd.Parameters.AddWithValue("@body", content.Text);
            cmd.Parameters.AddWithValue("@image_url", content.ImageUrl);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void DeleteContent(Guid content_id)
        {
            string sql = "DELETE FROM animal_content WHERE content_id = @content_id; " +
                         "DELETE FROM species_content WHERE content_id = @content_id; " +
                         "DELETE FROM enclosure_content WHERE content_id = @content_id; " +
                         "DELETE FROM content WHERE id = @content_id;";

            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.Parameters.AddWithValue("@content_id", content_id);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void CreateAnimalContent(Content content, Guid animal_id)
        {
            Guid content_id = CreateContent(content);

            string sql = "INSERT INTO animal_content (animal_id, content_id) VALUES (@animal, @content);";

            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.Parameters.AddWithValue("@animal", animal_id);
            cmd.Parameters.AddWithValue("@content", content_id);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void CreateSpeciesContent(Content content, Guid species_id)
        {
            Guid content_id = CreateContent(content);

            string sql = "INSERT INTO species_content (species_id, content_id) VALUES (@species, @content);";

            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.Parameters.AddWithValue("@species", species_id);
            cmd.Parameters.AddWithValue("@content", content_id);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void CreateEnclosureContent(Content content, Guid enclosure_id)
        {
            Guid content_id = CreateContent(content);

            string sql = "INSERT INTO enclosure_content (enclosure_id, content_id) VALUES (@enclosure, @content);";

            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.Parameters.AddWithValue("@enclosure", enclosure_id);
            cmd.Parameters.AddWithValue("@content", content_id);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        private Guid CreateContent(Content content)
        {
            string sql = "INSERT INTO content (Id,Web_Order, Title, Text, Image_Url) " +
                         "VALUES (@id,@order, @title, @body, @image)";

            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@id", content.Id);
            cmd.Parameters.AddWithValue("@order", content.Order);
            cmd.Parameters.AddWithValue("@title", content.Title);
            cmd.Parameters.AddWithValue("@body", content.Text);
            cmd.Parameters.AddWithValue("@image", content.ImageUrl);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

            return content.Id;
        }

		public void UpdateContentTitle(Guid content_Id, string text)
		{
			string sql = "UPDATE content SET title = @title " +
					   "WHERE content.id =  @content_ID;";

			SqlCommand cmd = new SqlCommand(sql, cnn);
			cmd.Parameters.AddWithValue("@content_ID", content_Id);
			cmd.Parameters.AddWithValue("@title", text);

			cnn.Open();
			cmd.ExecuteNonQuery();
			cnn.Close();
		}

		public void UpdateContenttext(Guid content_Id, string text)
		{
			string sql = "UPDATE content SET text = @body " +
					   "WHERE content.id =  @content_ID;";

			SqlCommand cmd = new SqlCommand(sql, cnn);
			cmd.Parameters.AddWithValue("@content_ID", content_Id);
			cmd.Parameters.AddWithValue("@body", text);

			cnn.Open();
			cmd.ExecuteNonQuery();
			cnn.Close();
		}

		public void UpdateContentPhotoUrl(Guid content_Id, string text)
		{
			string sql = "UPDATE content SET image_url = @image_url " +
					   "WHERE content.id =  @content_ID;";

			SqlCommand cmd = new SqlCommand(sql, cnn);
			cmd.Parameters.AddWithValue("@content_ID", content_Id);
			cmd.Parameters.AddWithValue("@image_url",text);

			cnn.Open();
			cmd.ExecuteNonQuery();
			cnn.Close();
		}

        public void UpdateAnimalContent(WebContentOrder order, string title, string contentText, string photoUrl, Guid animal_id)
        {
            string sql = @"UPDATE content
                   SET Web_order = @order,
                       title = @title,
                       text = @text,
                       image_url = @image
                   FROM content c
                   INNER JOIN animal_content ac ON ac.content_id = c.id
                   WHERE ac.animal_id = @animal_id;";

            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@order", order);
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@text", contentText);
                    cmd.Parameters.AddWithValue("@image", photoUrl);
                    cmd.Parameters.AddWithValue("@animal_id", animal_id);

                    cnn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void UpdateSpeciesContent(WebContentOrder order, string title, string contentText, string photoUrl, Guid species_id)
        {
            string sql = @"UPDATE content
                   SET Web_order = @order,
                       title = @title,
                       text = @text,
                       image_url = @image
                   FROM content c
                   INNER JOIN species_content sc ON sc.content_id = c.id
                   WHERE sc.species_id = @species_id;";

            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@order", order);
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@text", contentText);
                    cmd.Parameters.AddWithValue("@image", photoUrl);
                    cmd.Parameters.AddWithValue("@species_id", species_id);

                    cnn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateEnclosureContent(WebContentOrder order, string title, string contentText, string photoUrl, Guid enclosure_id)
        {
            string sql = @"UPDATE content
                   SET Web_order = @order,
                       title = @title,
                       text = @text,
                       image_url = @image
                   FROM content c
                   INNER JOIN enclosure_content ec ON ec.content_id = c.id
                   WHERE ec.enclosure_id = @enclosure_id;";

            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@order", order);
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@text", contentText);
                    cmd.Parameters.AddWithValue("@image", photoUrl);
                    cmd.Parameters.AddWithValue("@enclosure_id", enclosure_id);

                    cnn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void EdditContentOrder(Guid contentId, WebContentOrder wCO)
        {
            string sql = "UPDATE content SET Web_order = @order WHERE id = @id";

            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@order", wCO);
                    cmd.Parameters.AddWithValue("@id", contentId);

                    cnn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
