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

namespace Barley_break
{
    public partial class EndGameForm : Form
    {
        private int turns;
        private DateTime time;
        public EndGameForm(int turns,DateTime time)
        {
            InitializeComponent();
            this.turns = turns;
            this.time = time;
        }

        private void EndGameForm_Load(object sender, EventArgs e)
        {
            textBoxScore.Text = turns.ToString();
            textBoxTime.Text = time.ToString("mm:ss");
            StreamReader input = new StreamReader(@"..\\..\\Records.txt");
            List<string> records = new List<string>();
            while (!input.EndOfStream)
            {
                records.Add(input.ReadLine());
            }
            records.Insert(0,($"{turns}t {time.ToString("mm:ss")}"));
            if (records.Count == 10)
                records.RemoveAt(9);
            PrintLatestGames(records);
            input.Close();
            RecordLatestGames(records);
        }

        private void PrintLatestGames(List<string> games)
        {
            string output="";
            for(int i = 0;i<games.Count;i++)
            {
                output += $"{(i + 1).ToString()}. {games[i]}\n";
            }
            labelRecords.Text = output;   
        }
        private void RecordLatestGames(List<string> games)
        {
            StreamWriter output = new StreamWriter(@"..\\..\\Records.txt");
            foreach (string el in games)
                output.WriteLine(el);
            output.Close();
        }

        private void EndGameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
