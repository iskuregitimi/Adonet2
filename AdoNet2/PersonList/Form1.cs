using DataAccessLayer;
using Entities;
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

        public static int detay;

        private void Form1_Load(object sender, EventArgs e)
        {

            DataTable dt = DataContext.GetPersons("");
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dt;
            List<Person> person = DataContext.GetPersonForListBox("");
            listBox1.DataSource=person;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            DataTable dt = DataContext.GetPersons(name);
            dataGridView1.DataSource = dt;
            List<Person> person = DataContext.GetPersonForListBox(name);
            listBox1.DataSource=person;


        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            detay = Convert.ToInt32(dataGridView1[e.ColumnIndex,e.RowIndex].Value);
            Form2 frm = new Form2(detay);
            frm.Show();
        }
    }
}
