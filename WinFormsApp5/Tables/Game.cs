using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp5.Tables
{
    class Game
    {
        public int Id { get; set; }
        public Team? Team1 { get; set; }
        public Team? Team2 { get; set; }
        public int Goals1 { get; set; }
        public int Goals2 { get; set; }
        public Player? Scored {  get; set; }
        public string? Date { get; set; }
    }
}
