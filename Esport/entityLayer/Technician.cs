using System;
using System.Collections.Generic;
using System.Text;

namespace Esport.entityLayer
{
    public class Technician : Staff
    {
        private string technicianType;

        public Technician(string technicianType, string name, int phoneNumber, int pay, string jobType, int id) : base(name, phoneNumber, pay, jobType, id)
        {
            this.TechnicianType = technicianType;
        }

        public string TechnicianType { get => technicianType; set => technicianType = value; }
    }
}
