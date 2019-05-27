using Caliburn.Micro;

namespace TournamentTrackerUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        public ShellViewModel(DashboardViewModel viewModel)
        {
            ActivateItem(viewModel);
        }
    }
}
