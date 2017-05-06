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
    public partial class yoneticinotislemleri : Form
    {
        public yoneticinotislemleri()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=KURSATCAKAL\\SQL_2014;Initial Catalog=sistem;Integrated Security=True");
        public int ogrsorgula()
        {
            using (SqlConnection baglantı = new SqlConnection("Data Source=KURSATCAKAL\\SQL_2014;Initial Catalog=sistem;Integrated Security=True"))
            {
                int say;
                SqlCommand komut = new SqlCommand("select COUNT(*)from ogrencibilgi where Numara=@no",baglantı);
                komut.Parameters.AddWithValue("@no", textBoxno.Text);
                baglantı.Open();
                say = Convert.ToInt32(komut.ExecuteScalar());
                baglantı.Close();
                return say;
            }
        }
        public int genelsorgu(string degisken)
        {
            using (SqlConnection baglantı = new SqlConnection("Data Source=KURSATCAKAL\\SQL_2014;Initial Catalog=sistem;Integrated Security=True"))
            {
                int saybaba;
                SqlCommand komutbaba = new SqlCommand(degisken, baglantı);
                komutbaba.Parameters.AddWithValue("@noo", textBoxno.Text);
                baglantı.Open();
                saybaba = Convert.ToInt32(komutbaba.ExecuteScalar());
                baglantı.Close();
                return saybaba;
            }
        }

        private void buttonsrgu_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglantı.State == ConnectionState.Closed)
                    baglantı.Open();
                if (ogrsorgula()==1)
                {
                    //OGRENCİ BİLGİLERİNİ AKTARMA
                    SqlCommand komut = new SqlCommand("Select *from ogrencibilgi where Numara=@no",baglantı);
                    komut.Parameters.AddWithValue("@no", textBoxno.Text.ToString().Trim());
                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    SqlDataReader dr = komut.ExecuteReader();
                    while(dr.Read())
                    {
                    
                        labelisim.Text = dr["Ad"].ToString() + dr["Soyad"].ToString();
                        labelblm.Text = dr["Bolum"].ToString();
                    }
                    dr.Close();
                    baglantı.Close();
                    //MessageBox.Show("Sorgu Basarili.");
                    //OGRENCİ ORTAK VİZE AKTARMA
                    baglantı.Open();
                    SqlCommand kov = new SqlCommand("select *from ortakvize where Numara=@no", baglantı);
                    //kov.Parameters.AddWithValue("@no", baglantı);"BURAYA BAGLANTI YAZMIŞSIN NE HATA
                    kov.Parameters.AddWithValue("@no", textBoxno.Text);
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
                    kof.Parameters.AddWithValue("@no", textBoxno.Text);
                    SqlDataAdapter da3 = new SqlDataAdapter(kof);
                    SqlDataReader dr3 = kof.ExecuteReader();
                    while(dr3.Read())
                    {
                        matfinal.Text = dr3["MAT102"].ToString();
                        ingfinal.Text = dr3["İNG102"].ToString();
                        fizfinal.Text = dr3["FİZİK102"].ToString();
                        tcfinal.Text = dr3["TCİnkilap"].ToString();

                    }
                    dr3.Close();
                    baglantı.Close();
                    //BM VİZE-FİNAL AKTARMA
                    if(labelblm.Text.ToString().Trim()=="Bilgisayar Muhendisligi")
                    {
                        labelDERS5.Text = "BM102";
                        labelDERS6.Text = "BM103";
                        //DERS5
                        baglantı.Open();
                        SqlCommand bov = new SqlCommand("select *from vizebm where Numara=@no", baglantı);
                        bov.Parameters.AddWithValue("@no", textBoxno.Text);
                        SqlDataAdapter da4 = new SqlDataAdapter(bov);
                        SqlDataReader dr4 = bov.ExecuteReader();
                        while(dr4.Read())
                        {
                            ders5vize.Text = dr4["BM102"].ToString();
                            ders6vize.Text = dr4["BM103"].ToString();
                        }
                        dr4.Close();
                        baglantı.Close();
                        //DERS6
                        baglantı.Open();
                        SqlCommand bof = new SqlCommand("select *from finalbm where Numara=@no", baglantı);
                        bof.Parameters.AddWithValue("@no", textBoxno.Text);
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
                        labelDERS5.Text = "EM102";
                        labelDERS6.Text = "EM103";
                        //DERS5
                        baglantı.Open();
                        SqlCommand bov = new SqlCommand("select *from vizeem where Numara=@no", baglantı);
                        bov.Parameters.AddWithValue("@no", textBoxno.Text);
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
                        bof.Parameters.AddWithValue("@no", textBoxno.Text);
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
                        labelDERS5.Text = "KM102";
                        labelDERS6.Text = "KM103";
                        //DERS5
                        baglantı.Open();
                        SqlCommand bov = new SqlCommand("select *from vizekm where Numara=@no", baglantı);
                        bov.Parameters.AddWithValue("@no", textBoxno.Text);
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
                        bof.Parameters.AddWithValue("@no", textBoxno.Text);
                        SqlDataAdapter da5 = new SqlDataAdapter(bof);
                        SqlDataReader dr5 = bof.ExecuteReader();
                        while (dr5.Read())
                        {
                            ders5final.Text = dr5["KM102"].ToString();
                            ders6final.Text = dr5["KM103"].ToString();
                        }
                        dr5.Close();
                        baglantı.Close();

                    }


                }
                else
                {
                    labelisim.Text = "";
                    labelblm.Text = "";
                    matfinal.Clear();
                    matvize.Clear();
                    fizfinal.Clear();
                    fizvize.Clear();
                    ingfinal.Clear();
                    ingvize.Clear();
                    tcfinal.Clear();
                    tcvize.Clear();
                    ders5final.Clear();
                    ders5vize.Clear();
                    ders6final.Clear();
                    ders6vize.Clear();


                    MessageBox.Show("OGRENCİ KAYDI BULUNAMADI.");
                }

            }
            catch (Exception hata)
            {

                MessageBox.Show("Hata olustu." + hata.Message);
            }
           
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            yoneticiform yeni = new yoneticiform();
            yeni.Show();
            this.Hide();
        }

        private void yoneticinotislemleri_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(labelblm.Text.ToString().Trim()!=""&&labelisim.Text.ToString().Trim()!="")
            {
                if (matvize.Text != "" && ingvize.Text != "" && fizvize.Text != "" && tcvize.Text != "" && matfinal.Text != "" && ingfinal.Text != "" && fizfinal.Text != "" && tcfinal.Text != "" && ders5vize.Text != "" && ders5final.Text != "" && ders6final.Text != "" && ders6vize.Text != "")
                {
                    o1.Text = Convert.ToString(Convert.ToInt32(matvize.Text.ToString()) * 0.6 + Convert.ToInt32(matfinal.Text.ToString()) * 0.4);
                    o2.Text = Convert.ToString(Convert.ToInt32(fizvize.Text.ToString()) * 0.6 + Convert.ToInt32(fizfinal.Text.ToString()) * 0.4);
                    o3.Text = Convert.ToString(Convert.ToInt32(ingvize.Text.ToString()) * 0.6 + Convert.ToInt32(ingfinal.Text.ToString()) * 0.4);
                    o4.Text = Convert.ToString(Convert.ToInt32(tcvize.Text.ToString()) * 0.2 + Convert.ToInt32(tcfinal.Text.ToString()) * 0.8);
                    o5.Text = Convert.ToString(Convert.ToInt32(ders5vize.Text.ToString()) * 0.6 + Convert.ToInt32(ders5final.Text.ToString()) * 0.4);
                    o6.Text = Convert.ToString(Convert.ToInt32(ders6vize.Text.ToString()) * 0.6 + Convert.ToInt32(ders6final.Text.ToString()) * 0.4);
                    MessageBox.Show("Ortalamalar Hazır.");
                }
                else
                {
                    MessageBox.Show("Lütfen Ogrenci İçin Girilmeyen Notları Giriniz..");
                }
            }
            else
            {
                MessageBox.Show("Lutfen bir sahıs giriniz!!!");
            }
           
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if(textBoxno.Text!="")
            {
               
                if (labelblm.Text.ToString().Trim() == "Bilgisayar Muhendisligi")
                {
                    if (genelsorgu("select COUNT(*)from ortakvize where Numara=@noo") == 0)
                    {
                        baglantı.Open();
                        SqlCommand c1 = new SqlCommand("insert into ortakvize(Numara,MAT102,FİZİK102,İNG102,TCİnkilap)values(@n,@m,@f,@i,@tc)", baglantı);
                        c1.Parameters.AddWithValue("@n", textBoxno.Text);
                        c1.Parameters.AddWithValue("@m", matvize.Text);
                        c1.Parameters.AddWithValue("@f", fizvize.Text);
                        c1.Parameters.AddWithValue("@i", ingvize.Text);
                        c1.Parameters.AddWithValue("@tc", tcvize.Text);
                        c1.ExecuteNonQuery();
                        baglantı.Close();
                    }
                    else
                    {
                        baglantı.Open();
                        SqlCommand command = new SqlCommand("update ortakvize set MAT102=@mat,FİZİK102=@fiz,İNG102=@ing,TCİnkilap=@tc where Numara='" + textBoxno.Text + "'", baglantı);
                        command.Parameters.AddWithValue("@mat", matvize.Text);
                        command.Parameters.AddWithValue("@fiz", fizvize.Text);
                        command.Parameters.AddWithValue("@ing", ingvize.Text);
                        command.Parameters.AddWithValue("@tc", tcvize.Text);
                        command.ExecuteNonQuery();
                        baglantı.Close();
                    }
                    if(genelsorgu("select COUNT(*)from ortakfinal where Numara=@noo") ==0)
                    {
                        baglantı.Open();
                        SqlCommand c2 = new SqlCommand("insert into ortakfinal(Numara,MAT102,FİZİK102,İNG102,TCİnkilap)values(@n,@m,@f,@i,@tc)", baglantı);
                        c2.Parameters.AddWithValue("@n", textBoxno.Text);
                        c2.Parameters.AddWithValue("@m", matfinal.Text);
                        c2.Parameters.AddWithValue("@f", fizfinal.Text);
                        c2.Parameters.AddWithValue("@i", ingfinal.Text);
                        c2.Parameters.AddWithValue("@tc", tcfinal.Text);
                        c2.ExecuteNonQuery();
                        baglantı.Close();
                    }
                    else
                    {
                        baglantı.Open();
                        SqlCommand command2 = new SqlCommand("update ortakfinal set MAT102=@mat,FİZİK102=@fiz,İNG102=@ing,TCİnkilap=@tc  where Numara='" + textBoxno.Text + "'", baglantı);
                        command2.Parameters.AddWithValue("@mat", matfinal.Text);
                        command2.Parameters.AddWithValue("@fiz", fizfinal.Text);
                        command2.Parameters.AddWithValue("@ing", ingfinal.Text);
                        command2.Parameters.AddWithValue("@tc", tcfinal.Text);
                        command2.ExecuteNonQuery();
                        baglantı.Close();
                    }
                    if(genelsorgu("select COUNT(*)from vizebm where Numara=@noo") ==0)
                    {
                        baglantı.Open();
                        SqlCommand c3 = new SqlCommand("insert into vizebm(Numara,BM102,BM103)values(@no,@d5,@d6)",baglantı);
                        c3.Parameters.AddWithValue("@no", textBoxno.Text);
                        c3.Parameters.AddWithValue("@d5", ders5vize.Text);
                        c3.Parameters.AddWithValue("@d6", ders6vize.Text);
                        c3.ExecuteNonQuery();
                        baglantı.Close();
                    }
                    else
                    {
                        baglantı.Open();
                        SqlCommand command3 = new SqlCommand("update vizebm set BM102=@bm102,BM103=@bm103  where Numara='" + textBoxno.Text + "'", baglantı);
                        command3.Parameters.AddWithValue("@bm102", ders5vize.Text);
                        command3.Parameters.AddWithValue("@bm103", ders6vize.Text);
                        command3.ExecuteNonQuery();
                        baglantı.Close();
                       
                    }
                    if(genelsorgu("select COUNT(*)from finalbm where Numara=@noo") ==0)
                    {
                        baglantı.Open();
                        SqlCommand c4 = new SqlCommand("insert into finalbm(Numara,BM102,BM103)values(@no,@d5,@d6)",baglantı);
                        c4.Parameters.AddWithValue("@no", textBoxno.Text);
                        c4.Parameters.AddWithValue("@d5", ders5final.Text);
                        c4.Parameters.AddWithValue("@d6",ders6final.Text);
                        c4.ExecuteNonQuery();
                        baglantı.Close();
                    }
                    else
                    {
                        baglantı.Open();
                        SqlCommand command4 = new SqlCommand("update finalbm set BM102=@bm102,BM103=@bm103  where Numara='" + textBoxno.Text + "'", baglantı);
                        command4.Parameters.AddWithValue("@bm102", ders5final.Text);
                        command4.Parameters.AddWithValue("@bm103", ders6final.Text);
                        command4.ExecuteNonQuery();
                        baglantı.Close();
                    }
                    
                }
                if (labelblm.Text.ToString().Trim() == "Endustri Muhendisligi")
                {
                    if(genelsorgu("select COUNT(*)from ortakvize where Numara=@noo")==0)
                    {
                        baglantı.Open();
                        SqlCommand c1 = new SqlCommand("insert into ortakvize(Numara,MAT102,FİZİK102,İNG102,TCİnkilap)values(@n,@m,@f,@i,@tc)", baglantı);
                        c1.Parameters.AddWithValue("@n", textBoxno.Text);
                        c1.Parameters.AddWithValue("@m", matvize.Text);
                        c1.Parameters.AddWithValue("@f", fizvize.Text);
                        c1.Parameters.AddWithValue("@i", ingvize.Text);
                        c1.Parameters.AddWithValue("@tc", tcvize.Text);
                        c1.ExecuteNonQuery();
                        baglantı.Close();
                    }
                    else
                    {
                        baglantı.Open();
                        SqlCommand command = new SqlCommand("update ortakvize set MAT102=@mat,FİZİK102=@fiz,İNG102=@ing,TCİnkilap=@tc  where Numara='" + textBoxno.Text + "'", baglantı);
                        command.Parameters.AddWithValue("@mat", matvize.Text);
                        command.Parameters.AddWithValue("@fiz", fizvize.Text);
                        command.Parameters.AddWithValue("@ing", ingvize.Text);
                        command.Parameters.AddWithValue("@tc", tcvize.Text);
                        command.ExecuteNonQuery();
                        baglantı.Close();
                    }
                    if (genelsorgu("select COUNT(*)from ortakfinal where Numara=@noo") == 0)
                    {
                        baglantı.Open();
                        SqlCommand c2 = new SqlCommand("insert into ortakfinal(Numara,MAT102,FİZİK102,İNG102,TCİnkilap)values(@n,@m,@f,@i,@tc)", baglantı);
                        c2.Parameters.AddWithValue("@n", textBoxno.Text);
                        c2.Parameters.AddWithValue("@m", matfinal.Text);
                        c2.Parameters.AddWithValue("@f", fizfinal.Text);
                        c2.Parameters.AddWithValue("@i", ingfinal.Text);
                        c2.Parameters.AddWithValue("@tc", tcfinal.Text);
                        c2.ExecuteNonQuery();
                        baglantı.Close();
                    }
                    else
                    {
                        baglantı.Open();
                        SqlCommand command2 = new SqlCommand("update ortakfinal set MAT102=@mat,FİZİK102=@fiz,İNG102=@ing,TCİnkilap=@tc  where Numara='" + textBoxno.Text + "'", baglantı);
                        command2.Parameters.AddWithValue("@mat", matfinal.Text);
                        command2.Parameters.AddWithValue("@fiz", fizfinal.Text);
                        command2.Parameters.AddWithValue("@ing", ingfinal.Text);
                        command2.Parameters.AddWithValue("@tc", tcfinal.Text);
                        command2.ExecuteNonQuery();
                        baglantı.Close();
                    }
                    if (genelsorgu("select COUNT(*)from vizeem where Numara=@noo") == 0)
                    {
                        baglantı.Open();
                        SqlCommand c3 = new SqlCommand("insert into vizeem(Numara,EM102,EM103)values(@no,@d5,@d6)", baglantı);
                        c3.Parameters.AddWithValue("@no", textBoxno.Text);
                        c3.Parameters.AddWithValue("@d5", ders5vize.Text);
                        c3.Parameters.AddWithValue("@d6", ders6vize.Text);
                        c3.ExecuteNonQuery();
                        baglantı.Close();
                    }
                    else
                    {
                        baglantı.Open();
                        SqlCommand command3 = new SqlCommand("update vizeem set EM102=@em102,EM103=@em103  where Numara='" + textBoxno.Text + "'", baglantı);
                        command3.Parameters.AddWithValue("@em102", ders5vize.Text);
                        command3.Parameters.AddWithValue("@em103", ders6vize.Text);
                        command3.ExecuteNonQuery();
                        baglantı.Close();
                    }
                    if (genelsorgu("select COUNT(*)from finalem where Numara=@noo") == 0)
                    {
                        baglantı.Open();
                        SqlCommand c4 = new SqlCommand("insert into finalem(Numara,EM102,EM103)values(@no,@d5,@d6)", baglantı);
                        c4.Parameters.AddWithValue("@no", textBoxno.Text);
                        c4.Parameters.AddWithValue("@d5", ders5final.Text);
                        c4.Parameters.AddWithValue("@d6", ders6final.Text);
                        c4.ExecuteNonQuery();
                        baglantı.Close();
                    }
                    else
                    {
                        baglantı.Open();
                        SqlCommand command4 = new SqlCommand("update finalem set EM102=@em102,EM103=@em103  where Numara='" + textBoxno.Text + "'", baglantı);
                        command4.Parameters.AddWithValue("@em102", ders5final.Text);
                        command4.Parameters.AddWithValue("@em103", ders6final.Text);
                        baglantı.Close();
                    }
                   
                }
                if (labelblm.Text.ToString().Trim() == "Kimya Muhendisligi")
                {
                    if (genelsorgu("select COUNT(*)from ortakvize where Numara=@noo") == 0)
                    {
                        baglantı.Open();
                        SqlCommand c1 = new SqlCommand("insert into ortakvize(Numara,MAT102,FİZİK102,İNG102,TCİnkilap)values(@n,@m,@f,@i,@tc)", baglantı);
                        c1.Parameters.AddWithValue("@n", textBoxno.Text);
                        c1.Parameters.AddWithValue("@m", matvize.Text);
                        c1.Parameters.AddWithValue("@f", fizvize.Text);
                        c1.Parameters.AddWithValue("@i", ingvize.Text);
                        c1.Parameters.AddWithValue("@tc", tcvize.Text);
                        c1.ExecuteNonQuery();
                        baglantı.Close();
                    }
                    else
                    {
                        baglantı.Open();
                        SqlCommand command = new SqlCommand("update ortakvize set MAT102=@mat,FİZİK102=@fiz,İNG102=@ing,TCİnkilap=@tc  where Numara='" + textBoxno.Text + "'", baglantı);
                        command.Parameters.AddWithValue("@mat", matvize.Text);
                        command.Parameters.AddWithValue("@fiz", fizvize.Text);
                        command.Parameters.AddWithValue("@ing", ingvize.Text);
                        command.Parameters.AddWithValue("@tc", tcvize.Text);
                        command.ExecuteNonQuery();
                        baglantı.Close();
                    }
                    if (genelsorgu("select COUNT(*)from ortakfinal where Numara=@noo") == 0)
                    {
                        baglantı.Open();
                        SqlCommand c2 = new SqlCommand("insert into ortakfinal(Numara,MAT102,FİZİK102,İNG102,TCİnkilap)values(@n,@m,@f,@i,@tc)", baglantı);
                        c2.Parameters.AddWithValue("@n", textBoxno.Text);
                        c2.Parameters.AddWithValue("@m", matfinal.Text);
                        c2.Parameters.AddWithValue("@f", fizfinal.Text);
                        c2.Parameters.AddWithValue("@i", ingfinal.Text);
                        c2.Parameters.AddWithValue("@tc", tcfinal.Text);
                        c2.ExecuteNonQuery();
                        baglantı.Close();
                    }
                    else
                    {
                        baglantı.Open();
                        SqlCommand command2 = new SqlCommand("update ortakfinal set MAT102=@mat,FİZİK102=@fiz,İNG102=@ing,TCİnkilap=@tc  where Numara='" + textBoxno.Text + "'", baglantı);
                        command2.Parameters.AddWithValue("@mat", matfinal.Text);
                        command2.Parameters.AddWithValue("@fiz", fizfinal.Text);
                        command2.Parameters.AddWithValue("@ing", ingfinal.Text);
                        command2.Parameters.AddWithValue("@tc", tcfinal.Text);
                        command2.ExecuteNonQuery();
                        baglantı.Close();
                    }
                    if (genelsorgu("select COUNT(*)from vizekm where Numara=@noo") == 0)
                    {
                        baglantı.Open();
                        SqlCommand c3 = new SqlCommand("insert into vizekm(Numara,KM102,KM103)values(@no,@d5,@d6)", baglantı);
                        c3.Parameters.AddWithValue("@no", textBoxno.Text);
                        c3.Parameters.AddWithValue("@d5", ders5vize.Text);
                        c3.Parameters.AddWithValue("@d6", ders6vize.Text);
                        c3.ExecuteNonQuery();
                        baglantı.Close();
                    }
                    else
                    {
                        baglantı.Open();
                        SqlCommand command3 = new SqlCommand("update vizekm set KM102=@km102,KM103=@km103  where Numara='" + textBoxno.Text + "'", baglantı);
                        command3.Parameters.AddWithValue("@km102", ders5vize.Text);
                        command3.Parameters.AddWithValue("@km103", ders6vize.Text);
                        command3.ExecuteNonQuery();
                        baglantı.Close();
                    }

                    if (genelsorgu("select COUNT(*)from finalkm where Numara=@noo") == 0)
                    {
                        baglantı.Open();
                        SqlCommand c4 = new SqlCommand("insert into finalkm(Numara,KM102,KM103)values(@no,@d5,@d6)", baglantı);
                        c4.Parameters.AddWithValue("@no", textBoxno.Text);
                        c4.Parameters.AddWithValue("@d5", ders5final.Text);
                        c4.Parameters.AddWithValue("@d6", ders6final.Text);
                        c4.ExecuteNonQuery();
                        baglantı.Close();
                    }
                    else
                    {
                        baglantı.Open();
                        SqlCommand command4 = new SqlCommand("update finalkm set KM102=@km102,KM103=@km103  where Numara='" + textBoxno.Text + "'", baglantı);
                        command4.Parameters.AddWithValue("@km102", ders5final.Text);
                        command4.Parameters.AddWithValue("@km103", ders6final.Text);
                        baglantı.Close();
                    }
                   
                }
                MessageBox.Show("Update İslemi Basarili.");
            }
            else
            {
                MessageBox.Show("Giris Yapmadınız.");
            }
            
        }
        public int bmsorgula()
        {
            using (SqlConnection baglantı = new SqlConnection("Data Source=KURSATCAKAL\\SQL_2014;Initial Catalog=sistem;Integrated Security=True"))
            {
                int sayi;
                SqlCommand komut = new SqlCommand("select COUNT(*) from bmkarne where Numara=@no",baglantı);//DİKKAT FROM (TABLOİSİM) WHERE (NEREYEGORE)
                komut.Parameters.AddWithValue("@no",textBoxno.Text);                                        //baglantı ile ilişkilendirmeyide unutma
                baglantı.Open();
                sayi = Convert.ToInt32(komut.ExecuteScalar());
                baglantı.Close();
                return sayi;
            }
        }
        public int emsorgula()
        {
            using (SqlConnection baglantı = new SqlConnection("Data Source=KURSATCAKAL\\SQL_2014;Initial Catalog=sistem;Integrated Security=True"))
            {
                int sayi;
                SqlCommand command2 = new SqlCommand("select COUNT(*)from emkarne where Numara=@no",baglantı);
                command2.Parameters.AddWithValue("@no", textBoxno.Text);
                baglantı.Open();
                sayi = Convert.ToInt32(command2.ExecuteScalar());
                baglantı.Close();
                return sayi;
            }
        }
        public int kmsorgula()
        {
            using (SqlConnection baglantı = new SqlConnection("Data Source=KURSATCAKAL\\SQL_2014;Initial Catalog=sistem;Integrated Security=True"))
            {
                int sayi;
                SqlCommand command3 = new SqlCommand("select COUNT(*)from kmkarne where Numara=@no", baglantı);
                command3.Parameters.AddWithValue("@no", textBoxno.Text);
                baglantı.Open();
                sayi = Convert.ToInt32(command3.ExecuteScalar());
                baglantı.Close();
                return sayi;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if(labelisim.Text.ToString().Trim()!=""&&labelblm.Text.ToString().Trim()!="")
            {

                try
                {
                    if (o1.Text != "" && o2.Text != "" && o3.Text != "" && o4.Text != "" && o5.Text != "" && o6.Text != "")
                    {
                        if (labelblm.Text.ToString().Trim() == "Bilgisayar Muhendisligi")
                        {
                            if (bmsorgula() == 0)
                            {
                                baglantı.Open();
                                SqlCommand komut = new SqlCommand("insert into bmkarne(Numara,MAT102,FİZİK102,İNG102,TCİnkilap,BM102,BM103) values(@no,@m,@f,@i,@tc,@bm1,@bm2)", baglantı);
                                komut.Parameters.AddWithValue("@no", textBoxno.Text);
                                komut.Parameters.AddWithValue("@m", o1.Text.ToString().Trim());
                                komut.Parameters.AddWithValue("@f", o2.Text.ToString().Trim());
                                komut.Parameters.AddWithValue("@i", o3.Text.ToString().Trim());
                                komut.Parameters.AddWithValue("@tc", o4.Text.ToString().Trim());
                                komut.Parameters.AddWithValue("@bm1", o5.Text.ToString().Trim());
                                komut.Parameters.AddWithValue("@bm2", o6.Text.ToString().Trim());
                                komut.ExecuteNonQuery();
                                baglantı.Close();
                                MessageBox.Show("Karne Olusturuldu.");
                            }
                            else
                            {
                                baglantı.Open();
                                SqlCommand command = new SqlCommand("update bmkarne set MAT102=@m,FİZİK102=@f,İNG102=@i,TCİnkilap=@tc,BM102=@bm1,BM103=@bm2 where Numara=@no", baglantı);
                                command.Parameters.AddWithValue("@no", textBoxno.Text);
                                command.Parameters.AddWithValue("@m", o1.Text);
                                command.Parameters.AddWithValue("@f", o2.Text);
                                command.Parameters.AddWithValue("@i", o3.Text);
                                command.Parameters.AddWithValue("@tc", o4.Text);
                                command.Parameters.AddWithValue("@bm1", o5.Text);
                                command.Parameters.AddWithValue("@bm2", o6.Text);
                                command.ExecuteNonQuery();
                                baglantı.Close();
                                MessageBox.Show("Karne Guncellendi.");

                            }

                        }

                        if (labelblm.Text.ToString().Trim() == "Endustri Muhendisligi")
                        {
                            if (emsorgula() == 0)
                            {
                                baglantı.Open();
                                SqlCommand komut2 = new SqlCommand("insert into emkarne(Numara,MAT102,FİZİK102,İNG102,TCİnkilap,EM102,EM103) values(@no,@m,@f,@i,@tc,@em1,@em2)", baglantı);
                                komut2.Parameters.AddWithValue("@no", textBoxno.Text);
                                komut2.Parameters.AddWithValue("@m", o1.Text.ToString().Trim());
                                komut2.Parameters.AddWithValue("@f", o2.Text.ToString().Trim());
                                komut2.Parameters.AddWithValue("@i", o3.Text.ToString().Trim());
                                komut2.Parameters.AddWithValue("@tc", o4.Text.ToString().Trim());
                                komut2.Parameters.AddWithValue("@em1", o5.Text.ToString().Trim());
                                komut2.Parameters.AddWithValue("@em2", o6.Text.ToString().Trim());
                                komut2.ExecuteNonQuery();
                                baglantı.Close();
                                MessageBox.Show("Karne Olusturuldu.");
                            }
                            else
                            {
                                baglantı.Open();
                                SqlCommand komut3 = new SqlCommand("update emkarne set MAT102=@m,FİZİK102=@f,İNG102=@i,TCİnkilap=@tc,EM102=@em1,EM103=@em2 where Numara=@no", baglantı);
                                komut3.Parameters.AddWithValue("@no", textBoxno.Text);
                                komut3.Parameters.AddWithValue("@m", o1.Text);
                                komut3.Parameters.AddWithValue("@f", o2.Text);
                                komut3.Parameters.AddWithValue("@i", o3.Text);
                                komut3.Parameters.AddWithValue("@tc", o4.Text);
                                komut3.Parameters.AddWithValue("@em1", o5.Text);
                                komut3.Parameters.AddWithValue("@em2", o6.Text);
                                komut3.ExecuteNonQuery();
                                baglantı.Close();
                                MessageBox.Show("Karne Guncellendi.");
                            }

                        }
                        if (labelblm.Text.ToString().Trim() == "Kimya Muhendisligi")
                        {
                            if (kmsorgula() == 0)
                            {
                                baglantı.Open();
                                SqlCommand komut3 = new SqlCommand("insert into kmkarne(Numara,MAT102,FİZİK102,İNG102,TCİnkilap,KM102,KM103) values(@no,@m,@f,@i,@tc,@km1,@km2)", baglantı);
                                komut3.Parameters.AddWithValue("@no", textBoxno.Text);
                                komut3.Parameters.AddWithValue("@m", o1.Text.ToString().Trim());
                                komut3.Parameters.AddWithValue("@f", o2.Text.ToString().Trim());
                                komut3.Parameters.AddWithValue("@i", o3.Text.ToString().Trim());
                                komut3.Parameters.AddWithValue("@tc", o4.Text.ToString().Trim());
                                komut3.Parameters.AddWithValue("@km1", o5.Text.ToString().Trim());
                                komut3.Parameters.AddWithValue("@km2", o6.Text.ToString().Trim());
                                komut3.ExecuteNonQuery();
                                baglantı.Close();
                                MessageBox.Show("Karne Olusturuldu.");
                            }
                            else
                            {
                                baglantı.Open();
                                SqlCommand komut4 = new SqlCommand("update kmkarne set MAT102=@m,FİZİK102=@f,İNG102=@i,TCİnkilap=@tc,KM102=@km1,KM103=@km2 where Numara=@no", baglantı);
                                komut4.Parameters.AddWithValue("@no", textBoxno.Text);
                                komut4.Parameters.AddWithValue("@m", o1.Text.ToString().Trim());
                                komut4.Parameters.AddWithValue("@f", o2.Text.ToString().Trim());
                                komut4.Parameters.AddWithValue("@i", o3.Text.ToString().Trim());
                                komut4.Parameters.AddWithValue("@tc", o4.Text.ToString().Trim());
                                komut4.Parameters.AddWithValue("@km1", o5.Text.ToString().Trim());
                                komut4.Parameters.AddWithValue("@km2", o6.Text.ToString().Trim());
                                komut4.ExecuteNonQuery();
                                baglantı.Close();
                                MessageBox.Show("Karne Guncellendi.");
                            }

                        }

                    }
                    else
                    {
                        MessageBox.Show("Ortalama kaynagını gösteriniz!!!");
                    }
                }
                catch (Exception h)
                {

                    MessageBox.Show("Hata " + h.Message);
                }
            }
            else
            {
                MessageBox.Show("Lutfen bir sahış giriniz!!!");
            }

        }

        private void textBoxno_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
