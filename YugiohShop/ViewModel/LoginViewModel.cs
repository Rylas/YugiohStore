using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using YugiohShop.View;
using Model.Models;

namespace YugiohShop.ViewModel
{
    public class LoginWindowViewModel : INotifyPropertyChanged
    {
        private readonly DBContext _context;

        private string _imageUrl;

        public string ImageUrl
        {
            get => _imageUrl;
            set
            {
                _imageUrl = value;
                OnPropertyChanged(nameof(ImageUrl));
            }
        }

        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private bool _isPasswordVisible;
        public bool IsPasswordVisible
        {
            get => _isPasswordVisible;
            set
            {
                _isPasswordVisible = value;
                OnPropertyChanged(nameof(IsPasswordVisible));
            }
        }

        public ICommand NavigateToRegisterCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand LoginCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public LoginWindowViewModel()
        {
            _context = new DBContext();
            LoginCommand = new RelayCommand(Login, CanLogin);
            NavigateToRegisterCommand = new RelayCommand(NavigateToRegister);
            ShowPasswordCommand = new RelayCommand(TogglePasswordVisibility);
            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQf5D4UB6yt7PIqbCMVGQIe8jHaC5UN6AIGxQ&s";
        }

        private void NavigateToRegister()
        {
            var registerView = new RegisterView();
            registerView.Show();

            Application.Current.Windows.OfType<LoginWindow>().FirstOrDefault()?.Close();
        }

        private bool CanLogin()
        {
            return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
        }

        private void Login()
        {
            var user = _context.Accounts.FirstOrDefault(a => a.Name == Username);
            if (user == null)
            {
                MessageBox.Show("Invalid username or password", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            bool checkPassword = false;
            try
            {
                checkPassword = BCrypt.Net.BCrypt.Verify(Password, user.Password);
                
            } catch (Exception ex) { }
            if (!checkPassword)
            {
                MessageBox.Show("Invalid username or password", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            OpenMainWindow(user);
        }

        private void TogglePasswordVisibility()
        {
            IsPasswordVisible = !IsPasswordVisible;
        }

        private void OpenMainWindow(Account account)
        {
            var mainWindow = new MainWindow(account);
          
          

            mainWindow.Show();

            Application.Current.Windows.OfType<LoginWindow>().FirstOrDefault()?.Close();
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
