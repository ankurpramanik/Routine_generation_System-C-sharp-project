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
    public partial class View_routine : Form
    {
        public View_routine()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlDataAdapter adpt;
        SqlCommand com;
        DataSet ds;
        private void button2_Click(object sender, EventArgs e)
        {
            View_routine.ActiveForm.Hide();
            new Administrator1().Show();
        }

        private void View_routine_Load(object sender, EventArgs e)
        {
            /*con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\pc\Documents\Visual Studio 2012\Projects\Routine_Generation_System2017\Routine_Generation_System2017\Routine.mdf;Integrated Security=True;");
            con.Open();
            string s = "select BatchID from Student";
            adpt = new SqlDataAdapter();
            adpt.SelectCommand = new SqlCommand(s, con);
            ds = new DataSet();
            adpt.Fill(ds, "Student");
            comboBox1.Items.Clear();
            if (ds.Tables["Student"].Rows.Count == 0)
            {
                MessageBox.Show("No. Batch record Exists");
                comboBox1.Enabled = false;

            }
            else
            {
                comboBox1.Enabled = true;
                int cnt = ds.Tables["Student"].Rows.Count;

                for (int i = 0; i < cnt; i++)
                {
                    comboBox1.Items.Add(ds.Tables["Student"].Rows[i]["BatchID"].ToString());
                }
            }
           */

        }

        private void button1_Click(object sender, EventArgs e)
        {
            View_routine.ActiveForm.Height = 1000;
            View_routine.ActiveForm.Width = 1000;
            con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\pc\Documents\Visual Studio 2012\Projects\Routine_Generation_System2017\Routine_Generation_System2017\Routine.mdf;Integrated Security=True;");
            con.Open();
            string s = "select FacultyName,Department,Semester,Subject,Day,Time,RoomNo,TypeOfClass from Routine where Day='" + comboBox1.SelectedItem.ToString() + "' and Department='" + comboBox2.SelectedItem.ToString() + "' and Semester='" + comboBox3.SelectedItem.ToString() + "' order by Time";
            adpt = new SqlDataAdapter();
            adpt.SelectCommand = new SqlCommand(s, con);
            ds = new DataSet();
            adpt.Fill(ds, "Routine");
            if (ds.Tables["Routine"].Rows.Count == 0)
            {
                MessageBox.Show("No Routine records present");
            }
            dataGridView1.DataSource = ds.Tables["Routine"];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            new PrintDialog().ShowDialog().ToString();
        }
    }
}
