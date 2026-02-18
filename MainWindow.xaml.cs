using System.Diagnostics;
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

    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        Binding wheelBinding = new Binding("AngleName");
        double speed = 1;
        Random rnd = new Random();
        btn.IsEnabled = false;
        double realValue = 360/38 * 0;
        double value = Math.Floor(realValue/360 * 38); //rnd.Next(0, 360);
        realValue += 0;
        Debug.WriteLine(value);
        for (double i = 1; i <= realValue; i += speed) {
            Angle _angle = new Angle(-i);
            myGrid.DataContext = _angle;
            speed = Math.Clamp(realValue/i - 1, 0.0075, 1.5);
            await Task.Delay(1);
        }
        btn.IsEnabled = true;

        if (value == 0 || value == 19)
        {
            MessageBox.Show("Green");
        }
        else if (value % 2 == 0) { MessageBox.Show("Black"); }
        else { MessageBox.Show("Red"); }
    }
}
public class Vector
{
    public int x, y;

    public Vector(int X, int Y) { x = X; y = Y; }
}
public class Angle
{
    public double thisAngle { get; set; }
    public Angle(double x) { this.thisAngle = x; }
}