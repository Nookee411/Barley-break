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
using Game_Library;

namespace FithteenWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Game game;
        DateTime startTime;
        int turn = 0;
        public MainWindow()
        {
            InitializeComponent();
            game = new Game(16);
            startTime = new DateTime(0);
        }

        private void SrartGame(object sender, RoutedEventArgs e)
        {
            GameStart();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int position = Convert.ToInt32(((Button)sender).Tag);
            game.Shift(position);
            Turns.Header = "Turns: " + turn;
            turn++;
            RefreshButtonField();
            if (game.EndGameCheck()){
               
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
            startTime = new DateTime();
            for (int i = 0; i < 1; i++)
                game.ShiftRandom();
            RefreshButtonField();
            turn = 0;

        }

        private void Fifteen_Load(object sender, RoutedEventArgs e)
        {
            GameStart();
        }
    }
}
