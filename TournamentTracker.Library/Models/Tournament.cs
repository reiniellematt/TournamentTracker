using System.Collections.Generic;

namespace TournamentTracker.Library.Models
{
    public class Tournament
    {
        public int Id { get; set; }

        public string TournamentName { get; set; }

        public IEnumerable<Team> EnteredTeams { get; set; }

        public IEnumerable<IEnumerable<Matchup>> Rounds { get; set; }

        public IEnumerable<Prize> Prizes { get; set; }
    }
}
