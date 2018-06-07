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
    public partial class Admin_search : Form
    {
        public Admin_search()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlDataAdapter adpt;
        SqlCommand com;
        DataSet ds;
        private void button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\pc\Documents\Visual Studio 2012\Projects\Routine_Generation_System2017\Routine_Generation_System2017\Routine.mdf;Integrated Security=True;");
            con.Open();
            string s = "select * from Routine where FacultyID='" + comboBox1.SelectedItem.ToString() + "'";
            adpt = new SqlDataAdapter();
            adpt.SelectCommand = new SqlCommand(s, con);
            ds = new DataSet();
            adpt.Fill(ds, "Routine");
            if (ds.Tables["Routine"].Rows.Count == 0)
            {
                MessageBox.Show("No faculty present");
            }
            dataGridView1.DataSource = ds.Tables["Routine"];
        }

        private void Admin_search_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\pc\Documents\Visual Studio 2012\Projects\Routine_Generation_System2017\Routine_Generation_System2017\Routine.mdf;Integrated Security=True;");
            con.Open();
            string s = "select FacultyID from Routine";
            adpt = new SqlDataAdapter();
            adpt.SelectCommand = new SqlCommand(s, con);
            ds = new DataSet();
            adpt.Fill(ds, "Routine");
            comboBox1.Items.Clear();
            if (ds.Tables["Routine"].Rows.Count == 0)
            {
                MessageBox.Show("No. Faculty Exists in this ID");
                

            }
            else
            {
                comboBox1.Enabled = true;
                int cnt = ds.Tables["Routine"].Rows.Count;

                for (int i = 0; i < cnt; i++)
                {
                    comboBox1.Items.Add(ds.Tables["Routine"].Rows[i]["FacultyID"].ToString());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin_search.ActiveForm.Hide();
            new Administrator1().Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
