using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp5.Tables
{
    class Player
    {
        public int Id { get; set; }
        public string? TeamName { get; set; }
        public string? NameSurname {  get; set; }
        public string? Country {  get; set; }
        public int Number {  get; set; }
        public string? Position { get; set; }

        public override string ToString()
        {
            return NameSurname;
        }
    }
}
