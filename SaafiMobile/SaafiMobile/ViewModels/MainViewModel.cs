using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using SaafiMobile.Core.Contracts.ViewModel;

namespace SaafiMobile.Core.ViewModels
{
    public class MainViewModel : MvxViewModel, IMainViewModel
    {

        private readonly Lazy<SearchRemittanceViewModel> _searchRemittanceViewModel;
        private readonly Lazy<SavedRemittancesViewModel> _savedRemittancesViewModel;
        private readonly Lazy<SettingsViewModel> _settingsViewModel;

        public SearchRemittanceViewModel SearchRemittanceViewModel => _searchRemittanceViewModel.Value;

        public SavedRemittancesViewModel SavedRemittancesViewModel => _savedRemittancesViewModel.Value;

        public SettingsViewModel SettingsViewModel => _settingsViewModel.Value;

        public MainViewModel()
        {
            _searchRemittanceViewModel = new Lazy<SearchRemittanceViewModel>(Mvx.IocConstruct<SearchRemittanceViewModel>);
            _savedRemittancesViewModel = new Lazy<SavedRemittancesViewModel>(Mvx.IocConstruct<SavedRemittancesViewModel>);
            _settingsViewModel = new Lazy<SettingsViewModel>(Mvx.IocConstruct<SettingsViewModel>);
        }

        public void ShowMenu()
        {
            ShowViewModel<MenuViewModel>();
        }

        public void ShowSearchRemittances()
        {
            ShowViewModel<SearchRemittanceViewModel>();
        }
    }
}