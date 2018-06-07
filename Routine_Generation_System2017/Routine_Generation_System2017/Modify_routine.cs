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
    public partial class Modify_routine : Form
    {
        public Modify_routine()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlDataAdapter adpt;
        SqlCommand com;
        DataSet ds;
        private void button1_Click(object sender, EventArgs e)
        {
            Modify_routine.ActiveForm.Hide();
            new Administrator1().Show();
        }

        private void Modify_routine_Load(object sender, EventArgs e)
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
                MessageBox.Show("No Routine record Exists");
                comboBox1.Enabled = false;

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
            
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            comboBox5.Enabled = false;
            comboBox6.Enabled = false;
            textBox1.Enabled = false;
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
                MessageBox.Show("No Routine record present");
            }
            dataGridView1.DataSource = ds.Tables["Routine"];
            comboBox2.Enabled = true;
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\pc\Documents\Visual Studio 2012\Projects\Routine_Generation_System2017\Routine_Generation_System2017\Routine.mdf;Integrated Security=True;");
            con.Open();
            string s = "select SubjectName from Subject where Semester='" + comboBox2.SelectedItem.ToString() + "'";
            adpt = new SqlDataAdapter();
            adpt.SelectCommand = new SqlCommand(s, con);
            ds = new DataSet();
            adpt.Fill(ds, "Subject");
            if (ds.Tables["Subject"].Rows.Count != 0)
            {
                comboBox3.Enabled = true;
                comboBox4.Enabled = true;
                comboBox5.Enabled = true;
                
                
                int cnt = ds.Tables["Subject"].Rows.Count;

                for (int i = 0; i < cnt; i++)
                {
                    comboBox3.Items.Add(ds.Tables["Subject"].Rows[i]["SubjectName"].ToString());
                }
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox6.Enabled = true;
            if (comboBox5.SelectedItem.Equals("Day"))
            {
                comboBox6.Items.Clear();
                comboBox6.Items.Add("Tuesday");
                comboBox6.Items.Add("Wednesday");
                comboBox6.Items.Add("Thursday");
                comboBox6.Items.Add("Friday");
                comboBox6.Items.Add("Saturday");
            }

            else if (comboBox5.SelectedItem.Equals("Time"))
            {
                comboBox6.Items.Clear();
                comboBox6.Items.Add("10:00am-10:45am");
                comboBox6.Items.Add("10:45am-11:30am");
                comboBox6.Items.Add("11:30am-12:15am");
                comboBox6.Items.Add("12:15am-1:00pm");
                comboBox6.Items.Add("2:00pm-2:45pm");
                comboBox6.Items.Add("2:45pm-3:30pm");
                comboBox6.Items.Add("3:30pm-4:15pm");
                comboBox6.Items.Add("4:15pm-5:00pm");
                comboBox6.Items.Add("10:00am-12:00am");
                comboBox6.Items.Add("2:00pm-4:00pm");
            }
            else if (comboBox5.SelectedItem.Equals("Room No."))
            {
                comboBox6.Items.Clear();
                comboBox6.Items.Add("110");
                comboBox6.Items.Add("111");
                comboBox6.Items.Add("112");
                comboBox6.Items.Add("113");
                comboBox6.Items.Add("210");
                comboBox6.Items.Add("211");
                comboBox6.Items.Add("212");
                comboBox6.Items.Add("214");
                comboBox6.Items.Add("310");
                comboBox6.Items.Add("311");
                comboBox6.Items.Add("312");
                comboBox6.Items.Add("313");
                comboBox6.Items.Add("410");
                comboBox6.Items.Add("411");
                comboBox6.Items.Add("412");
                comboBox6.Items.Add("413");
            }
            else if (comboBox5.SelectedItem.Equals("Faculty Name"))
            {

                textBox1.Enabled = true;
                comboBox6.Enabled = false;
            }
                

        }

        private void button3_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\pc\Documents\Visual Studio 2012\Projects\Routine_Generation_System2017\Routine_Generation_System2017\Routine.mdf;Integrated Security=True;");
            con.Open();
            string s;
            if (comboBox5.SelectedItem.Equals("Day"))
            {
                s = "Update Routine set Day='" + comboBox6.SelectedItem.ToString() + "' where FacultyId='" + comboBox1.SelectedItem.ToString() + "'";
                com = new SqlCommand(s, con);
                com.ExecuteNonQuery();
            }
            else if (comboBox5.SelectedItem.Equals("Time"))
            {
                s = "Update Routine set Time='" + comboBox6.SelectedItem.ToString() + "' where FacultyId='" + comboBox1.SelectedItem.ToString() + "'";
                com = new SqlCommand(s, con);
                com.ExecuteNonQuery();
            }
            else if (comboBox5.SelectedItem.Equals("Room No."))
            {
                s = "Update Routine set RoomNo='" + comboBox6.SelectedItem.ToString() + "' where FacultyId='" + comboBox1.SelectedItem.ToString() + "'";
                com = new SqlCommand(s, con);
                com.ExecuteNonQuery();
            }
            else if (comboBox5.SelectedItem.Equals("Faculty Name"))
            {
                s = "Update Routine set FacultyName='" + textBox1.Text + "' where FacultyId='" + comboBox1.SelectedItem.ToString() + "'";
                com = new SqlCommand(s, con);
                com.ExecuteNonQuery();
            }
            MessageBox.Show("Faculty has been updated successfully");
            
        }
    }
}
