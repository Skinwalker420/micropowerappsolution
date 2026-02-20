using System.Diagnostics;
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
using Peak.Can.Uds;
using Peak.Can.IsoTp;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace micropowerappsolution;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window, INotifyPropertyChanged
{
    public MainWindow()
    {
        DataContext = this;
        Debug.WriteLine("Start");

        PcanChannel channel = PcanChannel.Usb01;

        PcanStatus status = Api.GetValue(channel, PcanParameter.ChannelIdentifying, out uint condition); 
        Debug.WriteLine(condition);
        if(condition == 0)
        {
            Debug.WriteLine("Channel not available");
        }
        else
        {
            cantp_handle handle = new cantp_handle();
            cantp_baudrate baudrate = new cantp_baudrate();

            UDSApi.Initialize_2013(handle, baudrate);
        }

        
    }

    void button_Click(object sender, RoutedEventArgs e)
    {
        PcanChannel channel = PcanChannel.Usb01;

        PcanStatus status = Api.GetValue(channel, PcanParameter.HardwareName, out string name);
        if (status != PcanStatus.OK)
        {
            Api.GetErrorText(status, out var errorText);
            Debug.WriteLine(errorText);
        }
        else
        {
            Debug.WriteLine(name);
        }

        Api.SetValue(channel, PcanParameter.ChannelIdentifying, ParameterValue.Activation.Off);
    }

    void button_click2(object sender, RoutedEventArgs e)
    {
        StringBuilder buffer = new StringBuilder(255);
        uds_status status = UDSApi.GetValue_2013(cantp_handle.PCANTP_HANDLE_USBBUS1, uds_parameter.PUDS_PARAMETER_HARDWARE_NAME, buffer, 255);
        MessageBox.Show(buffer.ToString());

        Application.Current.Shutdown();
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private string boundText;

    public string BoundText
    {

        get { return boundText; }
        set 
        { 
            boundText = value;
            OnPropertyChanged();
        }
    }

    public void writeButton_Click(object sender, RoutedEventArgs e)
    {
        Debug.WriteLine(boundText);
    }

    public void readButton_Click(object sender, RoutedEventArgs e)
    {
        Random rand = new Random();
        BoundText = rand.Next(0, 100).ToString();
    }

    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}