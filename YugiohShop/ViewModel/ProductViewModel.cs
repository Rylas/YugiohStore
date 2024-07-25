using Microsoft.EntityFrameworkCore;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class ProductViewModel : INotifyPropertyChanged
    {
        private readonly DBContext _context;

        

        public List<Product> ProductList { get; set; }

        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }


        private int _itemQuantity = 1;
        public int ItemQuantity
        {
            get => _itemQuantity;
            set
            {
                _itemQuantity = value;
                OnPropertyChanged();
            }
        }

        private List<ProductCategory> ProductCategories { get; set; }


        private ProductCategory _productCategory;
        public ProductCategory SelectedProductCategory
        {
            get => _productCategory;
            set
            {
                _productCategory = value;
                OnPropertyChanged();
                FilterProducts();
            }
        }

        public Account CurrentAccount { get; }

        public ICommand AddItemCommand { get; }

        public ProductViewModel(Account currentAccount)
        {
            CurrentAccount = currentAccount;
            _context = new DBContext();
            LoadData();
            AddItemCommand = new RelayCommand(AddItem);
           
        }

        public List<Product> AvaliableProducts { get; set; }


        public void LoadData()
        {
            ProductList = _context.Products.ToList();
            ProductCategories = _context.ProductCategories.ToList();
            OnPropertyChanged(nameof(ProductList));
            OnPropertyChanged(nameof(ProductCategories));  
        }


        public void FilterProducts()
        {
            ProductList.Clear();
            if (SelectedProductCategory.Id == null)
            {
                ProductList = _context.Products.ToList();
            } else
            {
                ProductList = _context.Products.Where(_ => _.IdCategory == SelectedProductCategory.Id).ToList();
            }
            OnPropertyChanged(nameof(ProductList));
        }


        private void AddItem()
        {

            if (SelectedProduct == null)
            {
                MessageBox.Show("Please select at least one item.");
                return;
            }
            if (ItemQuantity <= 0)
            {
                MessageBox.Show("Quantity must be greater than zero.");
                return;
            }
            if (SelectedProduct.Quantity <= 0)
            {
                MessageBox.Show("Product is out of stock.");
                return;
            }
            if (SelectedProduct.Quantity < ItemQuantity)
            {
                MessageBox.Show("Not enough product in stock.");
                return;
            }

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    void AddItemToBill(Product item, Bill bill)
                    {
                        var existingBillInfo = _context.BillDetails
                            .FirstOrDefault(bi => bi.IdBill == bill.Id && bi.IdProduct == item.Id);
                        if (existingBillInfo != null)
                        {
                            existingBillInfo.Quantity += ItemQuantity;
                        }
                        else
                        {
                            var newBillDetail = new BillDetails
                            {
                                IdBill = bill.Id,
                                IdProduct = item.Id,
                                Quantity = ItemQuantity
                            };
                            _context.BillDetails.Add(newBillDetail);
                        }
                    }

                    if (SelectedProduct != null)
                    {
                        Bill bill = _context.Bills.FirstOrDefault(b => b.userID == CurrentAccount.Id && b.Status == false);
                        if (bill == null)
                        {
                            bill = new Bill
                            {
                                DateBook = DateTime.Now,
                                DateCheckOut = null,
                                Status = false,
                                userID = CurrentAccount.Id,
                                TotalAmount = SelectedProduct.Quantity * SelectedProduct.Price,
                            };
                            _context.Bills.Add(bill);
                            _context.SaveChanges();
                        }
                        AddItemToBill(SelectedProduct, bill);

                    }

                    _context.SaveChanges();
                    transaction.Commit();
                    MessageBox.Show("Item(s) added successfully.");

                    SelectedProduct = null;
                    ItemQuantity = 1;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"Error adding item(s): {ex.Message}");
                }
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
    public class BoolToStatusConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length > 0 && values[0] is bool status)
            {
                return status ? "Available" : "Unavailable";
            }
            return "Unknown";
        }


        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
