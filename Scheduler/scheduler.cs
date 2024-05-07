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

        /// <summary>
        /// Initialize the coach and team list.
        /// </summary>
        /// <param name="coachesAndTeams">list of coaches and their teams. Formatted like, coachesname, age teamname, ... </param>
        private void init(List<string> coachesAndTeams)
        {
            foreach (string entry in coachesAndTeams)
            {
                String[] parts = entry.Split(',');
                string coachName = parts[0].Trim();
                List<Team> teams = new List<Team>();
                Coach coach;
                if (!coachList.Any(coach => coach.name.Equals(coachName, StringComparison.OrdinalIgnoreCase)))
                {
                    coach = new Coach(coachName);
                }else
                {
                    coach = coachList.FirstOrDefault(coach => coach.name.Equals(coachName, StringComparison.OrdinalIgnoreCase));
                }             

                for (int i = 1; i < parts.Length; i++)
                {
                    string teamInfo = parts[i].Trim();
                    int firstSpaceIndex = teamInfo.IndexOf(' ');
                    if (firstSpaceIndex > 0) 
                    {
                        string ageGroupStr = teamInfo.Substring(0, firstSpaceIndex);
                        string teamName = teamInfo.Substring(firstSpaceIndex + 1);

                        if (int.TryParse(ageGroupStr.Remove(ageGroupStr.Length - 1), out int ageGroup)) 
                        {
                            List<Coach> teamsCoaches = new List<Coach>();
                            teamsCoaches.Add(coach);
                            teams.Add(new Team(teamName, ageGroup, coaches: teamsCoaches)); 
                        }
                    }
                }           
                coachList.Add(coach);
            }
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
