using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Hospital.Class;
using Hospital.Model;
using mgh;
using System.Linq;
 

namespace Hospital
{
    public partial class frmLogin : Form
    {
        string LogContent = "";
        public frmLogin()
        {
            InitializeComponent();
         
        }
      
        private void btnVorud_Click(object sender, EventArgs e)
        {
            try
            {
            //    FrmMain FrmMain = new FrmMain();
            //    FrmMain.ShowDialog();

                if (txtUserName.Text.Trim().Length == 0 || txtPassword.Text.Trim().Length == 0)
                {
                    FarsiMessagbox.Show("تمامی اطلاعات درخواستی را وارد نمایید", "ورود کاربر", FMessageBoxButtons.Ok, FMessageBoxIcon.Information);
                }
                else
                {
                    CarpetCleaningEntities db = new CarpetCleaningEntities();
                      
                    string password = "";
                    LogContent = "UserName = " + txtUserName.Text;
                    password = ClsTools.EnCode(txtPassword.Text);
                    Program.tblUserLogin = db.tblUsers.Where(x => x.UserName == txtUserName.Text && x.PassWord == password).FirstOrDefault();

                    if (Program.tblUserLogin != null)
                    {

                        ClsTools.InsertLog(16, 1, LogContent, "tblUser", 1);
                        frmLogin frmLogin = new frmLogin();
                        this.Hide();
                        //Application.Run(new frmMain());
                        frmMain frmMain = new frmMain();
                        frmMain.Show();


                
                       
                        //frmMain.Owner = this;

                    }
                    else
                    {
                        FarsiMessagbox.Show("نام کاربری یا کلمه عبور اشتباه می باشد.", "ورود کاربر", FMessageBoxButtons.Ok, FMessageBoxIcon.Information);
                                    
                        ClsTools.InsertLog(17, 1, LogContent, "tblUser", 1);
                        return;
                    }
                }
                           
            }
            catch (Exception ex)
            {
                FarsiMessagbox.Show(ClsMessage.Error + "\n" + ex.Message, "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
   
    }
}
