using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MobileApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            UidTb.Text = "";
            PassTb.Text = "";
        }

        private void UidTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
               
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (UidTb.Text == ""||PassTb.Text =="")
            {
                MessageBox.Show("Enter Username and password");
            }
            else if(UidTb.Text =="Admin" && PassTb.Text == "Admin")
            {
                Home ahome = new Home();
                ahome.Show();
                this.Hide();
            }
            else if(UidTb.Text =="User" && PassTb.Text == "User")
            {
                User use = new User();
                use.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong username and Password ");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
