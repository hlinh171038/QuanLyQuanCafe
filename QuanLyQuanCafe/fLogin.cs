using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        // THIS WAY IS OK BUT THE KTEAM WAY IS BETTER: PUT THE RULE WHERE ALL PATH PASS THROUGH, NOT ON ONE ENTRY POINT.
        private void btnExit_Click(object sender, EventArgs e)
        {
            //DialogResult result =  MessageBox.Show("Do you want to exit the appkication ?", "Notification", MessageBoxButtons.OKCancel);
            // if (result ==  DialogResult.OK)
            // {
            //     Application.Exit();
            // }
            Application.Exit();
        }

        private void fLogin_Load(object sender, EventArgs e)
        {

        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you want to exit the application ?", "Notification", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true; // Cancel the closing event if the user does not confirm
            }
        }
    }
}
