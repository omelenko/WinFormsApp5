using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp5.Tables
{
    public class Team
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public int WinCount { get; set; }
        public int LossCount { get; set; }
        public int TieCount { get; set; }
        public int Goals { get; set; }
        public int MissedGoals { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }
}
