using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Game_Library;

namespace Dynamic_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int fieldSize;
        Game game;
        int turn;
        DateTime time;
        DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();
            uniformGrid.Columns = 5;
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0,0,1);
            timer.Tick += Timer_Tick;
            
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Time.Header = "Time: " + time.ToString("mm:ss");
            time = time.AddSeconds(1);
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                fieldSize = int.Parse(tbSize.Text);
                if (fieldSize <= 0 || fieldSize >= 9)
                    throw new ArgumentException();

                game = new Game(fieldSize);
                uniformGrid.Columns = fieldSize;
                uniformGrid.Rows = fieldSize;

                for (int i = 0; i < Math.Pow(fieldSize, 2); i++)
                {
                    //создание кнопок на поле
                    string s = "button" + i.ToString();
                    Button button1 = new Button();
                    button1.Content = "*";
                    button1.Click += button0_Click;
                    button1.FontSize = 20;
                    button1.Tag = i.ToString();
                    button1.Name = s;
                    button1.Visibility = Visibility.Visible;
                    uniformGrid.Children.Add(button1);

                }
            }
            catch
            {
                MessageBox.Show("Incoorect size.");
            }
        }

        private void button0_Click(object sender, RoutedEventArgs e)
        {
            int position = Convert.ToInt32(((Button)sender).Tag);
            game.Shift(position);
            RefreshButtonField();
            turn++;
            Turns.Header = "Turns: " + turn;
            if (game.EndGameCheck())
            {
                timer.Stop();
                MessageBox.Show($"Победа! \nВремя:{time.ToString("mm:ss")}\nTurns: {turn}");
                GameStart();
            }
        }

        private void SrartGame(object sender, RoutedEventArgs e)
        {
            if(game!=null)
            GameStart();
            timer.Stop();
        }

        private void RefreshButtonField()
        {
            for (int position = 0; position < Math.Pow(fieldSize, 2); position++)
            {
                GetButton(position).Content = game.GetNumber(position).ToString();
                GetButton(position).Visibility = (game.GetNumber(position) > 0?Visibility.Visible:Visibility.Hidden);
            }

        }

        private Button GetButton(int ind)
        {
            string s = "button" + ind.ToString();
            foreach (UIElement element in uniformGrid.Children)
            {
                Button button = element as Button;
                if (button != null && button.Name == s) return button;
            }
            return null;
        }
        private void GameStart()
        {
            time = new DateTime(0);
            turn = 0;
            game.Start();
            game.TossBeforeGame(1000);
            RefreshButtonField();
            Turns.Header = "Turns: " + turn;
            timer.Start();
        }
    }
}
