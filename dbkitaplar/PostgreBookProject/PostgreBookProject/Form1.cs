using Npgsql;
using System.Data;

namespace PostgreBookProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=dbkitaplar; user ID=postgres; password=12345");
        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from kategoriler";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into kategoriler (kategoriid,kategoriad) values (@p1,@p2)", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(TxtKategorid.Text));
            komut1.Parameters.AddWithValue("@p2", txtAd.Text);
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kategori ekleme iþlemi baþarýlý bir þekilde gerçekleþti.");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {

        }

        private void BtnAra_Click(object sender, EventArgs e)
        {

        }
    }
}