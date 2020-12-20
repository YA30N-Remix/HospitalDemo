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
    public partial class frmCustomers : Form
    {
        string LogContent = "";
        int SaveType = 1;          
 
        public static int LoadTypeID = 0;
        public static int CustomerTypeID = 0;
        public static tblCustomer tblCustomer = new tblCustomer();
        public frmCustomers()
        {
            InitializeComponent();
        }

        void BindGrid()
        {
            try
            {
                CarpetCleaningEntities db = new CarpetCleaningEntities();
                var Query = from a in db.tblCustomers
                            select new { a.CustomerID, a.Name, a.LastName, a.City, a.Mobile, CustomerType=a.CustomerTypeID == 1 ? "فروشنده مواد اولیه" : a.CustomerTypeID == 2 ? "خانگی" : "مشتری", ActiveName = a.Active == 0 ? "غیرفعال" : "فعال" };

                if (LoadTypeID == 1) Query = Query.Where(a => a.ActiveName == "فعال");
                if (CustomerTypeID == 2)
                {
                    Query = Query.Where(a => a.CustomerType == "خانگی");
                }
                if (CustomerTypeID == 3)
                {
                    Query = Query.Where(a => a.CustomerType == "مشتری");
                }

                if (txtSearch.Text.Trim().Length != 0)
                {
                    Query = Query.Where(a => a.CustomerID.ToString().Contains(txtSearch.Text) || a.Name.Contains(txtSearch.Text) || a.LastName.Contains(txtSearch.Text) || a.City.Contains(txtSearch.Text) || a.Mobile.Contains(txtSearch.Text) || a.CustomerType.Contains(txtSearch.Text) || a.ActiveName.Contains(txtSearch.Text));
                }

                dgv.DataSource = Query.ToList();
                      
                dgv.Columns[0].HeaderText = "کد مشتری";
                dgv.Columns[0].Width = 100;
                dgv.Columns[1].HeaderText = "نام";
                dgv.Columns[1].Width = 100;
                dgv.Columns[2].HeaderText = "نام خانوادگی";
                dgv.Columns[2].Width = 100;
                dgv.Columns[3].HeaderText = "شهر";
                dgv.Columns[3].Width = 120;
                dgv.Columns[4].HeaderText = "شماره موبایل";
                dgv.Columns[4].Width = 120;
                dgv.Columns[5].HeaderText = "نوع مشتری";
                dgv.Columns[5].Width = 100;
                dgv.Columns[6].HeaderText = "وضعیت";
                dgv.Columns[6].Width = 100;

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
                tblCustomer = db.tblCustomers.Find(tblCustomer.CustomerID);
                if (tblCustomer == null)
                {
                    FarsiMessagbox.Show(ClsMessage.ErrNotFound, "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
                    return;
                }

                txtName_.Text = tblCustomer.Name;
                txtLastName_.Text = tblCustomer.LastName;
                switch (tblCustomer.CustomerTypeID)
                {
                    case 1:
                        rdbMaterialSel.Checked = true;
                        break;
                    case 2:
                        rdbHome.Checked = true;
                        break;
                    case 3:
                        rdbCustomer.Checked = true;
                        break;
                    default:
                        break;
                }
          
                txtTell.Text = tblCustomer.Tell;
                txtCity.Text = tblCustomer.City;        
                txtMobile_.Text = tblCustomer.Mobile;
                txtAddress.Text = tblCustomer.Address;
                txtDescription.Text = tblCustomer.Description;    

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
                  tblCustomer = new tblCustomer();

                int MaxID = (from a in db.tblCustomers
                             select a.CustomerID).DefaultIfEmpty().Max() + 1;

                var Query = from a in db.tblCustomers
                            where a.Name == txtName_.Text & a.LastName == txtLastName_.Text
                            select a;

                if (Query.Count() != 0)
                {
                    FarsiMessagbox.Show(ClsMessage.ErrRepeat + "\n" + "نام کاربری تکراری می باشد", "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
                    return;
                }

                string savepath = @".\Documents\Personnel\";
                if (!Directory.Exists(savepath))
                {
                    Directory.CreateDirectory(savepath);
                }

                tblCustomer.CustomerID = MaxID;
                tblCustomer.Name = txtName_.Text;
                tblCustomer.LastName = txtLastName_.Text;
                              
                if (rdbHome.Checked) tblCustomer.CustomerTypeID = 2;
                else if (rdbCustomer.Checked) tblCustomer.CustomerTypeID = 3; else tblCustomer.CustomerTypeID = 1;

                tblCustomer.Tell = txtTell.Text;
                tblCustomer.City = txtCity.Text;
                tblCustomer.Mobile = txtMobile_.Text;
                tblCustomer.Address = txtAddress.Text;
                tblCustomer.Description = txtDescription.Text;
                tblCustomer.Active = 1;
                tblCustomer.RegisterDate = ClsTools.ShamsiDate();

                db.tblCustomers.Add(tblCustomer);
                db.SaveChanges();
                      
                LogContent = "Name = " + tblCustomer.Name + " | " + "LastName = " + tblCustomer.LastName + " | " +
                      "Tell = " + tblCustomer.Tell + " | " + "City = " + tblCustomer.City + " | " +
                      "Mobile = " + tblCustomer.Mobile + " | " + "Address = " + tblCustomer.Address + " | " +
                      "Description = " + tblCustomer.Description + " | " + "Active = " + tblCustomer.Active + " | ";

                ClsTools.InsertLog(9, Program.tblUserLogin.UserID, LogContent, "tblCustomer", tblCustomer.CustomerID);

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
                  tblCustomer = db.tblCustomers.Find(tblCustomer.CustomerID);

                if (tblCustomer == null)
                {
                    FarsiMessagbox.Show(ClsMessage.ErrNotFound, "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
                    return;
                }
                 
                tblCustomer.Name = txtName_.Text;
                tblCustomer.LastName = txtLastName_.Text;
                if (rdbHome.Checked) tblCustomer.CustomerTypeID = 2;
                else if (rdbCustomer.Checked) tblCustomer.CustomerTypeID = 3; else tblCustomer.CustomerTypeID = 1;
                tblCustomer.Tell = txtTell.Text;
                tblCustomer.City = txtCity.Text;
                tblCustomer.Mobile = txtMobile_.Text;
                tblCustomer.Address = txtAddress.Text;
                tblCustomer.Description = txtDescription.Text;

                db.tblCustomers.Attach(tblCustomer);
                db.Entry(tblCustomer).State = EntityState.Modified;
                //db.Entry(tblPersonnel).Property(x => x).IsModified = true;
                db.Entry(tblCustomer).Property(x => x.Active).IsModified = false;
                db.Entry(tblCustomer).Property(x => x.RegisterDate).IsModified = false;

                db.SaveChanges();

                LogContent = "Name = " + tblCustomer.Name + " | " + "LastName = " + tblCustomer.LastName + " | " +
                      "Tell = " + tblCustomer.Tell + " | " + "City = " + tblCustomer.City + " | " +
                      "Mobile = " + tblCustomer.Mobile + " | " + "Address = " + tblCustomer.Address + " | " +
                      "Description = " + tblCustomer.Description + " | " + "Active = " + tblCustomer.Active + " | ";

                ClsTools.InsertLog(10, Program.tblUserLogin.UserID, LogContent, "tblCustomer", tblCustomer.CustomerID);

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
                  tblCustomer = db.tblCustomers.Find(tblCustomer.CustomerID);

                if (tblCustomer == null)
                {
                    FarsiMessagbox.Show(ClsMessage.ErrNotFound, "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
                    return;
                }

                if (tblCustomer.Active == 1) tblCustomer.Active = 0;
                else tblCustomer.Active = 1;


                db.tblCustomers.Attach(tblCustomer);

                db.Entry(tblCustomer).Property(x => x.Active).IsModified = true; // $('#txtGoodsCode').val(),

                db.SaveChanges();

                LogContent = "Active = " + tblCustomer.Active;

                ClsTools.InsertLog(12, Program.tblUserLogin.UserID, LogContent, "tblCustomer", tblCustomer.CustomerID);

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
                  tblCustomer = db.tblCustomers.Find(tblCustomer.CustomerID);

                LogContent = "Name = " + tblCustomer.Name + " | " + "LastName = " + tblCustomer.LastName + " | " +
                      "Tell = " + tblCustomer.Tell + " | " + "City = " + tblCustomer.City + " | " +
                      "Mobile = " + tblCustomer.Mobile + " | " + "Address = " + tblCustomer.Address + " | " +
                      "Description = " + tblCustomer.Description + " | " + "Active = " + tblCustomer.Active + " | ";

                db.tblCustomers.Remove(tblCustomer);
                db.SaveChanges();

                ClsTools.InsertLog(11, Program.tblUserLogin.UserID, LogContent, "tblCustomer", tblCustomer.CustomerID);
                                 
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
            tblCustomer = new tblCustomer();
            SaveType = 1;
            BindGrid();
            ClsTools.ClearContent(pnlNewEdit);
            btnDelete.Enabled = false;
            btnChangeStatus.Enabled = false;
            btnSelect.Enabled = false;
        }
        private void frmCustomers_Load(object sender, EventArgs e)
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
                tblCustomer.CustomerID = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
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

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (tblCustomer.CustomerID == 0)
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
