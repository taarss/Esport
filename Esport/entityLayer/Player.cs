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

        public Player(string name, string ingameName, int rank, string phoneNumber)
        {
            this.Name = name;
            this.IngameName = ingameName;
            this.Rank = rank;
            this.PhoneNumber = phoneNumber;
        }

        public string Name { get => name; set => name = value; }
        public string IngameName { get => ingameName; set => ingameName = value; }
        public int Rank { get => rank; set => rank = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
    }
}
