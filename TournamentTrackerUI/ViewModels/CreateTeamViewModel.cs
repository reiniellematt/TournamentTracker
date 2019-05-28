using System;
using System.Threading.Tasks;
using Caliburn.Micro;
using TournamentTracker.Library.DataAccess;
using TournamentTracker.Library.Models;

namespace TournamentTrackerUI.ViewModels
{
    public class CreateTeamViewModel : Screen
    {
        private readonly IDataAccess _dataAccess;
        private readonly IEventAggregator _eventAggregator;

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

        private string _teamName;
        private BindableCollection<Person> _teamMembers = new BindableCollection<Person>();
        private Person _selectedTeamMember;
        private BindableCollection<Person> _availableMembers = new BindableCollection<Person>();
        private Person _selectedAvailableMember;

        public string TeamName
        {
            get { return _teamName; }
            set
            {
                _teamName = value;
                NotifyOfPropertyChange(() => TeamName);
                NotifyOfPropertyChange(() => CanCreateTeam);
            }
        }
        public BindableCollection<Person> TeamMembers
        {
            get { return _teamMembers; }
            set
            {
                _teamMembers = value;
                NotifyOfPropertyChange(() => TeamMembers);
                NotifyOfPropertyChange(() => CanCreateTeam);
            }
        }
        public Person SelectedTeamMember
        {
            get { return _selectedTeamMember; }
            set
            {
                _selectedTeamMember = value;
                NotifyOfPropertyChange(() => SelectedTeamMember);
                NotifyOfPropertyChange(() => CanRemoveMember);
            }
        }
        public BindableCollection<Person> AvailableMembers
        {
            get { return _availableMembers; }
            set
            {
                _availableMembers = value;
                NotifyOfPropertyChange(() => AvailableMembers);
            }
        }
        public Person SelectedAvailableMember
        {
            get { return _selectedAvailableMember; }
            set
            {
                _selectedAvailableMember = value;
                NotifyOfPropertyChange(() => SelectedAvailableMember);
                NotifyOfPropertyChange(() => CanAddMember);
            }
        }

        public CreateTeamViewModel(IDataAccess dataAccess, IEventAggregator eventAggregator)
        {
            _dataAccess = dataAccess;
            _eventAggregator = eventAggregator;
            InitializeLists();
        }

        private async void InitializeLists()
        {
            var people = await _dataAccess.GetPeople();

            AvailableMembers = new BindableCollection<Person>(people);
            SelectedAvailableMember = AvailableMembers[0];
        }

        public async void CreateTeam()
        {
            var team = new Team
            {
                TeamName = TeamName,
                TeamMembers = TeamMembers
            };

            await _dataAccess.CreateTeam(team);
            _eventAggregator.BeginPublishOnUIThread(team);
            TryClose();
        }

        public void AddMember()
        {
            TeamMembers.Add(SelectedAvailableMember);
            AvailableMembers.Remove(SelectedAvailableMember);
            NotifyOfPropertyChange(() => CanCreateTeam);
        }

        public void RemoveMember()
        {
            AvailableMembers.Add(SelectedTeamMember);
            TeamMembers.Remove(SelectedTeamMember);
            NotifyOfPropertyChange(() => CanCreateTeam);
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

            await _dataAccess.CreatePerson(person);
            TeamMembers.Add(person);

            FirstName = string.Empty;
            LastName = string.Empty;
            EmailAddress = string.Empty;
            ContactNumber = string.Empty;
        }

        public void Cancel() { TryClose(); }

        public bool CanCreateTeam
        {
            get
            {
                return !string.IsNullOrEmpty(TeamName) && TeamMembers.Count > 0;
            }
        }
        public bool CanAddMember
        {
            get { return SelectedAvailableMember != null; }
        }
        public bool CanRemoveMember
        {
            get { return SelectedTeamMember != null; }
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
