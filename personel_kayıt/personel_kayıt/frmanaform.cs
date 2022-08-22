﻿using System;
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
    public partial class frmanaform : Form
    {
        public frmanaform()
        {
            InitializeComponent();
        }

      SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-5R80TPD\\;Initial Catalog=personelveritabani;Integrated Security=True");

        void temizle()
        {
            txtpersonelid.Text = "";
            txtad.Text = "";
            txtmeslek.Text = "";
            txtsoyad.Text = "";
            cmbsehir.Text = "";
            mtxtbmaas.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            txtad.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.tbl_personelTableAdapter.Fill(this.personelveritabaniDataSet.tbl_personel);

        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            this.tbl_personelTableAdapter.Fill(this.personelveritabaniDataSet.tbl_personel);
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("insert into tbl_personel (perad, persoyad, permaas, persehir, permeslek, perdurum) values (@p1, @p2, @p3, @p4, @p5, @p6)",baglantı);
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", mtxtbmaas.Text);
            komut.Parameters.AddWithValue("@p4", cmbsehir.Text);
            komut.Parameters.AddWithValue("@p5", txtmeslek.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text);
            komut.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Personel eklendi");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
           if(radioButton1.Checked == true)
            {
                label8.Text = "True";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label8.Text = "False";
            }
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen= dataGridView1.SelectedCells[0].RowIndex;

            txtpersonelid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbsehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mtxtbmaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtmeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();

        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if(label8.Text == "True")
            {
                radioButton1.Checked = true;
            }
            if(label8.Text == "False")
            {
                radioButton2.Checked = true;
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komutsil = new SqlCommand("Delete From tbl_personel where perid=@k1", baglantı);
            komutsil.Parameters.AddWithValue("@k1", txtpersonelid.Text);
            komutsil.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Kayıt Silindi");
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komutguncelle = new SqlCommand("update tbl_personel set perad=@a1, persoyad=@a2, persehir=@a3, permaas=@a4, perdurum=@a5,permeslek=@a6 where perid=@a7", baglantı);
            komutguncelle.Parameters.AddWithValue("@a1", txtad.Text);
            komutguncelle.Parameters.AddWithValue("@a2", txtsoyad.Text);
            komutguncelle.Parameters.AddWithValue("@a3", cmbsehir.Text);
            komutguncelle.Parameters.AddWithValue("@a4", mtxtbmaas.Text);
            komutguncelle.Parameters.AddWithValue("@a5", label8.Text);
            komutguncelle.Parameters.AddWithValue("@a6", txtmeslek.Text);
            komutguncelle.Parameters.AddWithValue("@a7", txtpersonelid.Text);
            komutguncelle.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Personel Bilgi Güncellendi");

        }

        private void btnistatistik_Click(object sender, EventArgs e)
        {
            Frmistatistik fr = new Frmistatistik();
            fr.Show();
        }

        private void btngrafikler_Click(object sender, EventArgs e)
        {
            frmgrafikler frg = new frmgrafikler();
            frg.Show();
        }
    }
}
