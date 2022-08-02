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

namespace _02082022_MuratYucedag_AdoNetDemo
{
    public partial class FrmProduct : Form
    {
        public FrmProduct()
        {
            InitializeComponent();
        }
        
        private void btnList_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-6TUVH6H;Initial Catalog=DbistanbulAkademi;Integrated Security=True");

            connection.Open();

            SqlCommand command = new SqlCommand("Select * from TblProduct", connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);//datagridview e veri çekmek için kullanılır

            DataTable dataTable = new DataTable();//sanal tablom

            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            connection.Close();
        }
    }
}
