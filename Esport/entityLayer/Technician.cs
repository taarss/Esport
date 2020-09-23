using System;
using System.Collections.Generic;
using System.Text;

namespace Esport.entityLayer
{
    public class Technician : Staff
    {
        private string technicianType;

        public Technician(string technicianType, string name, int phoneNumber, int pay, string jobType) : base(name, phoneNumber, pay, jobType)
        {
            this.TechnicianType = technicianType;
        }

        public string TechnicianType { get => technicianType; set => technicianType = value; }
    }
}
