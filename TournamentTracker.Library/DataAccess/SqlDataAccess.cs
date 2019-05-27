using System.Configuration;
using System.Threading.Tasks;
using TournamentTracker.Library.Models;

namespace TournamentTracker.Library.DataAccess
{
    public class SqlDataAccess : IDataAccess
    {
        private readonly string _cnnString = ConfigurationManager.ConnectionStrings["TrackerData"].ConnectionString;

        public SqlDataAccess()
        {
            System.Console.WriteLine(_cnnString);
        }

        public Task CreatePerson(Person person)
        {
            throw new System.NotImplementedException();
        }

        public Task CreatePrize(Prize prize)
        {
            throw new System.NotImplementedException();
        }

        public Task CreateTeam(Team team)
        {
            throw new System.NotImplementedException();
        }

        public Task CreateTournament(Tournament tournament)
        {
            throw new System.NotImplementedException();
        }
    }
}
