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

namespace library_automation
{
    public partial class KitapListele : Form
    {
        public KitapListele()
        {
            InitializeComponent();
        }
        Baglanti connection = new Baglanti();
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            connection.connect.Open();

            string query = "select * from Book where KitapAdi like @p";

            SqlCommand cmd = new SqlCommand(query, connection.connect);

            cmd.Parameters.AddWithValue("@p", txtSearch.Text + "%");

            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            adp.Fill(dt);

            dataGridView1.DataSource = dt;

            connection.connect.Close();
        }

        private void frmListBook_Load(object sender, EventArgs e)
        {
            connection.connect.Open();

            string query = "select * from Book";

            SqlCommand cmd = new SqlCommand(query, connection.connect);

            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            adp.Fill(dt);

            dataGridView1.DataSource = dt;

            connection.connect.Close();
        }
    }
}
