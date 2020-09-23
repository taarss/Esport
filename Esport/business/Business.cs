using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using Esport.entityLayer;
using Esport.dal;

namespace Esport.business
{
    public class Business
    {
        DatabaseHandler databaseHandler = new DatabaseHandler();
        private string connectionString = "Data Source=DESKTOP-7VJ1O7V;Initial Catalog=lolDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

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
            String query = "INSERT INTO Sponser (companyName,field,cost,playerId) VALUES (@companyName, @field, @cost, @playerId)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@companyName", companyName);
                command.Parameters.AddWithValue("@field", field);
                command.Parameters.AddWithValue("@cost", cost);
                command.Parameters.AddWithValue("@playerId", databaseHandler.GetNewestPlayerId());

                connection.Open();
                int result = command.ExecuteNonQuery();

                // Check Error
                if (result < 0)
                    MessageBox.Show("Error while inserting private customer into database");
            }
        }


        public void CreateTournament(string name, string tournamentType, List<int> team1, List<int> team2, int judgeId)
        {
            CreateTeams(team1, team2);
            int teamId = databaseHandler.GetNewestTeamId();
            String query = "INSERT INTO Tournament (name,teamOneId,teamTwoId,judgeId,tournamentType) VALUES (@name, @teamOneId, @teamTwoId, @judgeId, @tournamentType)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@teamOneId", teamId - 1);
                command.Parameters.AddWithValue("@teamTwoId", teamId);
                command.Parameters.AddWithValue("@judgeId", judgeId);
                command.Parameters.AddWithValue("@tournamentType", tournamentType);

                connection.Open();
                int result = command.ExecuteNonQuery();

                // Check Error
                if (result < 0)
                    MessageBox.Show("Error while inserting private customer into database");
            }
        }

        public void CreateTeams(List<int> team1, List<int> team2)
        {
            CreateTeam1(team1);
            CreateTeam2(team2);
        }

        private void CreateTeam1(List<int> team1)
        {
            int newTeamId = databaseHandler.GetNewestTeamId();
            String query = "INSERT INTO Team (teamId,playerId) VALUES (@teamId, @playerId)";
            foreach (var item in team1)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@teamId", newTeamId);
                    command.Parameters.AddWithValue("@playerId", item);
                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                        MessageBox.Show("Error while inserting private customer into database");
                }
            }
        }
        private void CreateTeam2(List<int> team2)
        {
            int newTeamId = databaseHandler.GetNewestTeamId();
            String query = "INSERT INTO Team (teamId,playerId) VALUES (@teamId, @playerId)";
            foreach (var item in team2)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@teamId", newTeamId);
                    command.Parameters.AddWithValue("@playerId", item);
                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                        MessageBox.Show("Error while inserting private customer into database");
                }
            }

        }
    } 
}
