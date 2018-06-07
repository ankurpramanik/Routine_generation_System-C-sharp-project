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
    public partial class Add_faculty : Form
    {
        public Add_faculty()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand com;
        SqlDataAdapter adpt;
        DataSet ds;

        private void Add_faculty_Load(object sender, EventArgs e)
        {
                con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\pc\Documents\Visual Studio 2012\Projects\Routine_Generation_System2017\Routine_Generation_System2017\Routine.mdf;Integrated Security=True;");
                con.Open();
                string s = "select * from Faculty";
                adpt = new SqlDataAdapter();
                adpt.SelectCommand = new SqlCommand(s, con);
                ds = new DataSet();
                adpt.Fill(ds, "Faculty");
                int rec=ds.Tables["Faculty"].Rows.Count;
                rec=rec+1;
                String fid = "PCMTF" + rec.ToString();
                textBox1.Enabled = false;
                textBox1.Text = fid.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Equals(""))
            {
                MessageBox.Show("Enter Faculty Name");
                textBox2.Focus();
            }
            else if (textBox3.Text.Equals(""))
            {
                MessageBox.Show("Enter Subject Preference");
                textBox3.Focus();
            }
            else if (comboBox1.Text.Equals("Select"))
            {
                MessageBox.Show("Select Department");
                comboBox1.Focus();
                
            }
            else
            {
                con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\pc\Documents\Visual Studio 2012\Projects\Routine_Generation_System2017\Routine_Generation_System2017\Routine.mdf;Integrated Security=True;");
                con.Open();
                string s;
                s = "Insert into Faculty values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox1.SelectedItem.ToString() + "')";
                com = new SqlCommand(s, con);
                com.ExecuteNonQuery();
                MessageBox.Show("Faculty has been added successfully");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                comboBox1.Text="";
                textBox1.Focus();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Add_faculty.ActiveForm.Hide();
            new Administrator1().Show();
        }
    }
}
