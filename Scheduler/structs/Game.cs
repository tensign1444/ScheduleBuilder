using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.structs
{
    /// <summary>
    /// Game object
    /// </summary>
    public class Game
    {
        public string homeTeam {  get; set; }

        public string awayTeam { get; set; }

        public string clinicName { get; set; }

        public int rinkNumber { get; set; }

        public DateTime dateTime { get; set; }

        public bool isGame {  get; set; }

        /// <summary>
        /// Constructor for a game
        /// </summary>
        /// <param name="rinkNumber">the number the rink is on</param>
        /// <param name="dateTime">time and date of the event</param>
        /// <param name="isGame">if this is a game</param>
        /// <param name="homeTeam">home team name</param>
        /// <param name="awayTeam">away team name</param>
        /// <param name="clinicName">clinic name</param>
        public Game(int rinkNumber, DateTime dateTime, bool isGame = true, string? homeTeam = default, string? awayTeam = default, string? clinicName = default)
        {
            this.isGame = isGame;
            if (isGame)
            {
                this.homeTeam = homeTeam;
                this.awayTeam = awayTeam;
            }
            else
            {
                this.clinicName = clinicName;
            }

            this.rinkNumber = rinkNumber;
            this.dateTime = dateTime;
        }
    }
}
