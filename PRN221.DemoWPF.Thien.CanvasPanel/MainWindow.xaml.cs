using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PRN221.DemoWPF.Thien.CanvasPanel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnDisplay_Click(object sender, RoutedEventArgs e)
        {
            string CarInfo = $"Car Name: {txtCarName.Text}\n" + $"Color: {txtColor.Text} \nBrand: {txtBrand.Text}"; MessageBox.Show(CarInfo, "Car Details");
        }
    }
}