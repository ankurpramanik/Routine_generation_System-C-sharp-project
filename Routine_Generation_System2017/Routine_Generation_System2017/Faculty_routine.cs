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
    public partial class Faculty_routine : Form
    {
        public Faculty_routine()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlDataAdapter adpt;
        SqlCommand com;
        DataSet ds;
        private void button1_Click(object sender, EventArgs e)
        {
            Faculty_routine.ActiveForm.Hide();
            new Faculty1().Show();
        }

        private void Faculty_routine_Load(object sender, EventArgs e)
        {
            textBox1.Text = Login.fid.ToString();
            textBox1.Enabled = false;
            comboBox1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\pc\Documents\Visual Studio 2012\Projects\Routine_Generation_System2017\Routine_Generation_System2017\Routine.mdf;Integrated Security=True;");
            con.Open();
            string s = "select * from Routine where FacultyID='" + textBox1.Text + "' and Day='" + comboBox1.SelectedItem.ToString() + "'";
            adpt = new SqlDataAdapter();
            adpt.SelectCommand = new SqlCommand(s, con);
            ds = new DataSet();
            adpt.Fill(ds, "Routine");
            if (ds.Tables["Routine"].Rows.Count == 0)
            {
                MessageBox.Show("No record present");
            }
            dataGridView1.DataSource = ds.Tables["Routine"];
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
