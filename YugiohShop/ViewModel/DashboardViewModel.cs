using Microsoft.EntityFrameworkCore;
using Model.Models;
using OxyPlot;

using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YugiohShop.ViewModel
{
    public class DashboardViewModel : INotifyPropertyChanged
    {
        public PlotModel BarchartModel { get; set; }

        private readonly DBContext _context;

        public PlotModel PiechartModel { get; set; }
        public PlotModel LinechartModel {  get; set; }

        private int _accountCount;
        private int _totalOrders;
        private double _totalRevenue;

        public int AccountCount
        {
            get => _accountCount;
            set
            {
                _accountCount = value;
                OnPropertyChanged(nameof(AccountCount));
            }
        }

        public int TotalOrders
        {
            get => _totalOrders;
            set
            {
                _totalOrders = value;
                OnPropertyChanged(nameof(TotalOrders));
            }
        }

        public double TotalRevenue
        {
            get => _totalRevenue;
            set
            {
                _totalRevenue = value;
                OnPropertyChanged(nameof(TotalRevenue));
            }
        }

        public DashboardViewModel()
        {
            _context = new DBContext();
            LoadData();
            BarchartModel = CreateBarChartModel();
            PiechartModel = CreatePieChartModel();
            LinechartModel = CreateLineChartModel();
        }

        private void LoadData()
        {
            AccountCount = _context.Accounts.Count();
            TotalOrders = _context.Bills.Count();
            TotalRevenue = _context.Bills
                                 .Include(b => b.BillDetails) 
                                    .ThenInclude(bi => bi.IdProductNavigation) 
                                 .SelectMany(b => b.BillDetails)
                                 .Sum(bi => bi.Quantity * bi.IdProductNavigation.Price);
        }

        private PlotModel? CreateBarChartModel()
        {
            var model = new PlotModel
            {
                Title = "Product Categories",
                LegendPosition = LegendPosition.TopRight,
                LegendPlacement = LegendPlacement.Outside,
                LegendOrientation = LegendOrientation.Horizontal,
                LegendBorderThickness = 0
            };


            var categoryAxis = new CategoryAxis { Position = AxisPosition.Bottom, Title = "Month" };
            categoryAxis.Labels.Add("6/2024");
            categoryAxis.Labels.Add("7/2024");
            model.Axes.Add(categoryAxis);

            // Create LinearAxis for Y-axis (counts)
            var valueAxis = new LinearAxis { Position = AxisPosition.Left, Title = "Count" };
            model.Axes.Add(valueAxis);

            var cardBoxSeries = new ColumnSeries { Title = "Hộp thẻ bài", FillColor = OxyColors.AliceBlue };
            var cardPackSeries = new ColumnSeries { Title = "Gói thẻ bài", FillColor = OxyColors.AntiqueWhite };
            var accessorySeries = new ColumnSeries { Title = "Phụ kiện", FillColor = OxyColors.Azure };

            // Count the numbers in June and July
            var orders = _context.Bills.Include(b => b.BillDetails).ThenInclude(bi => bi.IdProductNavigation);
            var juneCardBoxCount = orders
                .Where(o => o.DateBook.Month == 6 && o.DateBook.Year == 2024)
                .SelectMany(o => o.BillDetails)
                .Where(b => b.IdProductNavigation.IdCategory == 1)
                .Sum(b => b.Quantity);
            var julyCardBoxCount = orders
                .Where(o => o.DateBook.Month == 7 && o.DateBook.Year == 2024)
                .SelectMany(o => o.BillDetails)
                .Where(b => b.IdProductNavigation.IdCategory == 1)
                .Sum(b => b.Quantity);
            var juneCardPackCount = orders
                .Where(o => o.DateBook.Month == 6 && o.DateBook.Year == 2024)
                .SelectMany(o => o.BillDetails)
                .Where(b => b.IdProductNavigation.IdCategory == 2)
                .Sum(b => b.Quantity);
            var julyCardPackCount = orders
                .Where(o => o.DateBook.Month == 7 && o.DateBook.Year == 2024)
                .SelectMany(o => o.BillDetails)
                .Where(b => b.IdProductNavigation.IdCategory == 2)
                .Sum(b => b.Quantity);
            var juneAccessoryCount = orders
               .Where(o => o.DateBook.Month == 6 && o.DateBook.Year == 2024)
               .SelectMany(o => o.BillDetails)
               .Where(b => b.IdProductNavigation.IdCategory == 3)
               .Sum(b => b.Quantity);
            var julyAccessoryCount = orders
                .Where(o => o.DateBook.Month == 7 && o.DateBook.Year == 2024)
                .SelectMany(o => o.BillDetails)
                .Where(b => b.IdProductNavigation.IdCategory == 3)
                .Sum(b => b.Quantity);

            cardBoxSeries.Items.Add(new ColumnItem { Value = juneCardBoxCount });
            cardBoxSeries.Items.Add(new ColumnItem { Value = julyCardBoxCount });
            cardPackSeries.Items.Add(new ColumnItem { Value = juneCardPackCount });
            cardPackSeries.Items.Add(new ColumnItem { Value = julyCardPackCount });
            accessorySeries.Items.Add(new ColumnItem { Value = juneAccessoryCount });
            accessorySeries.Items.Add(new ColumnItem { Value = julyAccessoryCount });

            model.Series.Add(cardBoxSeries);
            model.Series.Add(cardPackSeries);
            model.Series.Add(accessorySeries);

            return model;
        }

        private PlotModel CreatePieChartModel()
        {
            var model = new PlotModel
            {
                Title = "Total Category Product",
                IsLegendVisible = true,
                LegendPosition = LegendPosition.RightTop,
                LegendPlacement = LegendPlacement.Outside,
                LegendOrientation = LegendOrientation.Vertical,
                LegendBorderThickness = 0
            };

            var series = new PieSeries
            {
                StrokeThickness = 2.0,
                InsideLabelPosition = 0.8,
                AngleSpan = 360,
                StartAngle = 0
            };

            var orders = _context.Bills.Include(b => b.BillDetails).ThenInclude(bi => bi.IdProductNavigation);

            var cardBoxCount = orders
                .SelectMany(o => o.BillDetails)
                .Where(b => b.IdProductNavigation.IdCategory == 1)
                .Sum(b => b.Quantity);

            var cardPacksCount = orders
                .SelectMany(o => o.BillDetails)
                .Where(b => b.IdProductNavigation.IdCategory == 2)
                .Sum(b => b.Quantity);

            var accessoryCount = orders
                .SelectMany (o => o.BillDetails)
                .Where(b => b.IdProductNavigation.IdCategory == 3)
                .Sum(b => b.Quantity);

            series.Slices.Add(new PieSlice("Hộp thẻ bài", cardBoxCount) { Fill = OxyColors.AliceBlue });
            series.Slices.Add(new PieSlice("Gói thẻ bài", cardPacksCount) { Fill = OxyColors.AntiqueWhite });
            series.Slices.Add(new PieSlice("Phụ kiện", accessoryCount) { Fill = OxyColors.Azure });


            model.Series.Add(series);

            return model;
        }

        private PlotModel CreateLineChartModel()
        {
            var model = new PlotModel
            {
                Title = "Statistical",
                LegendPosition = LegendPosition.TopRight,
                LegendPlacement = LegendPlacement.Outside,
                LegendOrientation = LegendOrientation.Horizontal,
                LegendBorderThickness = 0
            };

            model.Padding = new OxyThickness(10, 10, 10, 10);

            var categoryAxis = new CategoryAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Khoảng thời gian",
                AxislineStyle = LineStyle.Solid,
                AxislineThickness = 1,
                AxislineColor = OxyColors.Black
            };
            var timeRanges = new[] { "0-4h", "4-8h", "8-12h","12-16h", "16-20h", "20-24h" };
            categoryAxis.Labels.AddRange(timeRanges);
            model.Axes.Add(categoryAxis);

            var valueAxis = new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "Number of Orders",
                AbsoluteMinimum = 0,
                AxislineStyle = LineStyle.Solid,
                AxislineThickness = 1,
                AxislineColor = OxyColors.Black
            };
            model.Axes.Add(valueAxis);

            var series = new LineSeries
            {
                Title = "Orders",
                Color = OxyColors.Red,
                StrokeThickness = 2,
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColors.Blue,
                MarkerFill = OxyColors.Blue,
                InterpolationAlgorithm = InterpolationAlgorithms.CatmullRomSpline 
            };

            var orders = _context.Bills;

            var orderCounts = new[]
            {
                orders.Count(o => o.DateBook.Hour >= 0 && o.DateBook.Hour < 4),
                orders.Count(o => o.DateBook.Hour >= 4 && o.DateBook.Hour < 8),
                orders.Count(o => o.DateBook.Hour >= 8 && o.DateBook.Hour < 12),
                orders.Count(o => o.DateBook.Hour >= 12 && o.DateBook.Hour < 16),
                orders.Count(o => o.DateBook.Hour >= 16 && o.DateBook.Hour < 20),
                orders.Count(o => o.DateBook.Hour >= 20 && o.DateBook.Hour < 24)

            };

            for (int i = 0; i < orderCounts.Length; i++)
            {
                series.Points.Add(new DataPoint(i, orderCounts[i]));
            }
            model.Series.Add(series);

            return model;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
