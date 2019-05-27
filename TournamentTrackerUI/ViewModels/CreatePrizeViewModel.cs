using Caliburn.Micro;
using System.Threading.Tasks;
using TournamentTracker.Library.DataAccess;
using TournamentTracker.Library.Models;

namespace TournamentTrackerUI.ViewModels
{
    public class CreatePrizeViewModel : Screen
    {
        private readonly IDataAccess _dataAccess;
        private readonly IEventAggregator _eventAggregator;

        private string _placeName = string.Empty;
        private string _placeNumber = "0";
        private string _prizeAmount = "0";
        private string _prizePercentage = "0";
        private bool _isPrizeAmount = true;
        private bool _isPrizePercentage = false;

        public string PlaceName
        {
            get { return _placeName; }
            set
            {
                _placeName = value;
                NotifyOfPropertyChange(() => PlaceName);
                NotifyOfPropertyChange(() => CanCreatePrize);
            }
        }
        public string PlaceNumber
        {
            get { return _placeNumber; }
            set
            {
                _placeNumber = value;
                NotifyOfPropertyChange(() => PlaceNumber);
                NotifyOfPropertyChange(() => CanCreatePrize);

            }
        }
        public string PrizeAmount
        {
            get { return _prizeAmount; }
            set
            {
                _prizeAmount = value;
                NotifyOfPropertyChange(() => PrizeAmount);
                NotifyOfPropertyChange(() => CanCreatePrize);
            }
        }
        public string PrizePercentage
        {
            get { return _prizePercentage; }
            set
            {
                _prizePercentage = value;
                NotifyOfPropertyChange(() => PrizePercentage);
                NotifyOfPropertyChange(() => CanCreatePrize);
            }
        }
        public bool IsPrizeAmount
        {
            get { return _isPrizeAmount; }
            set
            {
                _isPrizeAmount = value;
                NotifyOfPropertyChange(() => IsPrizeAmount);
                NotifyOfPropertyChange(() => CanCreatePrize);
            }
        }
        public bool IsPrizePercentage
        {
            get { return _isPrizePercentage; }
            set
            {
                _isPrizePercentage = value;
                NotifyOfPropertyChange(() => IsPrizePercentage);
                NotifyOfPropertyChange(() => CanCreatePrize);
            }
        }

        public CreatePrizeViewModel(IDataAccess dataAccess, IEventAggregator eventAggregator)
        {
            _dataAccess = dataAccess;
            _eventAggregator = eventAggregator;
        }

        public async void CreatePrize()
        {
            Prize prize = new Prize
            {
                PlaceName = PlaceName,
                PlaceNumber = int.Parse(PlaceNumber),
                PrizeAmount = decimal.Parse(PrizeAmount),
                PrizePercentage = int.Parse(PrizePercentage)
            };

            prize.Id = await _dataAccess.CreatePrize(prize, IsPrizeAmount);
            _eventAggregator.BeginPublishOnUIThread(prize);
            TryClose();
        }

        public bool CanCreatePrize
        {
            get
            {
                bool output = true;

                if (string.IsNullOrEmpty(PlaceName))
                {
                    output = false;
                }

                if (!int.TryParse(PlaceNumber, out int placeNumber))
                {
                    output = false;
                }
                else
                {
                    if (placeNumber <= 0)
                    {
                        output = false;
                    }
                }

                if (!decimal.TryParse(PrizeAmount, out decimal prizeAmount) && IsPrizeAmount)
                {
                    output = false;
                }
                else
                {
                    if (prizeAmount <= 0 && IsPrizeAmount)
                    {
                        output = false;
                    }
                }

                if (!int.TryParse(PrizePercentage, out int prizePercentage) && IsPrizePercentage)
                {
                    output = false;
                }
                else
                {
                    if ((prizePercentage <= 0 || prizePercentage > 100) && IsPrizePercentage)
                    {
                        output = false;
                    }
                }

                return output;
            }
        }
    }
}
