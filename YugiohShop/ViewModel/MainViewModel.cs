using YugiohShop.ViewModel;
using Model.Models;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using YugiohShop.View;

namespace YugiohShop.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private object _currentViewModel;
        public object CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }
		private Account _currentAccount;
		public Account CurrentAccount
		{
			get => _currentAccount;
			set
			{
				_currentAccount = value;
				OnPropertyChanged(nameof(CurrentAccount));
				OnPropertyChanged(nameof(IsAdminVisible));
				OnPropertyChanged(nameof(IsStaffVisible));
                OnPropertyChanged(nameof(IsUserVisible));
			}
		}
		public bool IsAdminVisible => CurrentAccount?.Type == 0;
		public bool IsStaffVisible => CurrentAccount?.Type == 1;
        public bool IsUserVisible => CurrentAccount?.Type == 2;

		public ICommand NavigateToProductCommand { get; }
        public ICommand NavigateToBillsCommand { get; }
        public ICommand NavigateToAccountsCommand { get; }
        public ICommand NavigateToProductListCommand {  get; }
        public ICommand NavigateToDailyBillsCommand { get; }
        public ICommand NavigateToDashboardCommand {  get; }
        public ICommand NavigateToCartCommand { get; }
        public ICommand LogoutCommand {  get; }
        public MainViewModel(Account account)
        {
            CurrentAccount = account;
            NavigateToProductCommand = new RelayCommand(NavigateToProductStatus);
            NavigateToBillsCommand = new RelayCommand(NavigateToBills);
            NavigateToAccountsCommand = new RelayCommand(NavigateToAccounts);
            NavigateToProductListCommand = new RelayCommand(NavigateToProductList);
            NavigateToDailyBillsCommand = new RelayCommand(NavigateToDailyBills);
            NavigateToDashboardCommand = new RelayCommand(NavigateToDashboard);
            NavigateToCartCommand = new RelayCommand(NavigateToCart);
            LogoutCommand = new RelayCommand(Logout);
            // Set initial view
            InitialView();
        }
        private void InitialView()
        {
			if (IsAdminVisible)
			{
                NavigateToProductList();

            }
            else if (IsStaffVisible)
			{
                NavigateToDashboard();
			}
            else
            {
                NavigateToProductList();
            }
		}

        private void NavigateToProductStatus()
        {
            CurrentViewModel = new ProductView();
        }

        private void NavigateToDashboard()
        {
            CurrentViewModel = new DashboardViewModel();
        }


        private void NavigateToBills()
        {
            CurrentViewModel = new BillsViewModel();
        }

        private void NavigateToAccounts() => CurrentViewModel = new ManageAccountViewModel();

        private void NavigateToProductList() => CurrentViewModel = new ProductViewModel(CurrentAccount);
        private void NavigateToDailyBills() => CurrentViewModel = new DailyBillViewModel();
        private void NavigateToCart() => CurrentViewModel = new CartViewModel(CurrentAccount);
        private void Logout()
        {
            CurrentAccount = null;
            var loginWindow = new LoginWindow();
            loginWindow.Show();

            Application.Current.Windows.OfType<MainWindow>().FirstOrDefault()?.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;
        private Action<PasswordBox> showPassword;

        public RelayCommand(Action<PasswordBox> showPassword)
        {
            this.showPassword = showPassword;
        }

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute();

        public void Execute(object parameter) => _execute();
    }

    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (Visibility)value == Visibility.Visible;
        }
    }
}
