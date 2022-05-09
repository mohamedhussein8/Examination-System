using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExaminationSystem
{
    public partial class frmLogIn : Form
    {

        UserList users = new UserList();

        public frmLogIn()
        {
            InitializeComponent();

            users = UserManager.SelectAllUsers();
        }

        private void frmLogIn_Load(object sender, EventArgs e)
        {


        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            Trace.WriteLine(users.Count());
            foreach (var item in users)
            {
                Trace.WriteLine(item.User_Type);
            }
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            User user = users.SingleOrDefault((U) => U.userName == username && U.password == password);

            if (user is null)
            {

                // Initializes the variables to pass to the MessageBox.Show method.
                string message = "Username or Password is Wrong";
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;

                // Displays the MessageBox.
                if (MessageBox.Show(message, caption, buttons) == DialogResult.OK)
                {
                    // Closes the parent form.

                }

            }
            else if(user.User_Type.Equals("s"))
            {
                Home.frmHome frmHome = new Home.frmHome(user);
                this.Hide();
                frmHome.ShowDialog();
                this.Show();
          

            }
            else
            {
                frmInstr frmInstHome = new frmInstr(user);
                this.Hide();
                frmInstHome.ShowDialog();
                this.Show();



            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
