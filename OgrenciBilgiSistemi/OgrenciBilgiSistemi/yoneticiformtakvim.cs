using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Data.SqlClient;


namespace OgrenciBilgiSistemi
{
    public partial class yoneticiformtakvim : Form
    {
        public yoneticiformtakvim()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=KURSATCAKAL\\SQL_2014;Initial Catalog=sistem;Integrated Security=True");
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {


        }

        private void yoneticiformtakvim_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            yoneticiform yeni = new yoneticiform();
            yeni.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "PDF Files(*.pdf)|*.pdf|DOC Files(*.docx)|*.docx";
            dlg.Title = "PDF Yukleyici";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string yol = dlg.FileName;
                textBox1.Text = yol;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    SqlCommand komut = new SqlCommand("insert into akademik(id,takvim) values(@i,@tak)", baglantı);
                    komut.Parameters.AddWithValue("@i", comboBox1.Text);
                    komut.Parameters.AddWithValue("@tak", textBox1.Text);
                    baglantı.Open();
                    komut.ExecuteNonQuery();

                    MessageBox.Show("Basarili.");
                }
                else
                {
                    MessageBox.Show("Resim yolu eklenmedi.");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata bu id de kimlik var." + ex.Message);
            }
            baglantı.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                baglantı.Open();
                SqlCommand komutsil = new SqlCommand("delete from akademik where id='" + comboBox1.Text.ToString().Trim() + "'", baglantı);
                komutsil.ExecuteNonQuery();

                MessageBox.Show("İslem Basarili.");
            }
            else
            {
                MessageBox.Show("İd bulunamadı.");
            }
            baglantı.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && textBox1.Text != "")
            {

                baglantı.Open();
                SqlCommand komutupdate = new SqlCommand("update akademik set id=@i,takvim=@takvim", baglantı);
                komutupdate.Parameters.AddWithValue("@i", comboBox1.Text);
                komutupdate.Parameters.AddWithValue("@takvim", textBox1.Text);
                komutupdate.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("Guncelleme Basarili.");
            }
            else
            {
                MessageBox.Show("Giris basarisiz..");
            }







        }
    }
}
