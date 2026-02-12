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
        StringBuilder condition = new StringBuilder(PCANBasic.MAX_LENGTH_HARDWARE_NAME);
        uint activate;
        MessageBoxResult result;
        TPCANStatus value = PCANBasic.GetValue(PCANBasic.PCAN_USBBUS1, TPCANParameter.PCAN_HARDWARE_NAME, condition, PCANBasic.MAX_LENGTH_HARDWARE_NAME);
        result = MessageBox.Show("" + condition, "blink",MessageBoxButton.YesNo);
        if(result == MessageBoxResult.Yes)
        {
            activate = PCANBasic.PCAN_PARAMETER_ON;
        }
        else
        {
            activate = PCANBasic.PCAN_PARAMETER_OFF;
        }
        PCANBasic.SetValue(PCANBasic.PCAN_USBBUS1, TPCANParameter.PCAN_CHANNEL_IDENTIFYING, ref activate, sizeof(uint));
    }
}