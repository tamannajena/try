using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileApp
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mobile mob = new Mobile();
            mob.Show();
            this.Hide();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Selling sold = new Selling();
            sold.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Accessories acc = new Accessories();
            acc.Show();
            this.Hide();
        }
    }
}
