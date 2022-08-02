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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Data Source=DESKTOP-6TUVH6H;Initial Catalog=DbistanbulAkademi;Integrated Security=True

        private void btnList_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-6TUVH6H;Initial Catalog=DbistanbulAkademi;Integrated Security=True");

            connection.Open();
            
            SqlCommand command = new SqlCommand("Select * from TblCategory",connection);//sorgu connectiondaki veritabanında çalışacak ondan dolayı, connection diye 2.parametreyi oluşturduk

            SqlDataAdapter adapter = new SqlDataAdapter(command);//datagridview e veri çekmek için kullanılır

            DataTable dataTable = new DataTable();//sanal tablom
            
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            connection.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-6TUVH6H;Initial Catalog=DbistanbulAkademi;Integrated Security=True");

            connection.Open();

            SqlCommand command = new SqlCommand("insert into TblCategory (CategoryName) Values (@p1)", connection);//sorgu connectiondaki veritabanında çalışacak ondan dolayı, connection diye 2.parametreyi oluşturduk

            command.Parameters.AddWithValue("@p1", txtCategoryName.Text);
            command.ExecuteNonQuery();//ilgili değişikliği veritabanına yansıt,kaydet
            connection.Close();
            MessageBox.Show("Kategori eklendi.");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-6TUVH6H;Initial Catalog=DbistanbulAkademi;Integrated Security=True");

            connection.Open();

            SqlCommand command = new SqlCommand("delete from TblCategory Where CategoryId=@p1", connection);
            command.Parameters.AddWithValue("@p1", txtCategoryId.Text);
            command.ExecuteNonQuery();//ilgili değişikliği veritabanına yansıt,kaydet

            connection.Close();
            MessageBox.Show("Kategori silindi");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-6TUVH6H;Initial Catalog=DbistanbulAkademi;Integrated Security=True");

            connection.Open();

            SqlCommand command = new SqlCommand("update TblCategory set CategoryName=@p1 where CategoryId=@p2", connection);

            command.Parameters.AddWithValue("@p1", txtCategoryName.Text);
            command.Parameters.AddWithValue("@p2", txtCategoryId.Text);

            command.ExecuteNonQuery();//ilgili değişikliği veritabanına yansıt,kaydet

            connection.Close();
            MessageBox.Show("Kategori güncellendi");
        }
    }
}
