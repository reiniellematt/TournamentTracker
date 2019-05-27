using System.Threading.Tasks;
using TournamentTracker.Library.Models;

namespace TournamentTracker.Library.DataAccess
{
    public interface IDataAccess
    {
        Task CreatePrize(Prize prize);

        Task CreatePerson(Person person);

        Task CreateTeam(Team team);

        Task CreateTournament(Tournament tournament);
    }
}
