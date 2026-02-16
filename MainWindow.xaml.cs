using System.Security.Policy;
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
    bool player1Turn = false;
    int[,] grid = { {0, 0, 0}, { 0, 0, 0}, { 0, 0, 0} };
    public MainWindow()
    {
        InitializeComponent();
    }
    void button_Click0(object sender, RoutedEventArgs e)
    {
        /*StringBuilder condition = new StringBuilder(PCANBasic.MAX_LENGTH_HARDWARE_NAME);
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
        PCANBasic.SetValue(PCANBasic.PCAN_USBBUS1, TPCANParameter.PCAN_CHANNEL_IDENTIFYING, ref activate, sizeof(uint)); */
        Vector pos = new Vector(0, 0);
        Game_Input(button, pos);

    }
    void button_Click1(object sender, RoutedEventArgs e)
    {
        Vector pos = new Vector(0, 1);
        Game_Input(button1, pos);
    }
    void button_Click2(object sender, RoutedEventArgs e)
    {
        Vector pos = new Vector(0, 2);
        Game_Input(button2, pos);
    }
    void button_Click3(object sender, RoutedEventArgs e)
    {
        Vector pos = new Vector(1, 0);
        Game_Input(button3, pos);
    }
    void button_Click4(object sender, RoutedEventArgs e)
    {
        Vector pos = new Vector(1, 1);
        Game_Input(button4, pos);
    }
    void button_Click5(object sender, RoutedEventArgs e)
    {
        Vector pos = new Vector(1, 2);
        Game_Input(button5, pos);
    }
    void button_Click6(object sender, RoutedEventArgs e)
    {
        Vector pos = new Vector(2, 0);
        Game_Input(button6, pos);
    }
    void button_Click7(object sender, RoutedEventArgs e)
    {
        Vector pos = new Vector(2, 1);
        Game_Input(button7, pos);
    }
    void button_Click8(object sender, RoutedEventArgs e)
    {
        Vector pos = new Vector(2, 2);
        Game_Input(button8, pos);
    }

    void Game_Input(Button inputbutton, Vector position)
    {
        WinCondition(0);
        if (inputbutton.Content != null) { return; }
        player1Turn = !player1Turn;
        if (player1Turn) { 
            inputbutton.Content = "X";
            grid[position.x, position.y] = 1;

            return; 
        }
        inputbutton.Content = "O";
        grid[position.x, position.y] = 2;
    }
    void WinCondition(int player)
    {
        
    }
}
public class Vector
{
    public int x, y;

    public Vector(int X, int Y) { x = X; y = Y; }
}