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
    public partial class ogrencigecmedurumu : Form
    {
        public ogrencigecmedurumu()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=KURSATCAKAL\\SQL_2014;Initial Catalog=sistem;Integrated Security=True");

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form3 yeni = new Form3();
            yeni.Show();
            this.Hide();
        }

        private void ogrencigecmedurumu_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            labelno.Text = dondur.Tut;

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
            baglantı.Close();

            baglantı.Open();
            SqlCommand kov = new SqlCommand("select *from ortakvize where Numara=@no", baglantı);
            //kov.Parameters.AddWithValue("@no", baglantı);"BURAYA BAGLANTI YAZMIŞSIN NE HATA
            kov.Parameters.AddWithValue("@no", labelno.Text);
            SqlDataAdapter da2 = new SqlDataAdapter(kov);
            SqlDataReader dr2 = kov.ExecuteReader();
            while (dr2.Read())
            {
                matvize.Text = dr2["MAT102"].ToString();
                ingvize.Text = dr2["İNG102"].ToString();
                fizvize.Text = dr2["FİZİK102"].ToString();
                tcvize.Text = dr2["TCİnkilap"].ToString();
            }
            dr2.Close();
            baglantı.Close();
            //OGRENCİ ORTAK FİNAL AKTARMA
            baglantı.Open();
            SqlCommand kof = new SqlCommand("select *from ortakfinal where Numara=@no", baglantı);
            kof.Parameters.AddWithValue("@no", labelno.Text);
            SqlDataAdapter da3 = new SqlDataAdapter(kof);
            SqlDataReader dr3 = kof.ExecuteReader();
            while (dr3.Read())
            {
                matfinal.Text = dr3["MAT102"].ToString();
                ingfinal.Text = dr3["İNG102"].ToString();
                fizfinal.Text = dr3["FİZİK102"].ToString();
                tcfinal.Text = dr3["TCİnkilap"].ToString();

            }
            dr3.Close();
            baglantı.Close();
            //--------------------------
            if (labelblm.Text.ToString().Trim() == "Bilgisayar Muhendisligi")
            {
                labelDERS5.Text = "Bilgisayar Programlama";
                labelDERS6.Text = "Bilgisayar Muhendisligine Giris";
                labeldr5.Text = "BM102";
                labeldr6.Text = "BM103";
                //DERS5
                baglantı.Open();
                SqlCommand bov = new SqlCommand("select *from vizebm where Numara=@no", baglantı);
                bov.Parameters.AddWithValue("@no", labelno.Text);
                SqlDataAdapter da4 = new SqlDataAdapter(bov);
                SqlDataReader dr4 = bov.ExecuteReader();
                while (dr4.Read())
                {
                    ders5vize.Text = dr4["BM102"].ToString();
                    ders6vize.Text = dr4["BM103"].ToString();
                    
                }
                dr4.Close();
                baglantı.Close();
                //DERS6
                baglantı.Open();
                SqlCommand bof = new SqlCommand("select *from finalbm where Numara=@no", baglantı);
                bof.Parameters.AddWithValue("@no", labelno.Text);
                SqlDataAdapter da5 = new SqlDataAdapter(bof);
                SqlDataReader dr5 = bof.ExecuteReader();
                while (dr5.Read())
                {
                    ders5final.Text = dr5["BM102"].ToString();
                    ders6final.Text = dr5["BM103"].ToString();
                }
                dr5.Close();
                baglantı.Close();

            }
            if (labelblm.Text.ToString().Trim() == "Endustri Muhendisligi")
            {
                labelDERS5.Text = "Temel Bil. Programlama";
                labelDERS6.Text = "Endustri Muhendisligine Giris";
                labeldr5.Text = "ENF106";
                labeldr6.Text = "ENM106";
                //DERS5
                baglantı.Open();
                SqlCommand bov = new SqlCommand("select *from vizeem where Numara=@no", baglantı);
                bov.Parameters.AddWithValue("@no", labelno.Text);
                SqlDataAdapter da4 = new SqlDataAdapter(bov);
                SqlDataReader dr4 = bov.ExecuteReader();
                while (dr4.Read())
                {
                    ders5vize.Text = dr4["EM102"].ToString();
                    ders6vize.Text = dr4["EM103"].ToString();

                }
                dr4.Close();
                baglantı.Close();
                //DERS6
                baglantı.Open();
                SqlCommand bof = new SqlCommand("select *from finalem where Numara=@no", baglantı);
                bof.Parameters.AddWithValue("@no", labelno.Text);
                SqlDataAdapter da5 = new SqlDataAdapter(bof);
                SqlDataReader dr5 = bof.ExecuteReader();
                while (dr5.Read())
                {
                    ders5final.Text = dr5["EM103"].ToString();
                    ders6final.Text = dr5["EM103"].ToString();

                }
                dr5.Close();
                baglantı.Close();

            }
            if (labelblm.Text.ToString().Trim() == "Kimya Muhendisligi")
            {
                labelDERS5.Text = "BİLGİSAYAR PROGRAMLAMA DİLLERİ ";
                labelDERS6.Text = "GENEL KİMYA LAB.";
                labeldr5.Text = "KM104";
                labeldr6.Text = "KM152";
                //DERS5
                baglantı.Open();
                SqlCommand bov = new SqlCommand("select *from vizekm where Numara=@no", baglantı);
                bov.Parameters.AddWithValue("@no", labelno.Text);
                SqlDataAdapter da4 = new SqlDataAdapter(bov);
                SqlDataReader dr4 = bov.ExecuteReader();
                while (dr4.Read())
                {
                    ders5vize.Text = dr4["KM102"].ToString();
                    ders6vize.Text = dr4["KM103"].ToString();
                }
                dr4.Close();
                baglantı.Close();
                //DERS6
                baglantı.Open();
                SqlCommand bof = new SqlCommand("select *from finalkm where Numara=@no", baglantı);
                bof.Parameters.AddWithValue("@no", labelno.Text);
                SqlDataAdapter da5 = new SqlDataAdapter(bof);
                SqlDataReader dr5 = bof.ExecuteReader();
                while (dr5.Read())
                {
                    ders5final.Text = dr5["KM102"].ToString();
                    ders6final.Text = dr5["KM103"].ToString();
                }
                dr5.Close();
                baglantı.Close();

                //------------
               
            }
            if (matvize.Text != "" && ingvize.Text != "" && fizvize.Text != "" && tcvize.Text != "" && matfinal.Text != "" && ingfinal.Text != "" && fizfinal.Text != "" && tcfinal.Text != "" && ders5vize.Text != "" && ders5final.Text != "" && ders6final.Text != "" && ders6vize.Text != "")
            {
                o1.Text = Convert.ToString(Convert.ToInt32(matvize.Text.ToString()) * 0.6 + Convert.ToInt32(matfinal.Text.ToString()) * 0.4);
                o2.Text = Convert.ToString(Convert.ToInt32(fizvize.Text.ToString()) * 0.6 + Convert.ToInt32(fizfinal.Text.ToString()) * 0.4);
                o3.Text = Convert.ToString(Convert.ToInt32(ingvize.Text.ToString()) * 0.6 + Convert.ToInt32(ingfinal.Text.ToString()) * 0.4);
                o4.Text = Convert.ToString(Convert.ToInt32(tcvize.Text.ToString()) * 0.2 + Convert.ToInt32(tcfinal.Text.ToString()) * 0.8);
                o5.Text = Convert.ToString(Convert.ToInt32(ders5vize.Text.ToString()) * 0.6 + Convert.ToInt32(ders5final.Text.ToString()) * 0.4);
                o6.Text = Convert.ToString(Convert.ToInt32(ders6vize.Text.ToString()) * 0.6 + Convert.ToInt32(ders6final.Text.ToString()) * 0.4);
                //1.ders
                if(Convert.ToDouble(o1.Text)>=90)
                {
                    drm1.Text = "AA";
                }
                if (Convert.ToDouble(o1.Text) <= 90 && Convert.ToDouble(o1.Text) >= 80)
                {
                    drm1.Text = "BA";
                }
                if (Convert.ToDouble(o1.Text) <= 80 && Convert.ToDouble(o1.Text) >= 70)
                {
                    drm1.Text = "BB";
                }
                if (Convert.ToDouble(o1.Text) <= 70 && Convert.ToDouble(o1.Text) >= 60)
                {
                    drm1.Text = "CB";
                }
                if (Convert.ToDouble(o1.Text) <= 60&& Convert.ToDouble(o1.Text)>=50)
                {
                    drm1.Text = "CC";
                }
                if (Convert.ToDouble(o1.Text) <= 50 && Convert.ToDouble(o1.Text) >= 40)
                {
                    drm1.Text = "CD";
                }
                if (Convert.ToDouble(o1.Text) <= 40 && Convert.ToDouble(o1.Text) >= 30)
                {
                    drm1.Text = "DD";
                }
                if (Convert.ToDouble(o1.Text) <= 30)
                {
                    drm1.Text = "KALDI";
                }
                //2.ders
                if (Convert.ToDouble(o2.Text) >= 90)
                {
                    drm2.Text = "AA";
                }
                if (Convert.ToDouble(o2.Text) <= 90 && Convert.ToDouble(o2.Text) >= 80)
                {
                    drm2.Text = "BA";
                }
                if (Convert.ToDouble(o2.Text) <= 80 && Convert.ToDouble(o2.Text) >= 70)
                {
                    drm2.Text = "BB";
                }
                if (Convert.ToDouble(o2.Text) <= 70 && Convert.ToDouble(o2.Text) >= 60)
                {
                    drm2.Text = "CB";
                }
                if (Convert.ToDouble(o2.Text) <= 60 && Convert.ToDouble(o2.Text) >= 50)
                {
                    drm2.Text = "CC";
                }
                if (Convert.ToDouble(o2.Text) <= 50 && Convert.ToDouble(o2.Text) >= 40)
                {
                    drm2.Text = "CD";
                }
                if (Convert.ToDouble(o2.Text) <= 40 && Convert.ToDouble(o2.Text) >= 30)
                {
                    drm2.Text = "DD";
                }
                if (Convert.ToDouble(o2.Text) <= 30)
                {
                    drm2.Text = "FF";
                }
                //3.ders
                if (Convert.ToDouble(o3.Text) >= 90)
                {
                    drm3.Text = "AA";
                }
                if (Convert.ToDouble(o3.Text) <= 90 && Convert.ToDouble(o3.Text) >= 80)
                {
                    drm3.Text = "BA";
                }
                if (Convert.ToDouble(o3.Text) <= 80 && Convert.ToDouble(o3.Text) >= 70)
                {
                    drm3.Text = "BB";
                }
                if (Convert.ToDouble(o3.Text) <= 70 && Convert.ToDouble(o3.Text) >= 60)
                {
                    drm3.Text = "CB";
                }
                if (Convert.ToDouble(o3.Text) <= 60 && Convert.ToDouble(o3.Text) >= 50)
                {
                    drm3.Text = "CC";
                }
                if (Convert.ToDouble(o3.Text) <= 50 && Convert.ToDouble(o3.Text) >= 40)
                {
                    drm3.Text = "CD";
                }
                if (Convert.ToDouble(o3.Text) <= 40 && Convert.ToDouble(o3.Text) >= 30)
                {
                    drm3.Text = "DD";
                }
                if (Convert.ToDouble(o3.Text) <= 30)
                {
                    drm3.Text = "FF";
                }
                //4.ders
                if (Convert.ToDouble(o4.Text) >= 90)
                {
                    drm4.Text = "AA";
                }
                if (Convert.ToDouble(o4.Text) <= 90 && Convert.ToDouble(o4.Text) >= 80)
                {
                    drm4.Text = "BA";
                }
                if (Convert.ToDouble(o4.Text) <= 80 && Convert.ToDouble(o4.Text) >= 70)
                {
                    drm4.Text = "BB";
                }
                if (Convert.ToDouble(o4.Text) <= 70 && Convert.ToDouble(o4.Text) >= 60)
                {
                    drm4.Text = "CB";
                }
                if (Convert.ToDouble(o4.Text) <= 60 && Convert.ToDouble(o4.Text) >= 50)
                {
                    drm4.Text = "CC";
                }
                if (Convert.ToDouble(o4.Text) <= 50 && Convert.ToDouble(o4.Text) >= 40)
                {
                    drm4.Text = "CD";
                }
                if (Convert.ToDouble(o4.Text) <= 40 && Convert.ToDouble(o4.Text) >= 30)
                {
                    drm4.Text = "DD";
                }
                if (Convert.ToDouble(o4.Text) <= 30)
                {
                    drm4.Text = "FF";
                }
                //5.ders
                if (Convert.ToDouble(o5.Text) >= 90)
                {
                    drm5.Text = "AA";
                }
                if (Convert.ToDouble(o5.Text) <= 90 && Convert.ToDouble(o5.Text) >= 80)
                {
                    drm5.Text = "BA";
                }
                if (Convert.ToDouble(o5.Text) <= 80 && Convert.ToDouble(o5.Text) >= 70)
                {
                    drm5.Text = "BB";
                }
                if (Convert.ToDouble(o5.Text) <= 70 && Convert.ToDouble(o5.Text) >= 60)
                {
                    drm5.Text = "CB";
                }
                if (Convert.ToDouble(o5.Text) <= 60 && Convert.ToDouble(o5.Text) >= 50)
                {
                    drm5.Text = "CC";
                }
                if (Convert.ToDouble(o5.Text) <= 50 && Convert.ToDouble(o5.Text) >= 40)
                {
                    drm5.Text = "CD";
                }
                if (Convert.ToDouble(o5.Text) <= 40 && Convert.ToDouble(o5.Text) >= 30)
                {
                    drm5.Text = "DD";
                }
                if (Convert.ToDouble(o5.Text) <= 30)
                {
                    drm5.Text = "FF";
                }
                //6.ders
                if (Convert.ToDouble(o6.Text) >= 90)
                {
                    drm6.Text = "AA";
                }
                if (Convert.ToDouble(o6.Text) <= 90 && Convert.ToDouble(o6.Text) >= 80)
                {
                    drm6.Text = "BA";
                }
                if (Convert.ToDouble(o6.Text) <= 80 && Convert.ToDouble(o6.Text) >= 70)
                {
                    drm6.Text = "BB";
                }
                if (Convert.ToDouble(o6.Text) <= 70 && Convert.ToDouble(o6.Text) >= 60)
                {
                    drm6.Text = "CB";
                }
                if (Convert.ToDouble(o6.Text) <= 60 && Convert.ToDouble(o6.Text) >= 50)
                {
                    drm6.Text = "CC";
                }
                if (Convert.ToDouble(o6.Text) <= 50 && Convert.ToDouble(o6.Text) >= 40)
                {
                    drm6.Text = "CD";
                }
                if (Convert.ToDouble(o6.Text) <= 40 && Convert.ToDouble(o6.Text) >= 30)
                {
                    drm6.Text = "DD";
                }
                if (Convert.ToDouble(o6.Text) <= 30)
                {
                    drm6.Text = "FF";
                }

              
            }
            else
            {
                MessageBox.Show("Lütfen Girilmeyen Notlarızın Sistem Tarafından Girilmesini Bekleyiniz..");
            }
            matfinal.Enabled = false;
            matvize.Enabled = false;
            fizvize.Enabled = false;
            fizfinal.Enabled = false;
            ingvize.Enabled = false;
            ingfinal.Enabled = false;
            tcvize.Enabled = false;
            tcfinal.Enabled = false;
            ders5final.Enabled = false;
            ders5vize.Enabled = false;
            ders6final.Enabled = false;
            ders6vize.Enabled = false;
        }


        int i=0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            //i++;
            //if (i % 2 == 0)
            //{
            //    panel8.BackColor = Color.Black;
            //    panel9.BackColor = Color.DarkTurquoise;
            //    panel10.BackColor = Color.DarkTurquoise;
            //    panel11.BackColor = Color.DarkTurquoise;
            //}
            //if (i % 3 == 1)
            //{
            //    panel8.BackColor = Color.DarkTurquoise;
            //    panel9.BackColor = Color.Black;
            //    panel10.BackColor = Color.DarkTurquoise;
            //    panel11.BackColor = Color.DarkTurquoise;
            //}
            //if (i % 2 == 1)
            //{
            //    panel8.BackColor = Color.DarkTurquoise;
            //    panel9.BackColor = Color.DarkTurquoise;
            //    panel10.BackColor = Color.Black;
            //    panel11.BackColor = Color.DarkTurquoise;
            //}

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
           
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }
    }
}
