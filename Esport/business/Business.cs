using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using Esport.entityLayer;

namespace Esport.business
{
    public class Business
    {
        private Sponser tempSponser;
        private string connectionString = "Data Source=DESKTOP-7VJ1O7V;Initial Catalog=cleanIt;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void CreatePlayer(string name, string ingameName, int rank, string phoneNumber, int sponserId)
        {
            String query = "INSERT INTO Player (name,ingameName,rank,phoneNumber) VALUES (@name, @ingameName, @rank, @phoneNumber)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@ingameName", ingameName);
                command.Parameters.AddWithValue("@rank", rank);
                command.Parameters.AddWithValue("@phoneNumber", phoneNumber);

                connection.Open();
                int result = command.ExecuteNonQuery();

                // Check Error
                if (result < 0)
                    MessageBox.Show("Error while inserting private customer into database");
            }
        }

        public void CreateSponser(string companyName, string field, int cost)
        {
            String query = "INSERT INTO Sponser (companyName,field,playerName,cost,playerId) VALUES (@companyName, @field, @playerName, @cost, @playerId)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@companyName", companyName);
                command.Parameters.AddWithValue("@field", field);
                command.Parameters.AddWithValue("@playerName", );
                command.Parameters.AddWithValue("@phoneNumber", phoneNumber);

                connection.Open();
                int result = command.ExecuteNonQuery();

                // Check Error
                if (result < 0)
                    MessageBox.Show("Error while inserting private customer into database");
            }

        
    }
}
