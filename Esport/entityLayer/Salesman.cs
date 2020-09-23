using System;
using System.Collections.Generic;
using System.Text;

namespace Esport.entityLayer
{
    public class Salesman : Staff
    {
        private int salesmanLevel;

        public Salesman(int salesmanLevel, string name, int phoneNumber, int pay, string jobType) : base(name, phoneNumber, pay, jobType)
        {
            this.SalesmanLevel = salesmanLevel;
        }

        public int SalesmanLevel { get => salesmanLevel; set => salesmanLevel = value; }
    }
}
