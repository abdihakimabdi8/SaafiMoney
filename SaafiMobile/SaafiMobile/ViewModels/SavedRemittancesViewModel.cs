using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using SaafiMobile.Core.Contracts.Services;
using SaafiMobile.Core.Contracts.ViewModel;
using SaafiMobile.Core.Extensions;
using SaafiMobile.Core.Messages;
using SaafiMobile.Core.Model;

namespace SaafiMobile.Core.ViewModels
{
    public class SavedRemittancesViewModel : BaseViewModel, ISavedRemittancesViewModel
    {
        private readonly ISavedRemittanceDataService _savedRemittanceDataService;
        private readonly IUserDataService _userDataService;

        private ObservableCollection<SavedRemittance> _savedRemittance;

        public MvxCommand ReloadDataCommand
        {
            get
            {
                return new MvxCommand(async () =>
                {
                    var user = _userDataService.GetActiveUser();
                    SavedRemittances = (await _savedRemittanceDataService.GetSavedRemittanceForUser(user.UserId)).ToObservableCollection();
                });
            }
        }

        public ObservableCollection<SavedRemittance> SavedRemittances
        {
            get
            {
                return _savedRemittance;
            }
            set
            {
                _savedRemittance = value;
                RaisePropertyChanged(() => SavedRemittances);
            }
        }
        // Remittance

        public SavedRemittancesViewModel(IMvxMessenger messenger, ISavedRemittanceDataService savedRemittanceDataService, IUserDataService userDataService) : base(messenger)
        {
            _savedRemittanceDataService = savedRemittanceDataService;
            _userDataService = userDataService;

            InitializeMessenger();
        }

        private void InitializeMessenger()
        {
            Messenger.Subscribe<CurrencyChangedMessage>(async message => await ReloadDataAsync());
        }


        public override async void Start()
        {
            base.Start();
            await ReloadDataAsync();
        }

        protected override async Task InitializeAsync()
        {
            var user = _userDataService.GetActiveUser();
            SavedRemittances = (await _savedRemittanceDataService.GetSavedRemittanceForUser(user.UserId)).ToObservableCollection();
        }
    }
}