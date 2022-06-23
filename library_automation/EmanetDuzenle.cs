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
    public partial class EmanetDuzenle : Form
    {
        public EmanetDuzenle()
        {
            InitializeComponent();
        }
        Baglanti connection = new Baglanti();

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            connection.connect.Open();

            SqlCommand cmd = new SqlCommand("select (KitapEmanetDurum) from Book where KitapID=@id and KitapEmanetEdilenTc=@tc", connection.connect);

            cmd.Parameters.AddWithValue("@id", txtId.Text);
            cmd.Parameters.AddWithValue("@tc", txtEmanetVerilenTc.Text);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                dr.Close();
                SqlCommand updatecmd = new SqlCommand("update Book set KitapEmanetDurum='False',KitapEmanetEdilenTC='' where KitapID=@id and KitapEmanetEdilenTc=@tc", connection.connect);
                updatecmd.Parameters.AddWithValue("@id", txtId.Text);
                updatecmd.Parameters.AddWithValue("@tc", txtEmanetVerilenTc.Text);
                updatecmd.ExecuteNonQuery();

                MessageBox.Show("Emanet geri alınmıştır.");
            }
            else
            {
                MessageBox.Show("Böyle bir emanet kaydı yok.");
            }

            connection.connect.Close();
        }
    }
}
