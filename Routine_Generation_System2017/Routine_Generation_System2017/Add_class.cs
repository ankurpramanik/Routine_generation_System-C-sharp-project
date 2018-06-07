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
    public partial class Add_class : Form
    {
        public Add_class()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlDataAdapter adpt;
        SqlCommand com;
        DataSet ds;

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\pc\Documents\Visual Studio 2012\Projects\Routine_Generation_System2017\Routine_Generation_System2017\Routine.mdf;Integrated Security=True;");
            con.Open();
            string s = "select distinct FacultyID from Faculty where Department='" + comboBox2.SelectedItem.ToString()+ "'";
            adpt = new SqlDataAdapter();
            adpt.SelectCommand = new SqlCommand(s, con);
            ds = new DataSet();
            adpt.Fill(ds, "Faculty");
            comboBox1.Items.Clear();
            if (ds.Tables["Faculty"].Rows.Count == 0)
            {
                MessageBox.Show("No. Faculty Exists in the Department");
                comboBox2.Focus();
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
                if (comboBox2.SelectedItem.Equals("All"))
                {
                    label11.Visible = true;
                    comboBox8.Visible = true;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\pc\Documents\Visual Studio 2012\Projects\Routine_Generation_System2017\Routine_Generation_System2017\Routine.mdf;Integrated Security=True;");
            con.Open();
            string s = "select FacultyName from Faculty where FacultyID='" + comboBox1.SelectedItem.ToString() + "'";
            adpt = new SqlDataAdapter();
            adpt.SelectCommand = new SqlCommand(s, con);
            ds = new DataSet();
            adpt.Fill(ds, "Faculty");
            //textBox1.Enabled = true;
            comboBox3.Enabled = true;

            if (ds.Tables["Faculty"].Rows.Count != 0)
            {
                textBox1.Text = ds.Tables["Faculty"].Rows[0]["FacultyName"].ToString();
            }
           
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\pc\Documents\Visual Studio 2012\Projects\Routine_Generation_System2017\Routine_Generation_System2017\Routine.mdf;Integrated Security=True;");
            con.Open();
            string s = "select SubjectName from Subject where Semester='" + comboBox3.SelectedItem.ToString() + "'";
            adpt = new SqlDataAdapter();
            adpt.SelectCommand = new SqlCommand(s, con);
            ds = new DataSet();
            adpt.Fill(ds, "Subject");
            //textBox1.Enabled = true;
            comboBox3.Enabled = true;

            if (ds.Tables["Subject"].Rows.Count != 0)
            {
                comboBox4.Enabled = true;
                comboBox5.Enabled = true;
                comboBox6.Enabled = true;
                comboBox7.Enabled = true;
                textBox2.Enabled = true;
                int cnt = ds.Tables["Subject"].Rows.Count;

                for (int i = 0; i < cnt; i++)
                {
                    comboBox4.Items.Add(ds.Tables["Subject"].Rows[i]["SubjectName"].ToString());
                }
            }
           
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\pc\Documents\Visual Studio 2012\Projects\Routine_Generation_System2017\Routine_Generation_System2017\Routine.mdf;Integrated Security=True;");
            con.Open();
            string s;
            if (comboBox2.SelectedItem.Equals("All"))
            {
                s = "Insert into Routine values('" + comboBox1.SelectedItem.ToString() + "','" + textBox1.Text + "','" + comboBox8.SelectedItem.ToString() + "','" + comboBox3.SelectedItem.ToString() + "','" + comboBox4.SelectedItem.ToString() + "','" + comboBox5.SelectedItem.ToString() + "','" + comboBox6.SelectedItem.ToString() + "','" + textBox2.Text + "','" + comboBox7.SelectedItem.ToString() + "')";
                com = new SqlCommand(s, con);
                com.ExecuteNonQuery();
            }
            else
            {
                s = "Insert into Routine values('" + comboBox1.SelectedItem.ToString() + "','" + textBox1.Text + "','" + comboBox2.SelectedItem.ToString() + "','" + comboBox3.SelectedItem.ToString() + "','" + comboBox4.SelectedItem.ToString() + "','" + comboBox5.SelectedItem.ToString() + "','" + comboBox6.SelectedItem.ToString() + "','" + textBox2.Text + "','" + comboBox7.SelectedItem.ToString() + "')";
                com = new SqlCommand(s, con);
                com.ExecuteNonQuery();
            }
            MessageBox.Show("Class has been added successfully");
            comboBox1.Enabled = false;
            textBox1.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            comboBox5.Enabled = false;
            comboBox6.Enabled = false;
            textBox2.Enabled = false;
            comboBox7.Enabled = false;
            label11.Visible = false;
            comboBox8.Visible = false;
            comboBox1.Text = "";
            textBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            comboBox6.Text = "";
            textBox2.Text = "";
            comboBox7.Text = "";
        }

        private void Add_class_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Add_class.ActiveForm.Hide();
            new Administrator1().Show();
        }
    }
}
