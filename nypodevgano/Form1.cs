using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace nypodevgano
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=ganoapp;User Id=postgres;Password=1234");

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
            conn.Close();
            conn.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("SELECT SUM(puan) FROM ders", conn);
            object totalPuan = cmd.ExecuteScalar();

            conn.Close();
            conn.Open();

            NpgsqlCommand cmdd = new NpgsqlCommand("SELECT SUM(kredi) FROM ders", conn);
            object totalKredi = cmd.ExecuteScalar();

            conn.Close();

            decimal gano = 3.21 M;   

            string harfNotu=null;
            if ((float)gano < 3.50)
            {
                harfNotu="AA";
            }
            else if ((float)gano > 3.00 && (float)gano < 3.50)
            {
                harfNotu = "BA";
            }
            else if((float)gano<3.00 && (float)gano >2.50)
            {
                harfNotu = "BB";
            }
            else if ((float)gano < 2.50 && (float)gano > 2.00)
            {
                harfNotu = "CB";
            }
            else if ((float)gano < 2.00 && (float)gano > 1.50)
            {
                harfNotu = "CC";
            }
            else if ((float)gano < 1.50 && (float)gano > 1.00)
            {
                harfNotu = "DC";
            }
            else if ((float)gano < 1.00 && (float)gano > 0.50)
            {
                harfNotu = "DD";
            }
            else if ((float)gano < 0.50 && (float)gano > 0.00)
            {
                harfNotu = "FD";
            }
            else if ((float)gano == 0)
            {
                harfNotu = "FF";
            }

            ganotxt.Text="GANO :" + gano.ToString() + "   " + "HARF NOTU : " + harfNotu ;
            
            

            cmd.Dispose();
            cmdd.Dispose();
            komut.Dispose();           
            dr.Close();
           
           
        }


        private void button2_Click(object sender, EventArgs e)
        {
            verileri_goster("select * from ders");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            NpgsqlCommand komut_sil = new NpgsqlCommand();  

            komut_sil.Connection = conn;
            komut_sil.Parameters.AddWithValue("@hangiKod", hangiKod);

            komut_sil.CommandType = CommandType.Text;
            komut_sil.CommandText = "delete from ders where Kod = @hangiKod";

            NpgsqlDataReader dr = komut_sil.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            komut_sil.Dispose();
            conn.Close();

            verileri_goster("select * from ders");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();

            form3.StartPosition = FormStartPosition.CenterParent;
            form3.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            Form2 form2 = new Form2();
            form2.StartPosition = FormStartPosition.CenterParent;
            form2.Show();
          
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
