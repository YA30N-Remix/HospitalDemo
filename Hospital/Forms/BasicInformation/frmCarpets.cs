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
    public partial class frmCarpets : Form
    {
        string LogContent = "";
        int SaveType = 1;
        public static tblCarpet tblCarpet = new tblCarpet();
        public static int LoadTypeID = 0;
        public frmCarpets()
        {
            InitializeComponent();
        }

        void BindGrid()
        {
            try
            {
                CarpetCleaningEntities db = new CarpetCleaningEntities();
                var Query = from a in db.tblCarpets
                            select new { a.CarpetID, a.Title, a.Width, a.Hight, a.Area };

                if (txtSearch.Text.Trim().Length != 0)
                {
                    Query = Query.Where(a => a.CarpetID.ToString().Contains(txtSearch.Text) || a.Title.ToString().Contains(txtSearch.Text) || a.Width.ToString().Contains(txtSearch.Text) || a.Hight.ToString().Contains(txtSearch.Text) || a.Area.ToString().Contains(txtSearch.Text));
                }

                dgv.DataSource = Query.ToList();
                          
                dgv.Columns[0].HeaderText = "کد فرش";
                dgv.Columns[0].Width = 120;
                dgv.Columns[1].HeaderText = "نوع";
                dgv.Columns[1].Width = 140;
                dgv.Columns[2].HeaderText = "طول";
                dgv.Columns[2].Width = 120;
                dgv.Columns[3].HeaderText = "عرض";
                dgv.Columns[3].Width = 120;
                dgv.Columns[4].HeaderText = "مساحت";
                dgv.Columns[3].Width = 120;
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
                tblCarpet = db.tblCarpets.Find(tblCarpet.CarpetID);
                if (tblCarpet == null)
                {
                    FarsiMessagbox.Show(ClsMessage.ErrNotFound, "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
                    return;
                }
                txtTitle_.Text = tblCarpet.Title;
                txtWidth_.Text = tblCarpet.Width.ToString();
                txtHight_.Text = tblCarpet.Hight.ToString();

                txtArea_.Text = tblCarpet.Area.ToString();
                txtShur.Text = tblCarpet.Shur.ToString();

                txtDarkesh.Text = tblCarpet.Darkesh.ToString();
                txtGayegh.Text = tblCarpet.Gayegh.ToString();
                txtShiraze.Text = tblCarpet.Shiraze.ToString();
                txtCharm.Text = tblCarpet.Charm.ToString();
                txtHasiri.Text = tblCarpet.Hasiri.ToString();
                txtGeytani.Text = tblCarpet.Geytani.ToString();
                txtPardakht.Text = tblCarpet.Pardakht.ToString();

                txtDescription.Text = tblCarpet.Description;
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
                tblCarpet tblCarpet = new tblCarpet();

                int MaxID = (from a in db.tblCarpets
                             select a.CarpetID).DefaultIfEmpty().Max() + 1;


                tblCarpet.CarpetID = MaxID;
                tblCarpet.Title = txtTitle_.Text;
                                              
                if (txtShur.Text.Trim().Length != 0) tblCarpet.Shur = Convert.ToDouble(txtShur.Text);
                if (txtDarkesh.Text.Trim().Length != 0) tblCarpet.Darkesh = Convert.ToDouble(txtDarkesh.Text);
                if (txtGayegh.Text.Trim().Length != 0) tblCarpet.Gayegh = Convert.ToDouble(txtGayegh.Text);
                if (txtShiraze.Text.Trim().Length != 0) tblCarpet.Shiraze = Convert.ToDouble(txtShiraze.Text);
                if (txtCharm.Text.Trim().Length != 0) tblCarpet.Charm = Convert.ToDouble(txtCharm.Text);
                if (txtHasiri.Text.Trim().Length != 0) tblCarpet.Hasiri = Convert.ToDouble(txtHasiri.Text);
                if (txtGeytani.Text.Trim().Length != 0) tblCarpet.Geytani = Convert.ToDouble(txtGeytani.Text);
                if (txtPardakht.Text.Trim().Length != 0) tblCarpet.Pardakht = Convert.ToDouble(txtPardakht.Text);

                tblCarpet.Width = Convert.ToDouble(txtWidth_.Text);
                tblCarpet.Hight = Convert.ToDouble(txtHight_.Text);
                tblCarpet.Area = Convert.ToDouble(txtArea_.Text);

                tblCarpet.Description = txtDescription.Text;

                tblCarpet.RegisterDate = ClsTools.ShamsiDate();

                db.tblCarpets.Add(tblCarpet);
                db.SaveChanges();
                      
                LogContent = "Title = " + tblCarpet.Title + " | " + "Width = " + tblCarpet.Width + " | " + "Hight = " + tblCarpet.Hight +
                      "Description = " + tblCarpet.Description + " | ";

                ClsTools.InsertLog(19, Program.tblUserLogin.UserID, LogContent, "tblCarpet", tblCarpet.CarpetID);

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
                tblCarpet = db.tblCarpets.Find(tblCarpet.CarpetID);

                if (tblCarpet == null)
                {
                    FarsiMessagbox.Show(ClsMessage.ErrNotFound, "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
                    return;
                }

                tblCarpet.Title = txtTitle_.Text;
                tblCarpet.Width = Convert.ToDouble(txtWidth_.Text);
                tblCarpet.Hight = Convert.ToDouble(txtHight_.Text);
                tblCarpet.Area = Convert.ToDouble(txtArea_.Text);
                if (txtShur.Text.Trim().Length != 0) tblCarpet.Shur = Convert.ToDouble(txtShur.Text);
                if (txtDarkesh.Text.Trim().Length != 0) tblCarpet.Darkesh = Convert.ToDouble(txtDarkesh.Text);
                if (txtGayegh.Text.Trim().Length != 0) tblCarpet.Gayegh = Convert.ToDouble(txtGayegh.Text);
                if (txtShiraze.Text.Trim().Length != 0) tblCarpet.Shiraze = Convert.ToDouble(txtShiraze.Text);
                if (txtCharm.Text.Trim().Length != 0) tblCarpet.Charm = Convert.ToDouble(txtCharm.Text);
                if (txtHasiri.Text.Trim().Length != 0) tblCarpet.Hasiri = Convert.ToDouble(txtHasiri.Text);
                if (txtGeytani.Text.Trim().Length != 0) tblCarpet.Geytani = Convert.ToDouble(txtGeytani.Text);
                if (txtPardakht.Text.Trim().Length != 0) tblCarpet.Pardakht = Convert.ToDouble(txtPardakht.Text);
                                     
                tblCarpet.Description = txtDescription.Text;
                tblCarpet.Description = txtDescription.Text;

                db.Entry(tblCarpet).State = EntityState.Modified;
                //db.Entry(tblPersonnel).Property(x => x).IsModified = true;        
                db.Entry(tblCarpet).Property(x => x.RegisterDate).IsModified = false;

                db.SaveChanges();

                LogContent = "Title = " + tblCarpet.Title + " | " + "Width = " + tblCarpet.Width + " | " + "Hight = " + tblCarpet.Hight +
                         "Description = " + tblCarpet.Description + " | ";

                ClsTools.InsertLog(20, Program.tblUserLogin.UserID, LogContent, "tblCarpet", tblCarpet.CarpetID);

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
                tblCarpet = db.tblCarpets.Find(tblCarpet.CarpetID);

                LogContent = "Title = " + tblCarpet.Title + " | " + "Width = " + tblCarpet.Width + " | " + "Hight = " + tblCarpet.Hight +
                           "Description = " + tblCarpet.Description + " | ";

                db.tblCarpets.Remove(tblCarpet);
                db.SaveChanges();

                ClsTools.InsertLog(21, Program.tblUserLogin.UserID, LogContent, "tblCarpet", tblCarpet.CarpetID);

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
            tblCarpet = new tblCarpet();
            SaveType = 1;
            BindGrid();
            ClsTools.ClearContent(pnlNewEdit);
            btnDelete.Enabled = false;
            btnSelect.Enabled = false;
        }
        private void frmCarpets_Load(object sender, EventArgs e)
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
                tblCarpet.CarpetID = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
                BindRow();
                SaveType = 2;
                btnDelete.Enabled = true;
                if (LoadTypeID == 1) btnSelect.Enabled = true;
            }
            catch (Exception ex)
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

        private void txtSums_TextChanged(object sender, EventArgs e)
        {
            sumText();
        }

        private void sumText()
        {
            double Shur = 0, Darkesh = 0, Gayegh = 0, Shiraze = 0, Charm = 0, Hasiri = 0, Geytani = 0, Pardakht = 0;

            if (txtShur.Text.Trim().Length != 0) Shur = Convert.ToDouble(txtShur.Text);
            if (txtDarkesh.Text.Trim().Length != 0) Darkesh = Convert.ToDouble(txtDarkesh.Text);
            if (txtGayegh.Text.Trim().Length != 0) Gayegh = Convert.ToDouble(txtGayegh.Text);
            if (txtShiraze.Text.Trim().Length != 0) Shiraze = Convert.ToDouble(txtShiraze.Text);
            if (txtCharm.Text.Trim().Length != 0) Charm = Convert.ToDouble(txtCharm.Text);
            if (txtHasiri.Text.Trim().Length != 0) Hasiri = Convert.ToDouble(txtHasiri.Text);
            if (txtGeytani.Text.Trim().Length != 0) Geytani = Convert.ToDouble(txtGeytani.Text);
            if (txtPardakht.Text.Trim().Length != 0) Pardakht = Convert.ToDouble(txtPardakht.Text);

            txtSum.Text = (Shur + Darkesh + Gayegh + Shiraze + Charm + Hasiri + Geytani + Pardakht).ToString();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (tblCarpet.CarpetID == 0)
            {
                FarsiMessagbox.Show(ClsMessage.Error + "\n" + "رکوردی انتخاب نشده است", "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
                return;
            }
            SaveType = 1;
            LoadTypeID = 0;
            this.Close();
        }
    }
}
