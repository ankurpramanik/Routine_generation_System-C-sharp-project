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
    public partial class Add_subject : Form
    {
        public Add_subject()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand com;
        SqlDataAdapter adpt;
        DataSet ds;

        private void Add_subject_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\pc\Documents\Visual Studio 2012\Projects\Routine_Generation_System2017\Routine_Generation_System2017\Routine.mdf;Integrated Security=True;");
            con.Open();
            string s = "select * from Subject";
            adpt = new SqlDataAdapter();
            adpt.SelectCommand = new SqlCommand(s, con);
            ds = new DataSet();
            adpt.Fill(ds, "Subject");
            int rec = ds.Tables["Subject"].Rows.Count;
            rec = rec + 1;
            String sid = "PCMTS" + rec.ToString();
            textBox1.Enabled = false;
            textBox1.Text = sid.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             if (textBox2.Text.Equals(""))
            {
                MessageBox.Show("Enter Subject Name");
                textBox2.Focus();
            }
            else if (comboBox1.Text.Equals("Select"))
            {
                MessageBox.Show("Select Semester");
                comboBox1.Focus();

            }
            else if (comboBox2.Text.Equals("Select"))
            {
                MessageBox.Show("Select Department");
                comboBox1.Focus();

            }
            else
            {
                con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\pc\Documents\Visual Studio 2012\Projects\Routine_Generation_System2017\Routine_Generation_System2017\Routine.mdf;Integrated Security=True;");
                con.Open();
                string s;
                s = "Insert into Subject values('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.SelectedItem.ToString() + "','" + comboBox2.SelectedItem.ToString() + "')";
                com = new SqlCommand(s, con);
                com.ExecuteNonQuery();
                MessageBox.Show("Subject has been added successfully");
                textBox1.Text = "";
                textBox2.Text = "";
                comboBox1.Text = "";
                comboBox2.Text = "";
                textBox1.Focus();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Add_subject.ActiveForm.Hide();
            new Administrator1().Show();
        }
    }
}
