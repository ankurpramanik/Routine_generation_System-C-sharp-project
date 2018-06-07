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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlDataAdapter adpt;
        SqlCommand com;
        DataSet ds;
        public static string fid="";
    
        private void Login_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("Enter Username");
                textBox1.Focus();
            }
            else if (textBox2.Text.Equals(""))
            {
                MessageBox.Show("Enter Password");
                textBox2.Focus();
            }
            else if (comboBox1.Text.Equals("Select"))
            {
                MessageBox.Show("Select Option");
                comboBox1.Focus();

            }
            
            
            else if (textBox1.Text.Equals("Admin") && textBox2.Text.Equals("Pailan") && comboBox1.SelectedItem.Equals("Administrator"))
            {
                Login.ActiveForm.Hide();
                new Administrator1().Show();
            }
            
            else if (comboBox1.SelectedItem.Equals("Faculty"))
            {
                fid = textBox1.Text;
            //    MessageBox.Show(fid.ToString());
                con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\pc\Documents\Visual Studio 2012\Projects\Routine_Generation_System2017\Routine_Generation_System2017\Routine.mdf;Integrated Security=True;");
                con.Open();
                string s = "select password from FacultyRegistration where FacultyID='" + textBox1.Text+"'";
                adpt = new SqlDataAdapter();
                adpt.SelectCommand = new SqlCommand(s, con);
                ds = new DataSet();
                adpt.Fill(ds, "FacultyRegistration");
                if (ds.Tables["FacultyRegistration"].Rows.Count == 0)
                {
                    MessageBox.Show("Invalid FacultyID");
                    textBox1.Focus();

                }
                else
                {
                    string p = ds.Tables["FacultyRegistration"].Rows[0]["Password"].ToString();
                    if (p.Equals(textBox2.Text))
                    {
                        fid = textBox1.Text;
                        Login.ActiveForm.Hide();
                        new Faculty1().Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Password");
                        textBox1.Focus();

                    }

                }
            }
            else
            {
                MessageBox.Show("Invalid Entry");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*if ((textBox1.Text.Equals("Admin")) && (textBox2.Text.Equals("Pailan")) && (comboBox1.Text.Equals("Administrator")))
            {
                Login.ActiveForm.Hide();
                new Administrator1().Show();
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login.ActiveForm.Hide();
            new Faculty_Registration().Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
