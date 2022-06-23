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
    public partial class KitapDuzenle : Form
    {
        public KitapDuzenle()
        {
            InitializeComponent();
        }

        void listbook()
        {
            Baglanti connection = new Baglanti();

            connection.connect.Open();

            string query = "select * from Book";
            SqlCommand cmd = new SqlCommand(query, connection.connect);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);

            dataGridView1.DataSource = dt;
            dataGridView1.ReadOnly = true;

            connection.connect.Close();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Baglanti connection = new Baglanti();

            connection.connect.Open();

            string query = "select * from Book where KitapID like @p";

            SqlCommand cmd = new SqlCommand(query, connection.connect);

            cmd.Parameters.AddWithValue("@p", txtSearch.Text + "%");

            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            adp.Fill(dt);

            dataGridView1.DataSource = dt;

            connection.connect.Close();
        }

        private void frmEditBook_Load(object sender, EventArgs e)
        {
            listbook();
        }

        void Clear()
        {
            txtName.Clear();
            txtAuthor.Clear();
            txtYayınevi.Clear();
            txtSayfaSayısı.Clear();
            txtSearch.Clear();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Baglanti connection = new Baglanti();

            connection.connect.Open();

            string query = "delete from Book where KitapAdi=@p";

            SqlCommand cmd = new SqlCommand(query, connection.connect);
            try
            {
                cmd.Parameters.AddWithValue("@p", dataGridView1.CurrentRow.Cells["KitapAdi"].Value.ToString());
            }
            catch
            {
                MessageBox.Show("Veritabanında kitap yok, kitap ekleyin.");
            }

            cmd.ExecuteNonQuery();

            connection.connect.Close();

            MessageBox.Show("Kitap silindi.");

            listbook();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Baglanti connection = new Baglanti();

            connection.connect.Open();

            string query = "update Book set KitapAdi=@kitapadi,KitapYazari=@kitapyazari," +
                "KitapYayinevi=@kitapyayinevi,KitapSayfaSayisi=@kitapsayfasayisi," +
                "KitapKayitTarihi=@kitapkayittarihi " +
                "where KitapID = @kitapid";

            SqlCommand cmd = new SqlCommand(query, connection.connect);

            cmd.Parameters.AddWithValue("@kitapadi", txtName.Text);
            cmd.Parameters.AddWithValue("@kitapyazari", txtAuthor.Text);
            cmd.Parameters.AddWithValue("@kitapyayinevi", txtYayınevi.Text);
            cmd.Parameters.AddWithValue("@kitapsayfasayisi", txtSayfaSayısı.Text);
            cmd.Parameters.AddWithValue("@kitapkayittarihi", DateTime.Now.ToString());
            cmd.Parameters.AddWithValue("kitapid", txtId.Text);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Kitap bilgileri güncellendi.");

            connection.connect.Close();

            listbook();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataGridView1.CurrentRow.Cells["KitapID"].Value.ToString();
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            Baglanti connection = new Baglanti();

            try
            {
                connection.connect.Open();

                string query = "select * from Book where KitapID like @p";

                SqlCommand cmd = new SqlCommand(query, connection.connect);

                cmd.Parameters.AddWithValue("@p", txtId.Text + "%");

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    txtId.Text = reader["KitapID"].ToString();
                    txtName.Text = reader["KitapAdi"].ToString();
                    txtAuthor.Text = reader["KitapYazari"].ToString();
                    txtYayınevi.Text = reader["KitapYayinevi"].ToString();
                    txtSayfaSayısı.Text = reader["KitapSayfaSayisi"].ToString();
                }

                reader.Close();
                connection.connect.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
