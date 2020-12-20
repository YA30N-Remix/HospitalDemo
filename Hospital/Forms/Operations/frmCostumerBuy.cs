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
    public partial class frmCostumerBuy : Form
    {
        string LogContent = "";
        int SaveType = 1;
        public static tblCustomerBuy tblCustomerBuy = new tblCustomerBuy();
        public static short LoadTypeID = 0;
        public static short FactorTypeID = 0;
        public frmCostumerBuy()
        {
            InitializeComponent();
        }

        void BindGrid()
        {
            try
            {
                CarpetCleaningEntities db = new CarpetCleaningEntities();
                var Query = from a in db.tblCustomerBuys  
                            join b in db.tblCustomers on a.CustomerID equals b.CustomerID
                            select new { a.CustomerBuyID, CustomerName = b.Name + " " + b.LastName };

                if (txtSearch.Text.Trim().Length != 0)
                {
                    Query = Query.Where(a => a.CustomerBuyID.ToString().Contains(txtSearch.Text) || a.CustomerName.ToString().Contains(txtSearch.Text));
                }

                dgv.DataSource = Query.ToList();

                dgv.Columns["factorlist"].DisplayIndex = 2;
                //dgv.Columns["Print"].DisplayIndex = 4;
                //dgv.Columns["PringA4"].DisplayIndex = 4;
                dgv.Columns[1].HeaderText = "کد لیست";
                dgv.Columns[1].Width = 100;
                dgv.Columns[2].HeaderText = "نام مشتری";
                dgv.Columns[2].Width = 140;
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
                tblCustomerBuy = db.tblCustomerBuys.Find(tblCustomerBuy.CustomerBuyID);
                if (tblCustomerBuy == null)
                {
                    FarsiMessagbox.Show(ClsMessage.ErrNotFound, "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
                    return;
                }

                BasicInformation.frmCustomers.tblCustomer.CustomerID = tblCustomerBuy.CustomerBuyID;
              
                var QueryCustomer = (from a in db.tblCustomers
                                     where a.CustomerID == BasicInformation.frmCustomers.tblCustomer.CustomerID
                                     select new { name = a.Name + " " + a.LastName }).ToList();

                txtCustomerName.Text = QueryCustomer.ElementAt(0).name;
                                                    
                txtDescription.Text = tblCustomerBuy.Description;

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
                tblCustomerBuy = new tblCustomerBuy();

                var CountCustumerRec = (from a in db.tblCustomerBuys
                             where a.CustomerID == BasicInformation.frmCustomers.tblCustomer.CustomerID
                             select a.CustomerBuyID).Count();

                if (CountCustumerRec !=0)
                {
                    FarsiMessagbox.Show(ClsMessage.Error + "\n" + "برای این مشتری قبلا رکوردی ایجاد شده است", "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
                    return;
                }


                int MaxID = (from a in db.tblCustomerBuys
                             select a.CustomerBuyID).DefaultIfEmpty().Max() + 1;


                tblCustomerBuy.CustomerBuyID = MaxID;
                tblCustomerBuy.CustomerID = BasicInformation.frmCustomers.tblCustomer.CustomerID;

                tblCustomerBuy.Description = txtDescription.Text;
                tblCustomerBuy.RegisterDate = ClsTools.ShamsiDate();

                db.tblCustomerBuys.Add(tblCustomerBuy);

                db.SaveChanges();

                LogContent = "CustomerBuyID = " + tblCustomerBuy.CustomerBuyID + " | " + "CustomerID = " + tblCustomerBuy.CustomerID + " | " +  
                     "Description = " + tblCustomerBuy.Description + " | " + "RegisterDate = " + tblCustomerBuy.RegisterDate + " | ";

                ClsTools.InsertLog(44, Program.tblUserLogin.UserID, LogContent, "tblCustomerBuy", tblCustomerBuy.CustomerID);

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
                tblCustomerBuy = db.tblCustomerBuys.Find(tblCustomerBuy.CustomerBuyID);

                if (tblCustomerBuy == null)
                {
                    FarsiMessagbox.Show(ClsMessage.ErrNotFound, "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
                    return;
                }

                tblCustomerBuy.CustomerID = BasicInformation.frmCustomers.tblCustomer.CustomerID;


                tblCustomerBuy.Description = txtDescription.Text;

                db.Entry(tblCustomerBuy).State = EntityState.Modified;
                //db.Entry(tblPersonnel).Property(x => x).IsModified = true;        
                db.Entry(tblCustomerBuy).Property(x => x.RegisterDate).IsModified = false;

                db.SaveChanges();

                LogContent = "CustomerBuyID = " + tblCustomerBuy.CustomerBuyID + " | " + "CustomerID = " + tblCustomerBuy.CustomerID + " | " +
                     "Description = " + tblCustomerBuy.Description + " | " + "RegisterDate = " + tblCustomerBuy.RegisterDate + " | ";

                ClsTools.InsertLog(45, Program.tblUserLogin.UserID, LogContent, "tblCustomerBuy", tblCustomerBuy.CustomerBuyID);

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
                tblCustomerBuy = db.tblCustomerBuys.Find(tblCustomerBuy.CustomerBuyID);

                List<tblCustomerBuyList> tblCustomerBuyLists = db.tblCustomerBuyLists.Where(x => x.CustomerBuyID == tblCustomerBuy.CustomerBuyID).ToList();

                LogContent = "CustomerBuyID = " + tblCustomerBuy.CustomerBuyID + " | " + "CustomerID = " + tblCustomerBuy.CustomerID + " | " +
                       "Description = " + tblCustomerBuy.Description + " | " + "RegisterDate = " + tblCustomerBuy.RegisterDate + " | ";

                foreach (var item in tblCustomerBuyLists)
                {
                    tblCustomerBuyList tblCustomerBuyList = db.tblCustomerBuyLists.Find(item.CustomerBuyID);
                    tblCustomerBuyList.FactorStatus = 0;

                    db.Entry(tblCustomerBuyList).State = EntityState.Modified;
                    db.Entry(tblCustomerBuyList).Property(x => x.FactorStatus).IsModified = true;
                }

                db.tblCustomerBuys.Remove(tblCustomerBuy);
                db.tblCustomerBuyLists.RemoveRange(tblCustomerBuyLists);

                db.SaveChanges();


                ClsTools.InsertLog(46, Program.tblUserLogin.UserID, LogContent, "tblCustomerBuys", tblCustomerBuy.CustomerBuyID);

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
            tblCustomerBuy = new tblCustomerBuy();
            SaveType = 1;
            BindGrid();
            BasicInformation.frmCustomers.tblCustomer.CustomerID = 0;
            ClsTools.ClearContent(pnlNewEdit);            
            btnDelete.Enabled = false;
            btnSelect.Enabled = false;
        }

        private void frmCostumerBuy_Load(object sender, EventArgs e)
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
                tblCustomerBuy.CustomerBuyID = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[1].Value.ToString());
                BindRow();
                SaveType = 2;
                btnDelete.Enabled = true;
                if (LoadTypeID == 1) btnSelect.Enabled = true;

                if (e.ColumnIndex == 0)
                {
                    frmCostumersBuyList frmCostumersBuyList = new frmCostumersBuyList();
                    frmCostumersBuyList.ShowDialog();
                }
               
            }
            catch (Exception ex)
            {
            }
        }

        private void btnSelectCustomers_Click(object sender, EventArgs e)
        {
            BasicInformation.frmCustomers frmCustomers = new BasicInformation.frmCustomers();
            BasicInformation.frmCustomers.CustomerTypeID = 3;
            BasicInformation.frmCustomers.LoadTypeID = 1;
            frmCustomers.FormClosed += frmCustomers_Closed;
            frmCustomers.ShowDialog();
        }

        private void frmCustomers_Closed(object sender, FormClosedEventArgs e)
        {
            try
            {
                BasicInformation.frmCustomers.CustomerTypeID = 0;
                BasicInformation.frmCustomers.LoadTypeID = 0;
                txtCustomerName.Text = BasicInformation.frmCustomers.tblCustomer.Name + " " + BasicInformation.frmCustomers.tblCustomer.LastName;
         
            }
            catch (Exception ex)
            {
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (tblCustomerBuy.CustomerBuyID == 0)
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
