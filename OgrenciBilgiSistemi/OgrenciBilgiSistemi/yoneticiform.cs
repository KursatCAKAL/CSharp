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

namespace OgrenciBilgiSistemi
{
    public partial class yoneticiform : Form
    {
        public yoneticiform()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=KURSATCAKAL\\SQL_2014;Initial Catalog=sistem;Integrated Security=True");
        string imgLoc = "";
        string imgLocogretmen = "";
        /*public void verigoster(string veriler)
        {
            baglantı.Open();
            SqlDataAdapter da = new SqlDataAdapter(veriler,baglantı);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglantı.Close();
        }*/
        public void verigoster(string veriler)
        {

            SqlDataAdapter da = new SqlDataAdapter(veriler, baglantı);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

        }
        public void verigostersistembilgileri(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, baglantı);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView3.DataSource = ds.Tables[0];
        }
        public void verigoster2(string veriler)
        {

            SqlDataAdapter da2 = new SqlDataAdapter(veriler, baglantı);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            dataGridView2.DataSource = ds2.Tables[0];

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            mainform yeni = new mainform();
            yeni.Show();
            this.Hide();
        }

        private void ogrenciKaydıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 yeni = new Form1();
            yeni.Show();
            this.Hide();
        }

        private void ogretimGorevlisiKaydıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ogruyesi yeni = new ogruyesi();
            yeni.Show();
            this.Hide();
        }

        private void ogrGorevlileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelogr.Hide();
            panelogrtmn.Hide();
            dataGridView3.Show();
            verigostersistembilgileri("Select *from ogruyesi"); //dikkat et bu hataya çok düşüyosun sistem değil veri çekmez istedigin tablonun ismini yaz.


        }

        private void ogrencilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelogr.Hide();
            panelogrtmn.Hide();
            dataGridView3.Show();
            verigostersistembilgileri("Select *from ogrencibilgi");
        }

        private void yoneticiform_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;

            panelogrtmn.Visible = false;
            panelogr.Visible = false;
            dataGridView3.Hide();
            if (dakika == 0)
            {
                MessageBox.Show("Lutfen Tekrar Giris Yapınız hareketsiz 15 dk oldu.");
                this.Close();
            }


        }

        private void goruntuleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void kayıtToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("delete from ogrencibilgi where Numara=@numara", baglantı);
            SqlCommand komut2 = new SqlCommand("delete from derskayıt1 where No=@no", baglantı);
            SqlCommand komut5 = new SqlCommand("delete from sifre where No=@no", baglantı);
            if (cbbolum.Text == "Bilgisayar Muhendisligi")
            {
                SqlCommand komut3 = new SqlCommand("delete from vizebm where Numara=@numara", baglantı);
                SqlCommand komut4 = new SqlCommand("delete  from finalbm where Numara=@numara", baglantı);
                komut3.Parameters.AddWithValue("@numara", tbno.Text);
                komut4.Parameters.AddWithValue("@numara", tbno.Text);
                komut3.ExecuteNonQuery();
                komut4.ExecuteNonQuery();
            }
            if (cbbolum.Text == "Endustri Muhendisligi")//Kimya Muhendisligi
            {
                SqlCommand komut3 = new SqlCommand("delete from vizeem where Numara=@numara", baglantı);
                SqlCommand komut4 = new SqlCommand("delete  from finalem where Numara=@numara", baglantı);
                komut3.Parameters.AddWithValue("@numara", tbno.Text);
                komut4.Parameters.AddWithValue("@numara", tbno.Text);
                komut3.ExecuteNonQuery();
                komut4.ExecuteNonQuery();
            }
            if (cbbolum.Text == "Kimya Muhendisligi")// Muhendisligi
            {
                SqlCommand komut3 = new SqlCommand("delete from vizekm where Numara=@numara", baglantı);
                SqlCommand komut4 = new SqlCommand("delete  from finalkm where Numara=@numara", baglantı);
                komut3.Parameters.AddWithValue("@numara", tbno.Text);
                komut4.Parameters.AddWithValue("@numara", tbno.Text);
                komut3.ExecuteNonQuery();
                komut4.ExecuteNonQuery();
            }


            komut.Parameters.AddWithValue("@numara", tbno.Text);
            komut2.Parameters.AddWithValue("@no", tbno.Text);
            komut5.Parameters.AddWithValue("@no", tbno.Text);
            komut.ExecuteNonQuery();
            komut2.ExecuteNonQuery();

            komut5.ExecuteNonQuery();
            verigoster("select *from ogrencibilgi");
            baglantı.Close();
            tbno.Clear();
            tbad.Clear();
            tbsoyad.Clear();
            cbbolum.Text = "";
            cbcinsiyet.Text = "";
            tbemail.Clear();
            tbtel.Clear();
            tbadres.Clear();
            MessageBox.Show("Silme İşlemi Basarili.");
        }

        private void pictureBox5_Click(object sender, EventArgs e)//OGRENCİ İÇİN HEM BİLGİ GOSTERİMİ HEMDE RESİM GOSTERİMİ YAPAN KOD.
        {
            verigoster("select *from ogrencibilgi");

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilialan = dataGridView1.SelectedCells[0].RowIndex;


            string numara = dataGridView1.Rows[secilialan].Cells[0].Value.ToString();//1 den basladın ve 
            string ad = dataGridView1.Rows[secilialan].Cells[1].Value.ToString();
            string soyad = dataGridView1.Rows[secilialan].Cells[2].Value.ToString();
            string bolum = dataGridView1.Rows[secilialan].Cells[3].Value.ToString();
            string cinsiyet = dataGridView1.Rows[secilialan].Cells[4].Value.ToString();
            string email = dataGridView1.Rows[secilialan].Cells[5].Value.ToString();
            string telefon = dataGridView1.Rows[secilialan].Cells[6].Value.ToString();
            string adres = dataGridView1.Rows[secilialan].Cells[7].Value.ToString(); //7 ile bitti yanlış oluyor 0 dan başlatman lazım aynı dizideki gibi indis mantıgı burası
            string resim = dataGridView1.Rows[secilialan].Cells[8].Value.ToString();
            tbno.Text = numara;
            tbad.Text = ad;
            tbsoyad.Text = soyad;
            cbbolum.Text = bolum;
            cbcinsiyet.Text = cinsiyet;
            tbemail.Text = email;
            tbtel.Text = telefon;
            tbadres.Text = adres;
            pBoxogrenci.ImageLocation = resim;

            //baglantı.Open();
            //SqlCommand komut = new SqlCommand("select Resim from ogrencibilgi where Numara='" + tbno.Text + "'", baglantı);
            //SqlDataReader dr = komut.ExecuteReader();
            //dr.Read();
            //if (dr.HasRows)
            //{
            //    byte[] img = (byte[])(dr[0]);
            //    if (img == null)
            //    {
            //        pBoxogrenci.Image = null;
            //    }
            //    else
            //    {
            //        MemoryStream ms = new MemoryStream(img);
            //        pBoxogrenci.Image = Image.FromStream(ms);
            //    }
            //}
            //else
            //{

            //    pBoxogrenci.Image = null;
            //    MessageBox.Show("Resim yok.");
            //}
            //baglantı.Close();


        }//CELLCLİCK YERİNE CELLENTER OZELLİGİ KULLANILDI

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //byte[] img = null;
            //FileStream fs = new FileStream(imgLoc,FileMode.Open,FileAccess.Read);//BUNLAR KOD KALABALIGIDIR TEXTBOX İLE İŞ BİTİRİLDİ.
            //BinaryReader br = new BinaryReader(fs);
            //img = br.ReadBytes((int)fs.Length);
            if (tbresimyologr.Text != "")
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("update ogrencibilgi set Ad='" + tbad.Text + "',Soyad='" + tbsoyad.Text + "',Bolum='" + cbbolum.Text + "',Cinsiyet='" + cbcinsiyet.Text + "',Email='" + tbemail.Text + "',Telefon='" + tbtel.Text + "',Adres='" + tbadres.Text + "',Resim='" + tbresimyologr.Text + "' where Numara='" + tbno.Text + "'", baglantı);
                komut.ExecuteNonQuery();
                verigoster("select *from ogrencibilgi");
                baglantı.Close();
                baglantı.Open();
                SqlCommand komut2 = new SqlCommand("update sifre set Sifre='"+telsifre.Text+"' where No='" + tbno.Text + "'", baglantı);
                komut2.ExecuteNonQuery();
                verigoster("select *from ogrencibilgi");
                baglantı.Close();
                MessageBox.Show("Guncelleme Basarili.");
            }
            else
            {
                MessageBox.Show("Hata resim kaybedildi lütfen tekrar ekleyiniz.");
            }
        }

        private void ogrenciBilgileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelogr.Visible = true;
            panelogrtmn.Visible = false;
            dataGridView3.Visible = false;

        }

        private void ogretimGorevlisiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelogrtmn.Visible = true;
            panelogr.Visible = false;
            dataGridView3.Visible = false;

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            verigoster2("select *from ogruyesi");

        }



        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)//CELLCLİCK KULLANMAK DAHA FAZLA KODA MAL OLUYOR.
        {
            int secilialan = dataGridView2.SelectedCells[0].RowIndex;

            string ad = dataGridView2.Rows[secilialan].Cells[0].Value.ToString();
            string soyad = dataGridView2.Rows[secilialan].Cells[1].Value.ToString();
            string gorev = dataGridView2.Rows[secilialan].Cells[2].Value.ToString();
            string cinsiyet = dataGridView2.Rows[secilialan].Cells[3].Value.ToString();
            string email = dataGridView2.Rows[secilialan].Cells[4].Value.ToString();
            string telefon = dataGridView2.Rows[secilialan].Cells[5].Value.ToString();
            string kullanıcıadı = dataGridView2.Rows[secilialan].Cells[6].Value.ToString();
            string sifre = dataGridView2.Rows[secilialan].Cells[7].Value.ToString();
            string unvan = dataGridView2.Rows[secilialan].Cells[8].Value.ToString();
            string resim = dataGridView2.Rows[secilialan].Cells[9].Value.ToString();
            textad.Text = ad;
            textsoyad.Text = soyad;
            combogrv.Text = gorev;
            combocinsiyet.Text = cinsiyet;
            textmail.Text = email;
            texttel.Text = telefon;
            textkadı.Text = kullanıcıadı;
            textsifre.Text = sifre;
            combounvan.Text = unvan;
            pBoxogretmen.ImageLocation = resim;
            //işaret
            //baglantı.Open();
            //SqlCommand komut = new SqlCommand("select Resim from ogrencibilgi where Numara='" + tbno.Text + "'", baglantı);
            //SqlDataReader dr = komut.ExecuteReader();
            //dr.Read();
            //if (dr.HasRows)
            //{
            //    byte[] img = (byte[])(dr[0]);
            //    if (img == null)
            //    {
            //        pBoxogrenci.Image = null;
            //    }
            //    else
            //    {
            //        MemoryStream ms = new MemoryStream(img);
            //        pBoxogrenci.Image = Image.FromStream(ms);
            //    }
            //}
            //baglantı.Close();
            //baglantı.Open();
            //SqlCommand komut = new SqlCommand("select Resim from ogruyesi where KullanıcıNo='" + textkadı.Text + "'", baglantı);
            //SqlDataReader dr = komut.ExecuteReader();
            //dr.Read();
            //if (dr.HasRows)
            //{
            //    byte[] imgogt = (byte[])(dr[0]);
            //    if (imgogt == null)
            //    {
            //        pBoxogretmen.Image = null;
            //    }
            //    else
            //    {
            //        MemoryStream ms2 = new MemoryStream(imgogt);
            //        pBoxogretmen.Image = Image.FromStream(ms2);
            //    }
            //}
            //baglantı.Close();
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //byte[] img = null;
            //FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
            //BinaryReader br = new BinaryReader(fs); //BU ŞEKİLDE BİNARY DEGİSKEN YARDIMIYLA EKLEME-UPDATE YAPMAK YERİNE CHAR BAZLI RESMİN ADRESİNİ ALIRIM.DAHA KOLAY VE DAHA AZ KOD KALABALIĞIYLA İŞ HALLOLUR.
            //img = br.ReadBytes((int)fs.Length);
            //byte[] img = null;
            //FileStream fs = new FileStream(imgLocogretmen, FileMode.Open, FileAccess.Read);
            //BinaryReader br = new BinaryReader(fs);
            //img = br.ReadBytes((int)fs.Length);


            if (tbresimyol.Text != "")
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("update ogruyesi set Ad='" + textad.Text + "',Soyad='" + textsoyad.Text + "',Gorev='" + combogrv.Text + "',Cinsiyet='" + combocinsiyet.Text + "',Email='" + textmail.Text + "',Telefon='" + texttel.Text + "',Sifre='" + textsifre.Text + "',Unvan='" + combounvan.Text + "',Resim='" + tbresimyol.Text + "' where KullanıcıNo='" + textkadı.Text + "'", baglantı);
                komut.ExecuteNonQuery();

                verigoster2("select *from ogruyesi");
                baglantı.Close();
                MessageBox.Show("Guncelleme Basarili.");
                textkadı.Clear();
                textad.Clear();
                textsoyad.Clear();
                textmail.Clear();
                texttel.Clear();
                tbresimyol.Clear();
                pBoxogretmen.Image = null;
                textsifre.Clear();
                combocinsiyet.Text = "";
                combogrv.Text = "";
                combocinsiyet.Text = "";
                combounvan.Text = "";
            }
            else
            {
                MessageBox.Show("Hata resim kaybedildi.");
            }

        }//OGR GOREVLİSİ UPDATE

        private void pictureBox8_Click_1(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("delete from ogruyesi where KullanıcıNo=@kno", baglantı);
            komut.Parameters.AddWithValue("@kno", textkadı.Text);//textbox.text yazmayı unutma eşleşmeyi sağlayamaz.
            komut.ExecuteNonQuery();
            verigoster2("select *from ogruyesi");
            baglantı.Close();
            MessageBox.Show("Silme basarili.");
            textkadı.Clear();
            textad.Clear();
            textsoyad.Clear();
            textmail.Clear();
            texttel.Clear();
            textsifre.Clear();
            combocinsiyet.Text = "";
            combogrv.Text = "";
            combocinsiyet.Text = "";
            combounvan.Text = "";


        }

        private void guncellemeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void duyuruYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formduyuru yeni = new formduyuru();
            yeni.Show();
            this.Hide();
        }

        private void notBilgisiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yoneticinotislemleri yeni = new yoneticinotislemleri();
            yeni.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.DoEvents();
            DataGridViewCellStyle rowc = new DataGridViewCellStyle();
            for (int i = 0; i < dataGridView3.Rows.Count - 1; i++)
            {
                if (dataGridView3.Rows[i].Cells[2].Value.ToString() == "BM102")
                {
                    rowc.BackColor = Color.Blue;
                    rowc.ForeColor = Color.White;
                }
                dataGridView3.Rows[i].DefaultCellStyle = rowc;
            }
        }

        private void takvimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yoneticiformtakvim yeni = new yoneticiformtakvim();
            yeni.Show();
            this.Hide();
        }
        int dakika = 14;


        private void timer1_Tick(object sender, EventArgs e)
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
                    timer1.Enabled = false;
                    MessageBox.Show("Lutfen Tekrar Giris Yapınız 15 dk hareketsiz kaldınız.");
                    Application.Exit();
                }

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|GIF Files(*.gif)|*.gif|All Files(*.*)|*.*";
            dlg.Title = "Resim seç ahbap";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                tbresimyologr.Text = dlg.FileName;
                imgLoc = dlg.FileName.ToString();
                pBoxogrenci.ImageLocation = imgLoc;
            }
            tbresimyologr.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|GIF Files(*.gif)|*.gif|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
            dlg.Title = "Resim Seç ahbap";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                tbresimyol.Text = dlg.FileName;
                imgLocogretmen = dlg.FileName.ToString();
                pBoxogretmen.ImageLocation = imgLocogretmen;
            }
            tbresimyol.Enabled = false;
        }

        private void panelogrtmn_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {

            //string numara = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            //string ad = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            //string soyad = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            //string bolum = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            //string cinsiyet = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            //string email = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            //string telefon = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            //string adres = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            //string resim = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            //tbno.Text = numara;
            //tbad.Text = ad;
            //tbsoyad.Text = soyad;
            //cbbolum.Text = bolum;
            //cbcinsiyet.Text = cinsiyet;
            //tbemail.Text = email;
            //tbtel.Text = telefon;
            //tbadres.Text = adres;
            //tbresimyologr.Text = resim;
            //pBoxogrenci.ImageLocation = resim;

        }

        private void dataGridView2_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            //string ad = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            //string soyad = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            //string gorev = dataGridView2.CurrentRow.Cells[2].Value.ToString();

            //string cinsiyet = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            //string email = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            //string tel = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            //string kadı = dataGridView2.CurrentRow.Cells[6].Value.ToString();
            //string sifre = dataGridView2.CurrentRow.Cells[7].Value.ToString();
            //string unvan = dataGridView2.CurrentRow.Cells[8].Value.ToString();
            //string resimogr = dataGridView2.CurrentRow.Cells[9].Value.ToString();//Aldığı resim uzantısı sayesinde picbox da resmi goruntlr

            //textad.Text = ad;
            //textsoyad.Text = soyad;
            //combogrv.Text = gorev;
            //combounvan.Text = unvan;
            //combocinsiyet.Text = cinsiyet;
            //textmail.Text = email;
            //texttel.Text = tel;
            //textkadı.Text = kadı;
            //textsifre.Text = sifre;
            //tbresimyol.Text = resimogr;
            //pBoxogretmen.ImageLocation = resimogr;


        }
    }
}
