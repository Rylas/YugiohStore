using YugiohShop.View;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace YugiohShop.ViewModel
{
    public class RegisterWindowViewModel : INotifyPropertyChanged
    {
        private readonly DBContext _context;

        public event PropertyChangedEventHandler PropertyChanged;

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
        public string UsernameReg
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(UsernameReg));
            }
        }

        private string _password;
        public string PasswordReg
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(PasswordReg));
            }
        }

        private string _repassword;
        public string PasswordReReg
        {
            get => _repassword;
            set
            {
                _repassword = value;
                OnPropertyChanged(nameof(PasswordReReg));
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
        public ICommand ShowPasswordCommand { get; }

        public ICommand RegisterCommand { get; }
        public ICommand NavigateToLoginCommand { get; }

        public RegisterWindowViewModel()
        {
            _context = new DBContext();

            RegisterCommand = new RelayCommand(Register, CanRegister);
            NavigateToLoginCommand = new RelayCommand(NavigateToLogin);
            ShowPasswordCommand = new RelayCommand(TogglePasswordVisibility);
            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQf5D4UB6yt7PIqbCMVGQIe8jHaC5UN6AIGxQ&s";
        }

        private void TogglePasswordVisibility()
        {
            IsPasswordVisible = !IsPasswordVisible;
        }
        private void NavigateToLogin()
        {
            // Chuyển đến trang đăng nhập
            var loginWindow = new LoginWindow();
            loginWindow.Show();

            Application.Current.Windows.OfType<RegisterView>().FirstOrDefault()?.Close();
        }

        private bool CanRegister()
        {
            return !string.IsNullOrWhiteSpace(UsernameReg) && !string.IsNullOrWhiteSpace(PasswordReg) && !string.IsNullOrWhiteSpace(PasswordReReg);
        }

        private void Register()
        {
            if (PasswordReg != PasswordReReg)
            {
                MessageBox.Show("Password and Re-entered password do not match", "Register Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var user = _context.Accounts.FirstOrDefault(a => a.Name == UsernameReg);
            if (user != null)
            {
                MessageBox.Show("Username already exists", "Register Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var hashPassword = BCrypt.Net.BCrypt.HashPassword(PasswordReg);
            var account = new Account
            {
                Name = UsernameReg,
                Password = hashPassword,
                Gender = false,
                Type = 2
            };
            _context.Accounts.Add(account);
            _context.SaveChanges();
            MessageBox.Show("Register successfully", "Register", MessageBoxButton.OK, MessageBoxImage.Information);
            NavigateToLogin();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
    }
}
