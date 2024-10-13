using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace nypodevgano
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public void verileri_goster(string txt)
        {

            conn.Open();
            NpgsqlCommand komut = new NpgsqlCommand();
            komut.Connection = conn;
            komut.CommandType = CommandType.Text;
            komut.CommandText = txt;
            NpgsqlDataReader dr = komut.ExecuteReader();

            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            komut.Dispose();
            conn.Close();
            dr.Close();
        }


        NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=ganoapp;User Id=postgres;Password=1234");

        private void Form2_Load(object sender, EventArgs e)
        {
            conn.Open();
            NpgsqlCommand komut_guncelle = new NpgsqlCommand();
            komut_guncelle.Connection = conn;

            komut_guncelle.Parameters.AddWithValue("@kod", textBox1.Text);
            komut_guncelle.Parameters.AddWithValue("@ad", textBox3.Text);
            komut_guncelle.Parameters.AddWithValue("@kredi", Convert.ToInt32(textBox5.Text));
            komut_guncelle.Parameters.AddWithValue("@akts", Convert.ToInt32(textBox7.Text));
            komut_guncelle.Parameters.AddWithValue("@ogruye", textBox6.Text);
            komut_guncelle.Parameters.AddWithValue("@donem", Convert.ToInt32(textBox4.Text));
            komut_guncelle.Parameters.AddWithValue("@puan", Convert.ToInt32(textBox2.Text));
            komut_guncelle.Parameters.AddWithValue("@hangiKod", hangiKod.Text);

            komut_guncelle.CommandType = CommandType.Text;
            komut_guncelle.CommandText = "update ders set kod= @kod, ad = @ad, kredi = @kredi, akts = @akts, ogruye = @ogruye, donem = @donem, puan = @puan where kod = @hangiKod";
            NpgsqlDataReader dr = komut_guncelle.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            komut_guncelle.Dispose();
            conn.Close();

            verileri_goster("select * from ders");
        }

        private void hangiKod_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
