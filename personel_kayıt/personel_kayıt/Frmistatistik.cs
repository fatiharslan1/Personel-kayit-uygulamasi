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

namespace personel_kayıt
{
    public partial class Frmistatistik : Form
    {
        public Frmistatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-5R80TPD\\;Initial Catalog=personelveritabani;Integrated Security=True");

        private void Frmistatistik_Load(object sender, EventArgs e)
        {
            //toplam personel sayısı
            baglantı.Open();
            SqlCommand komut1 = new SqlCommand("select count (*)From tbl_personel", baglantı);
            SqlDataReader dr1= komut1.ExecuteReader();
            while (dr1.Read())
            {
                lbltoplampersonel.Text = dr1[0].ToString();
            }

            baglantı.Close();

            //evli personel sayısı
            baglantı.Open();
            SqlCommand komut2 = new SqlCommand("select count (*)From tbl_personel where perdurum=1", baglantı);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                lblevli.Text = dr2[0].ToString();
            }
            baglantı.Close();

            //bekar personel
            baglantı.Open();
            SqlCommand komut3 = new SqlCommand("select count (*) From tbl_personel where perdurum=0", baglantı);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lblbekar.Text = dr3[0].ToString();
            }
            baglantı.Close();

            //şehir sayısı
            baglantı.Open();
            SqlCommand komut4 = new SqlCommand("select count (distinct(persehir)) From tbl_personel", baglantı);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                lblsehir.Text = dr4[0].ToString();
            }
            baglantı.Close();

            //toplam maaş
            baglantı.Open ();
            SqlCommand komut5 = new SqlCommand("select sum (permaas) From tbl_personel", baglantı);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                lblmaas.Text = dr5[0].ToString();
            }
            baglantı.Close ();

            //ortalama maas
            baglantı.Open();
            SqlCommand komut6 = new SqlCommand("select avg (permaas) From tbl_personel", baglantı);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                lblortmaas.Text = dr6[0].ToString();
            }
            baglantı.Close();
        }
    }
}
