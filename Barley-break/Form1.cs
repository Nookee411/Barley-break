using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Game_Library;

namespace Barley_break
{
    public partial class Fifteen : Form
    {
        Game game;
        DateTime startTime;

        public Fifteen()
        {
            InitializeComponent();
            game = new Game(16);
            startTime = new DateTime(0);
        }

        private void RefreshButtonField()
        {
            for (int poition = 0; poition < 16; poition++)
            {
                if (game.GetNumber(poition).ToString() == "0")
                    GetButton(poition).Visible = false;
                else
                {
                    GetButton(poition).Text = game.GetNumber(poition).ToString();
                    GetButton(poition).Visible = true;

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
            toolStripCounter.Text = "Turns: 0";
            toolStripTimer.Text = "Time: 00:00";
            startTime = new DateTime();
            for(int i=0;i<5;i++)
                game.ShiftRandom();
            RefreshButtonField();
        }
        private void startMenu_Click(object sender, EventArgs e)
        {
            GameStart();
        }

        private void Fifteen_Load(object sender, EventArgs e)
        {
            GameStart();
        }

        private void button0_Click(object sender, EventArgs e)
        {
            game.Save();
            int position = Convert.ToInt32(((Button)sender).Tag);
            game.Shift(position);
            RefreshButtonField();
            toolStripCounter.Text = "Turns: " + game.GetTurnCounter;
            
            if (game.EndGameCheck())
            {
                EndGameForm egf = new EndGameForm(game.GetTurnCounter, startTime);
                egf.ShowDialog();
                GameStart();

            }
        }

       
        private void timer_Tick(object sender, EventArgs e)
        {
            startTime = startTime.AddSeconds(1);
            toolStripTimer.Text = "Time: " +startTime.ToString("mm:ss");
        }

        private void stepBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game.Restore();
            RefreshButtonField();
        }

        private void Fifteen_KeyDown(object sender, KeyEventArgs e)
        {
            if (ModifierKeys == Keys.Control && e.KeyCode == Keys.Z)
                stepBackToolStripMenuItem_Click(sender, e);
        }
    }
}
