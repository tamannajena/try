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
    public partial class Accessories : Form
    {
        public Accessories()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void modeltb_TextChanged(object sender, EventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\MobiSoftDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            string query = "select * from AccessorieTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            AccessoireDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (AidTb.Text == "" || ABrandtb.Text == "" || AModeltb.Text == "" || APricetb.Text == "" || AStocktb.Text == "" )
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String sql = "insert into AccessorieTbl values(" + AidTb.Text + ",'" + ABrandtb.Text + "','" + AModeltb.Text + "'," + APricetb.Text + "," + AStocktb.Text + ")";
                    SqlCommand cmd = new SqlCommand(sql, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Accessories Added Successfully");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }
        private void Accessories_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AidTb.Text = "";
            ABrandtb.Text = "";
            AModeltb.Text = "";
            APricetb.Text = "";
            AStocktb.Text = "";

        }

        private void AccessoireDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                AidTb.Text = AccessoireDGV.SelectedRows[0].Cells[0].Value.ToString();
                ABrandtb.Text = AccessoireDGV.SelectedRows[0].Cells[1].Value.ToString();
                AModeltb.Text = AccessoireDGV.SelectedRows[0].Cells[2].Value.ToString();
                APricetb.Text = AccessoireDGV.SelectedRows[0].Cells[3].Value.ToString();
                AStocktb.Text = AccessoireDGV.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (AidTb.Text == "")
            {
                MessageBox.Show("Enter the Accessorie to be deleted");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from  AccessorieTbl where Aid =" + AidTb.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Accessorie Deleted");
                    Con.Close();
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)//update
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Home ahome = new Home();
            ahome.Show();
            this.Hide();

        }
    }
}
