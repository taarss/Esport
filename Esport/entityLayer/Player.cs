using System;
using System.Collections.Generic;
using System.Text;

namespace Esport.entityLayer
{
    public class Player
    {
        private string name;
        private string ingameName;
        private int rank;
        private string phoneNumber;
        private int sponserId;

        public Player(string name, string ingameName, int rank, string phoneNumber, int sponserId)
        {
            this.Name = name;
            this.IngameName = ingameName;
            this.Rank = rank;
            this.PhoneNumber = phoneNumber;
            this.SponserId = sponserId;
        }

        public string Name { get => name; set => name = value; }
        public string IngameName { get => ingameName; set => ingameName = value; }
        public int Rank { get => rank; set => rank = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public int SponserId { get => sponserId; set => sponserId = value; }
    }
}
