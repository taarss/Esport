using System;
using System.Collections.Generic;
using System.Text;

namespace Esport.entityLayer
{
    public class Sponser
    {
        private string companyName;
        private string field;
        private int playerId;
        private string playerName;
        private int cost;

        public Sponser(string companyName, string field, int playerId, string playerName, int cost)
        {
            this.CompanyName = companyName;
            this.Field = field;
            this.PlayerId = playerId;
            this.PlayerName = playerName;
            this.Cost = cost;
        }

        public string CompanyName { get => companyName; set => companyName = value; }
        public string Field { get => field; set => field = value; }
        public int PlayerId { get => playerId; set => playerId = value; }
        public string PlayerName { get => playerName; set => playerName = value; }
        public int Cost { get => cost; set => cost = value; }
    }
}
