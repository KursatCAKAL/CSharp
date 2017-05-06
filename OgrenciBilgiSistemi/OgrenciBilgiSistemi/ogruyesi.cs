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
    public partial class ogruyesi : Form
    {
        public ogruyesi()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=KURSATCAKAL\\SQL_2014;Initial Catalog=sistem;Integrated Security=True");

        string imgLoc = "";
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            yoneticiform yeni = new yoneticiform();
            yeni.Show();
            this.Hide();
        }//FORM GEÇİŞİ

        private void ogruyesi_Load(object sender, EventArgs e)
        {
        }
        public int sorgula()
        {
            using (SqlConnection baglantı = new SqlConnection("Data Source=KURSATCAKAL\\SQL_2014;Initial Catalog=sistem;Integrated Security=True"))
            {
                int adet;
                SqlCommand komutsorgu = new SqlCommand("Select COUNT(*)from ogruyesi where KullanıcıNo=@kno", baglantı);//BURAYA BAGLANTI YAZMASSAN CONNECTİONSTRİNG BAŞLATILMAMIŞ DER.
                komutsorgu.Parameters.AddWithValue("@kno", textBox6.Text);
                baglantı.Open();
                adet = Convert.ToInt32(komutsorgu.ExecuteScalar());
                baglantı.Close();
                return adet;
            }
        }//AYNI OGR GOREVLİSİNİN EKLENMEMESİNİ SAGLAYAN YORDAMIM.
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (sorgula() == 0)//BU HATAYA DÜŞME SEN Bİ VERİ TABANINA AYNI İD DEKİ 2 BİLGİNİN KAYDEDİLMESİNİ İSTEMİYORSAN BURASI sorgula()>0 olması lazım//gene hata burası hiç-
                               //kayıt yoksa girilmesi gereken komut satırı                                                                                                           
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "")
                {

                    MessageBox.Show("Lutfen tum bilgi kutucuklarını doldurunuz.");
                }
                else
                {
                    if (textBox1.TextLength > 25 || textBox2.TextLength > 25 || textBox4.TextLength > 25 || textBox5.TextLength > 10 || textBox6.TextLength > 25 || textBox7.TextLength > 25)
                    {
                        MessageBox.Show("Karakter sınırını aştınız.Girişleri kısaltıp tekrar deneyiniz.");
                    }
                    else
                    {
                        if(pictureBox2.Image!=null)
                        {

                            string parola = textBox7.Text.ToString();

                            //byte[] img = null;
                            //FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                            //BinaryReader br = new BinaryReader(fs);
                            //img = br.ReadBytes((int)fs.Length);
                            if(textBox7.Text.Length<=10&&textBox7.Text.Length>=6)
                            {
                                if (Regex.IsMatch(parola, @"(\d+[a-zA-Z])|([a-zA-Z]\d+)"))
                                {

                                    baglantı.Open();
                                    SqlCommand komut = new SqlCommand("insert into ogruyesi(Ad,Soyad,Gorev,Unvan,Cinsiyet,Email,Telefon,KullanıcıNo,Sifre,Resim) values(@adi,@soyadi,@gorevi,@unvani,@cinsiyeti,@emaili,@tel,@kno,@sifre,@img)", baglantı);
                                    komut.Parameters.AddWithValue("@adi", textBox1.Text);
                                    komut.Parameters.AddWithValue("@soyadi", textBox2.Text);
                                    komut.Parameters.AddWithValue("@gorevi", comboBox1.Text);
                                    komut.Parameters.AddWithValue("@unvani", comboBox2.Text);
                                    komut.Parameters.AddWithValue("@cinsiyeti", comboBox3.Text);
                                    komut.Parameters.AddWithValue("@emaili", textBox4.Text);
                                    komut.Parameters.AddWithValue("@tel", textBox5.Text);
                                    komut.Parameters.AddWithValue("@kno", textBox6.Text);
                                    komut.Parameters.AddWithValue("@sifre", textBox7.Text);
                                    komut.Parameters.AddWithValue("@img", textBox3.Text);
                                    komut.ExecuteNonQuery();//BU SATIRI UNUTTUN VE KAYIT İŞLEMİ GERÇEKLEŞMEDİ.
                                    baglantı.Close();
                                    MessageBox.Show("Kayıt Basarili.");
                                    textBox1.Clear();
                                    textBox2.Clear();
                                    comboBox1.Text = "";
                                    comboBox2.Text = "";
                                    comboBox3.Text = "";
                                    textBox3.Clear();
                                    textBox4.Clear();
                                    textBox5.Clear();
                                    textBox6.Clear();
                                    textBox7.Clear();
                                    pictureBox2.Image = null;
                                }
                                else
                                {
                                    MessageBox.Show("Parolanız karakter ve sayı içermelidir.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Şifreniz En az 6 En çok 10 Karakterli olmadılır.");
                            }
                          

                        }
                        else
                        {
                            MessageBox.Show("Lutfen Resim Ekleyiniz.");
                        }


                    }
                }
            }
            else
                MessageBox.Show("Girilen Kullanıcı No'ya ait bir kayıt bulunmakta.Lütfen baska bir kullanıcı adı deneyiniz.");

        }//OGR UYESİ EKLERKEN.BOS YER KALMAMASINI,AYNI OGR NİN EKLENMEMESİNİ,KARAKTER SINIRLARININ AŞILMAMASINI SAĞLAYAN KOD DİZİNİ.

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//resim seçme.
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|GIF Files(*.gif)|.*gif|All Files(*.*)|*.*";
            dlg.Title = "Resim Seç";
            if(dlg.ShowDialog()==DialogResult.OK)
            {
                string dosyayolu = dlg.FileName;
                textBox3.Text = dosyayolu;
                imgLoc = dlg.FileName.ToString();
                pictureBox2.ImageLocation = imgLoc;
            }
            textBox3.Enabled = false;
            
        }
    }
}
