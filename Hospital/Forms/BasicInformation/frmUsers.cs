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
    public partial class frmUsers : Form
    {
        string LogContent = "";
        int SaveType = 1;
        public static tblUser tblUser = new tblUser();
        public static int LoadTypeID = 0;
        byte[] array;       
        public frmUsers()
        {
            InitializeComponent();
        }

        void BindGrid()
        {
            try
            {
                CarpetCleaningEntities db = new CarpetCleaningEntities();
                var Query = from a in db.tblUsers
                            select new { a.UserID, a.Name, a.LastName, a.UserName, a.Mobile, ActiveName = a.Active == 0 ? "غیرفعال" : "فعال" };

                if (LoadTypeID == 1) Query = Query.Where(a => a.ActiveName == "فعال");

                if (txtSearch.Text.Trim().Length != 0)
                {
                    Query = Query.Where(a => a.UserID.ToString().Contains(txtSearch.Text) || a.Name.Contains(txtSearch.Text) || a.LastName.Contains(txtSearch.Text) || a.UserName.Contains(txtSearch.Text) || a.Mobile.Contains(txtSearch.Text) || a.ActiveName.Contains(txtSearch.Text));
                }
                
                dgv.DataSource = Query.ToList();
                                   
                dgv.Columns[0].HeaderText = "کد کاربری";
                dgv.Columns[0].Width = 100;
                dgv.Columns[1].HeaderText = "نام";
                dgv.Columns[1].Width = 100;
                dgv.Columns[2].HeaderText = "نام خانوادگی";
                dgv.Columns[2].Width = 100;
                dgv.Columns[3].HeaderText = "نام کاربری";
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
                 tblUser = db.tblUsers.Find(tblUser.UserID);
                if (tblUser == null)
                {
                    FarsiMessagbox.Show(ClsMessage.ErrNotFound, "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
                    return;
                }
                txtName_.Text = tblUser.Name;
                txtLastName_.Text = tblUser.LastName;
                txtUserName_.Text = tblUser.UserName;
                txtPassWord_.Text = ClsTools.DeCode(tblUser.PassWord);
                txtRePassWord_.Text = ClsTools.DeCode(tblUser.PassWord);
                txtMobile_.Text = tblUser.Mobile;
                txtDescription.Text = tblUser.Description;
                //myFile = File.Create(Application.StartupPath + tblUser.Image);
                if (!String.IsNullOrEmpty(tblUser.Image))
                {      
                    var stream = File.Open(tblUser.Image, FileMode.Open);
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
                tblUser tblUser = new tblUser();

                int MaxID = (from a in db.tblUsers
                             select a.UserID).DefaultIfEmpty().Max() + 1;

                var Query = from a in db.tblUsers
                            where a.UserName == txtUserName_.Text
                            select a;

                if (Query.Count() != 0)
                {
                    FarsiMessagbox.Show(ClsMessage.ErrRepeat + "\n" + "نام کاربری تکراری می باشد", "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
                    return;
                }

                string savepath = @".\Documents\Users\";
                if (!Directory.Exists(savepath))
                {
                    Directory.CreateDirectory(savepath);
                }

                tblUser.UserID = MaxID;
                tblUser.Name = txtName_.Text;
                tblUser.LastName = txtLastName_.Text;
                if (array != null) tblUser.Image = savepath + MaxID.ToString() + ".jpg"; else tblUser.Image = "";
tblUser.BackGroundImage = "";
                tblUser.UserName = txtUserName_.Text;
                tblUser.PassWord = ClsTools.EnCode(txtPassWord_.Text);
                tblUser.Mobile = txtMobile_.Text;
                tblUser.Description = txtDescription.Text;
                tblUser.Active = 1;
                tblUser.RegisterDate = ClsTools.ShamsiDate();

                db.tblUsers.Add(tblUser);
                db.SaveChanges();


                if (array != null)
                {
                    if (File.Exists(tblUser.Image))
                    {           
                        // imgBox_.Dispose();
                        //  Array.ForEach(Directory.GetFiles(tblUser.Image),  File.Delete);
                        File.Delete(tblUser.Image);
                    }
                    File.WriteAllBytes(tblUser.Image, array);
                }

                LogContent = "Name = " + tblUser.Name + " | " + "LastName = " + tblUser.LastName + " | " + "Image = " + tblUser.Image +
                      "UserName = " + tblUser.UserName + " | " + "Mobile = " + tblUser.Mobile + " | " + 
                      "Description = " + tblUser.Description + " | " +"Active = " + tblUser.Active + " | ";

                ClsTools.InsertLog(1, Program.tblUserLogin.UserID, LogContent, "tblUser", tblUser.UserID);

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
                 tblUser = db.tblUsers.Find(tblUser.UserID);

                if (tblUser == null)
                {
                    FarsiMessagbox.Show(ClsMessage.ErrNotFound, "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
                    return;
                }

                var Query = from a in db.tblUsers
                            where a.UserName == txtUserName_.Text && a.UserID != tblUser.UserID
                            select a;

                if (Query.Count() != 0)
                {
                    FarsiMessagbox.Show(ClsMessage.ErrRepeat + "\n" + "نام کاربری تکراری می باشد", "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
                    return;
                }
                                      
                tblUser.Name = txtName_.Text;
                tblUser.LastName = txtLastName_.Text;
                tblUser.BackGroundImage = "";
                tblUser.UserName = txtUserName_.Text;
                tblUser.PassWord = ClsTools.EnCode(txtPassWord_.Text);
                tblUser.Mobile = txtMobile_.Text;
                tblUser.Description = txtDescription.Text;

                db.Entry(tblUser).State = EntityState.Modified;
                //db.Entry(tblPersonnel).Property(x => x).IsModified = true;
                db.Entry(tblUser).Property(x => x.Active).IsModified = false;
                db.Entry(tblUser).Property(x => x.Image).IsModified = false;
                db.Entry(tblUser).Property(x => x.RegisterDate).IsModified = false;

                db.SaveChanges();

                if (array != null)
                {
                    if (File.Exists(tblUser.Image))
                    {
                        imgBox.Image = null;
                       imgBox.Refresh();
                        // imgBox_.Dispose();
                      //  Array.ForEach(Directory.GetFiles(tblUser.Image),  File.Delete);
                        File.Delete(tblUser.Image);
                    }
                    File.WriteAllBytes(tblUser.Image, array);                      
                }


                LogContent = "Name = " + tblUser.Name + " | " + "LastName = " + tblUser.LastName + " | " + "Image = " + tblUser.Image +
                       "UserName = " + tblUser.UserName + " | " + "Mobile = " + tblUser.Mobile + " | " + 
                       "Description = " + tblUser.Description + " | " + "Active = " + tblUser.Active + " | ";

                ClsTools.InsertLog(2, Program.tblUserLogin.UserID, LogContent, "tblUser", tblUser.UserID);
                          
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
                 tblUser = db.tblUsers.Find(tblUser.UserID);

                if (tblUser == null)
                {
                    FarsiMessagbox.Show(ClsMessage.ErrNotFound, "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
                    return;
                }

                if (tblUser.Active == 1) tblUser.Active = 0;
                else tblUser.Active = 1;


                db.tblUsers.Attach(tblUser);

                db.Entry(tblUser).Property(x => x.Active).IsModified = true; // $('#txtGoodsCode').val(),

                db.SaveChanges();

                LogContent = "Active = " + tblUser.Active;

                ClsTools.InsertLog(4, Program.tblUserLogin.UserID, LogContent, "tblUser", tblUser.UserID);

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
                 tblUser = db.tblUsers.Find(tblUser.UserID);

                LogContent = "Name = " + tblUser.Name + " | " + "LastName = " + tblUser.LastName + " | " + "Image = " + tblUser.Image +
                        "UserName = " + tblUser.UserName + " | " + "Mobile = " + tblUser.Mobile + " | " + 
                        "Description = " + tblUser.Description + " | " + "Active = " + tblUser.Active + " | ";
                
                File.Delete(tblUser.Image);
                if (tblUser.BackGroundImage.Trim().Length!=0)
                {
                        File.Delete(tblUser.BackGroundImage);    
                }
                      
                db.tblUsers.Remove(tblUser);
                db.SaveChanges();

                ClsTools.InsertLog(3, Program.tblUserLogin.UserID, LogContent, "tblUser", tblUser.UserID);

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
            tblUser.UserID = 0;
            SaveType = 1;
            BindGrid();
            ClsTools.ClearContent(pnlNewEdit);
            btnDelete.Enabled = false;
            btnChangeStatus.Enabled = false;
            btnSelect.Enabled = false;
            array = null;
        }
        private void frmUsers_Load(object sender, EventArgs e)
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

                if (txtPassWord_.Text != txtRePassWord_.Text)
                {
                    FarsiMessagbox.Show("تکرار کلمه عبور با کلمه عبور  یکسان نمی باشد", "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
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
                tblUser.UserID = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
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

        private void txtFarsi__KeyPress(object sender, KeyPressEventArgs e)
        {
              if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"^[آ-ی\b\s]$"))
            {
                // Stop the character from being entered into the control since it is illegal.
                e.Handled = true;
            }
        }
       
        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (tblUser.UserID == 0)
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
