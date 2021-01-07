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
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        int startpoint = 15;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpoint += 1;
            Vprogram.Value = startpoint;
            LProgram.Value = startpoint;
            if(LProgram.Value == 100)
            {
                Vprogram.Value = 0;
                LProgram.Value = 0;
                timer1.Stop();
                Login alog = new Login();
                alog.Show();
                this.Hide();
            }
      }
    }
}
