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
    public partial class Form3akademiktakvim : Form
    {
        public Form3akademiktakvim()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=KURSATCAKAL\\SQL_2014;Initial Catalog=sistem;Integrated Security=True");
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            
        }

        private void yılıAkademikTakvimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axAcroPDF1.Show();
            string tut;
            baglantı.Open();
            SqlCommand command = new SqlCommand("select takvim from akademik where id=@id", baglantı);
            command.Parameters.AddWithValue("@id", "2015-2016 Yılı Akademik Takvim");
            SqlDataReader dr = command.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                tut = dr["takvim"].ToString();
                axAcroPDF1.LoadFile(tut);
            }
            else
            {
                MessageBox.Show("Bulunamadı.");
                axAcroPDF1.Hide();

            }
            baglantı.Close();
        }

        private void yılıAkademikTakvimToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            axAcroPDF1.Show();
            string tut;
            baglantı.Open();
            SqlCommand command = new SqlCommand("select takvim from akademik where id=@id", baglantı);
            command.Parameters.AddWithValue("@id", "2013-2014 Yılı Akademik Takvim");
            SqlDataReader dr = command.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                tut = dr["takvim"].ToString();
                axAcroPDF1.LoadFile(tut);
            }
            else
            {
                MessageBox.Show("Bulunamadı.");
                axAcroPDF1.Hide();

            }
            baglantı.Close();
        }

        private void yılıAkademikTakvimToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            axAcroPDF1.Show();
            string tut;
            baglantı.Open();
            SqlCommand command = new SqlCommand("select takvim from akademik where id=@id", baglantı);
            command.Parameters.AddWithValue("@id", "2007-2008 Yılı Akademik Takvim");
            SqlDataReader dr = command.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                tut = dr["takvim"].ToString();
                axAcroPDF1.LoadFile(tut);
            }
            else
            {
                MessageBox.Show("Bulunamadı.");
                axAcroPDF1.Hide();

            }
            baglantı.Close();
        }

        private void çIKIŞToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            this.Hide();
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form3 yeni = new Form3();
            yeni.Show();
            this.Hide();
        }

        private void yılıAkademikTakvimToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            axAcroPDF1.Show();
            string tut;
            baglantı.Open();
            SqlCommand command = new SqlCommand("select takvim from akademik where id=@id", baglantı);
            command.Parameters.AddWithValue("@id", "2014-2015 Yılı Akademik Takvim");
            SqlDataReader dr = command.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                tut = dr["takvim"].ToString();
                axAcroPDF1.LoadFile(tut);
            }
            else
            {
                MessageBox.Show("Bulunamadı.");
                axAcroPDF1.Hide();
            }
            baglantı.Close();
        }

        private void yılıAkademikTakvimToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            axAcroPDF1.Show();
            string tut;
            baglantı.Open();
            SqlCommand command = new SqlCommand("select takvim from akademik where id=@id", baglantı);
            command.Parameters.AddWithValue("@id", "2012-2013 Yılı Akademik Takvim");
            SqlDataReader dr = command.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                tut = dr["takvim"].ToString();
                axAcroPDF1.LoadFile(tut);
            }
            else
            {
                MessageBox.Show("Bulunamadı.");
                axAcroPDF1.Hide();
            }
            baglantı.Close();
        }

        private void yılıAkademikTakvimToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            axAcroPDF1.Show();
            string tut;
            baglantı.Open();
            SqlCommand command = new SqlCommand("select takvim from akademik where id=@id", baglantı);
            command.Parameters.AddWithValue("@id", "2011-2012 Yılı Akademik Takvim");
            SqlDataReader dr = command.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                tut = dr["takvim"].ToString();
                axAcroPDF1.LoadFile(tut);
            }
            else
            {
                MessageBox.Show("Bulunamadı.");
                axAcroPDF1.Hide();
            }
            baglantı.Close();
        }

        private void yılıAkademikTakvimToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            axAcroPDF1.Show();
            string tut;
            baglantı.Open();
            SqlCommand command = new SqlCommand("select takvim from akademik where id=@id", baglantı);
            command.Parameters.AddWithValue("@id", "2010-2011 Yılı Akademik Takvim");
            SqlDataReader dr = command.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                tut = dr["takvim"].ToString();
                axAcroPDF1.LoadFile(tut);
            }
            else
            {
                MessageBox.Show("Bulunamadı.");
                axAcroPDF1.Hide();
            }
            baglantı.Close();
        }

        private void yılıAkademikTakvimToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            axAcroPDF1.Show();
            string tut;
            baglantı.Open();
            SqlCommand command = new SqlCommand("select takvim from akademik where id=@id", baglantı);
            command.Parameters.AddWithValue("@id", "2009-2010 Yılı Akademik Takvim");
            SqlDataReader dr = command.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                tut = dr["takvim"].ToString();
                axAcroPDF1.LoadFile(tut);
            }
            else
            {
                MessageBox.Show("Bulunamadı.");
                axAcroPDF1.Hide();
            }
            baglantı.Close();
        }

        private void yılıAkademikTakvimToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            axAcroPDF1.Show();
            string tut;
            baglantı.Open();
            SqlCommand command = new SqlCommand("select takvim from akademik where id=@id", baglantı);
            command.Parameters.AddWithValue("@id", "2008-2009 Yılı Akademik Takvim");
            SqlDataReader dr = command.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                tut = dr["takvim"].ToString();
                axAcroPDF1.LoadFile(tut);
            }
            else
            {
                MessageBox.Show("Bulunamadı.");
                axAcroPDF1.Hide();
            }
            baglantı.Close();
        }
    }
}
