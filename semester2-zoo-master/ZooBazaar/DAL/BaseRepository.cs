using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BaseRepository
    {
        const string connectionString = @"Data Source =mssqlstud.fhict.local;Database=dbi516551_zoobazaar;User Id=dbi516551_zoobazaar;Password=group1";
        protected SqlConnection cnn = new SqlConnection(connectionString);
        SqlCommand cmd;
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlDataReader sqlDataReader;

        protected SqlConnection CreateAndOpenSql()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        protected void WriteToDatabase(SqlCommand command)
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                adapter.InsertCommand = command;
                adapter.InsertCommand.ExecuteNonQuery();
            }
        }

        public void DeleteToDatabase(string query)
        {
                cnn.Open();
                string sql = query;
                cmd = new SqlCommand(sql, cnn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cnn.Close();
        }

        public void DeleteToDatabase(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.Parameters.AddRange(parameters);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        protected void UpdateInDatabase(SqlCommand command)
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                adapter.UpdateCommand = command;
                adapter.UpdateCommand.ExecuteNonQuery();
            }
        }

        public SqlDataReader OpenConnection(string query)
        {
            cnn.Open();
            string sql = query;
            cmd = new SqlCommand(sql, cnn);
            sqlDataReader = cmd.ExecuteReader();
            return sqlDataReader;

        }
        public void CloseConnection() 
        {
           sqlDataReader.Close();
            cmd.Dispose();
           cnn.Close() ;
        }
        public string ConnectionString { get { return cnn.ConnectionString; } }
    }
    
}

