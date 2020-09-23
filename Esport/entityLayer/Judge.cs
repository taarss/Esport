using System;
using System.Collections.Generic;
using System.Text;

namespace Esport.entityLayer
{
    public class Judge : Staff
    {
        private int JudgeLevel;

        public Judge(int judgeLevel, string name, int phoneNumber, int pay, string jobType) : base(name, phoneNumber, pay, jobType)
        {
            JudgeLevel1 = judgeLevel;
        }

        public int JudgeLevel1 { get => JudgeLevel; set => JudgeLevel = value; }
    }
}
