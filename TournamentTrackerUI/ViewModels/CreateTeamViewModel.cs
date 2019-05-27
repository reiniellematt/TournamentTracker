using Caliburn.Micro;
using TournamentTracker.Library.DataAccess;
using TournamentTracker.Library.Models;

namespace TournamentTrackerUI.ViewModels
{
    public class CreateTeamViewModel : Screen
    {
        private readonly IDataAccess _dataAccess;

        private BindableCollection<Person> _teamMembers = new BindableCollection<Person>();
        private Person _selectedTeamMember;

        public BindableCollection<Person> TeamMembers
        {
            get { return _teamMembers; }
            set
            {
                _teamMembers = value;
                NotifyOfPropertyChange(() => TeamMembers);
            }
        }
        public Person SelectedTeamMember
        {
            get { return _selectedTeamMember; }
            set
            {
                _selectedTeamMember = value;
                NotifyOfPropertyChange(() => SelectedTeamMember);
            }
        }

        #region CREATE_MEMBER_PROPERTIES
        private string _firstName, _lastName, _emailAddress, _contactNumber;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => CanCreateMember);
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => CanCreateMember);
            }
        }
        public string EmailAddress
        {
            get { return _emailAddress; }
            set
            {
                _emailAddress = value;
                NotifyOfPropertyChange(() => EmailAddress);
                NotifyOfPropertyChange(() => CanCreateMember);
            }
        }
        public string ContactNumber
        {
            get { return _contactNumber; }
            set
            {
                _contactNumber = value;
                NotifyOfPropertyChange(() => ContactNumber);
                NotifyOfPropertyChange(() => CanCreateMember);
            }
        }
        #endregion

        public CreateTeamViewModel(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async void CreateMember()
        {
            var person = new Person
            {
                FirstName = FirstName,
                LastName = LastName,
                EmailAddress = EmailAddress,
                ContactNumber = ContactNumber
            };

            person.Id = await _dataAccess.CreatePerson(person);
            TeamMembers.Add(person);

            FirstName = string.Empty;
            LastName = string.Empty;
            EmailAddress = string.Empty;
            ContactNumber = string.Empty;
        }

        public bool CanCreateMember
        {
            get
            {
                return !string.IsNullOrEmpty(FirstName) &&
                    !string.IsNullOrEmpty(LastName) &&
                    !string.IsNullOrEmpty(EmailAddress) &&
                    !string.IsNullOrEmpty(ContactNumber);
            }
        }
    }
}
