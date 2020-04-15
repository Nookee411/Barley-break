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

namespace Barley_break_Unliminted
{
    public partial class Form1 : Form
    {
        TableLayoutPanel maintlp = new TableLayoutPanel()
        {
            BackColor = Color.Black,
            Dock = DockStyle.Fill,
            ColumnCount = 2,
            RowCount = 2,
        };

        public Form1()
        {
            InitializeComponent();
            maintlp.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            maintlp.Enabled = true;
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
