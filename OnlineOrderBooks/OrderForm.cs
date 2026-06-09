using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace OnlineOrderBooks
{
    public partial class OrderForm : Form
    {
        public string Reader
        {
            get { return textBoxName.Text; }
        }
        public DateTime Date
        {
            get { return dateTimePicker.Value; }
        }

        public OrderForm(Book chosenBook)
        {
            InitializeComponent();
            this.Text = "Оформление книги: '" + chosenBook.Title + "'";
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Введите имя читателя!");
                return;
            }
            this.Close();
        }
    }
}
