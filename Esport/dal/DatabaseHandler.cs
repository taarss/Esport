using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Esport;
using Esport.entityLayer;

namespace Esport.dal
{
    public class DatabaseHandler
    {
        private string connectionString = "Data Source=PC-BB-5987;Initial Catalog=cleanIt;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


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
            DataSet dataSet = Execute("SELECT id FROM Player");
            DataTable customerTable = dataSet.Tables[0];
            List<int> ids = new List<int>();
            foreach (var item in customerTable.Rows)
            {
                ids.Add(Convert.ToInt32(item));
            }
            return ids.Max();

        }

    }
}
