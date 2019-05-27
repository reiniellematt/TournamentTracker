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
        public async Task<int> CreatePerson(Person person)
        {
            string commandString = "INSERT INTO Person(FirstName, LastName, EmailAddress, ContactNumber) VALUES (@FirstName, @LastName, @EmailAddress, @ContactNumber);SELECT last_insert_rowid();";

            using (IDbConnection cnn = new SQLiteConnection(_cnnString))
            {
                var id = await cnn.QueryAsync<int>(commandString, person);
                return id.FirstOrDefault();
            }
        }

        public async Task<int> CreatePrize(Prize prize, bool isPrizeAmount)
        {
            string commandString = string.Empty;
            if (isPrizeAmount)
            {
                commandString = "INSERT INTO Prize(PlaceName, PlaceNumber, PrizeAmount) VALUES (@PlaceName, @PlaceNumber, @PrizeAmount); SELECT last_insert_rowid();";
            }
            else
            {
                commandString = "INSERT INTO Prize(PlaceName, PlaceNumber, PrizePercentage) VALUES (@PlaceName, @PlaceNumber, @PrizePercentage); SELECT last_insert_rowid();";
            }

            using (IDbConnection cnn = new SQLiteConnection(_cnnString))
            {
                var id = await cnn.QueryAsync<int>(commandString, prize);

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
