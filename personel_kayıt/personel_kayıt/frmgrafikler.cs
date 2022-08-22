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
    public partial class frmgrafikler : Form
    {
        public frmgrafikler()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-5R80TPD\\;Initial Catalog=personelveritabani;Integrated Security=True");

        private void frmgrafikler_Load(object sender, EventArgs e)
        {
            //sehirler
            baglantı.Open();
            SqlCommand komutg1 = new SqlCommand("select persehir, count(*) from tbl_personel Group by persehir", baglantı);
            SqlDataReader dr1 = komutg1.ExecuteReader();
            while (dr1.Read())
            {
                chart1.Series["Sehirler"].Points.AddXY(dr1[0], dr1[1]);
            }
            baglantı.Close();

            //ortalama maas
            baglantı.Open();
            SqlCommand komutg2 = new SqlCommand("select permeslek, avg(permaas) From tbl_personel Group by permeslek", baglantı);
            SqlDataReader dr2 = komutg2.ExecuteReader();
            while (dr2.Read())
            {
                chart2.Series["Meslek-Maas"].Points.AddXY(dr2[0], dr2[1]);
            }
            baglantı.Close();

        }
    }
}
