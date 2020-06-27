using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Game_Library;

namespace Barley_break_2
{
    public partial class Form1 : Form
    {
        private int fieldSize = 16;
        Game game;
        DateTime time;
        int turns = 0;

        TableLayoutPanel maintlp = new TableLayoutPanel();

        public Form1()
        {
            InitializeComponent();
            this.MinimumSize = new Size(250, 300);
            timer1.Interval = 1000;

        }

        private void button0_Click(object sender, EventArgs e)
        {
            game.Save();
            if (!timer1.Enabled)
                timer1.Start();
            int pos = Convert.ToInt32(((Button)sender).Tag);
            game.Shift(pos);
            RefreshButtonField();
            turns++;
            
            toolStripLabel1.Text = "Turns: " + turns.ToString();
            if (game.EndGameCheck())
            {
                timer1.Stop();
                time = new DateTime(0);
                turns = 0;
                MessageBox.Show("Победа");
                GameStart();
                toolStripLabelTime.Text = "Time: " + time.ToString("mm:ss");

            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = "";
        }

        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                InitiateField();
            }
        }

        private void InitiateField()
        {
            try
            {
                fieldSize = int.Parse(toolStripTextBox1.Text);
                if (fieldSize <= 0 || fieldSize >= 9)
                    throw new ArgumentException("Wrong field size.");

                game = new Game(fieldSize);
                tableLayoutPanel1.Controls.Clear();
                maintlp = new TableLayoutPanel();
                maintlp.RowCount = fieldSize;
                maintlp.ColumnCount = fieldSize;
                maintlp.Dock = DockStyle.Fill;
                tableLayoutPanel1.Controls.Add(maintlp, 0, 1);
                for (int i = 0; i < fieldSize; i++)
                {
                    maintlp.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / fieldSize));
                    maintlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 / fieldSize));

                }

                for (int i = 0; i < Math.Pow(fieldSize, 2); i++)
                {
                    //создание кнопок на поле
                    string s = "button" + i.ToString();
                    Button button1 = new Button();
                    button1.Text = "*";
                    button1.Click += button0_Click;
                    button1.Font = new Font(Font.Name, 20, Font.Style);
                    button1.Dock = DockStyle.Fill;
                    button1.Tag = i.ToString();
                    button1.Name = s;
                    maintlp.Controls.Add(button1, i % fieldSize, i / fieldSize);
                }

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RefreshButtonField()
        {
            for (int position = 0; position < Math.Pow(fieldSize, 2); position++)
            {
                GetButton(position).Text = game.GetNumber(position).ToString();
                GetButton(position).Visible = (game.GetNumber(position) > 0);
            }

        }

        private Button GetButton(int ind)
        {
            string s = "button" + ind.ToString();
            foreach (Control control in maintlp.Controls)
            {
                Button button = control as Button;
                if (button != null && button.Name == s) return button;
            }
            return null;
        }
        private void GameStart()
        {
            game.Start();
            game.TossBeforeGame(1);
            RefreshButtonField();
            turns = 0;
            toolStripLabel1.Text = "Turns: " + turns.ToString();
            time = new DateTime(0);
            
        }

        private void GameEnd()
        {

        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (game != null)
                GameStart();
            else
                MessageBox.Show("Firstly choose size.");
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time = time.AddSeconds(1);
            toolStripLabelTime.Text = "Time: " + time.ToString("mm:ss");
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            InitiateField();
        }

        private void stepBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                game.Restore();
                RefreshButtonField();
            }
            catch 
            { }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Z && ModifierKeys == Keys.Control)
                {
                    game.Restore();
                    RefreshButtonField();
                }
            }
            catch
            { }
            
        }
    }
}
