namespace TournamentTracker.Library.Models
{
    public class Prize
    {
        public int Id { get; set; }

        public string PlaceName { get; set; }

        public string PlaceNumber { get; set; }

        public decimal? PrizeAmount { get; set; }

        public int? PrizePercentage { get; set; }
    }
}
