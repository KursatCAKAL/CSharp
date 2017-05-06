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
using System.Text.RegularExpressions;

namespace OgrenciBilgiSistemi
{
    public partial class ogrgorevlisimain : Form
    {
        public ogrgorevlisimain()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source = KURSATCAKAL\\SQL_2014; Initial Catalog = sistem; Integrated Security = True");

        private void ogrgorevlisimain_Load(object sender, EventArgs e)
        {
            timer2.Enabled = true;
            timer1.Enabled = true;
            panel3.Hide();
            label6.Text = "";
            label7.Text = "";
            labelkno.Text = dondur.Tut.ToUpper();//BUYUK HARFLE BASLAMASINI SAGLADIK.
            
            baglantı.Open();
            SqlCommand komutcek = new SqlCommand("Select *from ogruyesi where KullanıcıNo=@kno", baglantı);
            komutcek.Parameters.AddWithValue("@kno", labelkno.Text.ToString().Trim());

            SqlDataAdapter da = new SqlDataAdapter(komutcek);
            SqlDataReader dr = komutcek.ExecuteReader();
            while(dr.Read())
            {
                labelisim.Text = dr["Ad"].ToString().ToUpper();
                labelsoyisim.Text = dr["Soyad"].ToString().ToUpper();//BUYUK HARFLE BASLAMASINI SAGLADIK.
                label2.Text = dr["Gorev"].ToString();
                labelunvan.Text = dr["Unvan"].ToString();
            }
            baglantı.Close();
            //2.Panele Duyuru Çekme Veritabanından
            baglantı.Open();
            SqlCommand command2 = new SqlCommand("select *from duyuru where id='" + labeld2.Text.ToString().Trim() + "'", baglantı);
            SqlDataAdapter danew2 = new SqlDataAdapter(command2);
            SqlDataReader drnew2 = command2.ExecuteReader();
            while (drnew2.Read())
            {
                label26.Text = drnew2["Tarih"].ToString()+ drnew2["DUYURU"].ToString();
               
            }
            if (label26.Text.ToString().Trim() != "")
            {
                label26.Show();
            }
            else
                label26.Hide();

            drnew2.Close();
            baglantı.Close();
        }//FORM YÜKLENDİGİNCE OLACAKLAR.
        public int sorgula()
        {
            using (SqlConnection baglantı = new SqlConnection("Data Source = KURSATCAKAL\\SQL_2014; Initial Catalog = sistem; Integrated Security = True")) 
            {
                int sayi;
                SqlCommand komutsorgu = new SqlCommand("Select COUNT(*)from ogrencibilgi where Numara='" + textBox1.Text + "'",baglantı);
                baglantı.Open();
                sayi= Convert.ToInt32(komutsorgu.ExecuteScalar());
                baglantı.Close();
                return sayi;
            }

        }//SORGULAMA YORDAMIM.
        public int sorgulaortakvize()
        {
            using (SqlConnection baglantı = new SqlConnection("Data Source = KURSATCAKAL\\SQL_2014; Initial Catalog = sistem; Integrated Security = True"))
            {
                int sayi;
                SqlCommand komut = new SqlCommand("select COUNT(*)from ortakvize where Numara='" + textBox1.Text + "'",baglantı);//connection strin başlatmayı unutuyosun.
                baglantı.Open();
                sayi = Convert.ToInt32(komut.ExecuteScalar());
                baglantı.Close();
                return sayi;
            }
        }//ortakvize sorgula
        public int sorgulaortakfinal()
        {
            using (SqlConnection baglantı = new SqlConnection("Data Source = KURSATCAKAL\\SQL_2014; Initial Catalog = sistem; Integrated Security = True"))
            {
                int sayi;
                SqlCommand komut = new SqlCommand("select COUNT(*)from ortakfinal where Numara='" + textBox1.Text + "'", baglantı);
                baglantı.Open();
                sayi = Convert.ToInt32(komut.ExecuteScalar());
                baglantı.Close();
                return sayi;
            }
        }//ortakfinal sorgula
        public int sorgulavizebm()
        {
            using (SqlConnection baglantı = new SqlConnection("Data Source = KURSATCAKAL\\SQL_2014; Initial Catalog = sistem; Integrated Security = True"))
            {
                int sayi;
                SqlCommand komut = new SqlCommand("select COUNT(*)from vizebm where Numara='" + textBox1.Text + "'", baglantı);
                baglantı.Open();
                sayi = Convert.ToInt32(komut.ExecuteScalar());
                baglantı.Close();
                return sayi;
            }
        }//vizebm sorgula
        public int sorgulavizeem()
        {
            using (SqlConnection baglantı = new SqlConnection("Data Source = KURSATCAKAL\\SQL_2014; Initial Catalog = sistem; Integrated Security = True"))
            {
                int sayi;
                SqlCommand komut = new SqlCommand("select COUNT(*)from vizeem where Numara='" + textBox1.Text + "'", baglantı);
                baglantı.Open();
                sayi = Convert.ToInt32(komut.ExecuteScalar());
                baglantı.Close();
                return sayi;
            }
        }//vizeem sorgula
        public int sorgulavizekm()
        {
            using (SqlConnection baglantı = new SqlConnection("Data Source = KURSATCAKAL\\SQL_2014; Initial Catalog = sistem; Integrated Security = True"))
            {
                int sayi;
                SqlCommand komut = new SqlCommand("select COUNT(*)from vizekm where Numara='" + textBox1.Text + "'", baglantı);
                baglantı.Open();
                sayi = Convert.ToInt32(komut.ExecuteScalar());
                baglantı.Close();
                return sayi;
            }
        }//vizekm sorgula
        public int sorgulafinalbm()
        {
            using (SqlConnection baglantı = new SqlConnection("Data Source = KURSATCAKAL\\SQL_2014; Initial Catalog = sistem; Integrated Security = True"))
            {
                int sayi;
                SqlCommand komut = new SqlCommand("select COUNT(*)from finalbm where Numara='" + textBox1.Text + "'", baglantı);
                baglantı.Open();
                sayi = Convert.ToInt32(komut.ExecuteScalar());
                baglantı.Close();
                return sayi;
            }
        }//finalbm sorgula
        public int sorgulafinalem()
        {
            using (SqlConnection baglantı = new SqlConnection("Data Source = KURSATCAKAL\\SQL_2014; Initial Catalog = sistem; Integrated Security = True"))
            {
                int sayi;
                SqlCommand komut = new SqlCommand("select COUNT(*)from finalem where Numara='" + textBox1.Text + "'", baglantı);
                baglantı.Open();
                sayi = Convert.ToInt32(komut.ExecuteScalar());
                baglantı.Close();
                return sayi;
            }
        }//finalem sorgula
        public int sorgulafinalkm()
        {
            using (SqlConnection baglantı = new SqlConnection("Data Source = KURSATCAKAL\\SQL_2014; Initial Catalog = sistem; Integrated Security = True"))
            {
                int sayi;
                SqlCommand komut = new SqlCommand("select COUNT(*)from finalkm where Numara='"+textBox1.Text+"'",baglantı);
                baglantı.Open();
                sayi = Convert.ToInt32(komut.ExecuteScalar());
                baglantı.Close();
                return sayi;
            }
        }//finalkm sorgula
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            
          
            if (sorgula()>0)
            {
                //DİGER BOLUM OGRENCİLERİNE ULAŞIMI ENGELLEME.
                
                baglantı.Open();
                SqlCommand ara=new SqlCommand("select *from ogrencibilgi where Numara='"+textBox1.Text+"'",baglantı);
                SqlDataAdapter da2 = new SqlDataAdapter(ara);
                SqlDataReader dr2 = ara.ExecuteReader();
                if(dr2.Read())
                {
                    //labelgorunmez.Text = dr2["Bolum"].ToString();
                    labelgorunmez.Text = dr2["Bolum"].ToString();
                }
                    
                
                dr2.Close();
                baglantı.Close();
                //-----------
                if ((label2.Text.ToString().Trim() == "BM102"|| label2.Text.ToString().Trim()=="BM103") && labelgorunmez.Text.ToString().Trim() == "Bilgisayar Muhendisligi")
                {
                    textBox2.Clear();
                    textBox3.Clear();
                    baglantı.Open();
                    SqlCommand komutcek = new SqlCommand("Select *from ogrencibilgi where Numara=@numara", baglantı);
                    komutcek.Parameters.AddWithValue("@numara", textBox1.Text);

                    SqlDataAdapter da = new SqlDataAdapter(komutcek);
                    SqlDataReader dr = komutcek.ExecuteReader();
                    while (dr.Read())
                    {
                        label6.Text = dr["Ad"].ToString().ToUpper() + dr["Soyad"].ToString().ToUpper();
                        label7.Text = dr["Bolum"].ToString();

                    }
                    baglantı.Close();

                }
                else if ((label2.Text.ToString().Trim() == "MM102" || label2.Text.ToString().Trim() == "MM103") && labelgorunmez.Text.ToString().Trim() == "Makine Muhendisligi")
                {
                    textBox2.Clear();
                    textBox3.Clear();
                    baglantı.Open();
                    SqlCommand komutcek = new SqlCommand("Select *from ogrencibilgi where Numara=@numara", baglantı);
                    komutcek.Parameters.AddWithValue("@numara", textBox1.Text);

                    SqlDataAdapter da = new SqlDataAdapter(komutcek);
                    SqlDataReader dr = komutcek.ExecuteReader();
                    while (dr.Read())
                    {
                        label6.Text = dr["Ad"].ToString().ToUpper() + dr["Soyad"].ToString().ToUpper();
                        label7.Text = dr["Bolum"].ToString();

                    }
                    baglantı.Close();

                }
                else if ((label2.Text.ToString().Trim() == "KM102" || label2.Text.ToString().Trim() == "KM103") && labelgorunmez.Text.ToString().Trim() == "Kimya Muhendisligi")
                {
                    textBox2.Clear();
                    textBox3.Clear();
                    baglantı.Open();
                    SqlCommand komutcek = new SqlCommand("Select *from ogrencibilgi where Numara=@numara", baglantı);
                    komutcek.Parameters.AddWithValue("@numara", textBox1.Text);

                    SqlDataAdapter da = new SqlDataAdapter(komutcek);
                    SqlDataReader dr = komutcek.ExecuteReader();
                    while (dr.Read())
                    {
                        label6.Text = dr["Ad"].ToString().ToUpper() + dr["Soyad"].ToString().ToUpper();
                        label7.Text = dr["Bolum"].ToString();

                    }
                    baglantı.Close();

                }
                else if ((label2.Text.ToString().Trim() == "EM102" || label2.Text.ToString().Trim() == "EM103") && labelgorunmez.Text.ToString().Trim() == "Endustri Muhendisligi")
                {
                    textBox2.Clear();
                    textBox3.Clear();
                    baglantı.Open();
                    SqlCommand komutcek = new SqlCommand("Select *from ogrencibilgi where Numara=@numara", baglantı);
                    komutcek.Parameters.AddWithValue("@numara", textBox1.Text);

                    SqlDataAdapter da = new SqlDataAdapter(komutcek);
                    SqlDataReader dr = komutcek.ExecuteReader();
                    while (dr.Read())
                    {
                        label6.Text = dr["Ad"].ToString().ToUpper() + dr["Soyad"].ToString().ToUpper();
                        label7.Text = dr["Bolum"].ToString();

                    }
                    baglantı.Close();

                }
                else if ((label2.Text.ToString().Trim() == "İM102" || label2.Text.ToString().Trim() == "İM103") && labelgorunmez.Text.ToString().Trim() == "İnsaat Muhendisligi")
                {
                    textBox2.Clear();
                    textBox3.Clear();
                    baglantı.Open();
                    SqlCommand komutcek = new SqlCommand("Select *from ogrencibilgi where Numara=@numara", baglantı);
                    komutcek.Parameters.AddWithValue("@numara", textBox1.Text);

                    SqlDataAdapter da = new SqlDataAdapter(komutcek);
                    SqlDataReader dr = komutcek.ExecuteReader();
                    while (dr.Read())
                    {
                        label6.Text = dr["Ad"].ToString().ToUpper() + dr["Soyad"].ToString().ToUpper();
                        label7.Text = dr["Bolum"].ToString();

                    }
                    baglantı.Close();

                }
                else if ((label2.Text.ToString().Trim() == "EEM102" || label2.Text.ToString().Trim() == "EEM103") && labelgorunmez.Text.ToString().Trim() == "Elektrik Muhendisligi")
                {
                    textBox2.Clear();
                    textBox3.Clear();
                    baglantı.Open();
                    SqlCommand komutcek = new SqlCommand("Select *from ogrencibilgi where Numara=@numara", baglantı);
                    komutcek.Parameters.AddWithValue("@numara", textBox1.Text);

                    SqlDataAdapter da = new SqlDataAdapter(komutcek);
                    SqlDataReader dr = komutcek.ExecuteReader();
                    while (dr.Read())
                    {
                        label6.Text = dr["Ad"].ToString().ToUpper() + dr["Soyad"].ToString().ToUpper();
                        label7.Text = dr["Bolum"].ToString();

                    }
                    baglantı.Close();

                }
                else if(label2.Text.ToString().Trim()=="İNG102"||label2.Text.ToString().Trim()=="MAT102"||label2.Text.ToString().Trim()=="FİZİK102"||label2.Text.ToString().Trim()=="TC İnkilap")
                {
                    textBox2.Clear();
                    textBox3.Clear();
                    baglantı.Open();
                    SqlCommand komutcek = new SqlCommand("select *from ogrencibilgi where Numara=@numara", baglantı);
                    komutcek.Parameters.AddWithValue("@numara", textBox1.Text);
                    SqlDataAdapter da = new SqlDataAdapter(komutcek);
                    SqlDataReader dr = komutcek.ExecuteReader();

                    while(dr.Read())
                    {
                        label6.Text = dr["Ad"].ToString().ToUpper() + dr["Soyad"].ToString().ToUpper();
                        label7.Text = dr["Bolum"].ToString();
                    }
                    baglantı.Close();
                }
                else
                {
                    label6.Text = "";
                    label7.Text = "";
                    MessageBox.Show("Sorumlulugunuz dısında bir ogrenci erişim girişimi.");
                }
                    
                
            }
            else
            {
                label6.Text = "";
                label7.Text = "";
                MessageBox.Show("Bu bilgiye ait ogrenci kaydı bulunamadı.");
                
            }
            textBox2.Clear();
            textBox3.Clear();
          

        }//GÖREVLİLERİN ULAŞABİLECEKLERİ OGRENCİLERİ SINIRLAMA(ONEMLİ!)

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
          
            if (label2.Text.Trim() == "İNG102")// label-textbox daki metni koşul ifadesinde kullanacaksan trim kullan sağ soldaki boşluklar oldugundan metni tam almıyor.
            {
                //-------------------------------------
                baglantı.Open();
                SqlCommand kcek2 = new SqlCommand("Select *from vize where Numara=@numara", baglantı);
                kcek2.Parameters.AddWithValue("@numara", textBox1.Text);

                SqlDataAdapter da2 = new SqlDataAdapter(kcek2);
                SqlDataReader dr2 = kcek2.ExecuteReader();

                while (dr2.Read())
                {
                    textBox2.Text = dr2["İNG102"].ToString();
                }
                baglantı.Close();
                dr2.Close();
                //--------------------------------------
                baglantı.Open();
                SqlCommand kcek3 = new SqlCommand("Select *from final where Numara=@numara", baglantı);
                kcek3.Parameters.AddWithValue("@numara", textBox1.Text);

                SqlDataAdapter da3 = new SqlDataAdapter(kcek3);
                SqlDataReader dr3 = kcek3.ExecuteReader();
                while (dr3.Read())
                {
                    textBox3.Text = dr3["İNG102"].ToString();
                }
                baglantı.Close();
                //-------------------------------------
            }
            if(label2.Text.Trim()=="MAT102")
            {
                //-------------------------------------
                baglantı.Open();
                SqlCommand kcek2 = new SqlCommand("select *from vize where Numara=@numara", baglantı);
                kcek2.Parameters.AddWithValue("@numara", textBox1.Text);

                SqlDataAdapter da2 = new SqlDataAdapter(kcek2);
                SqlDataReader dr2 = kcek2.ExecuteReader();

                while(dr2.Read())
                {
                    textBox2.Text = dr2["MAT102"].ToString();
                }
                dr2.Close();
                baglantı.Close();
                //-------------------------------------
                baglantı.Open();
                SqlCommand kcek3 = new SqlCommand("select *from final where Numara='" + textBox1.Text + "'", baglantı);

                SqlDataAdapter da3 = new SqlDataAdapter(kcek3);
                SqlDataReader dr3 = kcek3.ExecuteReader();

                while(dr3.Read())
                {
                    textBox3.Text = dr3["MAT102"].ToString();
                }
                dr3.Close();
                baglantı.Close();
                //-------------------------------------
            }
            if (label2.Text.Trim() == "TC İnkilap")
            {
                //-------------------------------------
                baglantı.Open();
                SqlCommand kcek2 = new SqlCommand("select *from vize where Numara='" + textBox1.Text + "'", baglantı);
                SqlDataAdapter da2 = new SqlDataAdapter(kcek2);
                SqlDataReader dr2 = kcek2.ExecuteReader();

                while (dr2.Read())
                {
                    textBox2.Text = dr2["TC İnkilap"].ToString();
                }
                dr2.Close();
                baglantı.Close();
                //-------------------------------------
                baglantı.Open();
                SqlCommand kcek3 = new SqlCommand("select *from final where Numara='" + textBox1.Text + "'", baglantı);
                SqlDataAdapter da3 = new SqlDataAdapter(kcek3);
                SqlDataReader dr3 = kcek3.ExecuteReader();

                while(dr3.Read())
                {
                    textBox3.Text = dr3["TCİnkilap"].ToString();
                }
                dr3.Close();
                baglantı.Close();
                //-------------------------------------

            }
            if(label2.Text.Trim()=="FİZİK102")
            {
                baglantı.Open();
                SqlCommand kcek2 = new SqlCommand("select *from vize where Numara='"+textBox1.Text+"'",baglantı);
                SqlDataAdapter da2 = new SqlDataAdapter(kcek2);
                SqlDataReader dr2 = kcek2.ExecuteReader();
                while(dr2.Read())
                {
                    textBox2.Text = dr2["FİZİK102"].ToString();
                }
                dr2.Close();
                baglantı.Close();
                //-------------------------------------
                baglantı.Open();
                SqlCommand kcek3 = new SqlCommand("select *from final where Numara='" + textBox1.Text + "'", baglantı);
                SqlDataAdapter da3 = new SqlDataAdapter(kcek3);
                SqlDataReader dr3 = kcek3.ExecuteReader();
                while(dr3.Read())
                {
                    textBox3.Text=dr3["FİZİK102"].ToString();
                }
                dr3.Close();
                baglantı.Close();

            }
            if(label2.Text.Trim()=="BM102")
            {
                //-------------------------------------
                baglantı.Open();
                SqlCommand kcek2 = new SqlCommand("select *from vize where Numara='" + textBox1.Text + "'", baglantı);
                SqlDataAdapter da2 = new SqlDataAdapter(kcek2);
                SqlDataReader dr2 = kcek2.ExecuteReader();
                while(dr2.Read())
                {
                    textBox2.Text = dr2["BM102"].ToString();
                }
                dr2.Close();
                baglantı.Close();
                //-------------------------------------
                baglantı.Open();
                SqlCommand kcek3 = new SqlCommand("select *from final where Numara='" + textBox1.Text + "'", baglantı);
                SqlDataAdapter da3 = new SqlDataAdapter(kcek3);
                SqlDataReader dr3 = kcek3.ExecuteReader();
                while(dr3.Read())
                {
                    textBox3.Text = dr3["BM102"].ToString();
                }
                dr3.Close();
                baglantı.Close();
                //-------------------------------------

            }
            if (label2.Text.Trim() == "BM103")
            {
                //-------------------------------------
                baglantı.Open();
                SqlCommand kcek2 = new SqlCommand("select *from vize where Numara='" + textBox1.Text + "'", baglantı);
                SqlDataAdapter da2 = new SqlDataAdapter(kcek2);
                SqlDataReader dr2 = kcek2.ExecuteReader();
                while (dr2.Read())
                {
                    textBox2.Text = dr2["BM103"].ToString();
                }
                dr2.Close();
                baglantı.Close();
                //-------------------------------------
                baglantı.Open();
                SqlCommand kcek3 = new SqlCommand("select *from final where Numara='" + textBox1.Text + "'", baglantı);
                SqlDataAdapter da3 = new SqlDataAdapter(kcek3);
                SqlDataReader dr3 = kcek3.ExecuteReader();
                while (dr3.Read())
                {
                    textBox3.Text = dr3["BM103"].ToString();
                }
                dr3.Close();
                baglantı.Close();
                //-------------------------------------

            }
            if (label2.Text.Trim() == "EM102")
            {
                //-------------------------------------
                baglantı.Open();
                SqlCommand kcek2 = new SqlCommand("select *from vize where Numara='" + textBox1.Text + "'", baglantı);
                SqlDataAdapter da2 = new SqlDataAdapter(kcek2);
                SqlDataReader dr2 = kcek2.ExecuteReader();
                while (dr2.Read())
                {
                    textBox2.Text = dr2["EM102"].ToString();
                }
                dr2.Close();
                baglantı.Close();
                //-------------------------------------
                baglantı.Open();
                SqlCommand kcek3 = new SqlCommand("select *from final where Numara='" + textBox1.Text + "'", baglantı);
                SqlDataAdapter da3 = new SqlDataAdapter(kcek3);
                SqlDataReader dr3 = kcek3.ExecuteReader();
                while (dr3.Read())
                {
                    textBox3.Text = dr3["EM102"].ToString();
                }
                dr3.Close();
                baglantı.Close();
                //-------------------------------------

            }
            if (label2.Text.Trim() == "EM103")
            {
                //-------------------------------------
                baglantı.Open();
                SqlCommand kcek2 = new SqlCommand("select *from vize where Numara='" + textBox1.Text + "'", baglantı);
                SqlDataAdapter da2 = new SqlDataAdapter(kcek2);
                SqlDataReader dr2 = kcek2.ExecuteReader();
                while (dr2.Read())
                {
                    textBox2.Text = dr2["EM103"].ToString();
                }
                dr2.Close();
                baglantı.Close();
                //-------------------------------------
                baglantı.Open();
                SqlCommand kcek3 = new SqlCommand("select *from final where Numara='" + textBox1.Text + "'", baglantı);
                SqlDataAdapter da3 = new SqlDataAdapter(kcek3);
                SqlDataReader dr3 = kcek3.ExecuteReader();
                while (dr3.Read())
                {
                    textBox3.Text = dr3["EM103"].ToString();
                }
                dr3.Close();
                baglantı.Close();
                //-------------------------------------

            }
            if (label2.Text.Trim() == "MM102")
            {
                //-------------------------------------
                baglantı.Open();
                SqlCommand kcek2 = new SqlCommand("select *from vize where Numara='" + textBox1.Text + "'", baglantı);
                SqlDataAdapter da2 = new SqlDataAdapter(kcek2);
                SqlDataReader dr2 = kcek2.ExecuteReader();
                while (dr2.Read())
                {
                    textBox2.Text = dr2["MM102"].ToString();
                }
                dr2.Close();
                baglantı.Close();
                //-------------------------------------
                baglantı.Open();
                SqlCommand kcek3 = new SqlCommand("select *from final where Numara='" + textBox1.Text + "'", baglantı);
                SqlDataAdapter da3 = new SqlDataAdapter(kcek3);
                SqlDataReader dr3 = kcek3.ExecuteReader();
                while (dr3.Read())
                {
                    textBox3.Text = dr3["MM102"].ToString();
                }
                dr3.Close();
                baglantı.Close();
                //-------------------------------------

            }
            if (label2.Text.Trim() == "MM103")
            {
                //-------------------------------------
                baglantı.Open();
                SqlCommand kcek2 = new SqlCommand("select *from vize where Numara='" + textBox1.Text + "'", baglantı);
                SqlDataAdapter da2 = new SqlDataAdapter(kcek2);
                SqlDataReader dr2 = kcek2.ExecuteReader();
                while (dr2.Read())
                {
                    textBox2.Text = dr2["MM103"].ToString();
                }
                dr2.Close();
                baglantı.Close();
                //-------------------------------------
                baglantı.Open();
                SqlCommand kcek3 = new SqlCommand("select *from final where Numara='" + textBox1.Text + "'", baglantı);
                SqlDataAdapter da3 = new SqlDataAdapter(kcek3);
                SqlDataReader dr3 = kcek3.ExecuteReader();
                while (dr3.Read())
                {
                    textBox3.Text = dr3["MM103"].ToString();
                }
                dr3.Close();
                baglantı.Close();
                //-------------------------------------

            }
            if (label2.Text.Trim() == "KM102")
            {
                //-------------------------------------
                baglantı.Open();
                SqlCommand kcek2 = new SqlCommand("select *from vize where Numara='" + textBox1.Text + "'", baglantı);
                SqlDataAdapter da2 = new SqlDataAdapter(kcek2);
                SqlDataReader dr2 = kcek2.ExecuteReader();
                while (dr2.Read())
                {
                    textBox2.Text = dr2["KM102"].ToString();
                }
                dr2.Close();
                baglantı.Close();
                //-------------------------------------
                baglantı.Open();
                SqlCommand kcek3 = new SqlCommand("select *from final where Numara='" + textBox1.Text + "'", baglantı);
                SqlDataAdapter da3 = new SqlDataAdapter(kcek3);
                SqlDataReader dr3 = kcek3.ExecuteReader();
                while (dr3.Read())
                {
                    textBox3.Text = dr3["KM102"].ToString();
                }
                dr3.Close();
                baglantı.Close();
                //-------------------------------------

            }
            if (label2.Text.Trim() == "KM103")
            {
                //-------------------------------------
                baglantı.Open();
                SqlCommand kcek2 = new SqlCommand("select *from vize where Numara='" + textBox1.Text + "'", baglantı);
                SqlDataAdapter da2 = new SqlDataAdapter(kcek2);
                SqlDataReader dr2 = kcek2.ExecuteReader();
                while (dr2.Read())
                {
                    textBox2.Text = dr2["KM103"].ToString();
                }
                dr2.Close();
                baglantı.Close();
                //-------------------------------------
                baglantı.Open();
                SqlCommand kcek3 = new SqlCommand("select *from final where Numara='" + textBox1.Text + "'", baglantı);
                SqlDataAdapter da3 = new SqlDataAdapter(kcek3);
                SqlDataReader dr3 = kcek3.ExecuteReader();
                while (dr3.Read())
                {
                    textBox3.Text = dr3["KM103"].ToString();
                }
                dr3.Close();
                baglantı.Close();
                //-------------------------------------

            }
            if (label2.Text.Trim() == "İM102")
            {
                //-------------------------------------
                baglantı.Open();
                SqlCommand kcek2 = new SqlCommand("select *from vize where Numara='" + textBox1.Text + "'", baglantı);
                SqlDataAdapter da2 = new SqlDataAdapter(kcek2);
                SqlDataReader dr2 = kcek2.ExecuteReader();
                while (dr2.Read())
                {
                    textBox2.Text = dr2["İM102"].ToString();
                }
                dr2.Close();
                baglantı.Close();
                //-------------------------------------
                baglantı.Open();
                SqlCommand kcek3 = new SqlCommand("select *from final where Numara='" + textBox1.Text + "'", baglantı);
                SqlDataAdapter da3 = new SqlDataAdapter(kcek3);
                SqlDataReader dr3 = kcek3.ExecuteReader();
                while (dr3.Read())
                {
                    textBox3.Text = dr3["İM102"].ToString();
                }
                dr3.Close();
                baglantı.Close();
                //-------------------------------------

            }
            if (label2.Text.Trim() == "İM103")
            {
                //-------------------------------------
                baglantı.Open();
                SqlCommand kcek2 = new SqlCommand("select *from vize where Numara='" + textBox1.Text + "'", baglantı);
                SqlDataAdapter da2 = new SqlDataAdapter(kcek2);
                SqlDataReader dr2 = kcek2.ExecuteReader();
                while (dr2.Read())
                {
                    textBox2.Text = dr2["İM103"].ToString();
                }
                dr2.Close();
                baglantı.Close();
                //-------------------------------------
                baglantı.Open();
                SqlCommand kcek3 = new SqlCommand("select *from final where Numara='" + textBox1.Text + "'", baglantı);
                SqlDataAdapter da3 = new SqlDataAdapter(kcek3);
                SqlDataReader dr3 = kcek3.ExecuteReader();
                while (dr3.Read())
                {
                    textBox3.Text = dr3["İM103"].ToString();
                }
                dr3.Close();
                baglantı.Close();
                //-------------------------------------

            }
            if (label2.Text.Trim() == "EEM102")
            {
                //-------------------------------------
                baglantı.Open();
                SqlCommand kcek2 = new SqlCommand("select *from vize where Numara='" + textBox1.Text + "'", baglantı);
                SqlDataAdapter da2 = new SqlDataAdapter(kcek2);
                SqlDataReader dr2 = kcek2.ExecuteReader();
                while (dr2.Read())
                {
                    textBox2.Text = dr2["EEM102"].ToString();
                }
                dr2.Close();
                baglantı.Close();
                //-------------------------------------
                baglantı.Open();
                SqlCommand kcek3 = new SqlCommand("select *from final where Numara='" + textBox1.Text + "'", baglantı);
                SqlDataAdapter da3 = new SqlDataAdapter(kcek3);
                SqlDataReader dr3 = kcek3.ExecuteReader();
                while (dr3.Read())
                {
                    textBox3.Text = dr3["EEM102"].ToString();
                }
                dr3.Close();
                baglantı.Close();
                //-------------------------------------

            }
            if (label2.Text.Trim() == "EEM103")
            {
                //-------------------------------------
                baglantı.Open();
                SqlCommand kcek2 = new SqlCommand("select *from vize where Numara='" + textBox1.Text + "'", baglantı);
                SqlDataAdapter da2 = new SqlDataAdapter(kcek2);
                SqlDataReader dr2 = kcek2.ExecuteReader();
                while (dr2.Read())
                {
                    textBox2.Text = dr2["EEM103"].ToString();
                }
                dr2.Close();
                baglantı.Close();
                //-------------------------------------
                baglantı.Open();
                SqlCommand kcek3 = new SqlCommand("select *from final where Numara='" + textBox1.Text + "'", baglantı);
                SqlDataAdapter da3 = new SqlDataAdapter(kcek3);
                SqlDataReader dr3 = kcek3.ExecuteReader();
                while (dr3.Read())
                {
                    textBox3.Text = dr3["EEM103"].ToString();
                }
                dr3.Close();
                baglantı.Close();
                //-------------------------------------

            }

            //EN ALTTA KALMASI EN SON KONTROL EDİLMESİ AÇISINDAN ÖNEMLİ.
            if (textBox2.Text.Trim() == "" && textBox3.Text.Trim() == "")
            {
                MessageBox.Show("Lutfen not girisi yaptıktan sonra deneyiniz.");
            }
        }//DERS GORUNTULEME.GEÇERSİZ SİLİNECEK!!

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ogrgorevlisiform yeni = new ogrgorevlisiform();
            yeni.Show();
            this.Hide();
        }//FORM GEÇİŞİ
      
        private void pictureBox3_Click(object sender, EventArgs e)
        {
           if(label2.Text.Trim()=="İNG102")//trim koymazsan labeldan veri çekemezsin.
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("update vize set İNG102='" + textBox2.Text + "' where Numara='" + textBox1.Text + "'", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                //Console.WriteLine("Not Guncellemesi Basarili.");CONSOLE UYGULAMASINDA DEGİLSİN
                MessageBox.Show("Not Guncellemesi Basarili.");

            }
            if (label2.Text.Trim() == "MAT102")//trim koymazsan labeldan veri çekemezsin.
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("update vize set MAT102='" + textBox2.Text + "' where Numara='" + textBox1.Text + "'", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                //Console.WriteLine("Not Guncellemesi Basarili.");CONSOLE UYGULAMASINDA DEGİLSİN
                MessageBox.Show("Not Guncellemesi Basarili.");

            }
            if (label2.Text.Trim() == "FİZİK102")//trim koymazsan labeldan veri çekemezsin.
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("update vize set FİZİK102='" + textBox2.Text + "' where Numara='" + textBox1.Text + "'", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                //Console.WriteLine("Not Guncellemesi Basarili.");CONSOLE UYGULAMASINDA DEGİLSİN
                MessageBox.Show("Not Guncellemesi Basarili.");

            }
            if (label2.Text.Trim() == "TC İnkilap")//trim koymazsan labeldan veri çekemezsin.
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("update vize set [TC İnkilap]='" + textBox2.Text + "' where Numara='" + textBox1.Text + "'", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                //Console.WriteLine("Not Guncellemesi Basarili.");CONSOLE UYGULAMASINDA DEGİLSİN
                MessageBox.Show("Not Guncellemesi Basarili.");

            }
            if(label2.Text.Trim()=="BM102")
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("update vize set BM102='" + textBox2.Text + "' where Numara='" + textBox1.Text + "'", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("Not Guncellemesi Basarili.");
            }
            if (label2.Text.Trim() == "BM103")
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("update vize set BM103='" + textBox2.Text + "' where Numara='" + textBox1.Text + "'", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("Not Guncellemesi Basarili.");
            }
            if (label2.Text.Trim() == "EM102")
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("update vize set EM102='" + textBox2.Text + "' where Numara='" + textBox1.Text + "'", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("Not Guncellemesi Basarili.");
            }
            if (label2.Text.Trim() == "EM103")
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("update vize set EM103='" + textBox2.Text + "' where Numara='" + textBox1.Text + "'", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("Not Guncellemesi Basarili.");
            }
            if (label2.Text.Trim() == "MM102")
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("update vize set MM102='" + textBox2.Text + "' where Numara='" + textBox1.Text + "'", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("Not Guncellemesi Basarili.");
            }
            if (label2.Text.Trim() == "MM103")
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("update vize set MM103='" + textBox2.Text + "' where Numara='" + textBox1.Text + "'", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("Not Guncellemesi Basarili.");
            }
            if (label2.Text.Trim() == "KM102")
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("update vize set KM102='" + textBox2.Text + "' where Numara='" + textBox1.Text + "'", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("Not Guncellemesi Basarili.");
            }
            if (label2.Text.Trim() == "KM103")
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("update vize set KM103='" + textBox2.Text + "' where Numara='" + textBox1.Text + "'", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("Not Guncellemesi Basarili.");
            }
            if (label2.Text.Trim() == "İM102")
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("update vize set İM102='" + textBox2.Text + "' where Numara='" + textBox1.Text + "'", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("Not Guncellemesi Basarili.");
            }
            if (label2.Text.Trim() == "İM103")
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("update vize set İM103='" + textBox2.Text + "' where Numara='" + textBox1.Text + "'", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("Not Guncellemesi Basarili.");
            }
            if (label2.Text.Trim() == "EEM102")
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("update vize set EEM102='" + textBox2.Text + "' where Numara='" + textBox1.Text + "'", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("Not Guncellemesi Basarili.");
               
            }
            if (label2.Text.Trim() == "EEM103")
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("update vize set EEM103='" + textBox2.Text + "' where Numara='" + textBox1.Text + "'", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("Not Guncellemesi Basarili.");
            }
            /*//FİKİR//
            baglantı.Open();
            SqlCommand komut2 = new SqlCommand("uptade vize set label2.text='" + textBox2.Text + "' where Numara='" + textBox1.Text + "'", baglantı);
            komut2.ExecuteNonQuery();
            baglantı.Close();*/
        }//VİZE GUNCELLEME.GEÇERSİZ SİLİNECEK!!!

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if(label2.Text.Trim()=="İNG102")//trim koymazsan labeldan veri çekemezsin.
            {
                baglantı.Open();
                SqlCommand komut=new SqlCommand("update final set İNG102='"+textBox3.Text+"' where Numara='"+textBox1.Text+"'",baglantı);//uptade yanlış yazıyosun
                komut.ExecuteNonQuery();
                baglantı.Close();
                //Console.WriteLine("Not Guncellemesi Basarili.");CONSOLE UYGULAMASINDA DEGİLSİN
                MessageBox.Show("Not Guncellemesi Basarili.");
            }
            if (label2.Text.Trim()=="MAT102")
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("update final set MAT102='" + textBox3.Text+"' where Numara='" + textBox1.Text + "'", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                // Console.WriteLine("Not Guncellemesi Basarili.");CONSOLE UYGULAMASINDA DEGİLSİN
                MessageBox.Show("Not Guncellemesi Basarili.");
            }
            if (label2.Text.Trim()=="FİZİK102")
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("update final set FİZİK102='" + textBox3.Text + "' where Numara='" + textBox1.Text + "'", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                //Console.WriteLine("Not Guncellemesi Basarili."); CONSOLE UYGULAMASINDA DEGİLSİN
                MessageBox.Show("Not Guncellemesi Basarili.");
            }
            if (label2.Text.Trim()=="TC İnkilap")
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("update final set TCİnkilap='" + textBox3.Text + "' where Numara='" + textBox1.Text + "'", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                //Console.WriteLine("Not Guncellemesi Basarili.");CONSOLE UYGULAMASINDA DEGİLSİN
                MessageBox.Show("Not Guncellemesi Basarili.");
            }
            if (label2.Text.Trim() == "BM102")
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("update final set BM102='" + textBox2.Text + "' where Numara='" + textBox1.Text + "'", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("Not Guncellemesi Basarili.");
            }
            if (label2.Text.Trim() == "BM103")
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("update final set BM103='" + textBox2.Text + "' where Numara='" + textBox1.Text + "'", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("Not Guncellemesi Basarili.");
            }
            if (label2.Text.Trim() == "EM102")
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("update final set EM102='" + textBox2.Text + "' where Numara='" + textBox1.Text + "'", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("Not Guncellemesi Basarili.");
            }
            if (label2.Text.Trim() == "EM103")
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("update final set EM103='" + textBox2.Text + "' where Numara='" + textBox1.Text + "'", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("Not Guncellemesi Basarili.");
            }
            if (label2.Text.Trim() == "MM102")
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("update final set MM102='" + textBox2.Text + "' where Numara='" + textBox1.Text + "'", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("Not Guncellemesi Basarili.");
            }
            if (label2.Text.Trim() == "MM103")
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("update final set MM103='" + textBox2.Text + "' where Numara='" + textBox1.Text + "'", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("Not Guncellemesi Basarili.");
            }
            if (label2.Text.Trim() == "KM102")
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("update final set KM102='" + textBox2.Text + "' where Numara='" + textBox1.Text + "'", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("Not Guncellemesi Basarili.");
            }
            if (label2.Text.Trim() == "KM103")
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("update final set KM103='" + textBox2.Text + "' where Numara='" + textBox1.Text + "'", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("Not Guncellemesi Basarili.");
            }
            if (label2.Text.Trim() == "İM102")
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("update final set İM102='" + textBox2.Text + "' where Numara='" + textBox1.Text + "'", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("Not Guncellemesi Basarili.");
            }
            if (label2.Text.Trim() == "İM103")
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("update final set İM103='" + textBox2.Text + "' where Numara='" + textBox1.Text + "'", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("Not Guncellemesi Basarili.");
            }
            if (label2.Text.Trim() == "EEM102")
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("update final set EEM102='" + textBox2.Text + "' where Numara='" + textBox1.Text + "'", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("Not Guncellemesi Basarili.");

            }
            if (label2.Text.Trim() == "EEM103")
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("update final set EEM103='" + textBox2.Text + "' where Numara='" + textBox1.Text + "'", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("Not Guncellemesi Basarili.");
            }
        }//FİNAL GUNCELLEME.GEÇERSİZ SİLİNECEK!!

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (textad.TextLength <= 25 && textsoyad.TextLength <= 25 && textmail.TextLength <= 25 && texttel.TextLength <= 10 && textsifre.TextLength <= 25)
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("update ogruyesi set Ad='" + textad.Text + "',Soyad='" + textsoyad.Text + "',Gorev='" + combogrv.Text + "',Cinsiyet='" + combocinsiyet.Text + "',Email='" + textmail.Text + "',Telefon='" + texttel.Text + "',Sifre='" + textsifre.Text + "',Unvan='" + combounvan.Text + "' where KullanıcıNo='" + textkadı.Text + "'", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("İslem Basarili.");
                panel3.Hide();
            }
            else
                MessageBox.Show("Karakter Sınırlarını Aştınız!!");
            panel3.Hide();
            panel1.Show();

        }//OGR BİLGİLERİ GUNCELLEME.

        private void button1_Click(object sender, EventArgs e)
        {
            panel3.Show();
            panel1.Hide();
            baglantı.Open();
            SqlCommand komut = new SqlCommand("select *from ogruyesi where KullanıcıNo=@kno", baglantı);
            komut.Parameters.AddWithValue("@kno", labelkno.Text.ToString());//İNCELE

            SqlDataAdapter da = new SqlDataAdapter(komut);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                textad.Text = dr["Ad"].ToString();
                textsoyad.Text = dr["Soyad"].ToString();
                combogrv.Text = dr["Gorev"].ToString();
                combocinsiyet.Text = dr["Cinsiyet"].ToString();
                combounvan.Text = dr["Unvan"].ToString();
                textmail.Text = dr["Email"].ToString();
                texttel.Text = dr["Telefon"].ToString();
                textkadı.Text = dr["KullanıcıNo"].ToString();
                textsifre.Text = dr["Sifre"].ToString();

            }
            dr.Close();
            baglantı.Close();
            textkadı.Enabled = false;
        }//OGR BİLGİLERİNİ BOXLARA YAZDIRMA(GUNCELLEME YAPABİLMEK İÇİN REFERANS ALIYORUZ.)

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if(label2.Text.ToString().Trim()=="MAT102")
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("select *from ortakvize where Numara='" + textBox1.Text + "'", baglantı);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                SqlDataReader dr = komut.ExecuteReader();
                while(dr.Read())
                {
                    textBox2.Text = dr["MAT102"].ToString();
                }
                dr.Close();
                baglantı.Close();
                baglantı.Open();
                SqlCommand komut2 = new SqlCommand("select *from ortakfinal where Numara='" + textBox1.Text + "'", baglantı);
                SqlDataAdapter da2 = new SqlDataAdapter(komut2);
                SqlDataReader dr2 = komut2.ExecuteReader();
                while(dr2.Read())
                {
                    textBox3.Text = dr2["MAT102"].ToString();
                }
                dr2.Close();
                baglantı.Close();
            }
        }

        private void pictureBoxvizegir_Click(object sender, EventArgs e)
        {
            if(label2.Text.ToString().Trim()=="MAT102"||label2.Text.ToString().Trim()=="FİZİK102"||label2.Text.ToString().Trim()=="İNG102"||label2.Text.ToString().Trim()=="TCİnkilap")
            {
                                            if(label2.Text.ToString().Trim()=="MAT102")
                                            {
                                                baglantı.Open();
                                                SqlCommand komut = new SqlCommand("update ortakvize set MAT102='"+textBox2.Text+"'", baglantı);
                                                
                                                komut.ExecuteNonQuery();
                                                baglantı.Close();
                                                MessageBox.Show("İslem Basarili.");
                                            }
                                            if (label2.Text.ToString().Trim() == "FİZİK102")
                                            {
                                                baglantı.Open();
                                                SqlCommand komut = new SqlCommand("update ortakvize set FİZİK102=@fiz", baglantı);
                                                komut.Parameters.AddWithValue("@fiz", textBox2.Text);
                                                komut.ExecuteNonQuery();
                                                baglantı.Close();
                                                MessageBox.Show("İslem Basarili.");
                                            }
                                            if (label2.Text.ToString().Trim() == "İNG102")
                                            {
                                                baglantı.Open();
                                                SqlCommand komut = new SqlCommand("update ortakvize set İNG102=@ing", baglantı);
                                                komut.Parameters.AddWithValue("@ing", textBox2.Text);
                                                komut.ExecuteNonQuery();
                                                baglantı.Close();
                                                MessageBox.Show("İslem Basarili.");
                                            }
                                            if (label2.Text.ToString().Trim() == "TCİnkilap")
                                            {
                                                baglantı.Open();
                                                SqlCommand komut = new SqlCommand("update ortakvize set TCİnkilap=@tc", baglantı);
                                                komut.Parameters.AddWithValue("@tc", textBox2.Text);
                                                komut.ExecuteNonQuery();
                                                baglantı.Close();
                                                MessageBox.Show("İslem Basarili.");
                                            }
            }
            else if(label2.Text.ToString().Trim()=="BM102")
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("UPDATE vizebm SET BM102='"+textBox2.Text+"'",baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("BM102 VİZE GUNCELLEMESİ BASARİLİ.");
            }
            else if (label2.Text.ToString().Trim() == "BM103")
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("UPDATE vizebm SET BM103='" + textBox2.Text + "'", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("BM103 VİZE GUNCELLEMESİ BASARİLİ.");
            }
            else if (label2.Text.ToString().Trim() == "KM102")
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("UPDATE vizekm SET KM102='" + textBox2.Text + "'", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("KM102 VİZE GUNCELLEMESİ BASARİLİ.");
            }
            else if (label2.Text.ToString().Trim() == "KM103")
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("UPDATE vizekm SET KM103='" + textBox2.Text + "'", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("KM103 VİZE GUNCELLEMESİ BASARİLİ.");
            }
            else if (label2.Text.ToString().Trim() == "EM102")
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("UPDATE vizeem SET EM102='" + textBox2.Text + "'", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("EM102 VİZE GUNCELLEMESİ BASARİLİ.");
            }
            else if (label2.Text.ToString().Trim() == "EM103")
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("UPDATE vizeem SET EM103='" + textBox2.Text + "'", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("EM103 VİZE GUNCELLEMESİ BASARİLİ.");
            }

        }//VİZE NOT ATAMALARI UPDATE

        private void pictureBoxfinalgir_Click(object sender, EventArgs e)
        {
            if (label2.Text.ToString().Trim() == "MAT102" || label2.Text.ToString().Trim() == "FİZİK102" || label2.Text.ToString().Trim() == "İNG102" || label2.Text.ToString().Trim() == "TCİnkilap")
            {
                        if (label2.Text.ToString().Trim() == "MAT102")
                        {
                            baglantı.Open();
                            SqlCommand komut = new SqlCommand("update ortakfinal set MAT102=@mat", baglantı);
                            komut.Parameters.AddWithValue("@mat", textBox3.Text);
                            komut.ExecuteNonQuery();
                            baglantı.Close();
                            MessageBox.Show("İslem Basarili.");
                        }
                        if (label2.Text.ToString().Trim() == "FİZİK102")
                        {
                            baglantı.Open();
                            SqlCommand komut = new SqlCommand("update ortakfinal set FİZİK102=@fiz", baglantı);
                            komut.Parameters.AddWithValue("@fiz", textBox3.Text);
                            komut.ExecuteNonQuery();
                            baglantı.Close();
                            MessageBox.Show("İslem Basarili.");
                        }
                        if (label2.Text.ToString().Trim() == "İNG102")
                        {
                            baglantı.Open();
                            SqlCommand komut = new SqlCommand("update ortakfinal set İNG102=@ing", baglantı);
                            komut.Parameters.AddWithValue("@ing", textBox3.Text);
                            komut.ExecuteNonQuery();
                            baglantı.Close();
                            MessageBox.Show("İslem Basarili.");
                        }
                        if (label2.Text.ToString().Trim() == "TCİnkilap")
                        {
                            baglantı.Open();
                            SqlCommand komut = new SqlCommand("update ortakfinal set TCİnkilap=@tc", baglantı);
                            komut.Parameters.AddWithValue("@tc", textBox3.Text);
                            komut.ExecuteNonQuery();
                            baglantı.Close();
                            MessageBox.Show("İslem Basarili.");
                        }
            }
            else if (label2.Text.ToString().Trim() == "BM102")
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("UPDATE finalbm SET BM102='" + textBox2.Text + "'", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("BM102 VİZE GUNCELLEMESİ BASARİLİ.");
            }
            else if (label2.Text.ToString().Trim() == "BM103")
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("UPDATE finalbm SET BM103='" + textBox2.Text + "'", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("BM103 VİZE GUNCELLEMESİ BASARİLİ.");
            }
            else if (label2.Text.ToString().Trim() == "KM102")
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("UPDATE finalkm SET KM102='" + textBox2.Text + "'", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("KM102 VİZE GUNCELLEMESİ BASARİLİ.");
            }
            else if (label2.Text.ToString().Trim() == "KM103")
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("UPDATE finalkm SET KM103='" + textBox2.Text + "'", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("KM103 VİZE GUNCELLEMESİ BASARİLİ.");
            }
            else if (label2.Text.ToString().Trim() == "EM102")
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("UPDATE finalem SET EM102='" + textBox2.Text + "'", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("EM102 VİZE GUNCELLEMESİ BASARİLİ.");
            }
            else if (label2.Text.ToString().Trim() == "EM103")
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("UPDATE finalem SET EM103='" + textBox2.Text + "'", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("EM103 VİZE GUNCELLEMESİ BASARİLİ.");
            }
        }//FİNAL NOT ATAMALARI UPDATE

        private void pictureBox10_Click(object sender, EventArgs e)
        { if(label6.Text.ToString().Trim()!=""&&label7.Text.ToString().Trim()!="")
            {

                if (label2.Text.ToString().Trim() == "MAT102" || label2.Text.ToString().Trim() == "FİZİK102" || label2.Text.ToString().Trim() == "İNG102" || label2.Text.ToString().Trim() == "TC İnkilap")//ORTAK DERS GÖREVLİLERİNDEN GİRİŞ YAPTIYSA ORTAKDERS SORGULAMASINI KULLANIYORUZ
                {
                    if (sorgulaortakvize() == 0)//o numarada kimse yoksa ekleme işlemine girecek.(//daha once kayıt yapılmayan sorgu için buraya giriyor ve kayıt yapıyor.)
                    {
                        try
                        {
                            if (baglantı.State == ConnectionState.Closed)
                                baglantı.Open();

                            if (label2.Text.ToString().Trim() == "MAT102")
                            {

                                SqlCommand komut = new SqlCommand("insert into ortakvize(Numara,MAT102) values(@no,@mat)", baglantı);
                                komut.Parameters.AddWithValue("@no", textBox1.Text);
                                komut.Parameters.AddWithValue("@mat", textBox2.Text);
                                komut.ExecuteNonQuery();
                                baglantı.Close();
                                MessageBox.Show("Mat102 Not Ekleme İşlem basarili.");

                            }
                            if (label2.Text.ToString().Trim() == "FİZİK102")
                            {

                                SqlCommand komut = new SqlCommand("insert into ortakvize(Numara,FİZİK102) values(@no,@fiz)", baglantı);
                                komut.Parameters.AddWithValue("@no", textBox1.Text);
                                komut.Parameters.AddWithValue("@fiz", textBox2.Text);
                                komut.ExecuteNonQuery();
                                baglantı.Close();
                                MessageBox.Show("Fizik102 Not Ekleme İşlem basarili.");

                            }
                            if (label2.Text.ToString().Trim() == "İNG102")
                            {

                                SqlCommand komut = new SqlCommand("insert into ortakvize(Numara,İNG102) values(@no,@ing)", baglantı);
                                komut.Parameters.AddWithValue("@no", textBox1.Text);
                                komut.Parameters.AddWithValue("@ing", textBox2.Text);
                                komut.ExecuteNonQuery();
                                baglantı.Close();
                                MessageBox.Show("İng102 Not Ekleme İşlem basarili.");

                            }
                            if (label2.Text.ToString().Trim() == "TC İnkilap")
                            {

                                SqlCommand komut = new SqlCommand("insert into ortakvize(Numara,TCİnkilap) values(@no,@tc)", baglantı);
                                komut.Parameters.AddWithValue("@no", textBox1.Text);
                                komut.Parameters.AddWithValue("@tc", textBox2.Text);
                                komut.ExecuteNonQuery();
                                baglantı.Close();
                                MessageBox.Show("TCİnkilap Not Ekleme İşlem basarili.");

                            }



                        }
                        catch (Exception hata)
                        {

                            MessageBox.Show("HATA OLUSTU." + hata.Message);
                        }
                    }
                    else
                    {
                        if (label2.Text.ToString().Trim() == "MAT102")
                        {
                            baglantı.Open();
                            SqlCommand komut = new SqlCommand("update ortakvize set MAT102='" + textBox2.Text + "' where Numara='" + textBox1.Text + "'", baglantı);
                            komut.ExecuteNonQuery();
                            baglantı.Close();
                            MessageBox.Show("Mat102 Guncelleme İşlemi Basarili.");
                        }
                        else if (label2.Text.ToString().Trim() == "FİZİK102")
                        {
                            baglantı.Open();
                            SqlCommand komut = new SqlCommand("update ortakvize set FİZİK102='" + textBox2.Text + "' where Numara='" + textBox1.Text + "'", baglantı);
                            komut.ExecuteNonQuery();
                            baglantı.Close();
                            MessageBox.Show("Fizik102 Guncelleme İslemi Basarili.");
                        }
                        else if (label2.Text.ToString().Trim() == "İNG102")
                        {
                            baglantı.Open();
                            SqlCommand komut = new SqlCommand("update ortakvize set İNG102='" + textBox2.Text + "' where Numara='" + textBox1.Text + "'", baglantı);
                            komut.ExecuteNonQuery();
                            baglantı.Close();
                            MessageBox.Show("İng102 Guncelleme İslemi Basarili.");
                        }
                        else if (label2.Text.ToString().Trim() == "TC İnkilap")
                        {
                            baglantı.Open();
                            SqlCommand komut = new SqlCommand("update ortakvize set TCİnkilap='" + textBox2.Text + "' where Numara='" + textBox1.Text + "'", baglantı);
                            komut.ExecuteNonQuery();
                            baglantı.Close();
                            MessageBox.Show("TCİnkilap Guncelleme İslemi Basarili.");
                        }
                    }
                }

                if (label2.Text.ToString().Trim() == "BM102" || label2.Text.ToString().Trim() == "BM103")
                {
                    if (sorgulavizebm() == 0)
                    {
                        if (label2.Text.ToString().Trim() == "BM102")
                        {
                            baglantı.Open();
                            SqlCommand komut = new SqlCommand("insert into vizebm(Numara,BM102) values(@no,@bm102)", baglantı);
                            komut.Parameters.AddWithValue("@no", textBox1.Text);
                            komut.Parameters.AddWithValue("@bm102", textBox2.Text);
                            komut.ExecuteNonQuery();
                            baglantı.Close();
                            MessageBox.Show("BM102 Not Ekleme İşlem basarili.");

                        }
                        if (label2.Text.ToString().Trim() == "BM103")
                        {
                            baglantı.Open();
                            SqlCommand komut = new SqlCommand("insert into vizebm(Numara,BM103) values(@no,@bm103)", baglantı);
                            komut.Parameters.AddWithValue("@no", textBox1.Text);
                            komut.Parameters.AddWithValue("@bm103", textBox2.Text);
                            komut.ExecuteNonQuery();
                            baglantı.Close();
                            MessageBox.Show("BM103 Not Ekleme İşlem basarili.");

                        }
                    }
                    else
                    {
                        if (label2.Text.ToString().Trim() == "BM102")
                        {
                            baglantı.Open();
                            SqlCommand komut = new SqlCommand("update vizebm set BM102='" + textBox2.Text + "' where Numara='" + textBox1.Text + "'", baglantı);
                            komut.ExecuteNonQuery();
                            baglantı.Close();
                            MessageBox.Show("BM102 Guncelleme İslemi Basarili.");
                        }
                        else if (label2.Text.ToString().Trim() == "BM103")
                        {
                            baglantı.Open();
                            SqlCommand komut = new SqlCommand("update vizebm set BM103='" + textBox2.Text + "' where Numara='" + textBox1.Text + "'", baglantı);
                            komut.ExecuteNonQuery();
                            baglantı.Close();
                            MessageBox.Show("BM103 Guncelleme İslemi Basarili.");
                        }
                    }
                }
                if (label2.Text.ToString().Trim() == "EM102" || label2.Text.ToString().Trim() == "EM103")
                {
                    if (sorgulavizeem() == 0)
                    {
                        if (label2.Text.ToString().Trim() == "EM102")
                        {
                            baglantı.Open();
                            SqlCommand komut = new SqlCommand("insert into vizeem(Numara,EM102) values(@no,@em102)", baglantı);
                            komut.Parameters.AddWithValue("@no", textBox1.Text);
                            komut.Parameters.AddWithValue("@em103", textBox2.Text);
                            komut.ExecuteNonQuery();
                            baglantı.Close();
                            MessageBox.Show("EM102 Not Ekleme İşlem basarili.");

                        }
                        if (label2.Text.ToString().Trim() == "EM103")
                        {
                            baglantı.Open();
                            SqlCommand komut = new SqlCommand("insert into vizeem(Numara,EM103) values(@no,@em103)", baglantı);
                            komut.Parameters.AddWithValue("@no", textBox1.Text);
                            komut.Parameters.AddWithValue("@em103", textBox2.Text);
                            komut.ExecuteNonQuery();
                            baglantı.Close();
                            MessageBox.Show("EM103 Not Ekleme İşlem basarili.");

                        }

                    }
                    else
                    {

                        if (label2.Text.ToString().Trim() == "EM102")
                        {
                            baglantı.Open();
                            SqlCommand komut = new SqlCommand("update vizeem set EM102='" + textBox2.Text + "' where Numara='" + textBox1.Text + "'", baglantı);
                            komut.ExecuteNonQuery();
                            baglantı.Close();
                            MessageBox.Show("EM102 Guncelleme İslemi Basarili.");
                        }
                        else if (label2.Text.ToString().Trim() == "EM103")
                        {
                            baglantı.Open();
                            SqlCommand komut = new SqlCommand("update vizeem set EM103='" + textBox2.Text + "' where Numara='" + textBox1.Text + "'", baglantı);
                            komut.ExecuteNonQuery();
                            baglantı.Close();
                            MessageBox.Show("EM103 Guncelleme İslemi Basarili.");
                        }
                    }
                }
                if (label2.Text.ToString().Trim() == "KM102" || label2.Text.ToString().Trim() == "KM103")
                {
                    if (sorgulavizekm() == 0)
                    {
                        if (label2.Text.ToString().Trim() == "KM102")
                        {
                            baglantı.Open();
                            SqlCommand komut = new SqlCommand("insert into vizekm(Numara,KM102) values(@no,@km102)", baglantı);
                            komut.Parameters.AddWithValue("@no", textBox1.Text);
                            komut.Parameters.AddWithValue("@km102", textBox2.Text);
                            komut.ExecuteNonQuery();
                            baglantı.Close();
                            MessageBox.Show("KM102 Not Ekleme İşlem basarili.");

                        }
                        if (label2.Text.ToString().Trim() == "KM103")
                        {
                            baglantı.Open();
                            SqlCommand komut = new SqlCommand("insert into vizekm(Numara,KM103) values(@no,@km103)", baglantı);
                            komut.Parameters.AddWithValue("@no", textBox1.Text);
                            komut.Parameters.AddWithValue("@km103", textBox2.Text);
                            komut.ExecuteNonQuery();
                            baglantı.Close();
                            MessageBox.Show("KM103 Not Ekleme İşlem basarili.");

                        }


                    }
                    else
                    {
                        if (label2.Text.ToString().Trim() == "KM102")
                        {
                            baglantı.Open();
                            SqlCommand komut = new SqlCommand("update vizekm set KM102='" + textBox2.Text + "' where Numara='" + textBox1.Text + "'", baglantı);
                            komut.ExecuteNonQuery();
                            baglantı.Close();
                            MessageBox.Show("KM102 Guncelleme İslemi Basarili.");
                        }
                        else if (label2.Text.ToString().Trim() == "KM103")
                        {
                            baglantı.Open();
                            SqlCommand komut = new SqlCommand("update vizekm set KM103='" + textBox2.Text + "' where Numara='" + textBox1.Text + "'", baglantı);
                            komut.ExecuteNonQuery();
                            baglantı.Close();
                            MessageBox.Show("KM103 Guncelleme İslemi Basarili.");
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("Lutfen Ogrenci girisi yapınız.");
            }
                    
        }//SON OLARAK KAYDA DEGER VİZE GİRİŞLERİ

        private void pictureBoxyfinal_Click(object sender, EventArgs e)//SON OLARAK KAYDA DEGER FİNAL GİRİŞLERİ
        {
            if (label6.Text.ToString().Trim() != "" && label7.Text.ToString().Trim() != "")
            {
                if (label2.Text.ToString().Trim() == "MAT102" || label2.Text.ToString().Trim() == "FİZİK102" || label2.Text.ToString().Trim() == "İNG102" || label2.Text.ToString().Trim() == "TC İnkilap")//ORTAK DERS GÖREVLİLERİNDEN GİRİŞ YAPTIYSA ORTAKDERS SORGULAMASINI KULLANIYORUZ
                {
                    if (sorgulaortakfinal() == 0)//daha once kayıt yapılmayan sorgu için buraya giriyor ve kayıt yapıyor.
                    {
                        try
                        {
                            if (baglantı.State == ConnectionState.Closed)
                                baglantı.Open();
                            if (label2.Text.ToString().Trim() == "MAT102")
                            {

                                SqlCommand komut = new SqlCommand("insert into ortakfinal(Numara,MAT102) values(@no,@mat)", baglantı);
                                komut.Parameters.AddWithValue("@no", textBox1.Text);
                                komut.Parameters.AddWithValue("@mat", textBox3.Text);
                                komut.ExecuteNonQuery();
                                baglantı.Close();
                                MessageBox.Show("MAT102 Final Not Eklemesi Basarili.");
                            }
                            if (label2.Text.ToString().Trim() == "FİZİK102")
                            {

                                SqlCommand komut = new SqlCommand("insert into ortakfinal(Numara,FİZİK102) values(@no,@fiz)", baglantı);
                                komut.Parameters.AddWithValue("@no", textBox1.Text);
                                komut.Parameters.AddWithValue("@fiz", textBox3.Text);
                                komut.ExecuteNonQuery();
                                baglantı.Close();
                                MessageBox.Show("FİZİK102 Final Not Eklemesi Basarili.");
                            }
                            if (label2.Text.ToString().Trim() == "İNG102")
                            {

                                SqlCommand komut = new SqlCommand("insert into ortakfinal(Numara,İNG102) values(@no,@ing)", baglantı);
                                komut.Parameters.AddWithValue("@no", textBox1.Text);
                                komut.Parameters.AddWithValue("@ing", textBox3.Text);
                                komut.ExecuteNonQuery();
                                baglantı.Close();
                                MessageBox.Show("İNG102 Final Not Eklemesi Basarili.");
                            }
                            if (label2.Text.ToString().Trim() == "TC İnkilap")
                            {

                                SqlCommand komut = new SqlCommand("insert into ortakfinal(Numara,TCİnkilap) values(@no,@tc)", baglantı);
                                komut.Parameters.AddWithValue("@no", textBox1.Text);
                                komut.Parameters.AddWithValue("@tc", textBox3.Text);
                                komut.ExecuteNonQuery();
                                baglantı.Close();
                                MessageBox.Show("TCİnkilap Final Not Eklemesi Basarili.");
                            }
                        }
                        catch (Exception hata)
                        {

                            MessageBox.Show("Hata Olustu." + hata.Message);

                        }


                    }
                    else
                    {
                        try
                        {
                            if (baglantı.State == ConnectionState.Closed)
                                baglantı.Open();
                            if (label2.Text.ToString().Trim() == "MAT102")
                            {

                                SqlCommand komut = new SqlCommand("update ortakfinal set MAT102=@mat", baglantı);
                                komut.Parameters.AddWithValue("@mat", textBox3.Text);
                                komut.ExecuteNonQuery();
                                baglantı.Close();
                                MessageBox.Show("MAT102 Final Guncellemesi Basarili.");
                            }
                            if (label2.Text.ToString().Trim() == "FİZİK102")
                            {

                                SqlCommand komut = new SqlCommand("update ortakfinal set FİZİK102=@fiz", baglantı);
                                komut.Parameters.AddWithValue("@fiz", textBox3.Text);
                                komut.ExecuteNonQuery();
                                baglantı.Close();
                                MessageBox.Show("FİZİK102 Final Guncellemesi Basarili.");
                            }
                            if (label2.Text.ToString().Trim() == "İNG102")
                            {

                                SqlCommand komut = new SqlCommand("update ortakfinal set İNG102=@ing", baglantı);
                                komut.Parameters.AddWithValue("@ing", textBox3.Text);
                                komut.ExecuteNonQuery();
                                baglantı.Close();
                                MessageBox.Show("İNG102 Final Guncellemesi Basarili.");
                            }
                            if (label2.Text.ToString().Trim() == "TC İnkilap")
                            {

                                SqlCommand komut = new SqlCommand("update ortakfinal set TCİnkilap=@tc", baglantı);
                                komut.Parameters.AddWithValue("@tc", textBox3.Text);
                                komut.ExecuteNonQuery();
                                baglantı.Close();
                                MessageBox.Show("TCİnkilap Final Guncellemesi Basarili.");
                            }
                        }
                        catch (Exception hata)
                        {

                            MessageBox.Show("Hata Olustu." + hata.Message);

                        }

                    }
                }
                else if (label2.Text.ToString().Trim() == "BM102" || label2.Text.ToString().Trim() == "BM103")//finalbm için ekleme guncelleme işlemleri.
                {
                    if (sorgulafinalbm() == 0)//hiç kimse yoksa ekleme işlemi yapacak.
                    {
                        try
                        {
                            if (baglantı.State == ConnectionState.Closed)
                                baglantı.Open();
                            if (label2.Text.ToString().Trim() == "BM102")
                            {
                                SqlCommand komut = new SqlCommand("insert into finalbm(Numara,BM102) values(@no,@bm)", baglantı);
                                komut.Parameters.AddWithValue("@no", textBox1.Text);
                                komut.Parameters.AddWithValue("@bm", textBox3.Text);
                                komut.ExecuteNonQuery();
                                baglantı.Close();
                                MessageBox.Show("BM102 FİNAL EKLEMESİ BASARİLİ.");
                            }
                            if (label2.Text.ToString().Trim() == "BM103")
                            {
                                SqlCommand komut = new SqlCommand("insert into finalbm(Numara,BM103) values(@no,@bm3)", baglantı);
                                komut.Parameters.AddWithValue("@no", textBox1.Text);
                                komut.Parameters.AddWithValue("@bm3", textBox3.Text);
                                komut.ExecuteNonQuery();
                                baglantı.Close();
                                MessageBox.Show("BM103 FİNAL EKLEMESİ BASARİLİ.");
                            }
                        }
                        catch (Exception hata)
                        {

                            MessageBox.Show("Hata Olustu." + hata.Message);
                        }

                    }
                    else//biri varsa update işlemi yapacak.
                    {
                        try
                        {
                            if (baglantı.State == ConnectionState.Closed)
                                baglantı.Open();
                            if (label2.Text.ToString().Trim() == "BM102")
                            {
                                SqlCommand komut = new SqlCommand("update finalbm set BM102=@bm", baglantı);
                                komut.Parameters.AddWithValue("@bm", textBox3.Text);
                                komut.ExecuteNonQuery();
                                baglantı.Close();
                                MessageBox.Show("BM102 FİNAL GUNCELLEMESİ BASARİLİ.");
                            }
                            if (label2.Text.ToString().Trim() == "BM103")
                            {
                                SqlCommand komut = new SqlCommand("update finalbm set BM103=@bm3", baglantı);
                                komut.Parameters.AddWithValue("@bm3", textBox3.Text);
                                komut.ExecuteNonQuery();
                                baglantı.Close();
                                MessageBox.Show("BM103 FİNAL GUNCELLEMESİ BASARİLİ.");
                            }
                        }
                        catch (Exception hata)
                        {

                            MessageBox.Show("Hata Olustu." + hata.Message);
                        }

                    }
                }
                else if (label2.Text.ToString().Trim() == "EM102" || label2.Text.ToString().Trim() == "EM103")//em final ekleme guncelleme islemleri.
                {
                    if (sorgulafinalem() == 0)//hiç kimse yoksa ekleme işlemi yapacak.
                    {
                        try
                        {
                            if (baglantı.State == ConnectionState.Closed)
                                baglantı.Open();
                            if (label2.Text.ToString().Trim() == "EM102")
                            {
                                SqlCommand komut = new SqlCommand("insert into finalem(Numara,EM102) values(@no,@em)", baglantı);
                                komut.Parameters.AddWithValue("@no", textBox1.Text);
                                komut.Parameters.AddWithValue("@em", textBox3.Text);
                                komut.ExecuteNonQuery();
                                baglantı.Close();
                                MessageBox.Show("EM102 FİNAL EKLEMESİ BASARİLİ.");
                            }
                            if (label2.Text.ToString().Trim() == "EM103")
                            {
                                SqlCommand komut = new SqlCommand("insert into finalem(Numara,EM103) values(@no,@em3)", baglantı);
                                komut.Parameters.AddWithValue("@no", textBox1.Text);
                                komut.Parameters.AddWithValue("@em3", textBox3.Text);
                                komut.ExecuteNonQuery();
                                baglantı.Close();
                                MessageBox.Show("EM103 FİNAL EKLEMESİ BASARİLİ.");
                            }
                        }
                        catch (Exception hata)
                        {

                            MessageBox.Show("Hata Olustu." + hata.Message);
                        }

                    }
                    else
                    {
                        try
                        {
                            if (baglantı.State == ConnectionState.Closed)
                                baglantı.Open();
                            if (label2.Text.ToString().Trim() == "EM102")
                            {
                                SqlCommand komut = new SqlCommand("update finalem set EM102=@em", baglantı);
                                komut.Parameters.AddWithValue("@em", textBox3.Text);
                                komut.ExecuteNonQuery();
                                baglantı.Close();
                                MessageBox.Show("EM102 FİNAL GUNCELLEMESİ BASARİLİ.");
                            }
                            if (label2.Text.ToString().Trim() == "EM103")
                            {
                                SqlCommand komut = new SqlCommand("update finalem set EM103=@em3", baglantı);
                                komut.Parameters.AddWithValue("@em3", textBox3.Text);
                                komut.ExecuteNonQuery();
                                baglantı.Close();
                                MessageBox.Show("EM103 FİNAL GUNCELLEMESİ BASARİLİ.");
                            }
                        }
                        catch (Exception hata)
                        {

                            MessageBox.Show("Hata Olustu." + hata.Message);
                        }
                    }
                }
                else if (label2.Text.ToString().Trim() == "KM102" || label2.Text.ToString().Trim() == "KM103")//finalkm ekleme update işlemleri.
                {
                    if (sorgulafinalkm() == 0)//hiç kimse yoksa ekleme işlemi yapacak.
                    {
                        try
                        {
                            if (baglantı.State == ConnectionState.Closed)
                                baglantı.Open();
                            if (label2.Text.ToString().Trim() == "KM102")
                            {
                                SqlCommand komut = new SqlCommand("insert into finalkm(Numara,KM102) values(@no,@km)", baglantı);
                                komut.Parameters.AddWithValue("@no", textBox1.Text);
                                komut.Parameters.AddWithValue("@km", textBox3.Text);
                                komut.ExecuteNonQuery();
                                baglantı.Close();
                                MessageBox.Show("KM102 FİNAL EKLEMESİ BASARİLİ.");
                            }
                            if (label2.Text.ToString().Trim() == "KM103")
                            {
                                SqlCommand komut = new SqlCommand("insert into finalkm(Numara,KM103) values(@no,@km3)", baglantı);
                                komut.Parameters.AddWithValue("@no", textBox1.Text);
                                komut.Parameters.AddWithValue("@km3", textBox3.Text);
                                komut.ExecuteNonQuery();
                                baglantı.Close();
                                MessageBox.Show("EKM103 FİNAL EKLEMESİ BASARİLİ.");
                            }
                        }
                        catch (Exception hata)
                        {

                            MessageBox.Show("Hata Olustu." + hata.Message);
                        }

                    }
                    else
                    {
                        try
                        {
                            if (baglantı.State == ConnectionState.Closed)
                                baglantı.Open();
                            if (label2.Text.ToString().Trim() == "KM102")
                            {
                                SqlCommand komut = new SqlCommand("update finalkm set KM102=@km", baglantı);
                                komut.Parameters.AddWithValue("@km", textBox3.Text);
                                komut.ExecuteNonQuery();
                                baglantı.Close();
                                MessageBox.Show("KM102 FİNAL GUNCELLEMESİ BASARİLİ.");
                            }
                            if (label2.Text.ToString().Trim() == "KM103")
                            {
                                SqlCommand komut = new SqlCommand("update finalkm set KM103=@km3", baglantı);
                                komut.Parameters.AddWithValue("@km3", textBox3.Text);
                                komut.ExecuteNonQuery();
                                baglantı.Close();
                                MessageBox.Show("KM103 FİNAL GUNCELLEMESİ BASARİLİ.");
                            }
                        }
                        catch (Exception hata)
                        {

                            MessageBox.Show("Hata Olustu." + hata.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Lutfen Ogrenci girisi yapınız!!!");
            }

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.ToString().Trim()=="")
            {
                MessageBox.Show("Bilgi almak için bir ogrenci numarası giriniz.");
            }
            else
            {
                                if (label2.Text.ToString().Trim() == "MAT102")
                                {
                                            baglantı.Open();
                                            SqlCommand oku = new SqlCommand("select *from ortakvize where Numara='" + textBox1.Text + "'", baglantı);
                                            SqlDataAdapter da = new SqlDataAdapter(oku);
                                            SqlDataReader dr = oku.ExecuteReader();
                                            while (dr.Read())
                                            {
                                                labelvizetut.Text = dr["MAT102"].ToString();
                                            }
                                            dr.Close();

                                            SqlCommand oku2 = new SqlCommand("select *from ortakfinal where Numara='" + textBox1.Text + "'", baglantı);
                                            SqlDataAdapter da2 = new SqlDataAdapter(oku2);
                                            SqlDataReader dr2 = oku2.ExecuteReader();
                                            while (dr2.Read())
                                            {
                                                labelfinaltut.Text = dr2["MAT102"].ToString();
                                            }
                                            dr2.Close();
                                            baglantı.Close();
                                            if (labelvizetut.Text.ToString().Trim() == "" || labelfinaltut.Text.ToString().Trim() == "")
                                            {
                                                MessageBox.Show("Lütfen vize final degerlerini girdikten sonra goruntuleme işlemi yapınız.");
                                            }
                                            else if (sorgulaortakvize() == 0 || sorgulaortakfinal() == 0)
                                            {
                                                MessageBox.Show("Ogrenciye ait vize veya final girişlerinden bir tanesi yapılmadı.");
                                            }

                                            else
                                            {
                                                baglantı.Open();

                                                SqlCommand oku3 = new SqlCommand("select *from ortakvize where Numara='" + textBox1.Text + "'", baglantı);
                                                SqlDataAdapter da3 = new SqlDataAdapter(oku);
                                                SqlDataReader dr3 = oku3.ExecuteReader();
                                                while (dr3.Read())
                                                {
                                                    textBox2.Text = dr3["MAT102"].ToString();
                                                }
                                                dr3.Close();
                                                SqlCommand oku4 = new SqlCommand("select *from ortakfinal where Numara='" + textBox1.Text + "'", baglantı);
                                                SqlDataAdapter da4 = new SqlDataAdapter(oku2);
                                                SqlDataReader dr4 = oku4.ExecuteReader();
                                                while (dr4.Read())
                                                {
                                                    textBox3.Text = dr4["MAT102"].ToString();
                                                }
                                                dr3.Close();
                                                dr4.Close();


                                                  MessageBox.Show("Goruntuleme basarili.");
                                                baglantı.Close();

                                            }
                                }
                                else if (label2.Text.ToString().Trim() == "FİZİK102")
                                {
                                            baglantı.Open();
                                            SqlCommand oku = new SqlCommand("select *from ortakvize where Numara='" + textBox1.Text + "'", baglantı);
                                            SqlDataAdapter da = new SqlDataAdapter(oku);
                                            SqlDataReader dr = oku.ExecuteReader();
                                            while (dr.Read())
                                            {
                                                labelvizetut.Text = dr["FİZİK102"].ToString();
                                            }
                                            dr.Close();//KAPATMAYI UNTUMA.

                                            SqlCommand oku2 = new SqlCommand("select *from ortakfinal where Numara='" + textBox1.Text + "'", baglantı);
                                            SqlDataAdapter da2 = new SqlDataAdapter(oku2);
                                            SqlDataReader dr2 = oku2.ExecuteReader();
                                            while (dr2.Read())
                                            {
                                                labelfinaltut.Text = dr2["FİZİK102"].ToString();
                                            }
                                            dr2.Close();//KAPATMAYI UNUTMA
                                            baglantı.Close();
                                            if (labelvizetut.Text.ToString().Trim() == "" || labelfinaltut.Text.ToString().Trim() == "")
                                            {
                                                MessageBox.Show("Lütfen vize final degerlerini girdikten sonra goruntuleme işlemi yapınız.");
                                            }
                                            else if (sorgulaortakvize() == 0 || sorgulaortakfinal() == 0)
                                            {
                                                MessageBox.Show("Ogrenciye ait vize veya final girişlerinden bir tanesi yapılmadı.");
                                            }

                                            else
                                            {
                                                baglantı.Open();

                                                SqlCommand oku3 = new SqlCommand("select *from ortakvize where Numara='" + textBox1.Text + "'", baglantı);
                                                SqlDataAdapter da3 = new SqlDataAdapter(oku);
                                                SqlDataReader dr3 = oku3.ExecuteReader();
                                                while (dr3.Read())
                                                {
                                                    textBox2.Text = dr3["FİZİK102"].ToString();
                                                }
                                                dr3.Close();
                                                SqlCommand oku4 = new SqlCommand("select *from ortakfinal where Numara='" + textBox1.Text + "'", baglantı);
                                                SqlDataAdapter da4 = new SqlDataAdapter(oku2);
                                                SqlDataReader dr4 = oku4.ExecuteReader();
                                                while (dr4.Read())
                                                {
                                                    textBox3.Text = dr4["FİZİK102"].ToString();
                                                }
                                                dr3.Close();
                                                dr4.Close();


                                                MessageBox.Show("Goruntuleme basarili.");
                                                baglantı.Close();

                                            }
                                }
                                else if (label2.Text.ToString().Trim() == "İNG102")
                                {
                                            baglantı.Open();
                                            SqlCommand oku = new SqlCommand("select *from ortakvize where Numara='" + textBox1.Text + "'", baglantı);
                                            SqlDataAdapter da = new SqlDataAdapter(oku);
                                            SqlDataReader dr = oku.ExecuteReader();
                                            while (dr.Read())
                                            {
                                                labelvizetut.Text = dr["İNG102"].ToString();
                                            }
                                            dr.Close();//KAPATMAYI UNTUMA.

                                            SqlCommand oku2 = new SqlCommand("select *from ortakfinal where Numara='" + textBox1.Text + "'", baglantı);
                                            SqlDataAdapter da2 = new SqlDataAdapter(oku2);
                                            SqlDataReader dr2 = oku2.ExecuteReader();
                                            while (dr2.Read())
                                            {
                                                labelfinaltut.Text = dr2["İNG102"].ToString();
                                            }
                                            dr2.Close();//KAPATMAYI UNUTMA
                                            baglantı.Close();
                                            if (labelvizetut.Text.ToString().Trim() == "" || labelfinaltut.Text.ToString().Trim() == "")
                                            {
                                                MessageBox.Show("Lütfen vize final degerlerini girdikten sonra goruntuleme işlemi yapınız.");
                                            }
                                            else if (sorgulaortakvize() == 0 || sorgulaortakfinal() == 0)
                                            {
                                                MessageBox.Show("Ogrenciye ait vize veya final girişlerinden bir tanesi yapılmadı.");
                                            }

                                            else
                                            {
                                                baglantı.Open();

                                                SqlCommand oku3 = new SqlCommand("select *from ortakvize where Numara='" + textBox1.Text + "'", baglantı);
                                                SqlDataAdapter da3 = new SqlDataAdapter(oku);
                                                SqlDataReader dr3 = oku3.ExecuteReader();
                                                while (dr3.Read())
                                                {
                                                    textBox2.Text = dr3["İNG102"].ToString();
                                                }
                                                dr3.Close();
                                                SqlCommand oku4 = new SqlCommand("select *from ortakfinal where Numara='" + textBox1.Text + "'", baglantı);
                                                SqlDataAdapter da4 = new SqlDataAdapter(oku2);
                                                SqlDataReader dr4 = oku4.ExecuteReader();
                                                while (dr4.Read())
                                                {
                                                    textBox3.Text = dr4["İNG102"].ToString();
                                                }
                                                dr3.Close();
                                                dr4.Close();


                                                MessageBox.Show("Goruntuleme basarili.");
                                                baglantı.Close();

                                            }
                                }
                                else if (label2.Text.ToString().Trim() == "BM102")
                                {
                                    baglantı.Open();
                                    SqlCommand oku = new SqlCommand("select *from vizebm where Numara='" + textBox1.Text + "'", baglantı);
                                    SqlDataAdapter da = new SqlDataAdapter(oku);
                                    SqlDataReader dr = oku.ExecuteReader();
                                    while (dr.Read())
                                    {
                                        labelvizetut.Text = dr["BM102"].ToString();
                                    }
                                    dr.Close();//KAPATMAYI UNTUMA.

                                    SqlCommand oku2 = new SqlCommand("select *from finalbm where Numara='" + textBox1.Text + "'", baglantı);
                                    SqlDataAdapter da2 = new SqlDataAdapter(oku2);
                                    SqlDataReader dr2 = oku2.ExecuteReader();
                                    while (dr2.Read())
                                    {
                                        labelfinaltut.Text = dr2["BM102"].ToString();
                                    }
                                    dr2.Close();//KAPATMAYI UNUTMA
                                    baglantı.Close();
                                    if (labelvizetut.Text.ToString().Trim() == "" || labelfinaltut.Text.ToString().Trim() == "")
                                    {
                                        MessageBox.Show("Lütfen vize final degerlerini girdikten sonra goruntuleme işlemi yapınız.");
                                    }
                                    else if (sorgulavizebm() == 0 || sorgulafinalbm() == 0)
                                    {
                                        MessageBox.Show("Ogrenciye ait vize veya final girişlerinden bir tanesi yapılmadı.");
                                    }

                                    else
                                    {
                                        baglantı.Open();

                                        SqlCommand oku3 = new SqlCommand("select *from vizebm where Numara='" + textBox1.Text + "'", baglantı);
                                        SqlDataAdapter da3 = new SqlDataAdapter(oku);
                                        SqlDataReader dr3 = oku3.ExecuteReader();
                                        while (dr3.Read())
                                        {
                                            textBox2.Text = dr3["BM102"].ToString();
                                        }
                                        dr3.Close();
                                        SqlCommand oku4 = new SqlCommand("select *from finalbm where Numara='" + textBox1.Text + "'", baglantı);
                                        SqlDataAdapter da4 = new SqlDataAdapter(oku2);
                                        SqlDataReader dr4 = oku4.ExecuteReader();
                                        while (dr4.Read())
                                        {
                                            textBox3.Text = dr4["BM102"].ToString();
                                        }
                                        dr3.Close();
                                        dr4.Close();


                                        MessageBox.Show("Goruntuleme basarili.");
                                        baglantı.Close();

                                    }
                                }
                                else if (label2.Text.ToString().Trim() == "BM103")
                                {
                                    baglantı.Open();
                                    SqlCommand oku = new SqlCommand("select *from vizebm where Numara='" + textBox1.Text + "'", baglantı);
                                    SqlDataAdapter da = new SqlDataAdapter(oku);
                                    SqlDataReader dr = oku.ExecuteReader();
                                    while (dr.Read())
                                    {
                                        labelvizetut.Text = dr["BM103"].ToString();
                                    }
                                    dr.Close();//KAPATMAYI UNTUMA.

                                    SqlCommand oku2 = new SqlCommand("select *from finalbm where Numara='" + textBox1.Text + "'", baglantı);
                                    SqlDataAdapter da2 = new SqlDataAdapter(oku2);
                                    SqlDataReader dr2 = oku2.ExecuteReader();
                                    while (dr2.Read())
                                    {
                                        labelfinaltut.Text = dr2["BM103"].ToString();
                                    }
                                    dr2.Close();//KAPATMAYI UNUTMA
                                    baglantı.Close();
                                    if (labelvizetut.Text.ToString().Trim() == "" || labelfinaltut.Text.ToString().Trim() == "")
                                    {
                                        MessageBox.Show("Lütfen vize final degerlerini girdikten sonra goruntuleme işlemi yapınız.");
                                    }
                                     else if (sorgulavizebm() == 0 || sorgulafinalbm() == 0)
                                    {
                                        MessageBox.Show("Ogrenciye ait vize veya final girişlerinden bir tanesi yapılmadı.");
                                    }

                                    else
                                    {
                                        baglantı.Open();

                                        SqlCommand oku3 = new SqlCommand("select *from vizebm where Numara='" + textBox1.Text + "'", baglantı);
                                        SqlDataAdapter da3 = new SqlDataAdapter(oku);
                                        SqlDataReader dr3 = oku3.ExecuteReader();
                                        while (dr3.Read())
                                        {
                                            textBox2.Text = dr3["BM103"].ToString();
                                        }
                                        dr3.Close();
                                        SqlCommand oku4 = new SqlCommand("select *from finalbm where Numara='" + textBox1.Text + "'", baglantı);
                                        SqlDataAdapter da4 = new SqlDataAdapter(oku2);
                                        SqlDataReader dr4 = oku4.ExecuteReader();
                                        while (dr4.Read())
                                        {
                                            textBox3.Text = dr4["BM103"].ToString();
                                        }
                                        dr3.Close();
                                        dr4.Close();


                                        MessageBox.Show("Goruntuleme basarili.");
                                         baglantı.Close();

                                    }
                                }
                                else if (label2.Text.ToString().Trim() == "EM103")
                                {
                                    baglantı.Open();
                                    SqlCommand oku = new SqlCommand("select *from vizeem where Numara='" + textBox1.Text + "'", baglantı);
                                    SqlDataAdapter da = new SqlDataAdapter(oku);
                                    SqlDataReader dr = oku.ExecuteReader();
                                    while (dr.Read())
                                    {
                                        labelvizetut.Text = dr["EM103"].ToString();
                                    }
                                    dr.Close();//KAPATMAYI UNTUMA.

                                    SqlCommand oku2 = new SqlCommand("select *from finalem where Numara='" + textBox1.Text + "'", baglantı);
                                    SqlDataAdapter da2 = new SqlDataAdapter(oku2);
                                    SqlDataReader dr2 = oku2.ExecuteReader();
                                    while (dr2.Read())
                                    {
                                        labelfinaltut.Text = dr2["EM103"].ToString();
                                    }
                                    dr2.Close();//KAPATMAYI UNUTMA
                                    baglantı.Close();
                                    if (labelvizetut.Text.ToString().Trim() == "" || labelfinaltut.Text.ToString().Trim() == "")
                                    {
                                        MessageBox.Show("Lütfen vize final degerlerini girdikten sonra goruntuleme işlemi yapınız.");
                                    }
                                    else if (sorgulavizeem() == 0 || sorgulafinalem() == 0)
                                    {
                                        MessageBox.Show("Ogrenciye ait vize veya final girişlerinden bir tanesi yapılmadı.");
                                    }

                                    else
                                    {
                                        baglantı.Open();

                                        SqlCommand oku3 = new SqlCommand("select *from vizeem where Numara='" + textBox1.Text + "'", baglantı);
                                        SqlDataAdapter da3 = new SqlDataAdapter(oku);
                                        SqlDataReader dr3 = oku3.ExecuteReader();
                                        while (dr3.Read())
                                        {
                                            textBox2.Text = dr3["EM103"].ToString();
                                        }
                                        dr3.Close();
                                        SqlCommand oku4 = new SqlCommand("select *from finalem where Numara='" + textBox1.Text + "'", baglantı);
                                        SqlDataAdapter da4 = new SqlDataAdapter(oku2);
                                        SqlDataReader dr4 = oku4.ExecuteReader();
                                        while (dr4.Read())
                                        {
                                            textBox3.Text = dr4["EM103"].ToString();
                                        }
                                        dr3.Close();
                                        dr4.Close();


                                        MessageBox.Show("Goruntuleme basarili.");
                                        baglantı.Close();

                                    }
                                }
                                else if (label2.Text.ToString().Trim() == "EM102")
                                {
                                    baglantı.Open();
                                    SqlCommand oku = new SqlCommand("select *from vizeem where Numara='" + textBox1.Text + "'", baglantı);
                                    SqlDataAdapter da = new SqlDataAdapter(oku);
                                    SqlDataReader dr = oku.ExecuteReader();
                                    while (dr.Read())
                                    {
                                        labelvizetut.Text = dr["EM102"].ToString();
                                    }
                                    dr.Close();//KAPATMAYI UNTUMA.

                                    SqlCommand oku2 = new SqlCommand("select *from finalem where Numara='" + textBox1.Text + "'", baglantı);
                                    SqlDataAdapter da2 = new SqlDataAdapter(oku2);
                                    SqlDataReader dr2 = oku2.ExecuteReader();
                                    while (dr2.Read())
                                    {
                                        labelfinaltut.Text = dr2["EM102"].ToString();
                                    }
                                    dr2.Close();//KAPATMAYI UNUTMA
                                    baglantı.Close();
                                    if (labelvizetut.Text.ToString().Trim() == "" || labelfinaltut.Text.ToString().Trim() == "")
                                    {
                                        MessageBox.Show("Lütfen vize final degerlerini girdikten sonra goruntuleme işlemi yapınız.");
                                    }
                                    else if (sorgulavizeem() == 0 || sorgulafinalem() == 0)
                                    {
                                        MessageBox.Show("Ogrenciye ait vize veya final girişlerinden bir tanesi yapılmadı.");
                                    }

                                    else
                                    {
                                        baglantı.Open();

                                        SqlCommand oku3 = new SqlCommand("select *from vizeem where Numara='" + textBox1.Text + "'", baglantı);
                                        SqlDataAdapter da3 = new SqlDataAdapter(oku);
                                        SqlDataReader dr3 = oku3.ExecuteReader();
                                        while (dr3.Read())
                                        {
                                            textBox2.Text = dr3["EM102"].ToString();
                                        }
                                        dr3.Close();
                                        SqlCommand oku4 = new SqlCommand("select *from finalem where Numara='" + textBox1.Text + "'", baglantı);
                                        SqlDataAdapter da4 = new SqlDataAdapter(oku2);
                                        SqlDataReader dr4 = oku4.ExecuteReader();
                                        while (dr4.Read())
                                        {
                                            textBox3.Text = dr4["EM102"].ToString();
                                        }
                                        dr3.Close();
                                        dr4.Close();


                                        MessageBox.Show("Goruntuleme basarili.");
                                        baglantı.Close();

                                    }
                                }
                                else if (label2.Text.ToString().Trim() == "KM102")
                                {
                                    baglantı.Open();
                                    SqlCommand oku = new SqlCommand("select *from vizekm where Numara='" + textBox1.Text + "'", baglantı);
                                    SqlDataAdapter da = new SqlDataAdapter(oku);
                                    SqlDataReader dr = oku.ExecuteReader();
                                    while (dr.Read())
                                    {
                                        labelvizetut.Text = dr["KM102"].ToString();
                                    }
                                    dr.Close();//KAPATMAYI UNTUMA.

                                    SqlCommand oku2 = new SqlCommand("select *from finalkm where Numara='" + textBox1.Text + "'", baglantı);
                                    SqlDataAdapter da2 = new SqlDataAdapter(oku2);
                                    SqlDataReader dr2 = oku2.ExecuteReader();
                                    while (dr2.Read())
                                    {
                                        labelfinaltut.Text = dr2["KM102"].ToString();
                                    }
                                    dr2.Close();//KAPATMAYI UNUTMA
                                    baglantı.Close();
                                    if (labelvizetut.Text.ToString().Trim() == "" || labelfinaltut.Text.ToString().Trim() == "")
                                    {
                                        MessageBox.Show("Lütfen vize final degerlerini girdikten sonra goruntuleme işlemi yapınız.");
                                    }
                                    else if (sorgulavizekm() == 0 || sorgulafinalkm() == 0)
                                    {
                                        MessageBox.Show("Ogrenciye ait vize veya final girişlerinden bir tanesi yapılmadı.");
                                    }

                                    else
                                    {
                                        baglantı.Open();

                                        SqlCommand oku3 = new SqlCommand("select *from vizekm where Numara='" + textBox1.Text + "'", baglantı);
                                        SqlDataAdapter da3 = new SqlDataAdapter(oku);
                                        SqlDataReader dr3 = oku3.ExecuteReader();
                                        while (dr3.Read())
                                        {
                                            textBox2.Text = dr3["KM102"].ToString();
                                        }
                                        dr3.Close();
                                        SqlCommand oku4 = new SqlCommand("select *from finalkm where Numara='" + textBox1.Text + "'", baglantı);
                                        SqlDataAdapter da4 = new SqlDataAdapter(oku2);
                                        SqlDataReader dr4 = oku4.ExecuteReader();
                                        while (dr4.Read())
                                        {
                                            textBox3.Text = dr4["KM102"].ToString();
                                        }
                                        dr3.Close();
                                        dr4.Close();


                                        MessageBox.Show("Goruntuleme basarili.");
                                        baglantı.Close();

                                    }
                                }
                                else if (label2.Text.ToString().Trim() == "KM103")
                                {
                                    baglantı.Open();
                                    SqlCommand oku = new SqlCommand("select *from vizekm where Numara='" + textBox1.Text + "'", baglantı);
                                    SqlDataAdapter da = new SqlDataAdapter(oku);
                                    SqlDataReader dr = oku.ExecuteReader();
                                    while (dr.Read())
                                    {
                                        labelvizetut.Text = dr["KM103"].ToString();
                                    }
                                    dr.Close();//KAPATMAYI UNTUMA.

                                    SqlCommand oku2 = new SqlCommand("select *from finalkm where Numara='" + textBox1.Text + "'", baglantı);
                                    SqlDataAdapter da2 = new SqlDataAdapter(oku2);
                                    SqlDataReader dr2 = oku2.ExecuteReader();
                                    while (dr2.Read())
                                    {
                                        labelfinaltut.Text = dr2["KM103"].ToString();
                                    }
                                    dr2.Close();//KAPATMAYI UNUTMA
                                    baglantı.Close();
                                    if (labelvizetut.Text.ToString().Trim() == "" || labelfinaltut.Text.ToString().Trim() == "")
                                    {
                                        MessageBox.Show("Lütfen vize final degerlerini girdikten sonra goruntuleme işlemi yapınız.");
                                    }
                                     else if (sorgulavizekm() == 0 || sorgulafinalkm() == 0)
                                    {
                                        MessageBox.Show("Ogrenciye ait vize veya final girişlerinden bir tanesi yapılmadı.");
                                    }

                                    else
                                    {
                                        baglantı.Open();

                                        SqlCommand oku3 = new SqlCommand("select *from vizekm where Numara='" + textBox1.Text + "'", baglantı);
                                        SqlDataAdapter da3 = new SqlDataAdapter(oku);
                                        SqlDataReader dr3 = oku3.ExecuteReader();
                                        while (dr3.Read())
                                        {
                                            textBox2.Text = dr3["KM103"].ToString();
                                        }
                                        dr3.Close();
                                        SqlCommand oku4 = new SqlCommand("select *from finalkm where Numara='" + textBox1.Text + "'", baglantı);
                                        SqlDataAdapter da4 = new SqlDataAdapter(oku2);
                                        SqlDataReader dr4 = oku4.ExecuteReader();
                                        while (dr4.Read())
                                        {
                                            textBox3.Text = dr4["KM103"].ToString();
                                        }
                                        dr3.Close();
                                        dr4.Close();


                                        MessageBox.Show("Goruntuleme basarili.");
                                        baglantı.Close();

                                    }
                                }
            }
          
        }
        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            labeltrh.Text = DateTime.Now.ToShortDateString()+"-"+DateTime.Now.ToLongTimeString();
            /*  label5.Text = label5.Text.Substring(1) + label5.Text.Substring(0, 1);
            label5.ForeColor = Color.Black;
            label5.Font = new Font("Candara", 24, FontStyle.Regular);
            label5.Font = new Font("Minion Pro", 24, FontStyle.Regular);
            label5.ForeColor = Color.White;*/

            label26.Text = label26.Text.Substring(1) + label26.Text.Substring(0, 1);
            
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
    }
}
