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
    public partial class frmPersonnels : Form
    {
        string LogContent = "";
        byte[] array;
        int SaveType = 1;
        public static tblPersonnel tblPersonnel = new tblPersonnel();    
        public static int LoadTypeID = 0;
        public frmPersonnels()
        {
            InitializeComponent();
        }

        void BindGrid()
        {
            try
            {
                CarpetCleaningEntities db = new CarpetCleaningEntities();
                var Query = from a in db.tblPersonnels
                            select new { a.PersonnelID, a.Name, a.LastName, a.FatherName, a.Mobile, ActiveName = a.Active == 0 ? "غیرفعال" : "فعال" };

                if (LoadTypeID == 1) Query = Query.Where(a => a.ActiveName == "فعال");

                if (txtSearch.Text.Trim().Length != 0)
                {
                    Query = Query.Where(a => a.PersonnelID.ToString().Contains(txtSearch.Text) || a.Name.Contains(txtSearch.Text) || a.LastName.Contains(txtSearch.Text) || a.FatherName.Contains(txtSearch.Text) || a.Mobile.Contains(txtSearch.Text) || a.ActiveName.Contains(txtSearch.Text));
                }

                dgv.DataSource = Query.ToList();


                dgv.Columns[0].HeaderText = "کد کارمندی";
                dgv.Columns[0].Width = 100;
                dgv.Columns[1].HeaderText = "نام";
                dgv.Columns[1].Width = 100;
                dgv.Columns[2].HeaderText = "نام خانوادگی";
                dgv.Columns[2].Width = 100;
                dgv.Columns[3].HeaderText = "نام پدر";
                dgv.Columns[3].Width = 120;
                dgv.Columns[4].HeaderText = "شماره موبایل";
                dgv.Columns[4].Width = 120;
                dgv.Columns[5].HeaderText = "وضعیت";
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
                 tblPersonnel = db.tblPersonnels.Find(tblPersonnel.PersonnelID);
                if (tblPersonnel == null)
                {
                    FarsiMessagbox.Show(ClsMessage.ErrNotFound, "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
                    return;
                }
                txtName_.Text = tblPersonnel.Name;
                txtLastName_.Text = tblPersonnel.LastName;
                txtNationCode_.Text = tblPersonnel.NationCode;
                txtId_.Text = tblPersonnel.Id;
                if (tblPersonnel.SexType) rdbWoman.Checked = true; else rdbMan.Checked = true;
                if (tblPersonnel.MaritalStatus == 1) rdbSingle.Checked = true; else rdbMerrid.Checked = true;

                txtFatherName.Text = tblPersonnel.FatherName;
                txtBithayDay.Text = tblPersonnel.BithayDay;
                txtCityOfBirth.Text = tblPersonnel.CityOfBirth;
                txtCityOfLife.Text = tblPersonnel.CityOfLife;
                txtMobile.Text = tblPersonnel.Mobile;
                txtAddress.Text = tblPersonnel.Address;
                txtDescription.Text = tblPersonnel.Description;
                if (! String.IsNullOrEmpty(tblPersonnel.Image))
                {                                
                    var stream = File.Open(tblPersonnel.Image, FileMode.Open);
                    var image = Image.FromStream(stream);
                    imgBox.Image = image;
                    imgBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    stream.Close();
                }
           
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
                tblPersonnel tblPersonnel = new tblPersonnel();

                int MaxID = (from a in db.tblPersonnels
                             select a.PersonnelID).DefaultIfEmpty().Max() + 1;

                var Query = from a in db.tblPersonnels
                            where a.NationCode == txtNationCode_.Text
                            select a;

                if (Query.Count() != 0)
                {
                    FarsiMessagbox.Show(ClsMessage.ErrRepeat + "\n" + "کد ملی تکراری می باشد", "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
                    return;
                }

                string savepath = @".\Documents\Personnel\";
                if (!Directory.Exists(savepath))
                {
                    Directory.CreateDirectory(savepath);
                }

                tblPersonnel.PersonnelID = MaxID;
                tblPersonnel.Name = txtName_.Text;
                tblPersonnel.LastName = txtLastName_.Text;
                if (array != null) tblPersonnel.Image = savepath + tblPersonnel.PersonnelID.ToString() + ".jpg";
                else tblPersonnel.Image = "";

                tblPersonnel.NationCode = txtNationCode_.Text;
                tblPersonnel.Id = txtId_.Text;
                tblPersonnel.SexType = rdbWoman.Checked;
                if (rdbSingle.Checked) tblPersonnel.MaritalStatus = 1; else tblPersonnel.MaritalStatus = 2;
                tblPersonnel.FatherName = txtFatherName.Text;
                tblPersonnel.BithayDay = txtBithayDay.MaskedTextProvider.ToDisplayString();
                tblPersonnel.CityOfBirth = txtCityOfBirth.Text;
                tblPersonnel.CityOfLife = txtCityOfLife.Text;
                tblPersonnel.Mobile = txtMobile.Text;
                tblPersonnel.Address = txtAddress.Text;
                tblPersonnel.Description = txtDescription.Text;
                tblPersonnel.Active = 1;
                tblPersonnel.RegisterDate = ClsTools.ShamsiDate();

                db.tblPersonnels.Add(tblPersonnel);
                db.SaveChanges();

                if (array != null) File.WriteAllBytes(tblPersonnel.Image, array);

                LogContent = "Name = " + tblPersonnel.Name + " | " + "LastName = " + tblPersonnel.LastName + " | " + "Image = " + tblPersonnel.Image +
                  "NationCode = " + tblPersonnel.NationCode + " | " + "Id = " + tblPersonnel.Id + " | " + "SexType = " + tblPersonnel.SexType +
                  "MaritalStatus = " + tblPersonnel.MaritalStatus + " | " + "BithayDay = " + tblPersonnel.BithayDay + " | " + "CityOfBirth = " + tblPersonnel.CityOfBirth +
                  "CityOfLife = " + tblPersonnel.CityOfLife + " | " + "Mobile = " + tblPersonnel.Mobile + " | " + "Address = " + tblPersonnel.Address +
                  " | " + "Description = " + tblPersonnel.Description + " | ";

                ClsTools.InsertLog(5, Program.tblUserLogin.UserID, LogContent, "tblPersonnel", tblPersonnel.PersonnelID);

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
                 tblPersonnel = db.tblPersonnels.Find(tblPersonnel.PersonnelID);

                if (tblPersonnel == null)
                {
                    FarsiMessagbox.Show(ClsMessage.ErrNotFound, "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
                    return;
                }

                var Query = from a in db.tblPersonnels
                            where a.NationCode == txtNationCode_.Text && a.PersonnelID != tblPersonnel. PersonnelID 
                            select a;

                if (Query.Count() != 0)
                {
                    FarsiMessagbox.Show(ClsMessage.ErrRepeat + "\n" + "کد ملی تکراری می باشد", "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
                    return;
                }
                string savepath = @".\Documents\Personnel\";
                if (!Directory.Exists(savepath))
                {
                    Directory.CreateDirectory(savepath);
                }
                tblPersonnel.Name = txtName_.Text;
                tblPersonnel.LastName = txtLastName_.Text;
                if (array != null) tblPersonnel.Image = savepath + tblPersonnel.PersonnelID.ToString() + ".jpg";
                else tblPersonnel.Image = "";

                tblPersonnel.NationCode = txtNationCode_.Text;
                tblPersonnel.Id = txtId_.Text;
                tblPersonnel.SexType = rdbWoman.Checked;
                if (rdbSingle.Checked) tblPersonnel.MaritalStatus = 1; else tblPersonnel.MaritalStatus = 2;
                tblPersonnel.FatherName = txtFatherName.Text;
                tblPersonnel.BithayDay = txtBithayDay.MaskedTextProvider.ToDisplayString();
                tblPersonnel.CityOfBirth = txtCityOfBirth.Text;
                tblPersonnel.CityOfLife = txtCityOfLife.Text;
                tblPersonnel.Mobile = txtMobile.Text;
                tblPersonnel.Address = txtAddress.Text;
                tblPersonnel.Description = txtDescription.Text;

                db.tblPersonnels.Attach(tblPersonnel);
                db.Entry(tblPersonnel).State = EntityState.Modified;
                //db.Entry(tblPersonnel).Property(x => x).IsModified = true;
                db.Entry(tblPersonnel).Property(x => x.Active).IsModified = false;
                db.Entry(tblPersonnel).Property(x => x.RegisterDate).IsModified = false;
                if (array != null) db.Entry(tblPersonnel).Property(x => x.Image).IsModified = false;

                db.SaveChanges();
                if (array != null)
                {
                    if (File.Exists(tblPersonnel.Image))
                    {  
                        // imgBox_.Dispose();
                        //  Array.ForEach(Directory.GetFiles(tblUser.Image),  File.Delete);
                        File.Delete(tblPersonnel.Image);
                    }
                    File.WriteAllBytes(tblPersonnel.Image, array);

                }

                LogContent = "Name = " + tblPersonnel.Name + " | " + "LastName = " + tblPersonnel.LastName + " | " + "Image = " + tblPersonnel.Image +
                  "NationCode = " + tblPersonnel.NationCode + " | " + "Id = " + tblPersonnel.Id + " | " + "SexType = " + tblPersonnel.SexType +
                  "MaritalStatus = " + tblPersonnel.MaritalStatus + " | " + "BithayDay = " + tblPersonnel.BithayDay + " | " + "CityOfBirth = " + tblPersonnel.CityOfBirth +
                  "CityOfLife = " + tblPersonnel.CityOfLife + " | " + "Mobile = " + tblPersonnel.Mobile + " | " + "Address = " + tblPersonnel.Address +
                  " | " + "Description = " + tblPersonnel.Description + " | ";

                ClsTools.InsertLog(6, Program.tblUserLogin.UserID, LogContent, "tblPersonnel", tblPersonnel.PersonnelID);

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
                tblPersonnel = db.tblPersonnels.Find(tblPersonnel.PersonnelID);

                if (tblPersonnel == null)
                {
                    FarsiMessagbox.Show(ClsMessage.ErrNotFound, "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
                    return;
                }

                if (tblPersonnel.Active == 1) tblPersonnel.Active = 0;
                else tblPersonnel.Active = 1;
                                    
                db.tblPersonnels.Attach(tblPersonnel);

                db.Entry(tblPersonnel).Property(x => x.Active).IsModified = true; // $('#txtGoodsCode').val(),

                db.SaveChanges();

                LogContent = "Active = " + tblPersonnel.Active;

                ClsTools.InsertLog(8, Program.tblUserLogin.UserID, LogContent, "tblPersonnel", tblPersonnel.PersonnelID);

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
                 tblPersonnel = db.tblPersonnels.Find(tblPersonnel.PersonnelID);

                LogContent = "Name = " + tblPersonnel.Name + " | " + "LastName = " + tblPersonnel.LastName + " | " + "Image = " + tblPersonnel.Image +
   "NationCode = " + tblPersonnel.NationCode + " | " + "Id = " + tblPersonnel.Id + " | " + "SexType = " + tblPersonnel.SexType +
   "MaritalStatus = " + tblPersonnel.MaritalStatus + " | " + "BithayDay = " + tblPersonnel.BithayDay + " | " + "CityOfBirth = " + tblPersonnel.CityOfBirth + " | " +
   "CityOfLife = " + tblPersonnel.CityOfLife + " | " + "Mobile = " + tblPersonnel.Mobile + " | " + "Address = " + tblPersonnel.Address +
   " | " + "Description = " + tblPersonnel.Description + " | " + "Active = " + tblPersonnel.Active + " | ";

                db.tblPersonnels.Remove(tblPersonnel);
                db.SaveChanges();


                ClsTools.InsertLog(7, Program.tblUserLogin.UserID, LogContent, "tblPersonnel", tblPersonnel.PersonnelID);

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
            tblPersonnel = new tblPersonnel();
            SaveType = 1;
            BindGrid();
            ClsTools.ClearContent(pnlNewEdit);
            btnDelete.Enabled = false;
            btnChangeStatus.Enabled = false;
            btnSelect.Enabled = false;
            array = null;
        }
        private void frmPersonnels_Load(object sender, EventArgs e)
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

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            try
            {
                ofdImage_.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.png) | *.jpg; *.jpeg; *.jpe; *.png";
                if (ofdImage_.ShowDialog() == DialogResult.OK)
                {
                    string filename;
                    filename = ofdImage_.FileName;
                    var size = new FileInfo(filename).Length;

                    if (size > 130000)
                    {
                        FarsiMessagbox.Show(ClsMessage.ErrorSizeFile, "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
                        return;
                    }

                    array = File.ReadAllBytes(filename);
                    imgBox.Image = new Bitmap(filename);
                    imgBox.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                //var os = ofdImage.     
            }
            catch (Exception ex)
            {
                FarsiMessagbox.Show(ClsMessage.Error + "\n" + ex.Message.ToString(), "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
            }
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
                tblPersonnel.PersonnelID = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
                BindRow();
                SaveType = 2;
                btnDelete.Enabled = true;
                btnChangeStatus.Enabled = true;
                if (LoadTypeID == 1) btnSelect.Enabled = true;
            }
            catch (Exception ex)
            {
            }
        }

        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            ChangeStatusRow();
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

        private void txtBithayDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"^\d\b$"))
            {
                // Stop the character from being entered into the control since it is illegal.           Regex.IsMatch(input, @"^[a-zA-Z0-9]+$");
                e.Handled = true;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (tblPersonnel.PersonnelID == 0)
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
