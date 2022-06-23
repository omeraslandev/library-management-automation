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
    public partial class KitapEkle : Form
    {
        public KitapEkle()
        {
            InitializeComponent();
        }
        void Clear()
        {
            txtName.Clear();
            txtAuthor.Clear();
            txtYayınevi.Clear();
            txtSayfaSayısı.Clear();
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            Baglanti connection = new Baglanti();

            connection.connect.Open();

            string query = "insert into Book (KitapAdi,KitapYazari,KitapYayinevi,KitapSayfaSayisi,KitapKayitTarihi,KitapEmanetDurum) values(@ad,@yazar,@yayinevi,@kitapsayfa,@kitaptarihi,@kitapemanet)";
            SqlCommand cmd = new SqlCommand(query, connection.connect);

            try
            {
                cmd.Parameters.AddWithValue("@ad", txtName.Text);
                cmd.Parameters.AddWithValue("@yazar", txtAuthor.Text);
                cmd.Parameters.AddWithValue("@yayinevi", txtYayınevi.Text);
                cmd.Parameters.AddWithValue("@kitapsayfa", txtSayfaSayısı.Text);
                cmd.Parameters.AddWithValue("@kitaptarihi", DateTime.Now.ToString());
                cmd.Parameters.AddWithValue("@kitapemanet", "False");

                cmd.ExecuteNonQuery();

                if (connection.connect.State == ConnectionState.Open)
                    connection.connect.Close();

                MessageBox.Show("Kitap eklendi.");

                Clear();
        }
            catch
            {
                MessageBox.Show("Kitap bilgilerini eksiksiz girdiğinze emin olun.");
            }
}
    }
}
