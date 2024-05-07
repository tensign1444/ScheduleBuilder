using Scheduler.structs;

namespace Scheduler
{
    /// <summary>
    /// Schedules coachs for the weekend at Great Park Ice
    /// </summary>
    public class scheduler
    {
        private List<Coach> coachList;
        private List<Team> teamList;
        private List<Game> gameList;

        public scheduler()
        {
            coachList = new List<Coach>();
            teamList = new List<Team>();
            gameList = new List<Game>();
        }

        private void init(List<string> names, List<string> teams)
        {

        }

        public void schedulePeople()
        {
            // Sort games by dateTime
            gameList.Sort((a, b) => a.dateTime.CompareTo(b.dateTime));

            // Dictionary to track the next available time for each coach
            Dictionary<Coach, DateTime> coachAvailability = new Dictionary<Coach, DateTime>();

            // Initialize coach availability
            foreach (Coach coach in coachList)
            {
                coachAvailability[coach] = DateTime.MinValue;
            }

            foreach (Game game in gameList)
            {
                if (game.isGame)
                {
                    string homeTeam = game.homeTeam;
                    string awayTeam = game.awayTeam;

                    // Assign coaches to the home team
                    assignCoachToGame(homeTeam, game, coachAvailability);
                    // Assign coaches to the away team
                    assignCoachToGame(awayTeam, game, coachAvailability);
                }
            }
        }

        private void assignCoachToGame(string teamName, Game game, Dictionary<Coach, DateTime> coachAvailability)
        {
            Team team = teamList.Find(t => t.name == teamName);
            foreach (Coach coach in team.coaches)
            {
                if (coachAvailability[coach] <= game.dateTime) // Check if the coach is available
                {
                    // Assume the coach can coach the team for this game
                    // Update the coach's next available time (add the game duration, for simplicity, assume fixed duration)
                    coachAvailability[coach] = game.dateTime.AddHours(2); // assuming each game lasts 2 hours
                    break;
                }
            }
        }


    }
}
