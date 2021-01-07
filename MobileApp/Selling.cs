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
    public partial class Selling : Form
    {
        public Selling()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\MobiSoftDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void populateAccess()
        {
            Con.Open();
            string query = "select ABrand,AModel,Aprice from AccessorieTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder scb = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            AccessoireDGV.DataSource = ds.Tables[0];
            Con.Close();

        }   
        
        private void populate()
        {
            Con.Open();
            string query = "select Mbrand,MModel, Mprice from MobileTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            MobileDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        SqlConnection Con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\MobiSoftDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void Sum()
        {
            string query = "select sum(Amt) from NewTbl";
            Con1.Open();
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Sellamtlbl.Text = dt.Rows[0][0].ToString();  
            Con1.Close();
        }
        private void Selling_Load(object sender, EventArgs e)
        {
            Sum();
            populate();
            populateAccess();
        }
        //

        private void MobileDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ProductTb.Text = MobileDGV.SelectedRows[0].Cells[0].ToString() + MobileDGV.SelectedRows[0].Cells[1].Value.ToString();
            PriceTb.Text = MobileDGV.SelectedRows[0].Cells[2].Value.ToString();

        }

        private void AccessoireDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ProductTb.Text = AccessoireDGV.SelectedRows[0].Cells[0].Value.ToString() + AccessoireDGV.SelectedRows[0].Cells[1].Value.ToString();
            PriceTb.Text = AccessoireDGV.SelectedRows[0].Cells[2].Value.ToString();
        }
     


        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
        int prodid, prodqty, prodprice, tottal, pos = 60;
        private void button5_Click(object sender, EventArgs e)
        {
            Home ahome = new Home();
            ahome.Show();   
            this.Hide();
        }
        string prodname;
        private void insertbill1()
        {
            if (BillIdTb.Text == "" || ClientNameTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                int amount = Convert.ToInt32(Amtlbl.Text);
                try
                {
                    Con.Open();
                    String san = "insert into NewTbl values(" + BillIdTb.Text + ",'" + ClientNameTb.Text + "'," + amount + ")";
                    SqlCommand cmd = new SqlCommand(san, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Added Successfully");
                    Con.Close();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Amountlbl_Click(object sender, EventArgs e)
        {
            Sum();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("MobiSoft 1.0", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Red, new Point(90,15));
            e.Graphics.DrawString("ID PRODUCT PRICE QUANTITY TOTAL", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Red, new Point(26,40));
            foreach (DataGridViewRow row in DGV.Rows)
            {
                prodid = Convert.ToInt32(row.Cells["Column1"].Value);
                prodname = ""+row.Cells["Column2"].Value;
                prodprice = Convert.ToInt32(row.Cells["Column3"].Value);
                prodqty = Convert.ToInt32(row.Cells["Column4"].Value);
                tottal = Convert.ToInt32(row.Cells["Column5"].Value);
                e.Graphics.DrawString("" + prodid, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(26,pos));
                e.Graphics.DrawString("" + prodname, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point( 45,pos));
                e.Graphics.DrawString("" + prodprice, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(120,pos));
                e.Graphics.DrawString("" + prodqty, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(170,pos));
                e.Graphics.DrawString("" + tottal, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(235,pos));
                pos = pos + 20; 
            }
            e.Graphics.DrawString("Grand Total: Rs" + Grdtotal,new Font("Century Gothic",12,FontStyle.Bold),Brushes.Crimson,new Point(50,pos + 50));
            e.Graphics.DrawString("**************MobiSoft**************", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Crimson, new Point(10, pos + 85));
            DGV.Rows.Clear();
            DGV.Refresh();
            pos = 100;
            Grdtotal = 0;
            n = 0;
            insertbill1();
            Sum();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm",285,600);
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
            
        }
        int n = 0, Grdtotal = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            
            if (QtyTb.Text == "" || PriceTb.Text == "")
            {
                MessageBox.Show("Enter the quantity ");
            }
            else
            {
                int total = Convert.ToInt32(QtyTb.Text) * Convert.ToInt32(PriceTb.Text);
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(DGV);
                newRow.Cells[0].Value = n + 1;
                newRow.Cells[1].Value = ProductTb.Text;
                newRow.Cells[2].Value = PriceTb.Text;
                newRow.Cells[3].Value = QtyTb.Text;
               newRow.Cells[4].Value = total;
                DGV.Rows.Add(newRow);
                n++;
                Grdtotal = Grdtotal + total;
                Amtlbl.Text ="" + Grdtotal;
            }
        }
    }
}
