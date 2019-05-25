using System.Collections.Generic;

namespace TournamentTracker.Library.Models
{
    public class Matchup
    {
        /// <summary>
        /// The unique identifier for storing in the database.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The list of matchup entries which contains the information about the teams entering.
        /// </summary>
        public IEnumerable<MatchupEntry> MatchupEntries { get; set; }

        /// <summary>
        /// The id of the team that will win.
        /// </summary>
        public int WinnerId { get; set; }

        /// <summary>
        /// The team that will win this matchup.
        /// </summary>
        public Team Winner { get; set; }

        /// <summary>
        /// The round that this matchup is currently in.
        /// </summary>
        public int MatchupRound { get; set; }
    }
}
