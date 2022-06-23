using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace library_automation
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            KitapEkle adb = new KitapEkle();
            adb.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KitapDuzenle edb = new KitapDuzenle();
            edb.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KitapListele lb = new KitapListele();
            lb.ShowDialog();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {

        }

        private void btnHakkinda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Github: ayaato");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            UyeEkle adu = new UyeEkle();
            adu.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            UyeDuzenle edu = new UyeDuzenle();
            edu.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            UyeListele liu = new UyeListele();
            liu.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EmanetVer emv = new EmanetVer();
            emv.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EmanetDuzenle emd = new EmanetDuzenle();
            emd.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EmanetListele eml = new EmanetListele();
            eml.Show();
        }
    }
}
