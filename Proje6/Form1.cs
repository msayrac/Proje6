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


namespace Proje6
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		SqlConnection baglanti = new SqlConnection(@"Data Source=msyc;Initial Catalog=Proje6;Integrated Security=True");

		private void Form1_Load(object sender, EventArgs e)
		{
			// TODO: This line of code loads data into the 'proje6DataSet.URUNLER' table. You can move, or remove it, as needed.
			this.uRUNLERTableAdapter.Fill(this.proje6DataSet.URUNLER);
			baglanti.Open();
			SqlDataAdapter da = new SqlDataAdapter("Execute Proje6", baglanti);

			DataTable dt = new DataTable();
			da.Fill(dt);
			dataGridView1.DataSource = dt;
			baglanti.Close();
		}

		private void comboBox1_Click(object sender, EventArgs e)
		{
			baglanti.Open();

			SqlCommand cmd = new SqlCommand("Select AD From URUNLER", baglanti);

			SqlDataReader dr = cmd.ExecuteReader();

			while (dr.Read())
			{
				comboBox1.Items.Add(dr[0]).ToString();
			}
			baglanti.Close();
		}

		private void comboBox2_Click(object sender, EventArgs e)
		{
			baglanti.Open();

			SqlCommand cmd = new SqlCommand("Select AD From PERSONELLER", baglanti);

			SqlDataReader dr = cmd.ExecuteReader();

			while (dr.Read())
			{
				comboBox2.Items.Add(dr[0]).ToString();
			}
			baglanti.Close();
		}
	}
}
