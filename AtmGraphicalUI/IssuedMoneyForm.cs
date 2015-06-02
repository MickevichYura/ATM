using System.Collections.Generic;
using System.Windows.Forms;
using ATM;

namespace AtmConsoleUI
{
    public partial class IssuedMoneyForm : Form
    {
        public IssuedMoneyForm()
        {
            InitializeComponent();
        }

        public IssuedMoneyForm(DataGridViewRowCollection data)
        {
            InitializeComponent();
            dataGridViewMoney.Rows.Clear();
            foreach (var row in data)
            {
                dataGridViewMoney.Rows.Add(row);
            }
        }

        public IssuedMoneyForm(Dictionary<decimal, int> data)
        {
            InitializeComponent();
            dataGridViewMoney.Rows.Clear();
            foreach (var pair in data)
            {
                dataGridViewMoney.Rows.Add(pair.Key, pair.Value);
            }
        }
    }
}
