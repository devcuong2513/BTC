using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTC.Forms
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtusername.Focus();
            txtpassword.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login()
        {
            if (txtusername.Text.Length == 0 && txtpassword.Text.Length == 0)
                MessageBox.Show("Bạn chưa đăng nhập  !");
            else
                if (this.txtusername.Text.Length == 0)
                MessageBox.Show("Bạn chưa nhập Username");
            else
                if (this.txtpassword.Text.Length == 0)
                MessageBox.Show("Bạn chưa nhập Password");
            else
                if (this.txtusername.Text == "admin" && this.txtpassword.Text == "123456")
                MessageBox.Show("Đăng nhập thành công");
            else
                MessageBox.Show("Mời bạn kiểm tra lại Username hoặc Password!");

        }
        private void btnlogin_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            if(this.txtusername.Text == "admin" && this.txtpassword.Text == "123456")
            {
                fm.Show();
            }
            Login();
        }
    }
}
