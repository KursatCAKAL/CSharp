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

    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglantı = new SqlConnection("Data Source=KURSATCAKAL\\SQL_2014;Initial Catalog=sistem;Integrated Security=True");

        string imgLoc = "";
        public void goster(string veriler)
        {

            SqlDataAdapter da = new SqlDataAdapter(veriler, baglantı);

            DataSet dt = new DataSet();

            da.Fill(dt);

            dataGridView1.DataSource = dt.Tables[0];

        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            yoneticiform yeni = new yoneticiform();
            yeni.Show();
            this.Hide();
        }//FORM GEÇİŞİ
        public int sorgu()
        {
            using(SqlConnection baglantı = new SqlConnection("Data Source=KURSATCAKAL\\SQL_2014;Initial Catalog=sistem;Integrated Security=True"))
            {
                int adet;
                SqlCommand komutsorgu = new SqlCommand("select COUNT(*)from ogrencibilgi where Numara=@no",baglantı);
                komutsorgu.Parameters.AddWithValue("@no",textBox1.Text);
                baglantı.Open();
                adet = Convert.ToInt32(komutsorgu.ExecuteScalar());
                baglantı.Close();
                return adet;

            }
        }//AYNI OGRENCİNİN VARLIĞINI KONTROL EDEN SORGU YORDAMI.

        private void pictureBox2_Click(object sender, EventArgs e)
{
    if(textBox1.Text==""||textBox2.Text==""||textBox3.Text==""||textBox4.Text==""||textBox5.Text==""||textBox6.Text==""||comboBox1.Text==""||comboBox2.Text=="")
    {
        MessageBox.Show("Lutfen Tum Kutucukları Doldurunuz.");

    }
    else
    {
                if (sorgu() == 0)
                {
                        if (textBox1.TextLength > 15 || textBox2.TextLength > 18 || textBox3.TextLength > 15 || textBox4.TextLength > 25 || textBox5.TextLength > 10 || textBox6.TextLength > 50)
                        {
                            MessageBox.Show("Karakter sınırını aştınız.Girişleri kısaltıp tekrar deneyiniz.");
                        }
                  
                    else
                    {
                        
                        if(pictureBox1.Image!=null)
                        {
                            string parola = textBox7.Text.ToString();
                            if(textBox7.Text.Length<=10&&textBox7.Text.Length>=6)
                            {
                                if (Regex.IsMatch(parola, @"([a-zA-Z]\d+)|(\d+[a-zA-Z])"))
                                {
                                    //    byte[] img = null;
                                    //    FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);//DİKKAT BU ŞEKİLDE EKLEME BİNARY TİPİNDEDİR
                                    //STRİNG TİPİNDE BİR EKLEMEYLE DAHA AZ KOD İLE BU İŞİ YAPABİLİRİZ.
                                    //    BinaryReader br = new BinaryReader(fs);
                                    //    img = br.ReadBytes((int)fs.Length);
                                    baglantı.Open();
                                    SqlCommand resimkomut = new SqlCommand("insert into ogrencibilgi(Numara,Ad,Soyad,Bolum,Cinsiyet,Email,Telefon,Adres,Resim) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "',@img)", baglantı);

                                    resimkomut.Parameters.Add(new SqlParameter("@img", textBox8.Text));


                                    resimkomut.ExecuteNonQuery();
                                    baglantı.Close();

                                    //---------------//,
                                    baglantı.Open();
                                    SqlCommand komut2 = new SqlCommand("insert into sifre(No,Sifre) values(@nosu,@sifresi)", baglantı);
                                    komut2.Parameters.AddWithValue("@nosu", textBox1.Text);
                                    komut2.Parameters.AddWithValue("@sifresi", textBox7.Text);
                                    komut2.ExecuteNonQuery();
                                    baglantı.Close();
                                    textBox1.Clear();
                                    textBox2.Clear();
                                    textBox3.Clear();
                                    textBox4.Clear();
                                    textBox5.Clear();
                                    textBox6.Clear();
                                    textBox7.Clear();
                                    textBox8.Clear();
                                    comboBox1.Text = "";
                                    comboBox2.Text = "";
                                    pictureBox1.Image = null;
                                    MessageBox.Show("Kayıt Basarili.");

                                }
                                else
                                {
                                    MessageBox.Show("Sifreniz karakter ve sayı içermeledir.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Şifreniz En az 6 En çok 10 karakterli olmalıdır.");
                            }
                            
                        }
                        else
                        {
                            MessageBox.Show("Lutfen Resim ekleyiniz.");
                        }

                     
                        

                  
                    }

                }
                else
                    MessageBox.Show("Girilen Numaraya ait bir ogrenci bulunmakta.Lütfen baska numara ataması yapınız.");
    }
            
}//OGRENCİ EKLEME BUTONU -- NELER YAPAR =(BOSLUKLAR DOLMALI,AYNI OGRENCİ OLMAMALI,KARAKTER SINIRI AŞILMAMALI)
        private void pictureBox6_Click(object sender, EventArgs e)
        {

            baglantı.Open();
            SqlCommand komut = new SqlCommand("Select * from ogrencibilgi where Numara like '%" + textBox9.Text + "%'", baglantı);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglantı.Close();
        }//ARANAN OGRENCİYİ BULMA .
        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
        private void label12_Click(object sender, EventArgs e)
        {

        }
      

        private void btnbrowse_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|GIF Files(*.gif)|(*.gif)|All Files(*.*)|(*.*)";
            dlg.Title = "Select Resimler";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBox8.Text = dlg.FileName;
                imgLoc = dlg.FileName.ToString();
                pictureBox1.ImageLocation = imgLoc;

            }
            textBox8.Enabled = false;

        }

       
    }
}
