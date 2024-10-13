using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nypodevgano
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

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


        private void button1_Click(object sender, EventArgs e)
        {


            conn.Open();
            NpgsqlCommand komut_ekle = new NpgsqlCommand();
            komut_ekle.Connection = conn;

            komut_ekle.Parameters.AddWithValue("@kod", textBox1.Text);
            komut_ekle.Parameters.AddWithValue("@ad", textBox3.Text);
            komut_ekle.Parameters.AddWithValue("@kredi", Convert.ToInt32(textBox5.Text));
            komut_ekle.Parameters.AddWithValue("@akts", Convert.ToInt32(textBox7.Text));
            komut_ekle.Parameters.AddWithValue("@ogruye", textBox6.Text);
            komut_ekle.Parameters.AddWithValue("@donem", Convert.ToInt32(textBox4.Text));
            komut_ekle.Parameters.AddWithValue("@puan", Convert.ToDecimal(textBox2.Text));
         

            komut_ekle.CommandType = CommandType.Text;
            komut_ekle.CommandText = "insert into ders (kod, ad, kredi, akts, ogruye, donem, puan) values (@kod, @ad, @kredi, @akts, @ogruye, @donem, @puan)";
            conn.Close();
            conn.Open();

            NpgsqlDataReader dr = komut_ekle.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }

            

            conn.Close();
            komut_ekle.Dispose();

            verileri_goster("select * from ders");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
