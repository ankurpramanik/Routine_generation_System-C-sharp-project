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
    public partial class Administrator1 : Form
    {
        public Administrator1()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Administrator1.ActiveForm.Hide();
            new Login().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Administrator1.ActiveForm.Hide();
            new Add_class().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Administrator1.ActiveForm.Hide();
            new Add_faculty().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Administrator1.ActiveForm.Hide();
            new Add_subject().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Administrator1.ActiveForm.Hide();
            new View_faculty().Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Administrator1.ActiveForm.Hide();
            new Admin_search().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Administrator1.ActiveForm.Hide();
            new Modify_faculty().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Administrator1.ActiveForm.Hide();
            new View_routine().Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Administrator1.ActiveForm.Hide();
            new Modify_routine().Show();
        }

        private void Administrator1_Load(object sender, EventArgs e)
        {

        }
    }
}
