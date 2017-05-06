using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OgrenciBilgiSistemi
{
    public partial class mainform : Form
    {
        public mainform()
        {
            InitializeComponent();
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            Form2 yeni = new Form2();
            yeni.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ogrgorevlisiform yeni = new ogrgorevlisiform();
            yeni.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

            yoneticiform yeni = new yoneticiform();
            yeni.Show();
            this.Hide();
        }
        int i=0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            labeltrh.Text = DateTime.Now.ToLongDateString() ;
            label1.Text = DateTime.Now.ToLongTimeString();
            
                
        }

        private void mainform_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            Form2 yeni = new Form2();
            yeni.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            yoneticiform yeni = new yoneticiform();
            yeni.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            ogrgorevlisiform yeni = new ogrgorevlisiform();
            yeni.Show();
            this.Hide();
        }
    }
}
