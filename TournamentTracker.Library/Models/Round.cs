using System.Collections.Generic;

namespace TournamentTracker.Library.Models
{
    public class Round
    {
        public int Id { get; set; }

        public int RoundNumber { get; set; }

        public IEnumerable<Matchup> Matchups { get; set; }
    }
}
