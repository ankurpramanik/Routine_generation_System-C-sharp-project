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
    public partial class Faculty_Registration : Form
    {
        SqlConnection con;
        SqlCommand com;

    

        public Faculty_Registration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("Enter Faculty ID");
                textBox1.Focus();
            }
            else if (textBox2.Text.Equals(""))
            {
                MessageBox.Show("Enter Faculty Name");
                textBox2.Focus();
            }
            else if (textBox3.Text.Equals(""))
            {
                MessageBox.Show("Enter Phone No.");
                textBox3.Focus();
            }
            else if (textBox4.Text.Equals(""))
            {
                MessageBox.Show("Enter Address");
                textBox4.Focus();
            }
            else if (textBox5.Text.Equals(""))
            {
                MessageBox.Show("Enter Qualification");
                textBox5.Focus();
            }
            else if (comboBox1.Text.Equals("Select"))
            {
                MessageBox.Show("Select Designation");
                comboBox1.Focus();

            }
            else if (comboBox2.Text.Equals("Select"))
            {
                MessageBox.Show("Select Department");
                comboBox2.Focus();

            }
            else if (textBox6.Text.Equals(""))
            {
                MessageBox.Show("Enter Date of Joining");
                textBox6.Focus();
            }
            else if (textBox7.Text.Equals(""))
            {
                MessageBox.Show("Enter Password");
                textBox7.Focus();
            }
            else
            {
                con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\pc\Documents\Visual Studio 2012\Projects\Routine_Generation_System2017\Routine_Generation_System2017\Routine.mdf;Integrated Security=True;");
                con.Open();
                string s;
                s = "Insert into FacultyRegistration values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + comboBox1.SelectedItem.ToString() + "','" + comboBox2.SelectedItem.ToString() + "','" + textBox6.Text + "','" + textBox7.Text + "')";
                com = new SqlCommand(s, con);
                com.ExecuteNonQuery();
                MessageBox.Show("Faculty has been registered successfully");
                Faculty_Registration.ActiveForm.Hide();
                new Login().Show();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Faculty_Registration.ActiveForm.Hide();
            new Login().Show();
        }

        private void Faculty_Registration_Load(object sender, EventArgs e)
        {

        }
    }
}
