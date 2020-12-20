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
    public partial class frmNotes : Form
    {
        string LogContent = "";
        int SaveType = 1;
        public static tblNote tblNote = new tblNote();          
        public static int LoadTypeID = 0;
        public frmNotes()
        {
            InitializeComponent();
        }

        void BindGrid()
        {
            try
            {
                CarpetCleaningEntities db = new CarpetCleaningEntities();
                var Query = from a in db.tblNotes
                            select new { a.NoteID, a.Title, a.StartDate, a.EndDate, a.Note };

                if (txtSearch.Text.Trim().Length != 0)
                {
                    Query = Query.Where(a => a.NoteID.ToString().Contains(txtSearch.Text) || a.Title.Contains(txtSearch.Text) || a.StartDate.Contains(txtSearch.Text) || a.EndDate.Contains(txtSearch.Text));
                }

                dgv.DataSource = Query.ToList();

                dgv.Columns[0].HeaderText = "کد یادداشت";
                dgv.Columns[0].Width = 100;
                dgv.Columns[1].HeaderText = "عنوان";
                dgv.Columns[1].Width = 120;
                dgv.Columns[2].HeaderText = "از تاریخ";
                dgv.Columns[2].Width = 120;
                dgv.Columns[3].HeaderText = "تا تاریخ";
                dgv.Columns[3].Width = 120;
                dgv.Columns[4].HeaderText = "یادداشت";
                dgv.Columns[4].Width = 200;

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
                 tblNote = db.tblNotes.Find(tblNote.NoteID);
                if (tblNote == null)
                {
                    FarsiMessagbox.Show(ClsMessage.ErrNotFound, "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
                    return;
                }
                txtTitle_.Text = tblNote.Title;
                txtStartDate.Text = tblNote.StartDate;
                txtEndDate.Text = tblNote.EndDate;
                txtNote.Text = tblNote.Note;
                txtDescription.Text = tblNote.Description;
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
                tblNote tblNote = new tblNote();

                decimal MaxID = (from a in db.tblNotes
                                 select a.NoteID).DefaultIfEmpty().Max() + 1;
                                
                tblNote.NoteID = MaxID;
                tblNote.Title = txtTitle_.Text;
                tblNote.StartDate = txtStartDate.MaskedTextProvider.ToDisplayString();
                tblNote.EndDate = txtEndDate.MaskedTextProvider.ToDisplayString();
                tblNote.Note = txtNote.Text;
                tblNote.Description = txtDescription.Text;
                tblNote.RegisterDate = ClsTools.ShamsiDate();

                db.tblNotes.Add(tblNote);
                db.SaveChanges();

                LogContent = "Title = " + tblNote.Title + " | " + "StartDate = " + tblNote.StartDate + " | " + "Note = " + tblNote.Note + " | " +
                      "EndDate = " + tblNote.EndDate + " | " + "Description = " + tblNote.Description + " | ";

                ClsTools.InsertLog(13, Program.tblUserLogin.UserID, LogContent, "tblNote", tblNote.NoteID);

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
                 tblNote = db.tblNotes.Find(tblNote.NoteID);

                if (tblNote == null)
                {
                    FarsiMessagbox.Show(ClsMessage.ErrNotFound, "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
                    return;
                }

                tblNote.Title = txtTitle_.Text;
                tblNote.StartDate = txtStartDate.MaskedTextProvider.ToDisplayString();
                tblNote.EndDate = txtEndDate.MaskedTextProvider.ToDisplayString();
                tblNote.Note = txtNote.Text;
                tblNote.Description = txtDescription.Text;
                tblNote.RegisterDate = ClsTools.ShamsiDate();

                db.Entry(tblNote).State = EntityState.Modified;
                //db.Entry(tblPersonnel).Property(x => x).IsModified = true;         
                db.Entry(tblNote).Property(x => x.RegisterDate).IsModified = false;

                db.SaveChanges();

                LogContent = "Title = " + tblNote.Title + " | " + "StartDate = " + tblNote.StartDate + " | " + "Note = " + tblNote.Note + " | " +
                     "EndDate = " + tblNote.EndDate + " | " + "Description = " + tblNote.Description + " | ";

                ClsTools.InsertLog(14, Program.tblUserLogin.UserID, LogContent, "tblNote", tblNote.NoteID);

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
                tblNote = db.tblNotes.Find(tblNote.NoteID);

                LogContent = "Title = " + tblNote.Title + " | " + "StartDate = " + tblNote.StartDate + " | " + "Note = " + tblNote.Note + " | " +
                    "EndDate = " + tblNote.EndDate + " | " + "Description = " + tblNote.Description + " | ";

                db.tblNotes.Remove(tblNote);
                db.SaveChanges();



                ClsTools.InsertLog(15, Program.tblUserLogin.UserID, LogContent, "tblNote", tblNote.NoteID);

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
            tblNote = new tblNote();
              SaveType = 1;
            BindGrid();
            ClsTools.ClearContent(pnlNewEdit);
            btnDelete.Enabled = false;
            btnSelect.Enabled = false;
        }

        private void frmNotes_Load(object sender, EventArgs e)
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
                tblNote. NoteID = Convert.ToDecimal(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
                BindRow();
                SaveType = 2;
                btnDelete.Enabled = true;
                if (LoadTypeID == 1) btnSelect.Enabled = true;
            }
            catch (Exception ex)
            {
            }
        }

        private void txtMobile__KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"^\d\b\s$"))
            {
                // Stop the character from being entered into the control since it is illegal.           Regex.IsMatch(input, @"^[a-zA-Z0-9]+$");
                e.Handled = true;
            }
        }

        private void txtUserName__KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"^[A-Za-z0-9\b]"))
            {
                // Stop the character from being entered into the control since it is illegal.
                e.Handled = true;
            }
        }

        private void txtName__KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"^[آ-ی\b\s]$"))
            {
                // Stop the character from being entered into the control since it is illegal.
                e.Handled = true;
            }
        }

        private void txtLastName__KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"^[آ-ی\b\s]$"))
            {
                // Stop the character from being entered into the control since it is illegal.
                e.Handled = true;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (tblNote.NoteID == 0)
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
