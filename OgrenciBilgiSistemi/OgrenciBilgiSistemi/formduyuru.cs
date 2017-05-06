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
    public partial class formduyuru : Form
    {
        public formduyuru()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=KURSATCAKAL\\SQL_2014;Initial Catalog=sistem;Integrated Security=True");
        public int sorgud1()
        {
            using (SqlConnection baglantı = new SqlConnection("Data Source=KURSATCAKAL\\SQL_2014;Initial Catalog=sistem;Integrated Security=True"))
            {
                int sayi;
                SqlCommand komutd1 = new SqlCommand("select COUNT(*)from duyuru where id='" + label3.Text.ToString().Trim() + "'", baglantı);
                baglantı.Open();
                sayi = Convert.ToInt32(komutd1.ExecuteScalar());
                baglantı.Close();
                return sayi;
            }
        }
        public int sorgud2()
        {
            using (SqlConnection baglantı = new SqlConnection("Data Source=KURSATCAKAL\\SQL_2014;Initial Catalog=sistem;Integrated Security=True"))
            {
                int sayi;
                SqlCommand komutd2 = new SqlCommand("select COUNT(*)from duyuru where id='" + label4.Text.ToString().Trim() + "'", baglantı);
                baglantı.Open();
                sayi = Convert.ToInt32(komutd2.ExecuteScalar());
                baglantı.Close();
                return sayi;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (sorgud1() == 0)
            {
                if (textBox1.TextLength <= 200)
                {
                    baglantı.Open();
                    SqlCommand komut = new SqlCommand("insert into duyuru(DUYURU,Tarih) values(@d1,@tarih)", baglantı);

                    komut.Parameters.AddWithValue("@d1", textBox1.Text);
                    komut.Parameters.AddWithValue("@tarih", dateTimePicker1.Value);
                    komut.ExecuteNonQuery();
                    baglantı.Close();
                    MessageBox.Show("Duyuru Eklendi.");
                }
                else
                {
                    MessageBox.Show("Karakter Sınırlarını Aştınız..");
                }

            }
            else
            {
                if (textBox1.TextLength <= 200)
                {
                    try
                    {
                        baglantı.Open();
                        SqlCommand komut = new SqlCommand("update duyuru set DUYURU='" + textBox1.Text + "',Tarih='" + dateTimePicker1.Value + "' where id='" + label3.Text.ToString().Trim() + "'", baglantı);
                        komut.ExecuteNonQuery();
                        baglantı.Close();

                        MessageBox.Show("Guncelleme Basarili.");

                    }
                    catch (Exception hata)
                    {

                        MessageBox.Show("Hata olustu." + hata.Message);

                    }

                }
                else
                {
                    MessageBox.Show("Karakter Sınırlarını Aştınız..");
                }
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (sorgud2() == 0)
            {
                if (textBox1.TextLength <= 200)
                {
                    baglantı.Open();
                    SqlCommand komut = new SqlCommand("insert into duyuru(DUYURU,Tarih) values(@d2,@trh)", baglantı);
                    komut.Parameters.AddWithValue("@d2", textBox2.Text);
                    komut.Parameters.AddWithValue("@trh", dateTimePicker1.Value);
                    komut.ExecuteNonQuery();
                    baglantı.Close();
                    MessageBox.Show("Duyuru Eklendi.");
                }
                else
                {
                    MessageBox.Show("Karakter Sınırlarını Aştınız..");
                }
            }
            else
            {
                if (textBox1.TextLength <= 200)
                {
                    baglantı.Open();
                    SqlCommand komut = new SqlCommand("update duyuru set DUYURU='" + textBox2.Text + "',Tarih='" + dateTimePicker1.Value + "' where id='" + label4.Text.ToString().Trim() + "'", baglantı);
                    komut.ExecuteNonQuery();
                    baglantı.Close();
                    MessageBox.Show("Guncelleme Basarili.");
                }
                else
                {
                    MessageBox.Show("Karakter Sınırlarını Aştınız..");
                }
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            yoneticiform yeni = new yoneticiform();
            yeni.Show();
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

