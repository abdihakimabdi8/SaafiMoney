using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using SaafiMobile.Core.Contracts.Services;
using SaafiMobile.Core.Contracts.ViewModel;
using SaafiMobile.Core.Model;
using MvvmCross.Platform.Platform;

namespace SaafiMobile.Core.ViewModels
{
    public class RemittanceDetailViewModel : BaseViewModel, IRemittanceDetailViewModel
    {
        private readonly IRemittanceDataService _remittanceDataService;
        private readonly ISavedRemittanceDataService _savedRemittanceDataService;
        private readonly IDialogService _dialogService;
        private readonly IUserDataService _userDataService;
        private Remittance _selectedRemittance;
        private int _remittanceId;
        private int _beneficiaryId;

        public MvxCommand AddToSavedRemittancesCommand
        {
            get
            {
                return new MvxCommand(async () =>
                {
                    await _savedRemittanceDataService.AddSavedRemittance
                    (_userDataService.GetActiveUser().UserId, SelectedRemittance.RemittanceId, BeneficiaryId);

                    //Hardcoded text, better with resx translations
                    //await
                    //    _dialogService.ShowAlertAsync("This journey is now in your Saved Journeys!", "My Trains says...", "OK");

                    await
                        _dialogService.ShowAlertAsync
                        (TextSource.GetText("AddedToSavedRemittancesMessage"),
                         TextSource.GetText("AddedToSavedRemittancesTitle"),
                         TextSource.GetText("AddedToSavedRemittancesButton"));
                });
            }
        }

        public MvxCommand CloseCommand
        { get { return new MvxCommand(() => Close(this)); } }

        public Remittance SelectedRemittance
        {
            get { return _selectedRemittance; }
            set
            {
                _selectedRemittance = value;
                RaisePropertyChanged(() => SelectedRemittance);
            }
        }

        public int BeneficiaryId
        {
            get { return _beneficiaryId; }
            set
            {
                _beneficiaryId = value;
                RaisePropertyChanged(() => BeneficiaryId);
            }
        }

        public RemittanceDetailViewModel(IMvxMessenger messenger,
            IRemittanceDataService remittanceDataService,
            ISavedRemittanceDataService savedRemittanceDataService,
            IDialogService dialogService,
            IUserDataService userDataService) : base(messenger)
        {
            _remittanceDataService = remittanceDataService;
            _savedRemittanceDataService = savedRemittanceDataService;
            _dialogService = dialogService;
            _userDataService = userDataService;
        }

        public void Init(int journeyId)
        {
            _remittanceId = journeyId;
        }

        public override async void Start()
        {
            base.Start();
            await ReloadDataAsync();
        }

        protected override async Task InitializeAsync()
        {
            SelectedRemittance = await _remittanceDataService.GetRemittanceDetails(_remittanceId);
        }

        public class SavedState
        {
            public int RemittanceId { get; set; }
        }

        public SavedState SaveState()
        {
            MvxTrace.Trace("SaveState called");
            return new SavedState { RemittanceId = _remittanceId };
        }

        public void ReloadState(SavedState savedState)
        {
            MvxTrace.Trace("ReloadState called with {0}",
                savedState.RemittanceId);
            _remittanceId = savedState.RemittanceId;
        }
    }
}