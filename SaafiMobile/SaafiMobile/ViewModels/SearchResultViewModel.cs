using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using SaafiMobile.Core.Contracts.Services;
using SaafiMobile.Core.Contracts.ViewModel;
using SaafiMobile.Core.Extensions;
using SaafiMobile.Core.Messages;
using SaafiMobile.Core.Model;
using SaafiMobile.Core.Model.App;

namespace SaafiMobile.Core.ViewModels
{
    public class SearchResultViewModel : BaseViewModel, ISearchResultViewModel
    {
        private readonly IRemittanceDataService _remittanceDataService;
        private int _fromCityId;
        private int _toCityId;
        private DateTime _remittanceDate;
        private string _departureTime;
        private ObservableCollection<Remittance> _remittances;

        public ObservableCollection<Remittance> Remittances
        {
            get { return _remittances; }
            set
            {
                _remittances = value;
                RaisePropertyChanged(() => Remittances);
            }
        }

        public MvxCommand<Remittance> ShowJourneyDetailsCommand
        {
            get
            {
                return new MvxCommand<Remittance>(selectedRemittance =>
                {
                    ShowViewModel<RemittanceDetailViewModel>
                    (new { remittanceId = selectedRemittance.RemittanceId });
                });
            }
        }

        public MvxCommand ReloadDataCommand
        {
            get
            {
                return new MvxCommand(async () =>
                {
                    Remittances = (await _remittanceDataService.SearchRemittance(_fromCityId, _toCityId, _remittanceDate, DateTime.Parse(_departureTime))).ToObservableCollection();
                });
            }
        }


        public SearchResultViewModel(IMvxMessenger messenger, IRemittanceDataService remittanceDataService) : base(messenger)
        {
            _remittanceDataService = remittanceDataService;

            InitializeMessenger();
        }

        private void InitializeMessenger()
        {
            Messenger.Subscribe<CurrencyChangedMessage>
                (async message => await ReloadDataAsync());
        }

        public override async void Start()
        {
            base.Start();

            await ReloadDataAsync();
        }

        protected override async Task InitializeAsync()
        {
            Remittances = (await _remittanceDataService.SearchRemittance(_fromCityId, _toCityId, _remittanceDate, DateTime.Parse(_departureTime))).ToObservableCollection();
        }



        public void Init(SearchParameters parameters)
        {
            _fromCityId = parameters.FromCityId;
            _toCityId = parameters.ToCityId;
            _remittanceDate = parameters.RemittanceDate;
            _departureTime = parameters.DepartureTime;
        }
    }
}