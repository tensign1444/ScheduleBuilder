using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.structs
{
    public class Team
    {
        public string name {get ; set;}

        public List<Coach> coaches { get; set;}

        public int ageGroup { get ; set;}

        public List<Game> games { get; set;}

        /// <summary>
        /// Creates a team object
        /// </summary>
        /// <param name="name">name of the team</param>
        /// <param name="games">list of datetime and games</param>
        public Team(string name, int ageGroup, List<Game> games, List<Coach> coaches)
        {
            this.name = name;
            this.ageGroup = ageGroup;
            this.games = games;
            this.coaches = coaches;
        }
    }
}
