using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TokoPunakawan
{
    public partial class MenuPemesanan : Form
    {
        public MenuPemesanan()
        {
            InitializeComponent();
            Fill_Combo_Menu();
        }
        void Fill_Combo_Menu()
        {
            SqlConnection conn = new SqlConnection("Data Source=ALFIN\\ALFINKS;Initial Catalog=Toko_Punakawan;User ID=sa;Password=maulana");
            SqlCommand query = new SqlCommand("Select * From Menu_Makanan ", conn);
            SqlDataAdapter sda = new SqlDataAdapter(query);

            try
            {
                conn.Open();
                DataTable dt = new DataTable();
                sda.Fill(dt);

                cb_Menu.DisplayMember = "Id_Menu";
                cb_Menu.DataSource = dt;
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        void insertData()
        {
            SqlConnection conn = new SqlConnection("Data Source=ALFIN\\ALFINKS;Initial Catalog=Toko_Punakawan;User ID=sa;Password=maulana");
            try
            {
                conn.Open();
                SqlCommand insert = new SqlCommand("INSERT INTO Pemesananan (Id_Pemesanan, Id_Menu,Nama_Makanan,Jenis_Menu,Harga) VALUES" +
                    "('" + Id_Pemesanan.Text + "','" + cb_Menu.Text + "','" + Nama_Makanan.Text + "', '" + Jenis_Menu.Text + "','" + Harga.Text + "')", conn);
                insert.ExecuteNonQuery();
                conn.Close();
                getData();
                MessageBox.Show("Success Save Data");
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }
        void getData()
        {
            SqlConnection conn = new SqlConnection("Data Source=ALFIN\\ALFINKS;Initial Catalog=Toko_Punakawan;User ID=sa;Password=maulana");
            try
            {
                conn.Open();
                SqlCommand show = new SqlCommand("SELECT * FROM Pemesananan", conn);
                SqlDataAdapter sda = new SqlDataAdapter(show);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }


        private void MenuPemesanan_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'toko_PunakawanDataSet.Pemesananan' table. You can move, or remove it, as needed.
            this.pemesanananTableAdapter.Fill(this.toko_PunakawanDataSet.Pemesananan);
            Nama_Makanan.Enabled = false;
            Jenis_Menu.Enabled = false;
            Harga.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            insertData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                Id_Pemesanan.Text = dataGridView1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                cb_Menu.Text = dataGridView1.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                Nama_Makanan.Text = dataGridView1.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                Jenis_Menu.Text = dataGridView1.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                Harga.Text = dataGridView1.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
            }
        }

        private void cb_Menu_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=ALFIN\\ALFINKS;Initial Catalog=Toko_Punakawan;User ID=sa;Password=maulana");
            SqlCommand query = new SqlCommand("Select * From Menu_Makanan where Id_Menu = '" + cb_Menu.Text + "'", conn);
            SqlDataReader sdr;

            try
            {
                conn.Open();
                sdr = query.ExecuteReader();
                while (sdr.Read())
                {
                    Nama_Makanan.Text = sdr.GetString(1);
                    Jenis_Menu.Text = sdr.GetString(2);
                    Harga.Text = sdr.GetInt32(3).ToString();
                }
            }
            catch (Exception et)
            {
                MessageBox.Show(et.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Id_Pemesanan.Text = "";
            cb_Menu.Text = "";
            Nama_Makanan.Text = "";
            Jenis_Menu.Text = "";
            Harga.Text = "";

            Id_Pemesanan.Focus();
        }

        private void Harga_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
