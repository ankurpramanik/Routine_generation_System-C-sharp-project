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
    public partial class Modify_class_details : Form
    {
        public Modify_class_details()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlDataAdapter adpt;
        SqlCommand com;
        DataSet ds;
        private void button1_Click(object sender, EventArgs e)
        {
            Modify_class_details.ActiveForm.Hide();
            new Faculty1().Show();
        }

        private void Modify_class_details_Load(object sender, EventArgs e)
        {
            textBox1.Text = Login.fid.ToString();
            textBox1.Enabled = false;
            comboBox1.Enabled = true;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\pc\Documents\Visual Studio 2012\Projects\Routine_Generation_System2017\Routine_Generation_System2017\Routine.mdf;Integrated Security=True;");
            con.Open();
            string s = "select * from ClassDetails where FacultyID='" + textBox1.Text + "'";
            adpt = new SqlDataAdapter();
            adpt.SelectCommand = new SqlCommand(s, con);
            ds = new DataSet();
            adpt.Fill(ds, "ClassDetails");
            textBox2.Enabled = true;
            if (ds.Tables["ClassDetails"].Rows.Count != 0)
            {
                
                textBox2.Text = ds.Tables["ClassDetails"].Rows[0]["NoOfClassTaken"].ToString();
                textBox3.Text = ds.Tables["ClassDetails"].Rows[0]["EntryDate"].ToString();
            }
            textBox3.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Enabled = true;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Enabled = true;
            comboBox4.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\pc\Documents\Visual Studio 2012\Projects\Routine_Generation_System2017\Routine_Generation_System2017\Routine.mdf;Integrated Security=True;");
            con.Open();
            string s = "select SubjectName from Subject where Department='" + comboBox1.SelectedItem.ToString() + "' and Semester='" + comboBox3.SelectedItem.ToString() + "'";
            adpt = new SqlDataAdapter();
            adpt.SelectCommand = new SqlCommand(s, con);
            ds = new DataSet();
            adpt.Fill(ds, "Subject");
            if (ds.Tables["Subject"].Rows.Count != 0)
            {
                comboBox4.Enabled = true;
                textBox2.Enabled = false;
                textBox3.Enabled = false;


                int cnt = ds.Tables["Subject"].Rows.Count;

                for (int i = 0; i < cnt; i++)
                {
                    comboBox4.Items.Add(ds.Tables["Subject"].Rows[i]["SubjectName"].ToString());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\pc\Documents\Visual Studio 2012\Projects\Routine_Generation_System2017\Routine_Generation_System2017\Routine.mdf;Integrated Security=True;");
            con.Open();
            string s;
            s = "Update ClassDetails set NoOfClassTaken='" + textBox2.Text + "',EntryDate='" + textBox3.Text + "' where FacultyId='" + textBox1.Text + "'";
            com = new SqlCommand(s, con);
            com.ExecuteNonQuery();
            MessageBox.Show("Class Detail has been updated successfully");
            
        }
    }
}
