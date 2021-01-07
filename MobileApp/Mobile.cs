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
    public partial class Mobile : Form
    {
        public Mobile()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
                Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }



        private void label1_Click(object sender, EventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\MobiSoftDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            string query = "select * from MobileTbl ";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            MobileDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (MobidTb.Text == "" || brandtb.Text == "" || modeltb.Text == "" || pricetb.Text == "" || stocktb.Text == "" || cameratb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string sql = "insert into MobileTbl values(" + MobidTb.Text + ",'" + brandtb.Text + "','" + modeltb.Text + "'," + pricetb.Text + "," + stocktb.Text + "," + ramcb.SelectedItem.ToString() + "," + romcb.SelectedItem.ToString() + "," + cameratb.Text + ")";
                    SqlCommand cmd = new SqlCommand(sql, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Mobile Added Successfully");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }
        private void Mobile_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void MobileDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MobidTb.Text = MobileDGV.SelectedRows[0].Cells[0].Value.ToString();
            brandtb.Text = MobileDGV.SelectedRows[0].Cells[1].Value.ToString();
            modeltb.Text = MobileDGV.SelectedRows[0].Cells[2].Value.ToString();
            pricetb.Text = MobileDGV.SelectedRows[0].Cells[3].Value.ToString();
            stocktb.Text = MobileDGV.SelectedRows[0].Cells[4].Value.ToString();
            ramcb.SelectedItem = MobileDGV.SelectedRows[0].Cells[5].Value.ToString();
            romcb.SelectedItem = MobileDGV.SelectedRows[0].Cells[6].Value.ToString();
            cameratb.Text = MobileDGV.SelectedRows[0].Cells[7].Value.ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MobidTb.Text = "";
            brandtb.Text = "";
            modeltb.Text = "";
            pricetb.Text = "";
            stocktb.Text = "";
            ramcb.SelectedItem = "";
            romcb.SelectedItem = "";
            cameratb.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MobidTb.Text == "")
            {
                MessageBox.Show("Enter the mobile to be deleted");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from  MobileTbl where Mobid =" + MobidTb.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Mobile Deleted");
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
            if (MobidTb.Text == "" || brandtb.Text == "" || modeltb.Text == "" || pricetb.Text == "" || stocktb.Text == "" || cameratb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string sql = "update MobileTbl set Mbrand ='" + brandtb.Text + "', Mmodel ='" + modeltb.Text + "', Mprice =" + pricetb.Text + ",MStock = " + stocktb.Text + ", MRam = " + ramcb.SelectedItem.ToString() + ",Mrom = " + romcb.SelectedItem.ToString() + ",MCam = " + cameratb.Text + " where Mobid = " + MobidTb.Text + ";";
                    SqlCommand cmd = new SqlCommand(sql, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Mobile Updated Successfully");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Home ahome = new Home();
            ahome.Show();
            this.Hide();
        }
    }
}
