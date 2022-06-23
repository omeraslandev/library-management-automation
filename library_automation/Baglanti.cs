using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace library_automation
{
    internal class Baglanti
    {
        private static string constring = "Data Source=DESKTOP-7MG97MU;Initial Catalog=LibraryAutomation;User ID=sa;Password=YXlhdG8=";
        public SqlConnection connect = new SqlConnection(constring);
    }
}
