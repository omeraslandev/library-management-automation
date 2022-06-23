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
    public partial class UyeDuzenle : Form
    {
        public UyeDuzenle()
        {
            InitializeComponent();
        }
        void Clear()
        {
            txtTc.Clear();
            txtName.Clear();
            txtSurname.Clear();
            txtEmail.Clear();
            txtAge.Clear();
            cmbGender.Text = "Cinsiyet";
            txtPhone.Clear();
            txtAdress.Clear();
            txtSearch.Clear();
        }
        Baglanti connection = new Baglanti();

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTc.Text = dataGridView1.CurrentRow.Cells["tc"].Value.ToString();
        }
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

        void listusers()
        {
            connection.connect.Open();

            string query = "select * from Users";

            SqlCommand cmd = new SqlCommand(query, connection.connect);

            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            adp.Fill(dt);

            dataGridView1.DataSource = dt;

            connection.connect.Close();
        }

        private void EditUser_Load(object sender, EventArgs e)
        {
            listusers();
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            connection.connect.Open();

            string query = "update Users set tc=@tc,isim=@isim,soyisim=@soyisim,email=@email,yas=@yas,cinsiyet=@cinsiyet,telefon=@telefon,adres=@adres where tc=@tc";
            SqlCommand cmd = new SqlCommand(query, connection.connect);

            cmd.Parameters.AddWithValue("@tc", txtTc.Text);
            cmd.Parameters.AddWithValue("@isim", txtName.Text);
            cmd.Parameters.AddWithValue("@soyisim", txtSurname.Text);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@yas", txtAge.Text);
            cmd.Parameters.AddWithValue("@cinsiyet", cmbGender.Text);
            cmd.Parameters.AddWithValue("@telefon", txtPhone.Text);
            cmd.Parameters.AddWithValue("@adres", txtAdress.Text);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Üye bilgileri güncellendi.");

            connection.connect.Close();

            listusers();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            connection.connect.Open();

            string query = "delete from Users where tc=@p";

            SqlCommand cmd = new SqlCommand(query, connection.connect);
            try
            {
                cmd.Parameters.AddWithValue("@p", dataGridView1.CurrentRow.Cells["tc"].Value.ToString());
            }
            catch
            {
                MessageBox.Show("Veritabanında üye yok, üye ekleyin.");
            }

            cmd.ExecuteNonQuery();

            connection.connect.Close();

            MessageBox.Show("Üye silindi.");

            listusers();
        }

        private void txtTc_TextChanged(object sender, EventArgs e)
        {
            connection.connect.Open();

            string query = "select * from Users where tc like @p";

            SqlCommand cmd = new SqlCommand(query, connection.connect);

            cmd.Parameters.AddWithValue("@p", txtTc.Text + "%");

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                txtName.Text = reader["isim"].ToString();
                txtSurname.Text = reader["soyisim"].ToString();
                txtEmail.Text = reader["email"].ToString();
                txtAge.Text = reader["yas"].ToString();
                cmbGender.Text = reader["cinsiyet"].ToString();
                txtPhone.Text = reader["telefon"].ToString();
                txtAdress.Text = reader["adres"].ToString();
            }

            reader.Close();
            connection.connect.Close();
        }

        private void cmbGender_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
