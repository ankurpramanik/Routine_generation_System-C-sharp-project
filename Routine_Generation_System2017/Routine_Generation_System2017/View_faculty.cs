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
namespace Routine_Generation_System2017
{
    public partial class View_faculty : Form
    {
        public View_faculty()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlDataAdapter adpt;
        SqlCommand com;
        DataSet ds;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\pc\Documents\Visual Studio 2012\Projects\Routine_Generation_System2017\Routine_Generation_System2017\Routine.mdf;Integrated Security=True;");
            con.Open();
            string s = "select * from Faculty where Department='" + comboBox1.SelectedItem.ToString() + "'";
            adpt = new SqlDataAdapter();
            adpt.SelectCommand = new SqlCommand(s, con);
            ds = new DataSet();
            adpt.Fill(ds, "Faculty");
            if (ds.Tables["Faculty"].Rows.Count == 0)
            {
                MessageBox.Show("No faculty present in this department");
            }
            dataGridView1.DataSource = ds.Tables["Faculty"];
            //dataGridView1.DataBind();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            View_faculty.ActiveForm.Hide();
            new Administrator1().Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void View_faculty_Load(object sender, EventArgs e)
        {

        }
    }
}
