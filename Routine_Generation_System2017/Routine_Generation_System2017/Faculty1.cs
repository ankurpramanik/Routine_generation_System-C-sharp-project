using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Routine_Generation_System2017
{
    public partial class Faculty1 : Form
    {
        public Faculty1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Faculty1.ActiveForm.Hide();
            new Login().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Faculty1.ActiveForm.Hide();
            new Add_class_details().Show();
        }

        private void Faculty1_Load(object sender, EventArgs e)
        {
            
            //MessageBox.Show(Login.fid.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Faculty1.ActiveForm.Hide();
            new Faculty_search().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Faculty1.ActiveForm.Hide();
            new Modify_class_details().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Faculty1.ActiveForm.Hide();
            new Faculty_routine().Show();
        }
    }
}
