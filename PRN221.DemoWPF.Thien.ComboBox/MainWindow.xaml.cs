using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PRN221.DemoWPF.Thien.ComboBox
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
        private void cboColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ComboBoxItem selectedItem = cboColor.SelectedItem as ComboBoxItem;
            if (selectedItem != null)
            {
                StackPanel stackPanel = selectedItem.Content as StackPanel;
                if (stackPanel != null)
                {
                    Label label = stackPanel.Children[1] as Label;
                    if (label != null)
                    {
                        string color = label.Content.ToString();
                        lblMsg.Content = "Your color is " + color;
                    }
                }
            }
        }
    }
}