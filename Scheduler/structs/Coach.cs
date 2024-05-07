using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.structs
{
    /// <summary>
    /// Object for a coach,name, and teams
    /// </summary>
    public class Coach
    {
        public string name { get; set; }
        public List<Team> teams { get; set; }

        /// <summary>
        /// Constructor for a coach
        /// </summary>
        /// <param name="name">name of the coach</param>
        /// <param name="teams">teams the coach is coaching</param>
        public Coach(string name, List<Team>? teams = null)
        {
            this.name = name;
            this.teams = teams;
        }

    }
}
