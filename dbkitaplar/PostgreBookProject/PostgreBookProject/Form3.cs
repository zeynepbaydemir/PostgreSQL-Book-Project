using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostgreBookProject
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=dbkitaplar; user ID=postgres; password=12345");
        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from yayinevleri";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into yayinevleri (yayineviid,yayineviad) values (@p1,@p2)", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut1.Parameters.AddWithValue("@p2", textBox2.Text);
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kategori ekleme işlemi başarılı bir şekilde gerçekleşti.");
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from yayinevleri";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
