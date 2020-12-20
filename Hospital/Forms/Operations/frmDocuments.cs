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
    public partial class frmDocuments : Form
    {
        string LogContent = "";
        int SaveType = 1;      
        public static tblDocument tblDocument = new tblDocument();
        public static int LoadTypeID = 0;

        public frmDocuments()
        {
            InitializeComponent();
        }

        void BindGrid()
        {
            try
            {
                CarpetCleaningEntities db = new CarpetCleaningEntities();
                var Query = from a in db.tblDocuments
                            join b in db.tblCustomers on a.CustomerID equals b.CustomerID
                            join c in db.tblChecks on a.CheckID equals c.CheckID into joinedCheck
                            from d in joinedCheck.DefaultIfEmpty()
                            select new
                            {
                                a.DocumentID,
                                a.Title,
                                CustomerName = b.Name + " " + b.LastName,
                                PriceType = a.PriceTypeID == 1 ? "نقدی" : "چک",
                                a.Price,
                                a.DocumentDate,
                                d.CheckSerial,
                                d.CheckDate,
                                d.BankName,
                                DocumetnType = a.DocumetnTypeID == 1 ? "دریافتی" : "پرداختی"
                            };

                if (txtSearch.Text.Trim().Length != 0)
                {
                    Query = Query.Where(a => a.DocumentID.ToString().Contains(txtSearch.Text) || a.Title.ToString().Contains(txtSearch.Text) || a.CustomerName.ToString().Contains(txtSearch.Text) ||
                    a.PriceType.ToString().Contains(txtSearch.Text) || a.Price.ToString().Contains(txtSearch.Text) || a.DocumentDate.ToString().Contains(txtSearch.Text) || a.CheckSerial.ToString().Contains(txtSearch.Text)
                        || a.CheckDate.ToString().Contains(txtSearch.Text) || a.BankName.ToString().Contains(txtSearch.Text) || a.DocumetnType.ToString().Contains(txtSearch.Text));
                }

                dgv.DataSource = Query.ToList();

                dgv.Columns[0].HeaderText = "کد سند";
                dgv.Columns[0].Width = 80;
                dgv.Columns[1].HeaderText = "عنوان سند";
                dgv.Columns[1].Width = 80;
                dgv.Columns[2].HeaderText = "نام مشتری";
                dgv.Columns[2].Width = 120;
                dgv.Columns[3].HeaderText = "نوع پرداخت";
                dgv.Columns[3].Width = 100;
                dgv.Columns[4].HeaderText = "مبلغ";
                dgv.Columns[4].Width = 120;
                dgv.Columns[5].HeaderText = "تاریخ سند";
                dgv.Columns[5].Width = 100;
                dgv.Columns[6].HeaderText = "شماره سریال چک";
                dgv.Columns[6].Width = 140;
                dgv.Columns[7].HeaderText = "تاریخ چک";
                dgv.Columns[7].Width = 100;
                dgv.Columns[8].HeaderText = "نام بانک";
                dgv.Columns[8].Width = 80;
                dgv.Columns[9].HeaderText = "نوع سند";
                dgv.Columns[9].Width = 80;

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
                 tblDocument = db.tblDocuments.Find(tblDocument.DocumentID);
                if (tblDocument == null)
                {
                    FarsiMessagbox.Show(ClsMessage.ErrNotFound, "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
                    return;
                }

                BasicInformation.frmCustomers.tblCustomer.CustomerID = tblDocument.CustomerID;
                frmChecks.tblCheck.CheckID = Convert.ToInt32(tblDocument.CheckID);

                if (tblDocument.DocumetnTypeID == 1) rdbRecive.Checked = true; else rdbSend.Checked = true;

                var QueryCustomer = (from a in db.tblCustomers
                                     where a.CustomerID == BasicInformation.frmCustomers.tblCustomer.CustomerID
                                     select new { name = a.Name + " " + a.LastName }).ToList();

                txtCustomerName.Text = QueryCustomer.ElementAt(0).name;
                txtTitle_.Text = tblDocument.Title;
                txtDocumentDate_.Text = tblDocument.DocumentDate;
                txtPrice_.Text = tblDocument.Price.ToString();
                txtDiscount.Text = tblDocument.Discount.ToString();

                if (tblDocument.PriceTypeID == 1)
                {
                    rdbHandly.Checked = true;
                }
                else
                {
                    rdbChecks.Checked = true;
                    rdbChecks_CheckedChanged(null, null);

                      var QueryCheck = (from a in db.tblChecks
                                        where a.CheckID == frmChecks.tblCheck.CheckID
                                     select new { check = "تاریخ : " + a.CheckDate + "شماره چک :" + a.CheckSerial + "بانک :" + a.BankName
                }).ToList();
                                                          
                txtCheck.Text = QueryCheck.ElementAt(0).check;

                }
               
                    txtDescription.Text = tblDocument.Description;

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
                tblDocument tblDocument = new tblDocument();

                //decimal MaxID = Convert.ToDecimal(ClsTools.ShamsiDate().Substring(0, 2) + "00001");
                string year = ClsTools.ShamsiDate().ToString().Substring(2, 2);

                decimal firstcode = Convert.ToDecimal(year + "00000");
                decimal MaxID = ((from a in db.tblDocuments
                                  where a.DocumentID.ToString().Substring(0,2) == year
                                  select ((decimal?)a.DocumentID)).Max() ?? firstcode) + 1;

                //decimal MaxID = (from a in db.tblDocuments              
                //         select a.DocumentID).DefaultIfEmpty().Max() + 1;

                tblDocument.DocumentID = MaxID;
                tblDocument.CustomerID = BasicInformation.frmCustomers.tblCustomer.CustomerID;
                if (rdbSend.Checked) tblDocument.DocumetnTypeID = 2; else tblDocument.DocumetnTypeID = 1;

                tblDocument.DocumentDate = txtDocumentDate_.MaskedTextProvider.ToDisplayString();

                if (rdbHandly.Checked)
                {
                    tblDocument.PriceTypeID = 1;
                    tblDocument.CheckID = 0;
                }
                else
                {
                    tblDocument.PriceTypeID = 2;
                    tblDocument.CheckID = frmChecks.tblCheck.CheckID;
                }
            tblDocument.Title    =  txtTitle_.Text;
                tblDocument.Price = Convert.ToDecimal( txtPrice_.Text);
                if (txtDiscount.Text.Trim().Length == 0) tblDocument.Discount = 0; else tblDocument.Discount = Convert.ToDecimal(txtDiscount.Text);
                tblDocument.Description = txtDescription.Text;
                tblDocument.RegisterDate = ClsTools.ShamsiDate();

                db.tblDocuments.Add(tblDocument);

                db.SaveChanges();

                LogContent = "DocumentID = " + tblDocument.DocumentID + " | " + "DocumetnTypeID = " + tblDocument.DocumetnTypeID + " | " + "DocumentDate = " + tblDocument.DocumentDate + " | " + "PriceTypeID = " + tblDocument.PriceTypeID + " | " +
                   "Price = " + tblDocument.Price + " | " + "CheckID = " + tblDocument.CheckID + " | " + "CustomerID = " + tblDocument.CustomerID + " | " + "Description = " + tblDocument.Description + " | " + "RegisterDate = " + tblDocument.RegisterDate + " | " +
                      "Description = " + tblDocument.Description + " | ";

                ClsTools.InsertLog(29, Program.tblUserLogin.UserID, LogContent, "tblDocument", tblDocument.DocumentID);

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
                tblDocument = db.tblDocuments.Find(tblDocument.DocumentID);

                if (tblDocument == null)
                {
                    FarsiMessagbox.Show(ClsMessage.ErrNotFound, "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
                    return;
                }

                tblDocument.CustomerID = BasicInformation.frmCustomers.tblCustomer.CustomerID;
                if (rdbSend.Checked) tblDocument.DocumetnTypeID = 2; else tblDocument.DocumetnTypeID = 1;

                tblDocument.DocumentDate = txtDocumentDate_.MaskedTextProvider.ToDisplayString();

                if (rdbHandly.Checked)
                {
                    tblDocument.PriceTypeID = 1;
                    tblDocument.CheckID = 0;
                }
                else
                {
                    tblDocument.PriceTypeID = 2;
                    tblDocument.CheckID = frmChecks.tblCheck.CheckID;
                }
                tblDocument.Title = txtTitle_.Text;
                tblDocument.Price = Convert.ToDecimal(txtPrice_.Text);
                if (txtDiscount.Text.Trim().Length == 0) tblDocument.Discount = 0; else tblDocument.Discount = Convert.ToDecimal(txtDiscount.Text);
                tblDocument.Description = txtDescription.Text;

                db.Entry(tblDocument).State = EntityState.Modified;
                //db.Entry(tblPersonnel).Property(x => x).IsModified = true;        
                db.Entry(tblDocument).Property(x => x.RegisterDate).IsModified = false;

                db.SaveChanges();

                LogContent = "DocumentID = " + tblDocument.DocumentID + " | " + "DocumetnTypeID = " + tblDocument.DocumetnTypeID + " | " + "DocumentDate = " + tblDocument.DocumentDate + " | " + "PriceTypeID = " + tblDocument.PriceTypeID + " | " +
             "Price = " + tblDocument.Price + " | " + "CheckID = " + tblDocument.CheckID + " | " + "CustomerID = " + tblDocument.CustomerID + " | " + "Description = " + tblDocument.Description + " | " + "RegisterDate = " + tblDocument.RegisterDate + " | " +
                "Description = " + tblDocument.Description + " | ";

                ClsTools.InsertLog(30, Program.tblUserLogin.UserID, LogContent, "tblDocument", tblDocument.DocumentID);

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
                 tblDocument = db.tblDocuments.Find(tblDocument.DocumentID);

                LogContent = "DocumentID = " + tblDocument.DocumentID + " | " + "DocumetnTypeID = " + tblDocument.DocumetnTypeID + " | " + "DocumentDate = " + tblDocument.DocumentDate + " | " + "PriceTypeID = " + tblDocument.PriceTypeID + " | " +
                "Price = " + tblDocument.Price + " | " + "CheckID = " + tblDocument.CheckID + " | " + "CustomerID = " + tblDocument.CustomerID + " | " + "Description = " + tblDocument.Description + " | " + "RegisterDate = " + tblDocument.RegisterDate + " | " +
                   "Description = " + tblDocument.Description + " | ";


                db.tblDocuments.Remove(tblDocument);
                db.SaveChanges();

                ClsTools.InsertLog(30, Program.tblUserLogin.UserID, LogContent, "tblDocument", tblDocument.DocumentID);

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
            SaveType = 1;
            BindGrid();
            BasicInformation.frmCustomers.tblCustomer = new tblCustomer();
            frmChecks.tblCheck.CheckID = 0;
            ClsTools.ClearContent(pnlNewEdit);
            btnDelete.Enabled = false;
            txtDocumentDate_.Text = ClsTools.ShamsiDate();
        }
        private void frmDocuments_Load(object sender, EventArgs e)
        {
            try
            {
                New();
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
                if (ClsTools.CheckValidation(pnlNewEdit) == false || BasicInformation.frmCustomers.tblCustomer.CustomerID == 0 || (rdbChecks.Checked && frmChecks.tblCheck.CheckID == 0))
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
                tblDocument.DocumentID = Convert.ToDecimal(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
                BindRow();
                SaveType = 2;
                btnDelete.Enabled = true;
            }
            catch (Exception ex)
            {
            }
        }

        private void btnSelectCustomers_Click(object sender, EventArgs e)
        {
            BasicInformation.frmCustomers frmCustomers = new BasicInformation.frmCustomers();
            BasicInformation.frmCustomers.LoadTypeID = 1;
            frmCustomers.FormClosed += frmCustomers_Closed;
            frmCustomers.ShowDialog();
        }

        private void frmCustomers_Closed(object sender, FormClosedEventArgs e)
        {
            try
            {
                txtCustomerName.Text = BasicInformation.frmCustomers.tblCustomer.Name + " " + BasicInformation.frmCustomers.tblCustomer.LastName;
                BasicInformation.frmCustomers.LoadTypeID = 0;
            }
            catch (Exception)
            {
            }
        }

        private void rdbChecks_CheckedChanged(object sender, EventArgs e)
        {
            txtPrice_.Text = "0";
            if (rdbChecks.Checked)
            {
                lblCheck.Visible = true;
                lblCheckStar.Visible = true;
                btnCheck.Visible = true;
                lblinfoCheck.Visible = true;
                txtCheck.Visible = true;
                txtPrice_.Enabled = false;
            }
            else
            {
                lblCheck.Visible = false;
                lblCheckStar.Visible = false;
                btnCheck.Visible = false;
                                       
                lblinfoCheck.Visible = false;
                txtCheck.Visible = false;
                txtPrice_.Enabled = true;
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            frmChecks frmChecks = new frmChecks();
            frmChecks.FormClosed += frmChecks_Closed;
            frmChecks.LoadTypeID = 1;
            frmChecks.ShowDialog();
        }

        private void frmChecks_Closed(object sender, FormClosedEventArgs e)
        {
            try
            {
                txtCheck.Text = "تاریخ : " + frmChecks.tblCheck.CheckDate + "شماره چک :" + frmChecks.tblCheck.CheckSerial + "بانک :" + frmChecks.tblCheck.BankName;
                txtPrice_.Text = frmChecks.tblCheck.Price.ToString();
            }
            catch (Exception)
            {
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

        private void txtNumber__KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"^[0-9.\b]"))
            {
                // Stop the character from being entered into the control since it is illegal.
                e.Handled = true;
            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
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

        private void rdbHandly_CheckedChanged(object sender, EventArgs e)
        {
            txtPrice_.Text = "0";
        }
    }
}
