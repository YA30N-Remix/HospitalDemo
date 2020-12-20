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
    public partial class frmPersonnelFunction : Form
    {
        string LogContent = "";
        int SaveType = 1;
        public static tblPersonnelFunction tblPersonnelFunction = new tblPersonnelFunction();
        public static int LoadTypeID = 0;
        int Year = 0;
        public frmPersonnelFunction()
        {
            InitializeComponent();
        }

        void BindGrid()
        {
            try
            {
                CarpetCleaningEntities db = new CarpetCleaningEntities();
                var Query = from a in db.tblPersonnelFunctions
                            join b in db.tblPersonnels
                            on a.PersonnelID equals b.PersonnelID
                            select new { a.PersonnelFunctionID, PersonnelName = b.Name + " " + b.LastName, a.Month, a.Meters, a.Count, a.WorkDay };

                if (txtSearch.Text.Trim().Length != 0)
                {
                    Query = Query.Where(a => a.PersonnelFunctionID.ToString().Contains(txtSearch.Text) || a.PersonnelName.ToString().Contains(txtSearch.Text) || a.Month.ToString().Contains(txtSearch.Text) || a.Meters.ToString().Contains(txtSearch.Text) || a.Count.ToString().Contains(txtSearch.Text) || a.WorkDay.ToString().Contains(txtSearch.Text));
                }

                dgv.DataSource = Query.ToList();


                dgv.Columns[0].HeaderText = "کد کارکرد";
                dgv.Columns[0].Width = 100;
                dgv.Columns[1].HeaderText = "نام کارمند";
                dgv.Columns[1].Width = 140;
                dgv.Columns[2].HeaderText = "ماه";
                dgv.Columns[2].Width = 100;
                dgv.Columns[3].HeaderText = "متراژ";
                dgv.Columns[3].Width = 100;
                dgv.Columns[4].HeaderText = "تعداد";
                dgv.Columns[4].Width = 100;
                dgv.Columns[5].HeaderText = "روز کاری";
                dgv.Columns[5].Width = 100;
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
                  tblPersonnelFunction = db.tblPersonnelFunctions.Find(tblPersonnelFunction.PersonnelFunctionID);
                if (tblPersonnelFunction == null)
                {
                    FarsiMessagbox.Show(ClsMessage.ErrNotFound, "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
                    return;
                }

                BasicInformation.frmPersonnels.tblPersonnel.PersonnelID = Convert.ToInt32(tblPersonnelFunction.PersonnelID);
                BasicInformation.frmCarpets.tblCarpet.CarpetID = Convert.ToInt32(tblPersonnelFunction.CarpetID);
                var QueryPersonnel = (from a in db.tblPersonnels
                             where a.PersonnelID == BasicInformation.frmPersonnels.tblPersonnel.PersonnelID
                             select new { name = a.Name + " " + a.LastName }).ToList();
                txtPersonnel.Text = QueryPersonnel.ElementAt(0).name;

                var QueryCarpet = (from a in db.tblCarpets
                             where a.CarpetID == BasicInformation.frmCarpets.tblCarpet.CarpetID
                             select a.Title ).ToList();
                txtCarpet.Text = QueryCarpet.ElementAt(0);

                cmbMonth_.SelectedItem = tblPersonnelFunction.Month.ToString();
                Year = tblPersonnelFunction.Year;
                txtMeters_.Text = tblPersonnelFunction.Meters.ToString();
                txtCount_.Text = tblPersonnelFunction.Count.ToString();
                txtWorkDay_.Text = tblPersonnelFunction.WorkDay.ToString();
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
                tblPersonnelFunction tblPersonnelFunction = new tblPersonnelFunction();

                decimal MaxID = (from a in db.tblPersonnelFunctions
                                 select a.PersonnelFunctionID).DefaultIfEmpty().Max() + 1;

                tblPersonnelFunction.PersonnelFunctionID = MaxID;
                tblPersonnelFunction.PersonnelID = BasicInformation.frmPersonnels.tblPersonnel.PersonnelID;
                tblPersonnelFunction.CarpetID = BasicInformation.frmCarpets.tblCarpet.CarpetID;
                tblPersonnelFunction.Year = Convert.ToInt32(ClsTools.ShamsiDate().Substring(0, 4));
                tblPersonnelFunction.Month = Convert.ToInt16(cmbMonth_.SelectedItem);
                tblPersonnelFunction.Meters = Convert.ToDouble(txtMeters_.Text);
                tblPersonnelFunction.Count = Convert.ToDouble(txtCount_.Text);
                tblPersonnelFunction.WorkDay = Convert.ToDouble(txtWorkDay_.Text);

                tblPersonnelFunction.Description = txtDescription.Text;

                tblPersonnelFunction.RegisterDate = ClsTools.ShamsiDate();

                db.tblPersonnelFunctions.Add(tblPersonnelFunction);
                db.SaveChanges();


                LogContent = "PersonnelID = " + tblPersonnelFunction.PersonnelID + " | " + "CarpetID = " + tblPersonnelFunction.CarpetID + " | " + "Year = " + tblPersonnelFunction.Year + " | " + "Month = " + tblPersonnelFunction.Month + " | " +
                    "Meters = " + tblPersonnelFunction.Meters + " | " + "Count = " + tblPersonnelFunction.Count + " | " + "WorkDay = " + tblPersonnelFunction.WorkDay + " | " + tblPersonnelFunction.Active + " | " +
                      "Description = " + tblPersonnelFunction.Description + " | ";

                ClsTools.InsertLog(22, Program.tblUserLogin.UserID, LogContent, "tblPersonnelFunction", tblPersonnelFunction.PersonnelFunctionID);

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
                 tblPersonnelFunction = db.tblPersonnelFunctions.Find(tblPersonnelFunction.PersonnelFunctionID);

                if (tblPersonnelFunction == null)
                {
                    FarsiMessagbox.Show(ClsMessage.ErrNotFound, "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
                    return;
                }

                tblPersonnelFunction.PersonnelID = BasicInformation.frmPersonnels.tblPersonnel.PersonnelID;
                tblPersonnelFunction.CarpetID = BasicInformation.frmCarpets.tblCarpet.CarpetID;
                tblPersonnelFunction.Year = Year;
                tblPersonnelFunction.Month = Convert.ToInt16(cmbMonth_.SelectedItem);
                tblPersonnelFunction.Meters = Convert.ToDouble(txtMeters_.Text);
                tblPersonnelFunction.Count = Convert.ToDouble(txtCount_.Text);
                tblPersonnelFunction.WorkDay = Convert.ToDouble(txtWorkDay_.Text);

                tblPersonnelFunction.Description = txtDescription.Text;

                db.Entry(tblPersonnelFunction).State = EntityState.Modified;
                //db.Entry(tblPersonnel).Property(x => x).IsModified = true;        
                db.Entry(tblPersonnelFunction).Property(x => x.RegisterDate).IsModified = false;

                db.SaveChanges();

                LogContent = "PersonnelID = " + tblPersonnelFunction.PersonnelID + " | " + "CarpetID = " + tblPersonnelFunction.CarpetID + " | " + "Year = " + tblPersonnelFunction.Year + " | " + "Month = " + tblPersonnelFunction.Month + " | " +
                "Meters = " + tblPersonnelFunction.Meters + " | " + "Count = " + tblPersonnelFunction.Count + " | " + "WorkDay = " + tblPersonnelFunction.WorkDay + " | " + tblPersonnelFunction.Active + " | " +
                  "Description = " + tblPersonnelFunction.Description + " | ";

                ClsTools.InsertLog(23, Program.tblUserLogin.UserID, LogContent, "tblPersonnelFunction", tblPersonnelFunction.PersonnelFunctionID);

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

        void ChangeStatusRow()
        {
            try
            {
                CarpetCleaningEntities db = new CarpetCleaningEntities();
                  tblPersonnelFunction = db.tblPersonnelFunctions.Find(tblPersonnelFunction.PersonnelFunctionID);

                if (tblPersonnelFunction == null)
                {
                    FarsiMessagbox.Show(ClsMessage.ErrNotFound, "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
                    return;
                }

                if (tblPersonnelFunction.Active == 1) tblPersonnelFunction.Active = 0;
                else tblPersonnelFunction.Active = 1;


                db.tblPersonnelFunctions.Attach(tblPersonnelFunction);

                db.Entry(tblPersonnelFunction).Property(x => x.Active).IsModified = true; // $('#txtGoodsCode').val(),

                db.SaveChanges();

                LogContent = "Active = " + tblPersonnelFunction.Active;

                ClsTools.InsertLog(25, Program.tblUserLogin.UserID, LogContent, "tblPersonnelFunction", tblPersonnelFunction.PersonnelFunctionID);

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
                  tblPersonnelFunction = db.tblPersonnelFunctions.Find(tblPersonnelFunction.PersonnelFunctionID);

                LogContent = "PersonnelID = " + tblPersonnelFunction.PersonnelID + " | " + "CarpetID = " + tblPersonnelFunction.CarpetID + " | " + "Year = " + tblPersonnelFunction.Year + " | " + "Month = " + tblPersonnelFunction.Month + " | " +
                      "Meters = " + tblPersonnelFunction.Meters + " | " + "Count = " + tblPersonnelFunction.Count + " | " + "WorkDay = " + tblPersonnelFunction.WorkDay + " | " + tblPersonnelFunction.Active + " | " +
                        "Description = " + tblPersonnelFunction.Description + " | ";

                db.tblPersonnelFunctions.Remove(tblPersonnelFunction);
                db.SaveChanges();

                ClsTools.InsertLog(24, Program.tblUserLogin.UserID, LogContent, "tblPersonnelFunction", tblPersonnelFunction.PersonnelFunctionID);

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
            tblPersonnelFunction = new tblPersonnelFunction();
            SaveType = 1;
            BindGrid();
            BasicInformation.frmPersonnels.tblPersonnel.PersonnelID = 0;
            BasicInformation.frmCarpets.tblCarpet.CarpetID = 0;
            ClsTools.ClearContent(pnlNewEdit);
            btnDelete.Enabled = false;
            btnChangeStatus.Enabled = false;
            Year = 0;
        }
        private void frmPersonnelFunction_Load(object sender, EventArgs e)
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
                if (ClsTools.CheckValidation(pnlNewEdit) == false || BasicInformation.frmPersonnels.tblPersonnel.PersonnelID == 0 || BasicInformation.frmCarpets.tblCarpet.CarpetID == 0)
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
                tblPersonnelFunction.PersonnelFunctionID = Convert.ToDecimal(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
                BindRow();
                SaveType = 2;
                btnDelete.Enabled = true;
                btnChangeStatus.Enabled = true;
            }
            catch (Exception ex)
            {
            }
        }

        private void btnSelectPersonnels_Click(object sender, EventArgs e)
        {
            BasicInformation.frmPersonnels frmPersonnels = new BasicInformation.frmPersonnels();   
            BasicInformation.frmPersonnels.LoadTypeID = 1;
            frmPersonnels.FormClosed += frmPersonnels_Closed;
            frmPersonnels.ShowDialog();
        }

        private void frmPersonnels_Closed(object sender, FormClosedEventArgs e)
        {
            try
            {
                txtPersonnel.Text = BasicInformation.frmPersonnels.tblPersonnel.Name + " " + BasicInformation.frmPersonnels.tblPersonnel.LastName;
                BasicInformation.frmPersonnels.LoadTypeID = 0;
            }
            catch (Exception)
            {
            }
        }

        private void btnSelectCarpets_Click(object sender, EventArgs e)
        {
            BasicInformation.frmCarpets frmCarpets = new BasicInformation.frmCarpets();
            frmCarpets.FormClosed += frmCarpets_Closed;
            BasicInformation.frmCarpets.LoadTypeID = 1;
            frmCarpets.ShowDialog();
        }

        private void frmCarpets_Closed(object sender, FormClosedEventArgs e)
        {
            try
            {
                txtCarpet.Text = BasicInformation.frmCarpets.tblCarpet.Title;
            }
            catch (Exception)
            {
            }
        }

        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            ChangeStatusRow();
        }
    }
}
