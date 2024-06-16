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

namespace PRN221.DemoWPF.Thien.ListBox
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
        private void cmd_CheckAllItems(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (CheckBox item in 1st.Items) {
                if (item.IsChecked == true)
                {
                    sb.Append(
                    item.Content + is checked.");
                    sb.Append("\r\n");
                }
            }
            txtSelection.Text = sb.ToString();
        }
    }
}