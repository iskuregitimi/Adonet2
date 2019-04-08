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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(int detay):this()
        {
            DataTable table = DataContext.GetPersonsDetail(detay);
            dataGridView1.DataSource = table;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }
    }
}
