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
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Mobile mob = new Mobile();
            mob.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Accessories acc = new Accessories();
            acc.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Selling sold = new Selling();
            sold.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Login alog = new Login();
            alog.Show();
            this.Hide();
        }
    }
}
