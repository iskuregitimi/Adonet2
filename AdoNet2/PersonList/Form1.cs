using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = DataContext.GetPersons(string.Empty);
            dataGridView1.DataSource = dt;

            var persons = DataContext.GetPersonForListBox(string.Empty);
            listBox1.DataSource = persons;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = DataContext.GetPersons(textBox1.Text.Trim());
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dt;

            //TODO: burayada listboxu ekle

        }
    }
}
