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
    public partial class EmanetVer : Form
    {
        public EmanetVer()
        {
            InitializeComponent();
        }
        Baglanti connection = new Baglanti();

        void usercontrol()
        {
            connection.connect.Open();

            SqlCommand controlcmd = new SqlCommand("select (tc) from Users where tc=@tc",connection.connect);

            controlcmd.Parameters.AddWithValue("@tc", txtEmanetVerilenTc.Text);

            SqlDataReader dr = controlcmd.ExecuteReader();

            if( !dr.Read() )
            {
                MessageBox.Show("Böyle bir tc numarası sistemde mevcut değil.");
            }

            dr.Close();

            connection.connect.Close();
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {

            usercontrol();

            connection.connect.Open();

            SqlCommand cmd = new SqlCommand("select (KitapEmanetDurum) from Book where KitapID=@p", connection.connect);
            cmd.Parameters.AddWithValue("@p", txtId.Text);

            SqlDataReader dr = cmd.ExecuteReader();

            string Durum = "";
            if (dr.Read())
            {
                Durum = dr["KitapEmanetDurum"].ToString();
            }

            dr.Close();

            SqlCommand tccontrol = new SqlCommand("select (tc) from Users where tc=@tc", connection.connect);
            tccontrol.Parameters.AddWithValue("@tc", txtEmanetVerilenTc.Text);

            SqlDataReader tcdr = cmd.ExecuteReader();

            if (tcdr.Read())
            {
                tcdr.Close();
                if (Durum == "False")
                {
                    SqlCommand cmdd = new SqlCommand("update Book set KitapEmanetDurum='True',KitapEmanetEdilenTc=@tc where KitapID=@id", connection.connect);

                    cmdd.Parameters.AddWithValue("@id", txtId.Text);
                    cmdd.Parameters.AddWithValue("@tc", txtEmanetVerilenTc.Text);

                    cmdd.ExecuteNonQuery();

                    MessageBox.Show("Emanet verildi.");
                }
                else if (Durum == "True")
                    MessageBox.Show("Bu kitap zaten emanet edilmiş.");
                else
                    MessageBox.Show("Bu kitap veritabanında kayıtlı değil.");
            }
            else
            {
                MessageBox.Show("Bu tc veritabanında kayıtlı değil.");
            }

            connection.connect.Close();
        }
    }
}
