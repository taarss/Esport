using System;
using System.Collections.Generic;
using System.Text;

namespace Esport.entityLayer
{
    public class Technician : Staff
    {
        private int level;

        public Technician(int level, string name, int phoneNumber, int pay, string jobType, int id) : base(name, phoneNumber, pay, jobType, id)
        {
            this.level = level;
        }

        public int Level { get => level; set => level = value; }
    }
}
