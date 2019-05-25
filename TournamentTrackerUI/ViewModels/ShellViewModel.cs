using Caliburn.Micro;

namespace TournamentTrackerUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        public ShellViewModel(TournamentViewModel viewModel)
        {
            ActivateItem(viewModel);
        }
    }
}
