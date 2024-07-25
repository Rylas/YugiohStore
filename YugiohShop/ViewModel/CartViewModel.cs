using Microsoft.EntityFrameworkCore;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace YugiohShop.ViewModel
{
    public class CartViewModel : INotifyPropertyChanged
    {
        private readonly DBContext _context;

        private int _totalBillAmount;
        public int TotalBillAmount
        {
            get => _totalBillAmount;
            set
            {
                _totalBillAmount = value;
                OnPropertyChanged(nameof(TotalBillAmount));
            }
        }
        public ObservableCollection<BillDetailsModel> OrderDetails { get; set; } = new ObservableCollection<BillDetailsModel>();
        public Account CurrentAccount { get; }

        public ICommand CheckoutCommand { get; }

        // Parameterless constructor
        public CartViewModel()
        {
            _context = new DBContext();
            // Initialize with a default account for demonstration purposes
            CurrentAccount = _context.Accounts.FirstOrDefault(); // Replace with actual current account retrieval logic
            LoadCart();
            CheckoutCommand = new RelayCommand(Checkout);
        }

        public CartViewModel(Account account)
        {
            _context = new DBContext();
            CurrentAccount = account;
            LoadCart();
            CheckoutCommand = new RelayCommand(Checkout);
        }

        public void LoadCart()
        {
            var orderDetails = GetBillDetailsForUser(CurrentAccount.Id);

            foreach (var detail in orderDetails)
            {
                OrderDetails.Add(detail);
                TotalBillAmount += detail.Quantity * detail.Price;
            }
            OnPropertyChanged(nameof(OrderDetails));
        }

        private void Checkout()
        {
            var transaction = _context.Database.BeginTransaction();
            try
            {
                var activeBill = _context.Bills
                            .Include(b => b.BillDetails).ThenInclude(bi => bi.IdProductNavigation)
                            .Where(b => b.userID == CurrentAccount.Id)
                            .OrderByDescending(b => b.DateBook)
                            .FirstOrDefault();

                if (activeBill == null)
                {
                    MessageBox.Show("No active bill found for the selected table.");
                    return;
                }

                int totalPrice = activeBill.BillDetails.Sum(bi => bi.Quantity * bi.IdProductNavigation.Price);

                activeBill.DateCheckOut = DateTime.Now;
                activeBill.Status = true;

                _context.SaveChanges();
                transaction.Commit();
                OrderDetails.Clear();
                TotalBillAmount = 0;
                MessageBox.Show($"Checkout successful!\n" +
                                $"Subtotal: {totalPrice}\n" +
                                $"Total: {totalPrice}");

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show("Error checking out: " + ex.Message);
            }
        }

        public List<BillDetailsModel> GetBillDetailsForUser(int userID)
        {
            var mostRecentBill = _context.Bills
                .Where(_ => (_.userID == userID && _.Status == false))
                .OrderByDescending(b => b.DateBook)
                .FirstOrDefault();

            if (mostRecentBill != null)
            {
                var result = _context.BillDetails
                    .Where(bi => bi.IdBill == mostRecentBill.Id)
                    .Include(bi => bi.IdProductNavigation)
                    .Select(bi => new BillDetailsModel
                    {
                        ProductImage = bi.IdProductNavigation.ImageLink,
                        ProductName = bi.IdProductNavigation.Name,
                        Quantity = bi.Quantity,
                        Price = bi.IdProductNavigation.Price
                    })
                    .ToList();

                return result;
            }
            else
            {
                return new List<BillDetailsModel>();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
