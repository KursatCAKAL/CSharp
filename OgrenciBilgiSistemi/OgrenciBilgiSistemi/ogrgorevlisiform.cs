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
    public partial class ogrgorevlisiform : Form
    {
        public ogrgorevlisiform()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=KURSATCAKAL\\SQL_2014;Initial Catalog=sistem;Integrated Security=True");

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            mainform yeni = new mainform();
            yeni.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            dondur.Tut = textBox1.Text;
        
            
                baglantı.Open();
                SqlCommand komut = new SqlCommand("Select *from ogruyesi where KullanıcıNo=@kno AND Sifre=@sifresi",baglantı);
                SqlParameter p1 = new SqlParameter("kno", textBox1.Text.Trim());
                SqlParameter p2 = new SqlParameter("sifresi", textBox2.Text.Trim());

                komut.Parameters.Add(p1);
                komut.Parameters.Add(p2);

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(komut);
                da.Fill(dt);
                if(dt.Rows.Count>0)
                {
                    ogrgorevlisimain  yeni = new ogrgorevlisimain();
                    yeni.Show();
                    this.Hide();
                }
            
           else
            {
                MessageBox.Show("Hatalı Giris.Lutfen Tekrar Deneyin.");
                ogrgorevlisiform yeni = new ogrgorevlisiform();
                yeni.Show();
                this.Hide();
               
                
            }
            

        }
    }
}
