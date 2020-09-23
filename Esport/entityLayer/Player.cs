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
        private int id;

        public Player(string name, string ingameName, int rank, string phoneNumber, int id)
        {
            this.Name = name;
            this.IngameName = ingameName;
            this.Rank = rank;
            this.PhoneNumber = phoneNumber;
            this.Id = id;
        }

        public string Name { get => name; set => name = value; }
        public string IngameName { get => ingameName; set => ingameName = value; }
        public int Rank { get => rank; set => rank = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public int Id { get => id; set => id = value; }
    }
}
