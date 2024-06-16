using System.Collections.Generic;
using System.Windows;

namespace PRN221.DemoWPF.Thien.DataGrid
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
    
            Loaded += DemoDataGrid_Loaded;
        }

        private void DemoDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            List<dynamic> cars = new List<dynamic> {
                new { CarName = "A6", Color = "White", Brand = "Audi" },
                new { CarName = "Lexus 570", Color = "Black", Brand = "Toyota" },
                new { CarName = "Ford Ranger Raptor", Color = "White", Brand = "Ford" }
            };

            dgCarList.ItemsSource = cars;
        }
    }
}
