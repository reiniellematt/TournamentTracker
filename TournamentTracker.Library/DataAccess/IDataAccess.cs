using System.Threading.Tasks;
using TournamentTracker.Library.Models;

namespace TournamentTracker.Library.DataAccess
{
    public interface IDataAccess
    {
        Task<int> CreatePrize(Prize prize, bool isPrizeAmount);

        Task<int> CreatePerson(Person person);

        Task<int> CreateTeam(Team team);

        Task<int> CreateTournament(Tournament tournament);
    }
}
