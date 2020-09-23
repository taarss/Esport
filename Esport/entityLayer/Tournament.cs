﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Esport.entityLayer
{
    public class Tournament
    {
        private string tournamentName;
        private List<int> teamOnePlayerIds;
        private List<int> teamTwoPlayerIds;
        private int judgeId;
        private string tournamentType;
        private int id;

        public Tournament(string tournamentName, List<int> teamOnePlayerIds, List<int> teamTwoPlayerIds, int judgeId, string tournamentType, int id)
        {
            this.TournamentName = tournamentName;
            this.TeamOnePlayerIds = teamOnePlayerIds;
            this.TeamTwoPlayerIds = teamTwoPlayerIds;
            this.JudgeId = judgeId;
            this.TournamentType = tournamentType;
            this.Id = id;
        }

        public string TournamentName { get => tournamentName; set => tournamentName = value; }
        public List<int> TeamOnePlayerIds { get => teamOnePlayerIds; set => teamOnePlayerIds = value; }
        public List<int> TeamTwoPlayerIds { get => teamTwoPlayerIds; set => teamTwoPlayerIds = value; }
        public int JudgeId { get => judgeId; set => judgeId = value; }
        public string TournamentType { get => tournamentType; set => tournamentType = value; }
        public int Id { get => id; set => id = value; }
    }
}
