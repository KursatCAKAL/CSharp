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
using System.IO;
using System.Text.RegularExpressions;

namespace OgrenciBilgiSistemi
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=KURSATCAKAL\\SQL_2014;Initial Catalog=sistem;Integrated Security=True");
        public void verigostervize(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, baglantı);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            timer1.Enabled = true;
            timer2.Enabled = true;

            labelno.Text = dondur.Tut;
            //OGRENCİ BİLGİLERİNİ ÇEKME.
            baglantı.Open();
            SqlCommand komutcek = new SqlCommand("Select * from ogrencibilgi where Numara=@numarasi", baglantı);
            komutcek.Parameters.AddWithValue("@numarasi", labelno.Text.ToString());//labelno.Text yazsan sadece olmazdı çünkü string olarak algılayıp bulmuyo.

            SqlDataAdapter da = new SqlDataAdapter(komutcek);
            SqlDataReader dr = komutcek.ExecuteReader();
            while (dr.Read())
            {
                labelisim.Text = dr["Ad"].ToString().ToUpper() + dr["Soyad"].ToString().ToUpper();

                labelblm.Text = dr["Bolum"].ToString();

            }
            dr.Close();
            baglantı.Close();
            //1.Panele Duyuru Çekme Veritabanından
            baglantı.Open();
            SqlCommand command = new SqlCommand("select *from duyuru where id='" + labeld1.Text.ToString().Trim() + "'", baglantı);
            SqlDataAdapter danew = new SqlDataAdapter(command);
            SqlDataReader drnew = command.ExecuteReader();
            while (drnew.Read())
            {
                label4.Text = drnew["Tarih"].ToString() + drnew["DUYURU"].ToString();

            }
            if (label4.Text.ToString().Trim() != "")
            {
                label4.Show();
            }
            else
                label4.Hide();
            drnew.Close();
            baglantı.Close();
            //OGRENCİ RESMİ ÇEKME
            //baglantı.Open();
            //SqlCommand komutresim = new SqlCommand("select Resim from ogrencibilgi where Numara=@no",baglantı);
            //komutresim.Parameters.AddWithValue("@no",labelno.Text.ToString().Trim());
            //SqlDataReader drresim = komutresim.ExecuteReader();
            //drresim.Read();
            //if (drresim.HasRows)
            //{
            //    byte[] imgogr = (byte[])(drresim[0]);
            //    if(imgogr==null)
            //    {
            //        pictureBox3.Image = null;
            //    }
            //    else
            //    {
            //        MemoryStream ms = new MemoryStream(imgogr);
            //        pictureBox3.Image = Image.FromStream(ms);
            //    }
            //}
            //baglantı.Close();
            // baglantı.Open();
            // SqlCommand komut2 = new SqlCommand("Select Resim from ogrencibilgi where Numara='" + labelno.Text.ToString() + "'", baglantı);
            // SqlDataReader dr3 = komut2.ExecuteReader();

            //while(dr3.Read())
            // {
            //     byte[] imgogt = (byte[])(dr3[0]);

            //     if (imgogt == null)
            //     {
            //         pictureBox3.Image = null;
            //     }
            //     else
            //     {
            //         MemoryStream ms3 = new MemoryStream(imgogt);
            //         pictureBox3.Image = Image.FromStream(ms3);
            //     }
            // }

            baglantı.Open();
            SqlCommand komutc = new SqlCommand("select Resim from ogrencibilgi where Numara='" + labelno.Text.ToString() + "'", baglantı);
            SqlDataReader drfoto = komutc.ExecuteReader();
            drfoto.Read();
            if (drfoto.HasRows)
            {
                tbresimyolu.Text = drfoto[0].ToString();
            }
            else
            {
                MessageBox.Show("This Does not exisst.");
            }
            baglantı.Close();
            pictureBox3.ImageLocation = tbresimyolu.Text;
        }



        private void bilgileriGoruntuleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("Select * from ogrencibilgi where Numara like '%" + labelno.Text + "%'", baglantı);/*Numara yeri ad yazmıştın yanlış nereden arama yapacagını çok iyi belirle*/
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
            baglantı.Close();
        }

        private void dersKayıtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            derskayıt yeni = new derskayıt();
            yeni.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

            Form2 yeni = new Form2();
            yeni.Show();
            this.Hide();
        }
        int i = 0;


        private void timer1_Tick_1(object sender, EventArgs e)
        {
            i++;

            /* if (i % 2 == 0)
                 label1.ForeColor = Color.Green;*////MANTIK HATASI 2 YE BOLUM HEP SIFIRDIR
            if (i % 2 == 1)
            {
                label1.ForeColor = Color.White;
                


                //label4.Font = new Font("Minion Pro", 24, FontStyle.Regular);


            }
            if (i % 2 == 0)
            {
                label1.ForeColor = Color.Black;
             

                // label4.Font = new Font("Candara", 24, FontStyle.Regular);

            }

            label4.Text = label4.Text.Substring(1) + label4.Text.Substring(0, 1);

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            baglantı.Open();
            SqlCommand oku = new SqlCommand("select *from sifre where No='" + labelno.Text + "'", baglantı);
            SqlDataAdapter da = new SqlDataAdapter(oku);
            SqlDataReader dr = oku.ExecuteReader();
            if (dr.Read())
            {

                if (textBox1.Text.Trim() == dr["Sifre"].ToString().Trim())//Trim kullanmak canalıcı textbox,label,datareaderdan okunan degerleri koşul ifadesi içinde kullancaksan
                {
                    dr.Close();
                    baglantı.Close();
                    if (textBox2.Text.Trim() == textBox3.Text.Trim())
                    {
                        
                        if(Regex.IsMatch(textBox3.Text.ToString(),@"([a-zA-Z]+\d+)|(\d+[a-zA-Z])"))
                        {
                            baglantı.Open();
                            SqlCommand komutson = new SqlCommand("update sifre set Sifre='" + textBox2.Text + "' where No='" + labelno.Text + "'", baglantı);
                            komutson.ExecuteNonQuery();
                            textBox1.Clear();
                            textBox2.Clear();
                            textBox3.Clear();
                            MessageBox.Show("Sifre Guncellendi.");
                        }
                        else
                        {
                            MessageBox.Show("Sifreniz harf ve rakam içermelidir.");
                        }
                       
                    }
                    else
                    {
                        MessageBox.Show("Yeni Sifreler Uyuşmuyor..");
                    }


                }
                else
                {
                    MessageBox.Show("Geçersiz Parola..");
                }

            }

            baglantı.Close();
            groupBox1.Enabled = false;

        }

        private void şifreDegistirmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
        }

        private void notGoruntulemeToolStripMenuItem_Click(object sender, EventArgs e)
        {



        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bolumDersleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (labelblm.Text.ToString().Trim() == "Bilgisayar Muhendisligi")
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("select *from vizebm where Numara='" + labelno.Text + "'", baglantı);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView2.DataSource = ds.Tables[0];
                baglantı.Close();
                baglantı.Open();
                SqlCommand komut2 = new SqlCommand("select *from finalbm where Numara='" + labelno.Text + "'", baglantı);
                SqlDataAdapter da2 = new SqlDataAdapter(komut2);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                dataGridView3.DataSource = ds2.Tables[0];
                baglantı.Close();

            }
            if (labelblm.Text.ToString().Trim() == "Kimya Muhendisligi")
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("select *from vizekm where Numara='" + labelno.Text + "'", baglantı);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView2.DataSource = ds.Tables[0];
                baglantı.Close();
                baglantı.Open();
                SqlCommand komut2 = new SqlCommand("select *from finalkm where Numara='" + labelno.Text + "'", baglantı);
                SqlDataAdapter da2 = new SqlDataAdapter(komut2);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                dataGridView3.DataSource = ds2.Tables[0];
                baglantı.Close();

            }
            if (labelblm.Text.ToString().Trim() == "Endustri Muhendisligi")
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("select *from vizeem where Numara='" + labelno.Text + "'", baglantı);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView2.DataSource = ds.Tables[0];
                baglantı.Close();
                baglantı.Open();
                SqlCommand komut2 = new SqlCommand("select *from finalem where Numara='" + labelno.Text + "'", baglantı);
                SqlDataAdapter da2 = new SqlDataAdapter(komut2);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                dataGridView3.DataSource = ds2.Tables[0];
                baglantı.Close();

            }
            /* else if (labelblm.Text.ToString().Trim() == "Endustri Muhendisligi")
             {
                 baglantı.Open();
                 SqlCommand komut = new SqlCommand("select *from vizebm where Numara='" + labelno.Text + "'", baglantı);
                 SqlDataAdapter da = new SqlDataAdapter(komut);
                 DataSet ds = new DataSet();
                 da.Fill(ds);
                 dataGridView2.DataSource = ds.Tables[0];
             }*/



        }

        private void ortakDerslerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("select *from ortakvize where Numara='" + labelno.Text.ToString().Trim() + "'", baglantı);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglantı.Close();
            //DataGridViewCellStyle a = new DataGridViewCellStyle();
            //a.BackColor = Color.Black;
            //a.ForeColor = Color.White;
            //for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            //{
            //    dataGridView1.Rows[i].DefaultCellStyle = a;
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //baglantı.Open();
            //SqlCommand komut = new SqlCommand("delete from ortakvize where Numara='" + labelno.Text + "'", baglantı);
            //komut.ExecuteNonQuery();
            //baglantı.Close();


        }
        int dakika = 14;
        private void timer2_Tick(object sender, EventArgs e)
        {

            int san = Convert.ToInt32(sn.Text);
            san--;
            sn.Text = Convert.ToString(san);
            if (san < 9)
            {
                sn.Text = "0" + Convert.ToString(san);

            }
            if (san == 00)
            {
                san = 59;
                sn.Text = san.ToString();
                dakika--;
                dk.Text = dakika.ToString();

            }
            if (dakika <= 9)
            {
                dk.Text = "0" + dakika.ToString();
            }
            if (dakika == 0)
            {
                dk.Text = "0" + dakika.ToString();
                san--;
                if (san == 0)
                {
                    timer2.Enabled = false;
                    MessageBox.Show("Lutfen Tekrar Giris Yapınız 15 dk hareketsiz kaldınız.");
                    Application.Exit();
                }

            }
        }

        private void cıkısToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ogrencigecmedurumu yeni = new ogrencigecmedurumu();
            yeni.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {




        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void sistemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void karneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3akademiktakvim yeni = new Form3akademiktakvim();
            yeni.Show();
            this.Hide();
        }
    }
}
