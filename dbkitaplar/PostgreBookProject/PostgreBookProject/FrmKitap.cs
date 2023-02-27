using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostgreBookProject
{
    public partial class FrmKitap : Form
    {
        public FrmKitap()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=dbkitaplar; user ID=postgres; password=12345");

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void FrmKitap_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlDataAdapter da =new NpgsqlDataAdapter("select * from kategoriler,yazarlar,yayinevleri",baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "kategoriad";
            comboBox2.DisplayMember = "yazarad";
            comboBox3.DisplayMember = "yayineviad";
            comboBox1.ValueMember = "kategoriid";
            comboBox2.ValueMember = "yazarid";
            comboBox3.ValueMember = "yayineviid";
            comboBox1.DataSource = dt;
            comboBox2.DataSource = dt;
            comboBox3.DataSource = dt;
            baglanti.Close();
        }
        //NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=dbkitaplar; user ID=postgres; password=12345");
        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from kitaplar";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //TxtAd.Text = comboBox1.SelectedValue.ToString();
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("insert into (kitapid,kitapad,stok,alisfiyat,satisfiyat,gorsel,kategori,yazar,yayinevi) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)",baglanti);
            komut.Parameters.AddWithValue("@p1", int.Parse(TxtID.Text));
            komut.Parameters.AddWithValue("@p2", TxtAd.Text);
            komut.Parameters.AddWithValue("@p3", int.Parse(numericUpDown1.Text));
            komut.Parameters.AddWithValue("@p4", double.Parse(TxtAlisFiyat.Text));
            komut.Parameters.AddWithValue("@p5", double.Parse(TxtSatisFiyat.Text));
            komut.Parameters.AddWithValue("@p6", textGorsel.Text);
            komut.Parameters.AddWithValue("@p7", int.Parse(comboBox1.SelectedValue.ToString()));
            komut.Parameters.AddWithValue("@p8", int.Parse(comboBox2.SelectedValue.ToString()));
            komut.Parameters.AddWithValue("@p9", int.Parse(comboBox3.SelectedValue.ToString()));
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ürün kaydı başarılı bir şekilde gerçekleşti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut22 = new NpgsqlCommand("Delete From kitaplar where kitapid=@p1",baglanti);
            komut22.Parameters.AddWithValue("@p1", int.Parse(TxtID.Text));
            komut22.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ürün silme işlemi başarlı bir şekilde gerçekleşti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut3 = new NpgsqlCommand("update kitaplar set kitapad=@p1,stok=@p2,alisfiyat=@p3 where kitapid=@p4",baglanti);
            komut3.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut3.Parameters.AddWithValue("@p2", int.Parse(numericUpDown1.Value.ToString()));
            komut3.Parameters.AddWithValue("@p3", double.Parse(TxtAlisFiyat.Text));
            komut3.Parameters.AddWithValue("@p4", int.Parse(TxtID.Text));
            komut3.ExecuteNonQuery();
            MessageBox.Show("Ürün güncelleme başarılı bir şekilde gerçekleşti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            baglanti.Close();

        }
    }
}
