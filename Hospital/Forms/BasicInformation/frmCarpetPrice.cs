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

namespace Hospital.Forms.BasicInformation
{
    public partial class frmCarpetPrice : Form
    {
        string LogContent = "";
        int SaveType = 1;
        public static tblCarpetPrice tblCarpetPrice = new tblCarpetPrice();
        public static int LoadTypeID = 0;
        public frmCarpetPrice()
        {
            InitializeComponent();
        }

        void BindGrid()
        {
            try
            {
                CarpetCleaningEntities db = new CarpetCleaningEntities();
                var Query = from a in db.tblCarpetPrices
                            select new { a.CarpetPriceID, a.Year, a.Shur, a.Darkesh, a.Gayegh, a.Shiraze, a.Charm, a.Hasiri, a.Geytani, a.Pardakht };

                if (txtSearch.Text.Trim().Length != 0)
                {
                    Query = Query.Where(a => a.CarpetPriceID.ToString().Contains(txtSearch.Text) || a.Year.ToString().Contains(txtSearch.Text) || a.Shur.ToString().Contains(txtSearch.Text) || a.Darkesh.ToString().Contains(txtSearch.Text) ||
                    a.Gayegh.ToString().Contains(txtSearch.Text) || a.Shiraze.ToString().Contains(txtSearch.Text) || a.Charm.ToString().Contains(txtSearch.Text) || a.Hasiri.ToString().Contains(txtSearch.Text)
                     || a.Geytani.ToString().Contains(txtSearch.Text) || a.Pardakht.ToString().Contains(txtSearch.Text));
                }

                dgv.DataSource = Query.ToList();

                dgv.Columns[0].HeaderText = "کد";
                dgv.Columns[0].Width = 100;
                dgv.Columns[1].HeaderText = "سال";
                dgv.Columns[1].Width = 100;
                dgv.Columns[2].HeaderText = "شور";
                dgv.Columns[2].Width = 100;
                dgv.Columns[3].HeaderText = "دارکش";
                dgv.Columns[3].Width = 100;
                dgv.Columns[4].HeaderText = "قایق";
                dgv.Columns[4].Width = 100;
                dgv.Columns[5].HeaderText = "شیرازه";
                dgv.Columns[5].Width = 100;
                dgv.Columns[6].HeaderText = "چرم";
                dgv.Columns[6].Width = 100;
                dgv.Columns[7].HeaderText = "حصیری";
                dgv.Columns[7].Width = 100;
                dgv.Columns[8].HeaderText = "قیطانی";
                dgv.Columns[8].Width = 100;
                dgv.Columns[9].HeaderText = "پرداخت";
                dgv.Columns[9].Width = 100;
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
                tblCarpetPrice = db.tblCarpetPrices.Find(tblCarpetPrice.CarpetPriceID);
                if (tblCarpetPrice == null)
                {
                    FarsiMessagbox.Show(ClsMessage.ErrNotFound, "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
                    return;
                }
                txtYear_.Value = tblCarpetPrice.Year;

                txtShur_.Text = tblCarpetPrice.Shur.ToString();

                txtDarkesh_.Text = tblCarpetPrice.Darkesh.ToString();
                txtGayegh_.Text = tblCarpetPrice.Gayegh.ToString();
                txtShiraze_.Text = tblCarpetPrice.Shiraze.ToString();
                txtCharm_.Text = tblCarpetPrice.Charm.ToString();
                txtHasiri_.Text = tblCarpetPrice.Hasiri.ToString();
                txtGeytani_.Text = tblCarpetPrice.Geytani.ToString();
                txtPardakht_.Text = tblCarpetPrice.Pardakht.ToString();

                txtDescription.Text = tblCarpetPrice.Description;
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
                tblCarpetPrice tblCarpetPrice = new tblCarpetPrice();

                int MaxID = (from a in db.tblCarpetPrices
                             select a.CarpetPriceID).DefaultIfEmpty().Max() + 1;


                tblCarpetPrice.CarpetPriceID = MaxID;
                tblCarpetPrice.Year = Convert.ToInt32(txtYear_.Value);

                if (txtShur_.Text.Trim().Length != 0) tblCarpetPrice.Shur = Convert.ToDecimal(txtShur_.Text);
                if (txtDarkesh_.Text.Trim().Length != 0) tblCarpetPrice.Darkesh = Convert.ToDecimal(txtDarkesh_.Text);
                if (txtGayegh_.Text.Trim().Length != 0) tblCarpetPrice.Gayegh = Convert.ToDecimal(txtGayegh_.Text);
                if (txtShiraze_.Text.Trim().Length != 0) tblCarpetPrice.Shiraze = Convert.ToDecimal(txtShiraze_.Text);
                if (txtCharm_.Text.Trim().Length != 0) tblCarpetPrice.Charm = Convert.ToDecimal(txtCharm_.Text);
                if (txtHasiri_.Text.Trim().Length != 0) tblCarpetPrice.Hasiri = Convert.ToDecimal(txtHasiri_.Text);
                if (txtGeytani_.Text.Trim().Length != 0) tblCarpetPrice.Geytani = Convert.ToDecimal(txtGeytani_.Text);
                if (txtPardakht_.Text.Trim().Length != 0) tblCarpetPrice.Pardakht = Convert.ToDecimal(txtPardakht_.Text);

                tblCarpetPrice.Description = txtDescription.Text;

                tblCarpetPrice.RegisterDate = ClsTools.ShamsiDate();

                db.tblCarpetPrices.Add(tblCarpetPrice);
                db.SaveChanges();


                LogContent = "CarpetPriceID = " + tblCarpetPrice.CarpetPriceID + " | " + "Shur = " + tblCarpetPrice.Shur + " | " + "Darkesh = " + tblCarpetPrice.Darkesh +
                       "Gayegh = " + tblCarpetPrice.Gayegh + " | " + "Shiraze = " + tblCarpetPrice.Shiraze + " | " + "Charm = " + tblCarpetPrice.Charm + " | " +
                       "Hasiri = " + tblCarpetPrice.Hasiri + " | " + "Geytani = " + tblCarpetPrice.Geytani + " | " + "Pardakht = " + tblCarpetPrice.Pardakht + " | " + "Description = " + tblCarpetPrice.Description + " | ";

                ClsTools.InsertLog(41, Program.tblUserLogin.UserID, LogContent, "tblCarpetPrice", tblCarpetPrice.CarpetPriceID);

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
                tblCarpetPrice = db.tblCarpetPrices.Find(tblCarpetPrice.CarpetPriceID);

                if (tblCarpetPrice == null)
                {
                    FarsiMessagbox.Show(ClsMessage.ErrNotFound, "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
                    return;
                }

                tblCarpetPrice.Year = Convert.ToInt32(txtYear_.Value);

                if (txtShur_.Text.Trim().Length != 0) tblCarpetPrice.Shur = Convert.ToDecimal(txtShur_.Text);
                if (txtDarkesh_.Text.Trim().Length != 0) tblCarpetPrice.Darkesh = Convert.ToDecimal(txtDarkesh_.Text);
                if (txtGayegh_.Text.Trim().Length != 0) tblCarpetPrice.Gayegh = Convert.ToDecimal(txtGayegh_.Text);
                if (txtShiraze_.Text.Trim().Length != 0) tblCarpetPrice.Shiraze = Convert.ToDecimal(txtShiraze_.Text);
                if (txtCharm_.Text.Trim().Length != 0) tblCarpetPrice.Charm = Convert.ToDecimal(txtCharm_.Text);
                if (txtHasiri_.Text.Trim().Length != 0) tblCarpetPrice.Hasiri = Convert.ToDecimal(txtHasiri_.Text);
                if (txtGeytani_.Text.Trim().Length != 0) tblCarpetPrice.Geytani = Convert.ToDecimal(txtGeytani_.Text);
                if (txtPardakht_.Text.Trim().Length != 0) tblCarpetPrice.Pardakht = Convert.ToDecimal(txtPardakht_.Text);

                tblCarpetPrice.Description = txtDescription.Text;


                db.Entry(tblCarpetPrice).State = EntityState.Modified;
                //db.Entry(tblPersonnel).Property(x => x).IsModified = true;        
                db.Entry(tblCarpetPrice).Property(x => x.RegisterDate).IsModified = false;

                db.SaveChanges();

                LogContent = "CarpetPriceID = " + tblCarpetPrice.CarpetPriceID + " | " + "Shur = " + tblCarpetPrice.Shur + " | " + "Darkesh = " + tblCarpetPrice.Darkesh +
                         "Gayegh = " + tblCarpetPrice.Gayegh + " | " + "Shiraze = " + tblCarpetPrice.Shiraze + " | " + "Charm = " + tblCarpetPrice.Charm + " | " +
                         "Hasiri = " + tblCarpetPrice.Hasiri + " | " + "Geytani = " + tblCarpetPrice.Geytani + " | " + "Pardakht = " + tblCarpetPrice.Pardakht + " | " + "Description = " + tblCarpetPrice.Description + " | ";

                ClsTools.InsertLog(42, Program.tblUserLogin.UserID, LogContent, "tblCarpetPrice", tblCarpetPrice.CarpetPriceID);

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

        void DeleteRow()
        {
            try
            {
                CarpetCleaningEntities db = new CarpetCleaningEntities();
                tblCarpetPrice = db.tblCarpetPrices.Find(tblCarpetPrice.CarpetPriceID);

                LogContent = "CarpetPriceID = " + tblCarpetPrice.CarpetPriceID + " | " + "Shur = " + tblCarpetPrice.Shur + " | " + "Darkesh = " + tblCarpetPrice.Darkesh +
"Gayegh = " + tblCarpetPrice.Gayegh + " | " + "Shiraze = " + tblCarpetPrice.Shiraze + " | " + "Charm = " + tblCarpetPrice.Charm + " | " +
"Hasiri = " + tblCarpetPrice.Hasiri + " | " + "Geytani = " + tblCarpetPrice.Geytani + " | " + "Pardakht = " + tblCarpetPrice.Pardakht + " | " + "Description = " + tblCarpetPrice.Description + " | ";

                db.tblCarpetPrices.Remove(tblCarpetPrice);
                db.SaveChanges();


                ClsTools.InsertLog(43, Program.tblUserLogin.UserID, LogContent, "tblCarpetPrice", tblCarpetPrice.CarpetPriceID);

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
            tblCarpetPrice = new tblCarpetPrice();
            SaveType = 1;
            BindGrid();
            ClsTools.ClearContent(pnlNewEdit);
            btnDelete.Enabled = false;
            btnSelect.Enabled = false;
            txtYear_.Text = ClsTools.ShamsiDate().Substring(0, 4);
        }
        private void frmCarpetPrice_Load(object sender, EventArgs e)
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
                if (ClsTools.CheckValidation(pnlNewEdit) == false)
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
                tblCarpetPrice.CarpetPriceID = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
                BindRow();
                SaveType = 2;
                btnDelete.Enabled = true;
                if (LoadTypeID == 1) btnSelect.Enabled = true;
            }
            catch (Exception ex)
            {
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (tblCarpetPrice.CarpetPriceID == 0)
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
            try
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"^[0-9.\b]"))
                {
                    // Stop the character from being entered into the control since it is illegal.
                    e.Handled = true;
                }
            }
            catch (Exception)
            {        
            }     
        }

        private void txtMoney__TextChanged(object sender, EventArgs e)
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
