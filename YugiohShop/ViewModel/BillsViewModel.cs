﻿using Microsoft.EntityFrameworkCore;
using Model.Models;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace YugiohShop.ViewModel
{
    public class BillsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<BillWithTotal> _bills;
        public ObservableCollection<BillWithTotal> Bills
        {
            get { return _bills; }
            set
            {
                _bills = value;
                OnPropertyChanged(nameof(Bills));
            }
        }
        
        private readonly DBContext _context;
        private DateTime? startDate;
        public DateTime? StartDate
        {
            get { return startDate; }
            set
            {
                startDate = value;
                OnPropertyChanged("StartDate");
            }
        }

        public ICommand ViewCommand { get; set; }
        public ICommand ExportCommand { get; set; }

        private DateTime? endDate;
        public DateTime? EndDate
        {
            get { return endDate; }
            set
            {
                endDate = value;
                OnPropertyChanged("EndDate");
            }
        }

        private string _titleText;
        public string TitleText
        {
            get => _titleText;
            set
            {
                if (_titleText != value)
                {
                    _titleText = value;
                    OnPropertyChanged(nameof(TitleText));
                }
            }
        }

        public BillsViewModel()
        {
            _context = new DBContext();
            ViewCommand = new RelayCommand(View);
            ExportCommand = new RelayCommand(Export);
            LoadBills();
            InitializeDates();
        }

        private void LoadBills()
        {
            var bills = _context.Bills
                        .Include(b => b.BillDetails)
                            .ThenInclude(bi => bi.IdProductNavigation)
                        .ToList();

            var billsWithTotal = bills.Select(b => new BillWithTotal
            {
                Bill = b,
                TotalPrice = b.BillDetails.Sum(bi => bi.Quantity * bi.IdProductNavigation.Price)
            });

            Bills = new ObservableCollection<BillWithTotal>(billsWithTotal);
        }

        private void InitializeDates()
        {
            // Assuming you have a method to get the earliest date from your database
            StartDate = _context.Bills.Select(b => b.DateBook).OrderBy(d => d).FirstOrDefault();
            EndDate = DateTime.Today;
            UpdateTitleText();
        }
        private void UpdateTitleText()
        {
            TitleText = $"Bills from {StartDate:d} to {EndDate:d}";
        }

        private void Export()
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            string fileName = TitleText + ".xlsx";


            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, fileName);
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Bills");

                worksheet.Cells[1, 1].Value = TitleText;
                worksheet.Cells[1, 1, 1, 6].Merge = true;
                worksheet.Cells[1, 1].Style.Font.Size = 14;
                worksheet.Cells[1, 1].Style.Font.Bold = true;
                worksheet.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                // Add date
                worksheet.Cells[2, 1].Value = $"Generated on: {DateTime.Now.ToShortDateString()}";
                worksheet.Cells[2, 1, 2, 6].Merge = true;

                // Add headers
                string[] headers = new string[] { "ID Bill", "Date Book", "Date checkout", "Product Details", "Price"};
                for (int i = 0; i < headers.Length; i++)
                {
                    worksheet.Cells[4, i + 1].Value = headers[i];
                    worksheet.Cells[4, i + 1].Style.Font.Bold = true;
                }

                // Add data
                int row = 5;
                foreach (var bill in Bills)
                {
                    worksheet.Cells[row, 1].Value = bill.Bill.Id;
                    worksheet.Cells[row, 2].Value = bill.Bill.DateBook;
                    worksheet.Cells[row, 3].Value = bill.Bill.DateCheckOut;
                    worksheet.Cells[row, 2].Style.Numberformat.Format = "yyyy-mm-dd hh:mm:ss";
                    worksheet.Cells[row, 3].Style.Numberformat.Format = "yyyy-mm-dd hh:mm:ss";
                    worksheet.Cells[row, 4].Value = string.Join("\n ", bill.Bill.BillDetails.Select(bi => $"{bi.IdProductNavigation?.Name ?? "Unknown"} x{bi.Quantity}"));
                    worksheet.Cells[row, 4].Style.WrapText = true;
                    worksheet.Cells[row, 5].Value = bill.TotalPrice;
                    row++;
                }

                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                try
                {
                    File.WriteAllBytes(filePath, package.GetAsByteArray());
                    MessageBox.Show($"File saved successfully at: {filePath}", "Export Successful", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving file: {ex.Message}", "Export Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void View()
        {
            var filteredBills = Bills
                          .Where(b => b.Bill.DateBook >= StartDate && (b.Bill.DateCheckOut <= EndDate || b.Bill.DateCheckOut == null))
                          .ToList();
           Bills = new ObservableCollection<BillWithTotal>(filteredBills);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public class BillInfosConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var billDetails = value as IEnumerable<BillDetails>;
            if (billDetails != null && billDetails.Any())
            {
                return string.Join("\n", billDetails.Select(bi => $"{bi.IdProductNavigation?.Name ?? "Unknown"} x{bi.Quantity}"));
            }
            return string.Empty;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class BillWithTotal
    {
        public Bill Bill { get; set; }
        public double TotalPrice { get; set; }
    }
}
