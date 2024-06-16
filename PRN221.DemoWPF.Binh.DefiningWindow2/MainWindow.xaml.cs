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

namespace PRN221.DemoWPF.Binh.DefiningWindow2
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

        private void frMain_Navigated(object sender, NavigationEventArgs e)
        {

        }
        private void btnToPage01_Click(object sender, RoutedEventArgs e)
        {
            frMain.Content = new Page_01();
        }
        //Show Page_02
        private void btnToPage02_Click(object sender, RoutedEventArgs e)
        {
            frMain.Content = new Page_02();
        }
    }
}