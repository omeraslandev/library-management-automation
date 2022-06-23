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
    public partial class UyeListele : Form
    {
        public UyeListele()
        {
            InitializeComponent();
        }
        Baglanti connection = new Baglanti();
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            connection.connect.Open();

            string query = "select * from Users where tc like @p";

            SqlCommand cmd = new SqlCommand(query, connection.connect);

            cmd.Parameters.AddWithValue("@p", txtSearch.Text + "%");

            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            adp.Fill(dt);

            dataGridView1.DataSource = dt;

            connection.connect.Close();
        }

        private void frmListUser_Load(object sender, EventArgs e)
        {
            connection.connect.Open();

            string query = "select * from Users";

            SqlCommand cmd = new SqlCommand(query, connection.connect);

            cmd.Parameters.AddWithValue("@p", txtSearch.Text);

            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            adp.Fill(dt);

            dataGridView1.DataSource = dt;

            connection.connect.Close();
        }
    }
}
