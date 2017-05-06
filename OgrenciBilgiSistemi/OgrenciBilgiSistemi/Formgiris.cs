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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=KURSATCAKAL\\SQL_2014;Initial Catalog=sistem;Integrated Security=True");
 
        private void button1_Click(object sender, EventArgs e)
        {
            dondur.Tut = textBox1.Text;
            

            try//girisi saglayan kodlarımız.
            {
                baglantı.Open();
                string sql = "Select *from sifre where No=@nosu AND Sifre=@sifresi";
                SqlParameter prm1 = new SqlParameter("nosu",textBox1.Text);
                SqlParameter prm2 = new SqlParameter("sifresi", textBox2.Text);
                SqlCommand komut = new SqlCommand(sql,baglantı);

                komut.Parameters.Add(prm1);
                komut.Parameters.Add(prm2);

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(komut);
                da.Fill(dt);

                if(dt.Rows.Count>0)
                {
                    Form3 fr = new Form3();
                    fr.Show();
                   // this.Hide();

                }

            }
            catch(Exception)
            {
                MessageBox.Show("Hatalı Giris");
                Form2 yeni = new Form2();
                yeni.Show();
                this.Hide();
            }

           


            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            fr.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //checkedListBox1.Visible = false;

            /*if (label3.Text == "Bilgisayar Muhendisligi")
            {
                checkedListBox1.Show();

            }*/
        }
    }
}
