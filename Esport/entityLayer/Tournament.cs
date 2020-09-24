using System;
using System.Collections.Generic;
using System.Text;

namespace Esport.entityLayer
{
    public class Tournament
    {
        //Fields
        /* type that represents a memory location for storing a value. 
         * Fields are used to store data that must be accessible to multiple methods of a class 
         * and available throughout the lifetime of an object.*/
        private string tournamentName;
        private List<int> teamOnePlayerIds;
        private List<int> teamTwoPlayerIds;
        private int judgeId;
        private string tournamentType;
        private int id;

        //Constructor
        /*A special method of the class that is automatically invoked when an instance 
         * of the class is created is called a constructor. 
         * The main use of constructors is to initialize the private fields of the class while 
         * creating an instance for the class.*/
        public Tournament(string tournamentName, List<int> teamOnePlayerIds, List<int> teamTwoPlayerIds, int judgeId, string tournamentType, int id)
        {
            this.TournamentName = tournamentName;
            this.TeamOnePlayerIds = teamOnePlayerIds;
            this.TeamTwoPlayerIds = teamTwoPlayerIds;
            this.JudgeId = judgeId;
            this.TournamentType = tournamentType;
            this.Id = id;
        }
        //Properties
        /*Properties enable a class to expose a public way of getting 
         * and setting values, while hiding implementation or verification code*/
        public string TournamentName { get => tournamentName; set => tournamentName = value; }
        public List<int> TeamOnePlayerIds { get => teamOnePlayerIds; set => teamOnePlayerIds = value; }
        public List<int> TeamTwoPlayerIds { get => teamTwoPlayerIds; set => teamTwoPlayerIds = value; }
        public int JudgeId { get => judgeId; set => judgeId = value; }
        public string TournamentType { get => tournamentType; set => tournamentType = value; }
        public int Id { get => id; set => id = value; }
    }
}
