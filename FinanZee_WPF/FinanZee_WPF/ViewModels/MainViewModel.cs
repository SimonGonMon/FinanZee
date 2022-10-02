using FinanZee_WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using FinanZee_WPF.Models;
using FinanZee_WPF.Repositories;
using FontAwesome.Sharp;

namespace FinanZee_WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        //Fields
        private UserAccountModel _currentUserAccount;
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;
        
        private IUserRepository userRepository;

        //Properties
        public UserAccountModel CurrentUserAccount
        {
            get
            {
                return _currentUserAccount;
            }
            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }
        public ViewModelBase CurrentChildView
        {
            get
            {
                return _currentChildView;
            }
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }
        public string Caption
        {
            get
            {
                return _caption;
            }
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }
        public IconChar Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }
        //--> Commands
        public ICommand ShowHomeViewCommand { get; }

        public ICommand ShowMetricsViewCommand { get; }
        public ICommand ShowCustomerViewCommand { get; }

        public ICommand ShowCalendarViewCommand { get; }

        public ICommand ShowRegisterViewCommand { get; }
        public MainViewModel()
        {
            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();
            //Initialize commands
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowCustomerViewCommand = new ViewModelCommand(ExecuteShowCustomerViewCommand);
            ShowMetricsViewCommand = new ViewModelCommand(ExecuteShowMetricsViewCommand);
            ShowCalendarViewCommand = new ViewModelCommand(ExecuteShowCalendarViewCommand);
            ShowRegisterViewCommand = new ViewModelCommand(ExecuteShowRegisterViewCommand);
            //Default view
            ExecuteShowHomeViewCommand(null);
            LoadCurrentUserData();
        }
        private void ExecuteShowCustomerViewCommand(object obj)
        {
            CurrentChildView = new CustomerViewModel();
            Caption = "Métricas";
            Icon = IconChar.ChartLine;
        }
        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
            Caption = "Inicio";
            Icon = IconChar.Home;
        }

        private void ExecuteShowMetricsViewCommand(object obj)
        {
            CurrentChildView = new MetricsViewModel();
            Caption = "Métricas";
            Icon = IconChar.ChartLine;
        }

        private void ExecuteShowCalendarViewCommand(object obj)
        {
            CurrentChildView = new CalendarViewModel();
            Caption = "Calendario";
            Icon = IconChar.Calendar;
        }

        private void ExecuteShowRegisterViewCommand(object obj)
        {
            CurrentChildView = new RegisterViewModel();
            Caption = "Registrar";
            Icon = IconChar.MoneyBill1;
        }





        private void LoadCurrentUserData()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                CurrentUserAccount.Username = user.Username;
                CurrentUserAccount.DisplayName = $"{user.Name} {user.LastName}";
                CurrentUserAccount.ProfilePicture = user.ProfilePicture;
            }
            else
            {
                CurrentUserAccount.DisplayName="Usuario inválido";
            }
        }

   


    }
}
