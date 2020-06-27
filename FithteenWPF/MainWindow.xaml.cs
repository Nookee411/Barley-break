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

namespace FithteenWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Game game;
        int turn = 0;
        DateTime time;
        DispatcherTimer timer;
        public MainWindow()
        {
            this.MinHeight = 250;
            this.MinWidth = 400;
            InitializeComponent();
            game = new Game(4);
            time = new DateTime(0);

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_tick;
            timer.Start();
        }
        
        void Timer_tick(object sender, EventArgs e)
        {
            Time.Header = "Time:" + time.ToString("mm:ss");
            time = time.AddSeconds(1);
        }

        private void SrartGame(object sender, RoutedEventArgs e)
        {
            GameStart();
            time = new DateTime(0);
            turn = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int position = Convert.ToInt32(((Button)sender).Tag);
            game.Shift(position);
            Turns.Header = "Turns: " + turn;

            turn++;
            RefreshButtonField();
            if (game.EndGameCheck()){
                MessageBox.Show("Победа!");
                GameStart();
            }
        }

        private void RefreshButtonField()
        {
            for (int poition = 0; poition < 16; poition++)
            {
                if (game.GetNumber(poition).ToString() == "0")
                    GetButton(poition).Visibility = Visibility.Hidden;
                else
                {
                    GetButton(poition).Content = game.GetNumber(poition).ToString();
                    GetButton(poition).Visibility = Visibility.Visible;

                }
            }
        }

        private Button GetButton(int index)
        {
            switch (index)
            {
                case 0: return button0;
                case 1: return button1;
                case 2: return button2;
                case 3: return button3;
                case 4: return button4;
                case 5: return button5;
                case 6: return button6;
                case 7: return button7;
                case 8: return button8;
                case 9: return button9;
                case 10: return button10;
                case 11: return button11;
                case 12: return button12;
                case 13: return button13;
                case 14: return button14;
                case 15: return button15;
                default: throw new IndexOutOfRangeException("Button doesn't exist");
            }

        }

        private void GameStart()
        {
            game.Start();
            game.TossBeforeGame(1);
            RefreshButtonField();
            turn = 0;
            Turns.Header = "Turns: " + turn;
            time = new DateTime(0);
            Time.Header = "Time:" + time.ToString("mm:ss");

        }

        private void Fifteen_Load(object sender, RoutedEventArgs e)
        {
            GameStart();
        }
    }
}
