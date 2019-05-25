using System.Collections.Generic;

namespace TournamentTracker.Library.Models
{
    public class Team
    {
        public int Id { get; set; }

        public string TeamName { get; set; }

        public IEnumerable<Person> TeamMembers { get; set; }
    }
}
