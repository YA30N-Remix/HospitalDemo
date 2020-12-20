using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hospital.Class;
using Hospital.Model;
using mgh;

namespace Hospital.Forms.Operations
{
    public partial class frmChecks : Form
    {
        string LogContent = "";        
        int SaveType = 1; 
        public static tblCheck tblCheck = new tblCheck();
        public static int LoadTypeID = 0;
        public frmChecks()
        {
            InitializeComponent();
        }

        void BindGrid()
        {
            try
            {
                CarpetCleaningEntities db = new CarpetCleaningEntities();
                var Query = from a in db.tblChecks
                            join b in db.tblCustomers
                            on a.CustomerID equals b.CustomerID
                            select new { a.CheckID, CustomerName = b.Name + " " + b.LastName, a.Price, a.CheckSerial, a.CheckDate, a.CheckDueDate, a.BankName, CheckType = a.CheckTypeID == 1 ? "دریافتی" : "پرداختی" };

                if (txtSearch.Text.Trim().Length != 0)
                {
                    Query = Query.Where(a => a.CheckID.ToString().Contains(txtSearch.Text) || a.CustomerName.ToString().Contains(txtSearch.Text) || a.Price.ToString().Contains(txtSearch.Text) || a.CheckSerial.ToString().Contains(txtSearch.Text)
                        || a.CheckDate.ToString().Contains(txtSearch.Text) || a.CheckDueDate.ToString().Contains(txtSearch.Text) || a.BankName.ToString().Contains(txtSearch.Text) || a.CheckType.ToString().Contains(txtSearch.Text));
                }

                dgv.DataSource = Query.ToList();

                dgv.Columns[0].HeaderText = "کد چک";
                dgv.Columns[0].Width = 100;
                dgv.Columns[1].HeaderText = "نام مشتری";
                dgv.Columns[1].Width = 140;
                dgv.Columns[2].HeaderText = "مبلغ";
                dgv.Columns[2].Width = 140;
                dgv.Columns[3].HeaderText = "شماره سریال چک";
                dgv.Columns[3].Width = 160;
                dgv.Columns[4].HeaderText = "تاریخ چک";
                dgv.Columns[4].Width = 100;
                dgv.Columns[5].HeaderText = "تاریخ سر رسید";
                dgv.Columns[5].Width = 100;
                dgv.Columns[6].HeaderText = "نام بانک";
                dgv.Columns[6].Width = 100;
                dgv.Columns[7].HeaderText = "نوع چک";
                dgv.Columns[7].Width = 100;
            }
            catch (Exception ex)
            {
                FarsiMessagbox.Show(ClsMessage.Error + "\n" + ex.Message.ToString(), "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
            }
        }

        void BindRow()
        {
            try
            {
                CarpetCleaningEntities db = new CarpetCleaningEntities();
                 tblCheck = db.tblChecks.Find(tblCheck.CheckID);
                if (tblCheck == null)
                {
                    FarsiMessagbox.Show(ClsMessage.ErrNotFound, "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
                    return;
                }

                BasicInformation.frmCustomers.tblCustomer.CustomerID = tblCheck.CustomerID;
                  
                if (tblCheck.CheckTypeID == 1) rdbRecive.Checked = true; else rdbSend.Checked=true;

               var QueryCustomer = (from a in db.tblCustomers
                                     where a.CustomerID == BasicInformation.frmCustomers.tblCustomer.CustomerID
                                     select new { name = a.Name + " " + a.LastName }).ToList();

                txtCustomerName.Text = QueryCustomer.ElementAt(0).name;
 
                txtCheckDate_.Text = tblCheck.CheckDate;
                txtCheckSerial_.Value = Convert.ToDecimal(tblCheck.CheckSerial);
                txtCheckDueDate_.Text = tblCheck.CheckDueDate;
                txtPrice_.Text = tblCheck.Price.ToString();
                txtBankName_.Text = tblCheck.BankName;
                chkRemainder.Checked = tblCheck.Reminder;
                txtRemainderDay.Value = tblCheck.ReminderDay;
                chkRemainder_CheckedChanged(null, null);
                   
                txtDescription.Text = tblCheck.Description;
                                                           
            }
            catch (Exception ex)
            {
                FarsiMessagbox.Show(ClsMessage.ErrNotFound + "\n" + ex.Message.ToString(), "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
            }
        }

        void InsertRow()
        {
            try
            {
                CarpetCleaningEntities db = new CarpetCleaningEntities();
                tblCheck tblCheck = new tblCheck();

                decimal MaxID = (from a in db.tblChecks
                             select a.CheckID).DefaultIfEmpty().Max() + 1;

                tblCheck.CheckID = MaxID;
                tblCheck.CustomerID = BasicInformation.frmCustomers.tblCustomer.CustomerID;
                if (rdbRecive.Checked) tblCheck.CheckTypeID = 1; else tblCheck.CheckTypeID = 2;

                var QueryCustomer = (from a in db.tblCustomers
                                     where a.CustomerID == BasicInformation.frmCustomers.tblCustomer.CustomerID
                                     select new { name = a.Name + " " + a.LastName }).ToList();
                                                          
                txtCustomerName.Text = QueryCustomer.ElementAt(0).name;

                tblCheck.ReminderDay = Convert.ToInt32(txtRemainderDay.Value);
                tblCheck.CheckDate = txtCheckDate_.MaskedTextProvider.ToDisplayString(); 
                tblCheck.CheckSerial = txtCheckSerial_.Value.ToString();
                tblCheck.CheckDueDate = txtCheckDueDate_.MaskedTextProvider.ToDisplayString();
                tblCheck.Price = Convert.ToDecimal(txtPrice_.Text);
                tblCheck.BankName = txtBankName_.Text;
                tblCheck.Description = txtDescription.Text;
                tblCheck.Reminder = chkRemainder.Checked;
                                  
                DateTime dtnow = ClsTools.ShamsiDateToGregorianDate(tblCheck.CheckDueDate);
                dtnow = dtnow.AddDays(-tblCheck.ReminderDay);
                tblCheck.ReminderDate = ClsTools.GregorianDateToShamsiDate(dtnow);

                tblCheck.RegisterDate = ClsTools.ShamsiDate();

                db.tblChecks.Add(tblCheck);

                db.SaveChanges();

                LogContent = "CheckID = " + tblCheck.CheckID + " | " + "CheckTypeID = " + tblCheck.CheckTypeID + " | " + "CustomerID = " + tblCheck.CustomerID + " | " + "CheckDate = " + tblCheck.CheckDate + " | " + "CheckSerial = " + tblCheck.CheckSerial + " | " +
                  "CheckDueDate = " + tblCheck.CheckDueDate + " | " + "BankName = " + tblCheck.BankName + " | " + "Description = " + tblCheck.Description + " | " + "RegisterDate = " + tblCheck.RegisterDate + " | " +
                     "Description = " + tblCheck.Description + " | ";

                ClsTools.InsertLog(26, Program.tblUserLogin.UserID, LogContent, "tblCheck", tblCheck.CheckID);

                New();
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage);
                var fullErrorMessage = string.Join("\n", errorMessages);
                var exceptionMessage = string.Concat(ClsMessage.Error, ex.Message, " The validation errors are: ", fullErrorMessage);
                FarsiMessagbox.Show(exceptionMessage, "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
            }
            catch (DbUpdateException ex)
            {
                FarsiMessagbox.Show(ClsMessage.Error + "\n" + ex.Message.ToString(), "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                FarsiMessagbox.Show(ClsMessage.Error + "\n" + ex.Message.ToString(), "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
            }

        }

        void UpdateRow()
        {
            try
            {
                CarpetCleaningEntities db = new CarpetCleaningEntities();
                 tblCheck = db.tblChecks.Find(tblCheck.CheckID);

                if (tblCheck == null)
                {
                    FarsiMessagbox.Show(ClsMessage.ErrNotFound, "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
                    return;
                }
                   
                tblCheck.CustomerID = BasicInformation.frmCustomers.tblCustomer.CustomerID;
                if (rdbRecive.Checked) tblCheck.CheckTypeID = 1; else tblCheck.CheckTypeID = 2;
                tblCheck.ReminderDay = Convert.ToInt32(txtRemainderDay.Value);
                tblCheck.CheckDate = txtCheckDate_.MaskedTextProvider.ToDisplayString();
                tblCheck.CheckSerial = txtCheckSerial_.Value.ToString();
                tblCheck.CheckDueDate = txtCheckDueDate_.MaskedTextProvider.ToDisplayString();
                tblCheck.Price = Convert.ToDecimal(txtPrice_.Text);
                tblCheck.BankName = txtBankName_.Text;         
                tblCheck.Reminder = chkRemainder.Checked;

                DateTime dtnow = ClsTools.ShamsiDateToGregorianDate(tblCheck.CheckDueDate);
                dtnow= dtnow.AddDays(-tblCheck.ReminderDay);
                tblCheck.ReminderDate = ClsTools.GregorianDateToShamsiDate(dtnow);

                tblCheck.RegisterDate = ClsTools.ShamsiDate();

                tblCheck.Description = txtDescription.Text;

                db.Entry(tblCheck).State = EntityState.Modified;
                //db.Entry(tblPersonnel).Property(x => x).IsModified = true;        
                db.Entry(tblCheck).Property(x => x.RegisterDate).IsModified = false;

                db.SaveChanges();

                LogContent = "CheckID = " + tblCheck.CheckID + " | " + "CheckTypeID = " + tblCheck.CheckTypeID + " | " + "CustomerID = " + tblCheck.CustomerID + " | " + "CheckDate = " + tblCheck.CheckDate + " | " + "CheckSerial = " + tblCheck.CheckSerial + " | " +
                         "CheckDueDate = " + tblCheck.CheckDueDate + " | " + "BankName = " + tblCheck.BankName + " | " + "Description = " + tblCheck.Description + " | " + "RegisterDate = " + tblCheck.RegisterDate + " | " +
                            "Description = " + tblCheck.Description + " | ";

                ClsTools.InsertLog(27, Program.tblUserLogin.UserID, LogContent, "tblCheck", tblCheck.CheckID);

                New();
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage);
                var fullErrorMessage = string.Join("\n", errorMessages);
                var exceptionMessage = string.Concat(ClsMessage.Error, ex.Message, " The validation errors are: ", fullErrorMessage);
                FarsiMessagbox.Show(exceptionMessage, "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
            }
            catch (DbUpdateException ex)
            {
                FarsiMessagbox.Show(ClsMessage.Error + "\n" + ex.Message.ToString(), "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                FarsiMessagbox.Show(ClsMessage.Error + "\n" + ex.Message.ToString(), "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
            }
        }

        //void ChangeStatusRow()
        //{
        //    try
        //    {
        //        CarpetCleaningEntities db = new CarpetCleaningEntities();
        //        tblPersonnelFunction tblPersonnelFunction = db.tblPersonnelFunctions.Find(PersonnelID);

        //        if (tblPersonnelFunction == null)
        //        {
        //            FarsiMessagbox.Show(ClsMessage.ErrNotFound, "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
        //            return;
        //        }

        //        if (tblPersonnelFunction.Active == 1) tblPersonnelFunction.Active = 0;
        //        else tblPersonnelFunction.Active = 1;


        //        db.tblPersonnelFunctions.Attach(tblPersonnelFunction);

        //        db.Entry(tblPersonnelFunction).Property(x => x.Active).IsModified = true; // $('#txtGoodsCode').val(),

        //        db.SaveChanges();

        //        LogContent = "Active = " + tblPersonnelFunction.Active;

        //        ClsTools.InsertLog(25, Program.tblUserLogin.UserID, LogContent, "tblPersonnelFunction", tblPersonnelFunction.PersonnelFunctionID);

        //        New();
        //    }
        //    catch (DbEntityValidationException ex)
        //    {
        //        var errorMessages = ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage);
        //        var fullErrorMessage = string.Join("\n", errorMessages);
        //        var exceptionMessage = string.Concat(ClsMessage.Error, ex.Message, " The validation errors are: ", fullErrorMessage);
        //        FarsiMessagbox.Show(exceptionMessage, "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
        //    }
        //    catch (DbUpdateException ex)
        //    {
        //        FarsiMessagbox.Show(ClsMessage.Error + "\n" + ex.Message.ToString(), "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
        //    }
        //    catch (Exception ex)
        //    {
        //        FarsiMessagbox.Show(ClsMessage.Error + "\n" + ex.Message.ToString(), "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
        //    }
        //}

        void DeleteRow()
        {
            try
            {
                CarpetCleaningEntities db = new CarpetCleaningEntities();
                 tblCheck = db.tblChecks.Find(tblCheck.CheckID);

                LogContent = "CheckID = " + tblCheck.CheckID + " | " + "CheckTypeID = " + tblCheck.CheckTypeID + " | " + "CustomerID = " + tblCheck.CustomerID + " | " + "CheckDate = " + tblCheck.CheckDate + " | " + "CheckSerial = " + tblCheck.CheckSerial + " | " +
                    "CheckDueDate = " + tblCheck.CheckDueDate + " | " + "BankName = " + tblCheck.BankName + " | " + "Description = " + tblCheck.Description + " | " + "RegisterDate = " + tblCheck.RegisterDate + " | " +
                       "Description = " + tblCheck.Description + " | ";

                db.tblChecks.Remove(tblCheck);
                db.SaveChanges();

                ClsTools.InsertLog(28, Program.tblUserLogin.UserID, LogContent, "tblCheck", tblCheck.CheckID);

                New();
            }
            catch (DbUpdateException ex)
            {
                FarsiMessagbox.Show(ClsMessage.Error + "\n" + ex.Message.ToString(), "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                FarsiMessagbox.Show(ClsMessage.Error + "\n" + ex.Message.ToString(), "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
            }
        }

        void New()
        {
            tblCheck = new tblCheck();
            SaveType = 1;
            BindGrid();
            BasicInformation.frmCustomers.tblCustomer = new tblCustomer();
            ClsTools.ClearContent(pnlNewEdit);
            btnDelete.Enabled = false;
            btnSelect.Enabled = false;  
        }
        private void frmChecks_Load(object sender, EventArgs e)
        {
            try
            {
                New();
                if (LoadTypeID == 1) btnSelect.Visible = true;
            }
            catch (Exception ex)
            {
                FarsiMessagbox.Show(ClsMessage.Error + "\n" + ex.Message.ToString(), "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClsTools.CheckValidation(pnlNewEdit) == false || BasicInformation.frmCustomers.tblCustomer.CustomerID == 0)
                {
                    FarsiMessagbox.Show(ClsMessage.ErrNotRegEmptyValue, "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
                    return;
                }

                if (SaveType == 1)
                {
                    InsertRow();
                }
                else
                {
                    UpdateRow();
                }


            }
            catch (Exception ex)
            {
                FarsiMessagbox.Show(ClsMessage.Error + "\n" + ex.Message.ToString(), "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (FarsiMessagbox.Show("آیا از حذف اطلاعات مورد نظر مطمئن هستید؟", "حذف", FMessageBoxButtons.YesNo, FMessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DeleteRow();
                }
            }
            catch (Exception ex)
            {
                FarsiMessagbox.Show(ClsMessage.Error + "\n" + ex.Message.ToString(), "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            New();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tblCheck.CheckID = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
                BindRow();
                SaveType = 2;
                btnDelete.Enabled = true;
                if (LoadTypeID == 1) btnSelect.Enabled = true;

            }
            catch (Exception ex)
            {
            }
        }

        private void btnSelectCustomers_Click(object sender, EventArgs e)
        {
            BasicInformation.frmCustomers frmCustomers = new BasicInformation.frmCustomers();
            frmCustomers.FormClosed += frmCustomers_Closed;
            BasicInformation.frmCustomers.LoadTypeID = 1;
            frmCustomers.ShowDialog();
        }

        private void frmCustomers_Closed(object sender, FormClosedEventArgs e)
        {
            try
            {
                BasicInformation.frmCustomers.LoadTypeID = 0;
                txtCustomerName.Text = BasicInformation.frmCustomers.tblCustomer.Name + " " + BasicInformation.frmCustomers.tblCustomer.LastName;
            }
            catch (Exception)
            {
            }
        }
            
        private void chkRemainder_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRemainder.Checked)
            {
                txtRemainderDay.Enabled = true;
            }
            else
            {
                txtRemainderDay.Enabled = false;
                txtRemainderDay.Value = 0;
            }

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (tblCheck.CheckID == 0)
            {
                FarsiMessagbox.Show(ClsMessage.Error + "\n" + "رکوردی انتخاب نشده است", "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
                return;
            }      
            SaveType = 1;
            LoadTypeID = 0;
            this.Close();
        }

        private void txtNumber__KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"^[0-9.\b]"))
            {
                // Stop the character from being entered into the control since it is illegal.
                e.Handled = true;
            }
        }

        private void txtPrice__TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (((TextBox)sender).Text != String.Empty)
                {
                    ((TextBox)sender).Text = String.Format("{0:N0}", double.Parse(((TextBox)sender).Text.Replace(",", "")));
                    ((TextBox)sender).Select(((TextBox)sender).TextLength, 0);
                }
            }
            catch (Exception)
            {
            }
        }

    }
}
