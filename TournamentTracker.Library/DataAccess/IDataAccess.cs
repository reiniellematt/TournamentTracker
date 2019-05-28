using System.Collections.Generic;
using System.Threading.Tasks;
using TournamentTracker.Library.Models;

namespace TournamentTracker.Library.DataAccess
{
    public interface IDataAccess
    {
        Task<IEnumerable<Person>> GetPeople();

        Task CreatePrize(Prize prize, bool isPrizeAmount);

        Task CreatePerson(Person person);

        Task CreateTeam(Team team);

        Task CreateTournament(Tournament tournament);
    }
}
