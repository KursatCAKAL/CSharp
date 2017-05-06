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


namespace OgrenciBilgiSistemi
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=KURSATCAKAL\\SQL_2014;Initial Catalog=sistem;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            mainform yeni = new mainform();
            yeni.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            dondur.Tut = textBox1.Text;
            /*
            try
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("Select *from sifre where No=@nosu AND Sifre=@sifresi", baglantı);
                SqlParameter p1 = new SqlParameter("nosu", textBox1.Text.Trim());
                SqlParameter p2 = new SqlParameter("sifresi", textBox2.Text.Trim());
                komut.Parameters.Add(p1);
                komut.Parameters.Add(p2);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(komut);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Form3 fr = new Form3();
                    fr.Show();
                    this.Hide();

                }
            }

            catch (Exception)
            {
                MessageBox.Show("Hatalı Giris.");
                Form2 yeni = new Form2();
                yeni.Show();
                this.Hide();
            }*/
            
                baglantı.Open();
                SqlCommand komut = new SqlCommand("Select *from sifre where No=@nosu AND Sifre=@sifresi", baglantı);
                SqlParameter p1 = new SqlParameter("nosu", textBox1.Text.Trim());
                SqlParameter p2 = new SqlParameter("sifresi", textBox2.Text.Trim());
                komut.Parameters.Add(p1);
                komut.Parameters.Add(p2);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(komut);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Form3 fr = new Form3();
                    fr.Show();
                    this.Hide();

                }
           
            else
            {
                MessageBox.Show("Hatalı Giris.");
                Form2 yeni = new Form2();
                yeni.Show();
                this.Hide();
            }
        }
    }
}
