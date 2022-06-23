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
    public partial class UyeEkle : Form
    {
        public UyeEkle()
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
        }

        private void cmbGender_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnEkle_Click_1(object sender, EventArgs e)
        {
            Baglanti connection = new Baglanti();

            connection.connect.Open();

            string query = "insert into Users (tc,isim,soyisim,email,yas,cinsiyet,telefon,adres) values(@tc,@isim,@soyisim,@email,@yas,@cinsiyet,@telefon,@adres)";
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

            if (connection.connect.State == ConnectionState.Open)
                connection.connect.Close();

            MessageBox.Show("Üye eklendi.");

            Clear();
        }
    }
}
