using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Hospital.Class;
using Hospital.Model;
using mgh;
using System.Linq;
using System.IO;

namespace Hospital
{
    public partial class frmMain : Form
    {
        int timeNotif = 0;
        public frmMain()
        {
            InitializeComponent();
        }
     
        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                timeNotif = 0;
                //lblday.Text = WepApi.ClsTools.AyamHafte();
                lblUserName.Text = " خوش آمدید " + Program.tblUserLogin.Name + " " + Program.tblUserLogin.LastName;
               
            }
            catch (Exception ex)
            {
                FarsiMessagbox.Show(ex.Message, "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
            }


        }

        private void btnsettings_Click(object sender, EventArgs e)
        {
            try
            {
                Forms.BasicInformation.frmPersonnels frmPersonnels = new Forms.BasicInformation.frmPersonnels();
                Forms.BasicInformation.frmPersonnels.LoadTypeID = 0;
                frmPersonnels.Show();
            }
            catch { }
        }


        private void btnchangewallpaper_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(openFileDialog1.FileName);
                this.imgBackGround.Image = img;
                img = Image.FromFile(Application.StartupPath + "\\Untitled-2 copy.png");
                //Graphics g= this.pictureBox4.CreateGraphics();
                //Point p = new Point(pictureBox4.Left , pictureBox4.Top);
                //g.DrawImage(img, p);

            }
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            try
            {
                Forms.frmUsers frmUsers = new Forms.frmUsers();
                Forms.frmUsers.LoadTypeID = 0;
                frmUsers.Show();
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            Forms.BasicInformation.frmCustomers frmCustomers = new Forms.BasicInformation.frmCustomers();
            Forms.BasicInformation.frmPersonnels.LoadTypeID = 0;
            frmCustomers.Show();
        }
       
        private void btnNotes_Click(object sender, EventArgs e)
        {
            Forms.BasicInformation.frmNotes frmNotes = new Forms.BasicInformation.frmNotes();
            Forms.BasicInformation.frmNotes.LoadTypeID = 0;
            frmNotes.Show();
        }

        private void btnCarpets_Click(object sender, EventArgs e)
        {
            Forms.BasicInformation.frmCarpets frmCarpets = new Forms.BasicInformation.frmCarpets();
            Forms.BasicInformation.frmCarpets.LoadTypeID = 0;
            frmCarpets.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Program.tblUserLogin = new Model.tblUser();

            Application.Exit();

        }

        private void btnPersonnelFunction_Click(object sender, EventArgs e)
        {
            Forms.Operations.frmPersonnelFunction frmPersonnelFunction = new Forms.Operations.frmPersonnelFunction();
            frmPersonnelFunction.Show();
        }

        private void btnChecks_Click(object sender, EventArgs e)
        {
            Forms.Operations.frmChecks frmChecks = new Forms.Operations.frmChecks();
            Forms.Operations.frmChecks.LoadTypeID = 0;
            frmChecks.Show();
        }


        private void btnDocuments_Click(object sender, EventArgs e)
        {
            Forms.Operations.frmDocuments frmDocuments = new Forms.Operations.frmDocuments();
            Forms.Operations.frmDocuments.LoadTypeID = 0;
            frmDocuments.Show();
        }

      
        private void btnCostumerBuyList_Click(object sender, EventArgs e)
        {
            Forms.Operations.frmCostumerBuy frmCostumerBuyList = new Forms.Operations.frmCostumerBuy();
            Forms.Operations.frmCostumerBuy.LoadTypeID = 0;
            frmCostumerBuyList.Show();
        }
         
        private void btnCarpetPrice_Click(object sender, EventArgs e)
        {
            Forms.BasicInformation.frmCarpetPrice frmCarpetPrice = new Forms.BasicInformation.frmCarpetPrice();
            frmCarpetPrice.Show();
        }
            
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.tblUserLogin = new Model.tblUser();
            Application.Exit();
        }
        
    }
}
