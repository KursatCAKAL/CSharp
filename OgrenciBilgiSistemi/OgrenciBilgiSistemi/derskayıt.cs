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
    public partial class derskayıt : Form
    {
        public derskayıt()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=KURSATCAKAL\\SQL_2014;Initial Catalog=sistem;Integrated Security=True");
        private void derskayıt_Load(object sender, EventArgs e)
        {
            pictureBox1.Hide();
            pictureBox2.Hide();
            pictureBox3.Hide();
            pictureBox4.Hide();
            pictureBox5.Hide();
            pictureBox6.Hide();
            groupBox1.Hide();
            groupBox2.Hide();
            groupBox3.Hide();
            groupBox4.Hide();
            groupBox5.Hide();
            groupBox6.Hide();

            label2.Text = dondur.Tut;
            baglantı.Open();
            SqlCommand komut = new SqlCommand("Select *from ogrencibilgi where Numara=@numarasi",baglantı);
            komut.Parameters.AddWithValue("@numarasi", label2.Text.ToString());//ToString ifadesini eklemelisin.

            SqlDataAdapter da = new SqlDataAdapter(komut);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                label3.Text = dr["Bolum"].ToString();
            }
            if(label3.Text.ToString().Trim() == "Bilgisayar Muhendisligi")
            {
                groupBox1.Show();
                pictureBox6.Show();
            }
            if (label3.Text.ToString().Trim() == "Endustri Muhendisligi")
            {
                groupBox2.Show();
                pictureBox2.Show();

            }
            if (label3.Text.ToString().Trim() == "Kimya Muhendisligi")
            {
                groupBox5.Show();
                pictureBox5.Show();

            }
          /*  if (label2.Text.Substring(0, 2) == "12")
            {
                groupBox3.Show();
                pictureBox3.Show();

            }
            if (label2.Text.Substring(0, 2) == "11")
            {
                groupBox4.Show();
                pictureBox4.Show();

            }
            
            if (label2.Text.Substring(0, 2) == "16")
            {
                groupBox6.Show();
                pictureBox6.Show();

            }
            */
            dr.Close();
            baglantı.Close();

        


            /* string secim;
             secim = label3.Text;
    switch (secim)
               {
                   case "Bilgisayar Muhendisligi":
                     groupBox1.Show();
                       break;
                  case "Endustri Muhendisligi":
                     groupBox2.Show();
                       break;
                  /* case "İnsaat Muhendisligi":
                       checkedListBox2.Show();
                       break;
                   case "Kimya Muhendisligi":
                       checkedListBox4.Show();
                       break;
                   case "Endustri Muhendisligi":
                       checkedListBox5.Show();
                       break;
                   case "Elektrik Muhendisligi":
                       checkedListBox6.Show();
                       break;

             default:
                       break;
             */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("insert into derskayıt1(No,Ders1,Ders2,Ders3,Ders4,Ders5,Ders6) values(@nosu,@bir,@iki,@uc,@dort,@bes,@alti)", baglantı);
            komut.Parameters.AddWithValue("@nosu", label2.Text);
            komut.Parameters.AddWithValue("@bir", checkBox1.Text);
            komut.Parameters.AddWithValue("@iki", checkBox2.Text);
            komut.Parameters.AddWithValue("@uc", checkBox3.Text);
            komut.Parameters.AddWithValue("@dort", checkBox4.Text);
            komut.Parameters.AddWithValue("@bes", checkBox5.Text);
            komut.Parameters.AddWithValue("@alti", checkBox6.Text);
            komut.ExecuteNonQuery();
            baglantı.Close();

            MessageBox.Show("Bilgisayar Muhendisi Kayıt Basarili.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("insert into derskayıt1(No,Ders1,Ders2,Ders3,Ders4,Ders5,Ders6) values(@nosu,@bir,@iki,@uc,@dort,@bes,@alti)", baglantı);
            komut.Parameters.AddWithValue("@nosu", label2.Text);
            komut.Parameters.AddWithValue("@bir", checkBox10.Text);
            komut.Parameters.AddWithValue("@iki", checkBox12.Text);
            komut.Parameters.AddWithValue("@uc", checkBox11.Text);
            komut.Parameters.AddWithValue("@dort", checkBox9.Text);
            komut.Parameters.AddWithValue("@bes", checkBox8.Text);
            komut.Parameters.AddWithValue("@alti", checkBox7.Text);
            komut.ExecuteNonQuery();
            baglantı.Close();

            MessageBox.Show("Endustri Muhendisi Kayıt Basarili.");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("insert into derskayıt1(No,Ders1,Ders2,Ders3,Ders4,Ders5,Ders6) values(@nosu,@bir,@iki,@uc,@dort,@bes,@alti)", baglantı);
            komut.Parameters.AddWithValue("@nosu", label2.Text);
            komut.Parameters.AddWithValue("@bir", checkBox16.Text);
            komut.Parameters.AddWithValue("@iki", checkBox18.Text);
            komut.Parameters.AddWithValue("@uc", checkBox17.Text);
            komut.Parameters.AddWithValue("@dort", checkBox15.Text);
            komut.Parameters.AddWithValue("@bes", checkBox14.Text);
            komut.Parameters.AddWithValue("@alti", checkBox13.Text);
            komut.ExecuteNonQuery();
            baglantı.Close();

            MessageBox.Show("Makine Muhendisi Kayıt Basarili.");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("insert into derskayıt1(No,Ders1,Ders2,Ders3,Ders4,Ders5,Ders6) values(@nosu,@bir,@iki,@uc,@dort,@bes,@alti)", baglantı);
            komut.Parameters.AddWithValue("@nosu", label2.Text);
            komut.Parameters.AddWithValue("@bir", checkBox22.Text);
            komut.Parameters.AddWithValue("@iki", checkBox24.Text);
            komut.Parameters.AddWithValue("@uc", checkBox23.Text);
            komut.Parameters.AddWithValue("@dort", checkBox21.Text);
            komut.Parameters.AddWithValue("@bes", checkBox20.Text);
            komut.Parameters.AddWithValue("@alti", checkBox19.Text);
            komut.ExecuteNonQuery();
            baglantı.Close();

            MessageBox.Show("İnsaat Muhendisi Kayıt Basarili.");
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("insert into derskayıt1(No,Ders1,Ders2,Ders3,Ders4,Ders5,Ders6) values(@nosu,@bir,@iki,@uc,@dort,@bes,@alti)", baglantı);
            komut.Parameters.AddWithValue("@nosu", label2.Text);
            komut.Parameters.AddWithValue("@bir", checkBox28.Text);
            komut.Parameters.AddWithValue("@iki", checkBox30.Text);
            komut.Parameters.AddWithValue("@uc", checkBox29.Text);
            komut.Parameters.AddWithValue("@dort", checkBox27.Text);
            komut.Parameters.AddWithValue("@bes", checkBox26.Text);
            komut.Parameters.AddWithValue("@alti", checkBox25.Text);
            komut.ExecuteNonQuery();
            baglantı.Close();

            MessageBox.Show("Kimya Muhendisi Kayıt Basarili.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("insert into derskayıt1(No,Ders1,Ders2,Ders3,Ders4,Ders5,Ders6) values(@nosu,@bir,@iki,@uc,@dort,@bes,@alti)", baglantı);
            komut.Parameters.AddWithValue("@nosu", label2.Text);
            komut.Parameters.AddWithValue("@bir", checkBox34.Text);
            komut.Parameters.AddWithValue("@iki", checkBox36.Text);
            komut.Parameters.AddWithValue("@uc", checkBox35.Text);
            komut.Parameters.AddWithValue("@dort", checkBox33.Text);
            komut.Parameters.AddWithValue("@bes", checkBox32.Text);
            komut.Parameters.AddWithValue("@alti", checkBox31.Text);
            komut.ExecuteNonQuery();
            baglantı.Close();

            MessageBox.Show("Elektrik-Elektronik Muhendisi Kayıt Basarili.");
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form3 yeni = new Form3();
            yeni.Show();
            this.Hide();
        }
    }
}
