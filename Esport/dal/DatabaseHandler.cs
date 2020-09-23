using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows;
using Esport;
using Esport.entityLayer;

namespace Esport.dal
{
    public class DatabaseHandler
    {
        private string connectionString = "Data Source=DESKTOP-7VJ1O7V;Initial Catalog=lolDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        private DataSet resultSet = new DataSet();
        public DataSet Execute(string query)
        {
            DataSet resultSet = new DataSet();
            using (SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand(query, new SqlConnection(connectionString))))
            {
                adapter.Fill(resultSet);
            }
            return resultSet;
        }

        /// <summary>Gets the players.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public List<Player> GetPlayers()
        {
            DataSet dataSet = Execute("SELECT * FROM Player");
            DataTable customerTable = dataSet.Tables[0];
            List<Player> players = new List<Player>();
            foreach (DataRow itemRow in customerTable.Rows)
            {
                players.Add(new Player((string)itemRow["name"], (string)itemRow["ingameName"], (int)itemRow["rank"], (string)itemRow["phoneNumber"]));
            }
            return players;
        }

        public List<Judge> GetJudges()
        {
            DataSet dataSet = Execute("SELECT * FROM Judge");
            DataTable customerTable = dataSet.Tables[0];
            List<Judge> judges = new List<Judge>();
            foreach (DataRow itemRow in customerTable.Rows)
            {
                judges.Add(new Judge((int)itemRow["jugdeLevel"], (string)itemRow["name"], (int)itemRow["phoneNumber"], (int)itemRow["pay"], "judge"));
            }
            return judges;
        }


        /// <summary>Checks if the player exists.</summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public bool DoesPlayerExists(string phoneNumber)
        {
            foreach (var item in GetPlayers())
            {
                if (item.PhoneNumber == phoneNumber)
                {
                    return true;
                }
            }
            return false;
        }

        public int GetNewestPlayerId()
        {
            DataSet dataSet = Execute("SELECT * FROM Player");
            DataTable customerTable = dataSet.Tables[0];
            List<int> ids = new List<int>();
            foreach (DataRow itemRow in customerTable.Rows)
            {
                ids.Add(Convert.ToInt32((int)itemRow["id"]));
            }
            return ids.Max();
        }

        public int GetNewestTeamId()
        {
            DataSet dataSet = Execute("SELECT * FROM Team");
            DataTable customerTable = dataSet.Tables[0];
            List<int> ids = new List<int>();
            foreach (DataRow itemRow in customerTable.Rows)
            {
                ids.Add(Convert.ToInt32((int)itemRow["id"]));
            }
            return ids.Max();
        }



    }
}
