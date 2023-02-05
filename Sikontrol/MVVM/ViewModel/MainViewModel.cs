using Sikontrol.Core;
using Sikontrol.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sikontrol.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }

        public RelayCommand SettingsViewCommand { get; set; }

        public HomeViewModel HomeVW { get; set; }

        public SettingsViewModel SettingsVW { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            HomeVW = new HomeViewModel();
            SettingsVW = new SettingsViewModel();

            CurrentView = HomeVW;

            HomeViewCommand = new RelayCommand((o) =>
            {
                CurrentView = HomeVW;
            });

            SettingsViewCommand = new RelayCommand((o) =>
            {
                CurrentView = SettingsVW;
            });
        }
    }
}
