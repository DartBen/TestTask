using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace TestTask
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public double CursorX;
        public double CursorY;
        public MainWindow()
        {
            InitializeComponent();

            //для отправки запросов на положение и тд
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs a)
        {
            ;
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {

            CursorX = Mouse.GetPosition(Application.Current.MainWindow).X;
            Cursor_X.Text = CursorX.ToString();

            CursorY = Mouse.GetPosition(Application.Current.MainWindow).Y;
            Cursor_Y.Text = CursorY.ToString();
        }

        private void Button_1_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
