using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using TournamentTracker.Library.Models;

namespace TournamentTracker.Library.DataAccess
{
    public class SqlDataAccess : IDataAccess
    {
        private readonly string _cnnString = ConfigurationManager.ConnectionStrings["TrackerData"].ConnectionString;
        public Task<int> CreatePerson(Person person)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> CreatePrize(Prize prize, bool isPrizeAmount)
        {
            var p = new DynamicParameters();
            p.Add("@PlaceName", prize.PlaceName);
            p.Add("@PlaceNumber", prize.PlaceNumber);
            p.Add("@PrizeAmount", prize.PrizeAmount);

            string commandString = string.Empty;
            if (isPrizeAmount)
            {
                p.Add("@PrizeAmount", prize.PrizeAmount);

                commandString = "INSERT INTO Prize(PlaceName, PlaceNumber, PrizeAmount) VALUES (@PlaceName, @PlaceNumber, @PrizeAmount); SELECT last_insert_rowid();";
            }
            else
            {
                p.Add("@PrizePercentage", prize.PrizePercentage);

                commandString = "INSERT INTO Prize(PlaceName, PlaceNumber, PrizePercentage) VALUES (@PlaceName, @PlaceNumber @PrizePercentage); SELECT last_insert_rowid();";
            }

            using (IDbConnection cnn = new SQLiteConnection(_cnnString))
            {
                var id = await cnn.QueryAsync<int>(commandString, p);

                return id.FirstOrDefault();
            }
        }

        public Task<int> CreateTeam(Team team)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> CreateTournament(Tournament tournament)
        {
            throw new System.NotImplementedException();
        }
    }
}
