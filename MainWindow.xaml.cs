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
using Peak.Can.Basic;

namespace micropowerappsolution;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    void button_Click(object sender, RoutedEventArgs e)
    {
        uint condition;
        TPCANStatus value = PCANBasic.GetValue(PCANBasic.PCAN_USBBUS1, TPCANParameter.PCAN_CHANNEL_CONDITION, out condition, sizeof(uint));
        MessageBox.Show("" + condition);
         
    }
}