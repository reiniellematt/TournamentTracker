using Caliburn.Micro;

namespace TournamentTrackerUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        public ShellViewModel(CreateTeamViewModel viewModel)
        {
            ActivateItem(viewModel);
        }
    }
}
