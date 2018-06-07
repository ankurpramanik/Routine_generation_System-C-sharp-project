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
    public partial class Modify_faculty : Form
    {
        public Modify_faculty()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlDataAdapter adpt;
        SqlCommand com;
        DataSet ds;
        private void button4_Click(object sender, EventArgs e)
        {
            Modify_faculty.ActiveForm.Hide();
            new Administrator1().Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Modify_faculty_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\pc\Documents\Visual Studio 2012\Projects\Routine_Generation_System2017\Routine_Generation_System2017\Routine.mdf;Integrated Security=True;");
            con.Open();
            string s = "select FacultyID from Faculty";
            adpt = new SqlDataAdapter();
            adpt.SelectCommand = new SqlCommand(s, con);
            ds = new DataSet();
            adpt.Fill(ds, "Faculty");
            comboBox1.Items.Clear();
            if (ds.Tables["Faculty"].Rows.Count == 0)
            {
                MessageBox.Show("No. Faculty Exists");
                comboBox1.Enabled = false;

            }
            else
            {
                comboBox1.Enabled = true;
                int cnt = ds.Tables["Faculty"].Rows.Count;

                for (int i = 0; i < cnt; i++)
                {
                    comboBox1.Items.Add(ds.Tables["Faculty"].Rows[i]["FacultyID"].ToString());
                }
            }
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\pc\Documents\Visual Studio 2012\Projects\Routine_Generation_System2017\Routine_Generation_System2017\Routine.mdf;Integrated Security=True;");
            con.Open();
            string s = "select * from Faculty where FacultyID='" + comboBox1.SelectedItem.ToString() + "'";
            adpt = new SqlDataAdapter();
            adpt.SelectCommand = new SqlCommand(s, con);
            ds = new DataSet();
            adpt.Fill(ds, "Faculty");
            textBox2.Enabled = true;
            if (ds.Tables["Faculty"].Rows.Count != 0)
            {
                textBox1.Text = ds.Tables["Faculty"].Rows[0]["FacultyName"].ToString();
                textBox2.Text = ds.Tables["Faculty"].Rows[0]["Subject"].ToString();
                textBox3.Text = ds.Tables["Faculty"].Rows[0]["Department"].ToString();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\pc\Documents\Visual Studio 2012\Projects\Routine_Generation_System2017\Routine_Generation_System2017\Routine.mdf;Integrated Security=True;");
            con.Open();
            string s;
            s = "Update Faculty set Subject='" + textBox2.Text + "' where FacultyId='" + comboBox1.SelectedItem.ToString() + "'";
            com = new SqlCommand(s, con);
            com.ExecuteNonQuery();
            MessageBox.Show("Faculty has been updated successfully");
            textBox2.Enabled = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\pc\Documents\Visual Studio 2012\Projects\Routine_Generation_System2017\Routine_Generation_System2017\Routine.mdf;Integrated Security=True;");
            con.Open();
            string s;
            s = "delete Faculty where FacultyId='" + comboBox1.SelectedItem.ToString() + "'";
            com = new SqlCommand(s, con);
            com.ExecuteNonQuery();
            MessageBox.Show("Faculty has been deleted successfully");
            textBox2.Enabled = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        }
    }

