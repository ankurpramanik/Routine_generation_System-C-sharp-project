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
    public partial class Faculty_search : Form
    {
        public Faculty_search()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlDataAdapter adpt;
        SqlCommand com;
        DataSet ds;
        private void button2_Click(object sender, EventArgs e)
        {
            Faculty_search.ActiveForm.Hide();
            new Faculty1().Show();
        }

        private void Faculty_search_Load(object sender, EventArgs e)
        {
            textBox1.Text = Login.fid.ToString();
            textBox1.Enabled = false;
            textBox2.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\pc\Documents\Visual Studio 2012\Projects\Routine_Generation_System2017\Routine_Generation_System2017\Routine.mdf;Integrated Security=True;");
            con.Open();
            string s = "select * from ClassDetails where FacultyID='" + textBox1.Text + "' and Subject='" + textBox2.Text + "'";
            adpt = new SqlDataAdapter();
            adpt.SelectCommand = new SqlCommand(s, con);
            ds = new DataSet();
            adpt.Fill(ds, "ClassDetails");
            if (ds.Tables["ClassDetails"].Rows.Count == 0)
            {
                MessageBox.Show("No record present");
            }
            dataGridView1.DataSource = ds.Tables["ClassDetails"];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
                new PrintDialog().ShowDialog().ToString();
        }
    }
}
