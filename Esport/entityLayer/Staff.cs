using System;
using System.Collections.Generic;
using System.Text;

namespace Esport.entityLayer
{
    public class Staff
    {
        private string name;
        private int phoneNumber;
        private int pay;
        private string jobType;
        private int id;

        public Staff(string name, int phoneNumber, int pay, string jobType, int id)
        {
            this.Name = name;
            this.PhoneNumber = phoneNumber;
            this.Pay = pay;
            this.JobType = jobType;
            this.Id = id;
        }

        public string Name { get => name; set => name = value; }
        public int PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public int Pay { get => pay; set => pay = value; }
        public string JobType { get => jobType; set => jobType = value; }
        public int Id { get => id; set => id = value; }
    }
}
