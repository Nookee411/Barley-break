using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barley_break_2
{
    public partial class Form1 : Form
    {
        TableLayoutPanel maintlp = new TableLayoutPanel()
        {
            ColumnCount = 1,
            RowCount = 2,
            Dock = DockStyle.Fill,
            CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset,
        };

        public Form1()
        {
            InitializeComponent();
            maintlp.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            maintlp.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            maintlp.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            Controls.Add(maintlp);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            maintlp.Show();
            MessageBox.Show(maintlp.RowCount.ToString());
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
