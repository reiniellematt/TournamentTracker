using Dapper;
using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Person>> GetPeople()
        {
            string commandString = "SELECT Id, FirstName, LastName, EmailAddress, ContactNumber from Person;";

            using (IDbConnection cnn = new SQLiteConnection(_cnnString))
            {
                var result = await cnn.QueryAsync<Person>(commandString);
                return result;
            }
        }

        public async Task CreatePerson(Person person)
        {
            string commandString = "INSERT INTO Person(FirstName, LastName, EmailAddress, ContactNumber) VALUES (@FirstName, @LastName, @EmailAddress, @ContactNumber);SELECT last_insert_rowid();";

            using (IDbConnection cnn = new SQLiteConnection(_cnnString))
            {
                var id = await cnn.QueryAsync<int>(commandString, person);
                person.Id = id.FirstOrDefault();
            }
        }

        public async Task CreatePrize(Prize prize, bool isPrizeAmount)
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

                prize.Id = id.FirstOrDefault();
            }
        }

        public async Task CreateTeam(Team team)
        {
            string commandString = "INSERT INTO Team(TeamName) VALUES (@TeamName);SELECT last_insert_rowid();";

            using (IDbConnection cnn = new SQLiteConnection(_cnnString))
            {
                var id = await cnn.QueryAsync<int>(commandString, team);
                team.Id = id.FirstOrDefault();
                await CreateTeamMembers(cnn, team);
            }
        }

        public Task CreateTournament(Tournament tournament)
        {
            throw new System.NotImplementedException();
        }

        private async Task CreateTeamMembers(IDbConnection cnn, Team team)
        {
            string commandString = "INSERT INTO TeamMembers(PersonId, TeamId) VALUES(@PersonId, @TeamId);";

            foreach (var member in team.TeamMembers)
            {
                var p = new DynamicParameters();
                p.Add("@PersonId", member.Id);
                p.Add("@TeamId", team.Id);
                await cnn.ExecuteAsync(commandString, p);
            }
        }
    }
}
