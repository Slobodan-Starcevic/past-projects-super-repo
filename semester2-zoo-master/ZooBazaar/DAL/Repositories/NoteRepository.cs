using BLL.Interfaces.Repositories;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class NoteRepository : BaseRepository, INoteRepository
    {
        private readonly EmployeeRepository _employeeRepository;
        private readonly SpeciesRepository _speciesRepository;

        public NoteRepository()
        {
            _employeeRepository = new EmployeeRepository();
            _speciesRepository = new SpeciesRepository();
        }

        public void Create(Note note)
        {
            string sql = "INSERT INTO note (id,employee_id, description, archive) " +
                         "VALUES (@id,@employee_id, @description, @archive); SELECT SCOPE_IDENTITY()";

            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@id", note.Id);
            cmd.Parameters.AddWithValue("@employee_id", note.Employee.Id);
            cmd.Parameters.AddWithValue("@description", note.Text);
            cmd.Parameters.AddWithValue("@archive", 0);

            cnn.Open();
            int content_id = Convert.ToInt32(cmd.ExecuteScalar());

            foreach (Animal animal in note.Species)
            {
                sql = "INSERT INTO note_animal (animal_id, note_id) VALUES (@animal_id, @note_id); ";

                cmd = new SqlCommand(sql, cnn);

                cmd.Parameters.AddWithValue("@animal_id", animal.AnimalId);
                cmd.Parameters.AddWithValue("@note_id", content_id);

                cmd.ExecuteNonQuery();
            }

            cnn.Close();
        }

        public void Delete(Guid id)
        {
            string sql = "DELETE FROM note WHERE id = @id";

            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.Parameters.AddWithValue("@id", id);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void Edit(Guid id, string newDescription)
        {
            string sql = "UPDATE note SET description = @description WHERE id = @id;";

            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@description", newDescription);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void Edit(Guid id, List<Animal> animals)
        {
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                cnn.Open();
                string deleteNoteAnimalsSql = "DELETE FROM note_animal WHERE note_id = @note_id";
                using (SqlCommand deleteNoteAnimalsCmd = new SqlCommand(deleteNoteAnimalsSql, cnn))
                {
                    deleteNoteAnimalsCmd.Parameters.AddWithValue("@note_id", id);
                    deleteNoteAnimalsCmd.ExecuteNonQuery();
                }

               
                string insertNoteAnimalsSql = "INSERT INTO note_animal (animal_id, note_id) VALUES (@animal_id, @note_id)";
                using (SqlCommand insertNoteAnimalsCmd = new SqlCommand(insertNoteAnimalsSql, cnn))
                {
                    SqlParameter animalIdParam = insertNoteAnimalsCmd.Parameters.Add("@animal_id", SqlDbType.UniqueIdentifier);
                    SqlParameter noteIdParam = insertNoteAnimalsCmd.Parameters.Add("@note_id", SqlDbType.Int);

                    foreach (Animal animal in animals)
                    {
                        animalIdParam.Value = animal.AnimalId;
                        noteIdParam.Value = id;
                        insertNoteAnimalsCmd.ExecuteNonQuery();
                    }
                }

                cnn.Close();
            }
        }

        public List<Note> GetAllNotes()
        {
            string query =
                "SELECT n.id, n.employee_id, n.description, ns.species_id, n.archive " +
                "FROM note n " +
                "LEFT JOIN note_species ns ON n.id = ns.note_id";

            List<Note> notes = new List<Note>();

            using (SqlConnection connection = CreateAndOpenSql())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Guid id = reader.GetGuid(0);
                            Employee emp = _employeeRepository.GetEmployeeById(reader.GetGuid(1));
                            string text = reader.GetString(2);
                            bool archived = reader.GetBoolean(4);

                            if (!reader.IsDBNull(3))
                            {
                                Species sp = _speciesRepository.GetSpeciesByInt(reader.GetGuid(3));
                                List<Species> species = new List<Species>();
                                species.Add(sp);

                                Note newNote = new Note(id, text, emp, species, archived);

                                notes.Add(newNote);
                            }
                            else
                            {
                                Note newNote = new Note(id, text, emp, archived);

                                notes.Add(newNote);
                            }
                        }
                    }
                }
            }
            return notes;
        }

        public Note GetNote(Guid id)
        {
            AnimalRepository animalRepository = new AnimalRepository();
            EmployeeRepository employeeRepository = new EmployeeRepository();

            Note note = null;

            Guid _id = Guid.Empty;
            Guid employeeId = Guid.Empty;
            string description = string.Empty;
            bool archived = false;
            List<Guid>AnimalIds = new List<Guid>();

            string AnimalQuery = "na.animal_id " +
                         "FROM note AS n, note_animal AS na " +
                         "WHERE n.id = na.note_id AND n.id = @id;";



            string sql = "SELECT n.id, n.employee_id, n.description, n.archive" +
                         "FROM note AS n, note_animal AS na " +
                         "WHERE n.id = na.note_id AND n.id = @id;";

            SqlCommand cmd2 = new SqlCommand(AnimalQuery, cnn);
            SqlCommand cmd = new SqlCommand(sql, cnn);


            cmd2.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@id", id);

            cnn.Open();
            using (var reader = cmd2.ExecuteReader())
            {
                while (reader.Read())
                {
                    AnimalIds.Add(reader.GetGuid(0));
                }
            }
            List<Species> animals = new List<Species>();

            foreach (var Animalid in AnimalIds)
            {
                animals.Add(animalRepository.GetAnimal(Animalid));
            }


                cnn.Open();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    _id = reader.GetGuid(0);
                    employeeId = reader.GetGuid(1);
                    description = reader.GetString(2);
                    archived = reader.GetBoolean(3);
                }
            }
            cnn.Close();
            Employee employee = employeeRepository.GetEmployeeID(employeeId);

            note = new Note(id, description, employee, animals, archived);


            return note;
        }

        public List<Note> GetEmployeeNotes(Guid employee_id)
        {
            List<Note> notes = new List<Note>();
            List<Guid> NoteIDs = new List<Guid>();

            string sql = "select Id from Note where Employee_id = @employee_id";

            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.Parameters.AddWithValue("@employee_id", employee_id);
            try
            {
				cnn.Open();
				using (var reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
                      NoteIDs.Add(reader.GetGuid(0));
                    }
				}

			}
            catch(Exception ex)
            {
            }
            finally {

                cnn.Close();
             
                
            }
            foreach (var NoteId in NoteIDs)
            {
                notes.Add(GetNote(NoteId));
            }
            return notes;
        }

        public void CreateNote(Note note)
        {
            if(note.SpeciesId == Guid.Empty)
            {
                string query =
                "INSERT INTO note (id, employee_id, description, archive) " +
                "VALUES (@note_id, @employee_id, @description, @archive);";

                using (SqlConnection connection = CreateAndOpenSql())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@note_id", note.Id);
                        command.Parameters.AddWithValue("@employee_id", note.EmployeeId);
                        command.Parameters.AddWithValue("@description", note.Text);
                        command.Parameters.AddWithValue("@archive", 0);

                        WriteToDatabase(command);
                    }
                }
            }
            else
            {
                string query =
                    "INSERT INTO note (id, employee_id, description, archive) " +
                    "VALUES (@note_id, @employee_id, @description, @archive);" +
                    "INSERT INTO note_species (note_id, species_id) " +
                    "VALUES (@note_id, @species_id);";

                using (SqlConnection connection = CreateAndOpenSql())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@note_id", note.Id);
                        command.Parameters.AddWithValue("@employee_id", note.EmployeeId);
                        command.Parameters.AddWithValue("@description", note.Text);
                        command.Parameters.AddWithValue("@species_id", note.SpeciesId);
                        command.Parameters.AddWithValue("@archive", 0);

                        WriteToDatabase(command);
                    }
                }
            }
        }

        public void ArchiveNote(Guid id)
        {
            string query =
                "UPDATE [note] " +
                "SET [archive] = 1 " +
                "WHERE id = @id;";

            using (SqlConnection connection = CreateAndOpenSql())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
