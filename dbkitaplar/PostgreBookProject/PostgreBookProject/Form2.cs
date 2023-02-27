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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        NpgsqlConnection bglnti = new NpgsqlConnection("server=localHost; port=5432; Database=dbkitaplar; user ID=postgres; password=12345");
        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from yazarlar";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, bglnti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bglnti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("insert into kategoriler (yazarid,yazarad) values (@p1,@p2)", bglnti);
            komut2.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut2.Parameters.AddWithValue("@p2", textBox2.Text);
            komut2.ExecuteNonQuery();
            bglnti.Close();
            MessageBox.Show("Ekleme işlemi başarılı bir şekilde gerçekleşti.");
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
