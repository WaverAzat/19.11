using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW10
{
    public class Team
    {
        public int Points { get; set; }
        public string Name { get; set; }
        public Team(string name)
        {
            Name = name;
        }
    }
}