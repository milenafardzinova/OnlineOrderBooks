using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineOrderBooks
{
    public partial class MainForm : Form
    {
        List<Book> allBooks = new List<Book>();
        List<Order> allOrders = new List<Order>();
        List<Order> filteredOrders = new List<Order>();
        bool showFilter = false;
        public MainForm()
        {
            InitializeComponent();
            FillBooks();
            UpdateScreen();
        }

        void FillBooks()
        {
            allBooks.Add(new Book(1, "1984", "Джордж Оруэлл", 3));
            allBooks.Add(new Book(2, "Мастер и Маргарита", "Михаил Булгаков", 5));
            allBooks.Add(new Book(3, "Преступление и наказание", "Федор Достоевский", 2));
        }

        void UpdateScreen()
        {
            listBoxBooks.Items.Clear();
            foreach (Book b in allBooks)
            {
                string book = b.Title + " — " + b.Author + " (" + b.Count + " шт.)";
                listBoxBooks.Items.Add(book);
            }

            listBoxOrders.Items.Clear();
            filteredOrders.Clear();

            foreach (Order o in allOrders)
            {
                if (showFilter)
                {
                    double daysLeft = (o.ReturnDate.Date - DateTime.Today).TotalDays;
                    if (daysLeft <= 2)
                    {
                        string orderLine = "\"" + o.OrderedBook.Title + "\" у читателя: " + o.ReaderName + " (До: " + o.ReturnDate.ToShortDateString() + ")";
                        listBoxOrders.Items.Add(orderLine);
                        filteredOrders.Add(o); 
                    }
                }
                else
                {
                    string orderLine = "\"" + o.OrderedBook.Title + "\" у читателя: " + o.ReaderName + " (До: " + o.ReturnDate.ToShortDateString() + ")";
                    listBoxOrders.Items.Add(orderLine);
                }
            }
        }

        private void buttonOrder_Click(object sender, EventArgs e)
        {
            int index = listBoxBooks.SelectedIndex;
            Book selectedBook = allBooks[index];

            if (selectedBook.Count <= 0)
            {
                MessageBox.Show("Этой книги нет в наличии!");
                return;
            }
            OrderForm form2 = new OrderForm(selectedBook);
            form2.ShowDialog();
            selectedBook.Count--;
            Order newOrder = new Order(selectedBook, form2.Reader, form2.Date);
            allOrders.Add(newOrder);
            UpdateScreen();
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            showFilter = !showFilter;
            if (showFilter)
            {
                buttonCheck.Text = "Показать все";
            }
            else
            {
                buttonCheck.Text = "Проверить";
            }
            UpdateScreen();
        }
    }
}
