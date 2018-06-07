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
    public partial class Add_class_details : Form
    {
        public Add_class_details()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlDataAdapter adpt;
        SqlCommand com;
        DataSet ds;
        private void button2_Click(object sender, EventArgs e)
        {
            Add_class_details.ActiveForm.Hide();
            new Faculty1().Show();
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


                int cnt = ds.Tables["Subject"].Rows.Count;

                for (int i = 0; i < cnt; i++)
                {
                    comboBox4.Items.Add(ds.Tables["Subject"].Rows[i]["SubjectName"].ToString());
                }
            }
        }

        private void Add_class_details_Load(object sender, EventArgs e)
        {
            
           
            textBox1.Text = Login.fid.ToString();
            textBox1.Enabled = false;
            comboBox1.Enabled = true;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox3.Text = System.DateTime.Now.ToShortDateString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = true;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
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

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = true;
            textBox3.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\pc\Documents\Visual Studio 2012\Projects\Routine_Generation_System2017\Routine_Generation_System2017\Routine.mdf;Integrated Security=True;");
            con.Open();
            string s;
            s = "Insert into ClassDetails values('"  + textBox1.Text + "','" + comboBox1.SelectedItem.ToString() + "','" + comboBox2.SelectedItem.ToString() + "','" + comboBox3.SelectedItem.ToString() + "','" + comboBox4.SelectedItem.ToString() +  "','" + textBox2.Text + "','"+ textBox3.Text +"')";
            com = new SqlCommand(s, con);
            com.ExecuteNonQuery();
            MessageBox.Show("Class details have been added successfully");
            
            textBox1.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            textBox2.Enabled = false;
            
        }
    }
}
