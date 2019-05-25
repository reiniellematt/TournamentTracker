namespace TournamentTracker.Library.Models
{
    /// <summary>
    /// Represents a team that will be entering a matchup.
    /// </summary>
    public class MatchupEntry
    {
        /// <summary>
        /// The unique identifier that will be given by the database.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The unique identifier of the team that will be entering a matchup.
        /// </summary>
        public int TeamCompetingId { get; set; }

        /// <summary>
        /// The team that will be entering a matchup.
        /// </summary>
        public Team TeamCompeting { get; set; }

        /// <summary>
        /// The score of this team when the matchup this entry is in is done.
        /// </summary>
        public double Score { get; set; }

        /// <summary>
        /// The unique identifier of the parent matchup.
        /// </summary>
        public int ParentMatchupId { get; set; }

        /// <summary>
        /// The matchup this entry came from.
        /// </summary>
        public Matchup ParentMatchup { get; set; }

    }
}
