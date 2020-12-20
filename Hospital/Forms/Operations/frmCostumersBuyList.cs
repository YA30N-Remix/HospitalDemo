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
    public partial class frmCostumersBuyList : Form
    {
        string LogContent = "";
        int SaveType = 1;
        public static tblCustomerBuyList tblCustomerBuyList = new tblCustomerBuyList();
        public static int LoadTypeID = 0;
        public frmCostumersBuyList()
        {
            InitializeComponent();
        }

        void BindGrid()
        {
            try
            {
                //CarpetCleaningEntities db = new CarpetCleaningEntities();
                //var Query = from a in db.tblCustomerBuyLists
                //            join b in db.tblCustomerBuys
                //            on a.CustomerBuyID equals b.CustomerBuyID
                //            join c in db.tblCarpets
                //            on a.CarpetID equals c.CarpetID
                //            where ((frmFactors.FactorTypeID == 2 && LoadTypeID == 1) ? b.CustomerID == frmFactors.tblFactor.CustomerID : b.CustomerBuyID == frmCostumerBuy.tblCustomerBuy.CustomerBuyID)
                //            select new
                //            {
                //                a.CustomerBuyListID,
                //                c.Title,
                //                a.Count,
                //                a.FactorDate,
                //                Khadamat = (a.Shur != 0 ? "شور-" : "") + (a.Darkesh != 0 ? "دارکش-" : "") + (a.Gayegh != 0 ? "قایق-" : "") + (a.Shiraze != 0 ? "شیرازه-" : "") + (a.Charm != 0 ? "چرم-" : "") + (a.Hasiri != 0 ? "حصیری-" : "") + (a.Geytani != 0 ? "قیطانی-" : "") + (a.Pardakht != 0 ? "پرداخت-" : ""),
                //                FactorType = a.FactorStatus == 0 ? "فاکتور نشده" : "فاکتور شده"
                //            };

                //if (chkFactorStatus.Checked)
                //{
                //    Query = Query.Where(a => a.FactorType == "فاکتور نشده");
                //}

                //if (txtSearch.Text.Trim().Length != 0)
                //{
                //    Query = Query.Where(a => a.CustomerBuyListID.ToString().Contains(txtSearch.Text) || a.Title.ToString().Contains(txtSearch.Text)
                //       || a.Count.ToString().Contains(txtSearch.Text) || a.FactorDate.ToString().Contains(txtSearch.Text) || a.Khadamat.ToString().Contains(txtSearch.Text) || a.FactorType.ToString().Contains(txtSearch.Text));
                //}

                //dgv.DataSource = Query.ToList();

                dgv.Columns[0].HeaderText = "کد فاکتور";
                dgv.Columns[0].Width = 80;
                dgv.Columns[1].HeaderText = "عنوان فرش";
                dgv.Columns[1].Width = 140;
                dgv.Columns[2].HeaderText = "تعداد";
                dgv.Columns[2].Width = 80;
                dgv.Columns[3].HeaderText = "تاریخ فاکتور";
                dgv.Columns[3].Width = 100;
                dgv.Columns[4].HeaderText = "خدمات";
                dgv.Columns[4].Width = 200;
                dgv.Columns[5].HeaderText = "نوع فاکتور";
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
                tblCustomerBuyList = db.tblCustomerBuyLists.Find(tblCustomerBuyList.CustomerBuyListID);
                if (tblCustomerBuyList == null)
                {
                    FarsiMessagbox.Show(ClsMessage.ErrNotFound, "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
                    return;
                }

                frmCostumerBuy.tblCustomerBuy.CustomerBuyID = tblCustomerBuyList.CustomerBuyID;
                BasicInformation.frmCarpets.tblCarpet.CarpetID = tblCustomerBuyList.CarpetID;

                var QueryCarpet = (from a in db.tblCarpets
                                   where a.CarpetID == BasicInformation.frmCarpets.tblCarpet.CarpetID
                                   select a.Title).ToList();
                txtCarpet.Text = QueryCarpet.ElementAt(0);


                txtCarpet.Text = QueryCarpet.ElementAt(0);

                txtDiscount.Value = tblCustomerBuyList.Discount;

                txtCount_.Value = tblCustomerBuyList.Count;

                txtShur_.Text = tblCustomerBuyList.Shur.ToString();
                txtShurPrice_.Text = tblCustomerBuyList.ShurPrice.ToString();
                if (tblCustomerBuyList.Shur != 0) chkShur.Checked = true; chkShur_CheckedChanged(null, null);

                txtDarkesh_.Text = tblCustomerBuyList.Darkesh.ToString();
                txtDarkeshPrice_.Text = tblCustomerBuyList.DarkeshPrice.ToString();
                if (tblCustomerBuyList.Darkesh != 0) chkDarkesh.Checked = true; chkDarkesh_CheckedChanged(null, null);

                txtGayegh_.Text = tblCustomerBuyList.Gayegh.ToString();
                txtGayeghPrice_.Text = tblCustomerBuyList.GayeghPrice.ToString();
                if (tblCustomerBuyList.Gayegh != 0) chkGayegh.Checked = true; chkGayegh_CheckedChanged(null, null);

                txtShiraze_.Text = tblCustomerBuyList.Shiraze.ToString();
                txtShirazePrice_.Text = tblCustomerBuyList.ShirazePrice.ToString();
                if (tblCustomerBuyList.Shiraze != 0) chkShiraze.Checked = true; chkShiraze_CheckedChanged(null, null);

                txtCharm_.Text = tblCustomerBuyList.Charm.ToString();
                txtCharmPrice_.Text = tblCustomerBuyList.CharmPrice.ToString();
                if (tblCustomerBuyList.Charm != 0) chkCharm.Checked = true; chkCharm_CheckedChanged(null, null);

                txtHasiri_.Text = tblCustomerBuyList.Hasiri.ToString();
                txtHasiriPrice_.Text = tblCustomerBuyList.HasiriPrice.ToString();
                if (tblCustomerBuyList.Hasiri != 0) chkHasiri.Checked = true; chkHasiri_CheckedChanged(null, null);

                txtGeytani_.Text = tblCustomerBuyList.Geytani.ToString();
                txtGeytaniPrice_.Text = tblCustomerBuyList.GeytaniPrice.ToString();
                if (tblCustomerBuyList.Geytani != 0) chkGeytani.Checked = true; chkGeytani_CheckedChanged(null, null);

                txtPardakht_.Text = tblCustomerBuyList.Pardakht.ToString();
                txtPardakhtPrice_.Text = tblCustomerBuyList.PardakhtPrice.ToString();
                if (tblCustomerBuyList.Pardakht != 0) chkPardakht.Checked = true; chkPardakht_CheckedChanged(null, null);

                txtFactorDate_.Text = tblCustomerBuyList.FactorDate;
                txtSumPrice_.Text = tblCustomerBuyList.SumPrice.ToString();
                txtDescription.Text = tblCustomerBuyList.Description;

                if (tblCustomerBuyList.FactorStatus == 0)
                {
                    btnDelete.Visible = true;
                    btnSave.Visible = true;
                    if (LoadTypeID == 1)
                    {
                        btnSelect.Visible = true;
                    }
                }
                else
                {
                    btnDelete.Visible = false;
                    btnSave.Visible = false;
                    btnSelect.Visible = false;
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
                tblCustomerBuyList tblCustomerBuyList = new tblCustomerBuyList();

                decimal MaxID = (from a in db.tblCustomerBuyLists
                                 select a.CustomerBuyListID).DefaultIfEmpty().Max() + 1;

                tblCustomerBuyList.CustomerBuyListID = MaxID;
                tblCustomerBuyList.CustomerBuyID = frmCostumerBuy.tblCustomerBuy.CustomerBuyID;
                tblCustomerBuyList.CarpetID = BasicInformation.frmCarpets.tblCarpet.CarpetID;
                tblCustomerBuyList.Count = Convert.ToInt32(txtCount_.Value);

                if (chkShur.Checked)
                {
                    if (txtShur_.Text.Trim().Length != 0) tblCustomerBuyList.Shur = Convert.ToDouble(txtShur_.Text);
                    if (txtShurPrice_.Text.Trim().Length != 0) tblCustomerBuyList.ShurPrice = Convert.ToDecimal(txtShurPrice_.Text);
                }
                if (chkDarkesh.Checked)
                {
                    if (txtDarkesh_.Text.Trim().Length != 0) tblCustomerBuyList.Darkesh = Convert.ToDouble(txtDarkesh_.Text);
                    if (txtDarkeshPrice_.Text.Trim().Length != 0) tblCustomerBuyList.DarkeshPrice = Convert.ToDecimal(txtDarkeshPrice_.Text);
                }
                if (chkGayegh.Checked)
                {
                    if (txtGayegh_.Text.Trim().Length != 0) tblCustomerBuyList.Gayegh = Convert.ToDouble(txtGayegh_.Text);
                    if (txtGayeghPrice_.Text.Trim().Length != 0) tblCustomerBuyList.GayeghPrice = Convert.ToDecimal(txtGayeghPrice_.Text);
                }
                if (chkShiraze.Checked)
                {
                    if (txtShiraze_.Text.Trim().Length != 0) tblCustomerBuyList.Shiraze = Convert.ToDouble(txtShiraze_.Text);
                    if (txtShirazePrice_.Text.Trim().Length != 0) tblCustomerBuyList.ShirazePrice = Convert.ToDecimal(txtShirazePrice_.Text);
                }
                if (chkShiraze.Checked)
                {
                    if (txtShiraze_.Text.Trim().Length != 0) tblCustomerBuyList.Shiraze = Convert.ToDouble(txtShiraze_.Text);
                    if (txtShirazePrice_.Text.Trim().Length != 0) tblCustomerBuyList.ShirazePrice = Convert.ToDecimal(txtShirazePrice_.Text);
                }
                if (chkCharm.Checked)
                {
                    if (txtCharm_.Text.Trim().Length != 0) tblCustomerBuyList.Charm = Convert.ToDouble(txtCharm_.Text);
                    if (txtCharmPrice_.Text.Trim().Length != 0) tblCustomerBuyList.CharmPrice = Convert.ToDecimal(txtCharmPrice_.Text);
                }
                if (chkHasiri.Checked)
                {
                    if (txtHasiri_.Text.Trim().Length != 0) tblCustomerBuyList.Hasiri = Convert.ToDouble(txtHasiri_.Text);
                    if (txtHasiriPrice_.Text.Trim().Length != 0) tblCustomerBuyList.HasiriPrice = Convert.ToDecimal(txtHasiriPrice_.Text);
                }
                if (chkGeytani.Checked)
                {
                    if (txtGeytani_.Text.Trim().Length != 0) tblCustomerBuyList.Geytani = Convert.ToDouble(txtGeytani_.Text);
                    if (txtGeytaniPrice_.Text.Trim().Length != 0) tblCustomerBuyList.GeytaniPrice = Convert.ToDecimal(txtGeytaniPrice_.Text);
                }
                if (chkPardakht.Checked)
                {
                    if (txtPardakht_.Text.Trim().Length != 0) tblCustomerBuyList.Pardakht = Convert.ToDouble(txtPardakht_.Text);
                    if (txtPardakhtPrice_.Text.Trim().Length != 0) tblCustomerBuyList.PardakhtPrice = Convert.ToDecimal(txtPardakhtPrice_.Text);
                }

                if (txtDiscount.Text.Trim().Length == 0) tblCustomerBuyList.Discount = 0; else tblCustomerBuyList.Discount = Convert.ToDecimal(txtDiscount.Text);
                tblCustomerBuyList.SumPrice = Convert.ToDecimal(txtSumPrice_.Text);
                tblCustomerBuyList.FactorStatus = 0;
                tblCustomerBuyList.FactorDate = txtFactorDate_.MaskedTextProvider.ToDisplayString();
                tblCustomerBuyList.Description = txtDescription.Text;
                tblCustomerBuyList.RegisterDate = ClsTools.ShamsiDate();

                db.tblCustomerBuyLists.Add(tblCustomerBuyList);

                db.SaveChanges();

                LogContent = "CustomerBuyListID = " + tblCustomerBuyList.CustomerBuyListID + " | " + "CustomerBuyID = " + tblCustomerBuyList.CustomerBuyID + " | " +
                    "CarpetID = " + tblCustomerBuyList.CarpetID + " | " + "Count = " + tblCustomerBuyList.Count + " | " + "Shur = " + tblCustomerBuyList.Shur + " | " + "Darkesh = " + tblCustomerBuyList.Darkesh + " | " +
                    "Gayegh = " + tblCustomerBuyList.Gayegh + " | " + "Shiraze = " + tblCustomerBuyList.Shiraze + " | " + "Charm = " + tblCustomerBuyList.Charm + " | " + "Hasiri = " + tblCustomerBuyList.Hasiri + " | " +
                    "Geytani = " + tblCustomerBuyList.Geytani + " | " + "Pardakht = " + tblCustomerBuyList.Pardakht + " | " + "ShurPrice = " + tblCustomerBuyList.ShurPrice + " | " + "DarkeshPrice = " + tblCustomerBuyList.DarkeshPrice + " | " +
                    "GayeghPrice = " + tblCustomerBuyList.GayeghPrice + " | " + "ShirazePrice = " + tblCustomerBuyList.ShirazePrice + " | " + "CharmPrice = " + tblCustomerBuyList.CharmPrice + " | " + "HasiriPrice = " + tblCustomerBuyList.HasiriPrice + " | " +
                      "GeytaniPrice = " + tblCustomerBuyList.GeytaniPrice + " | " + "PardakhtPrice = " + tblCustomerBuyList.PardakhtPrice + " | " + "FactorDate = " + tblCustomerBuyList.FactorDate + " | " +
                   "FactorStatus = " + tblCustomerBuyList.FactorStatus + " | " + "Description = " + tblCustomerBuyList.Description + " | " + "RegisterDate = " + tblCustomerBuyList.RegisterDate + " | ";

                ClsTools.InsertLog(35, Program.tblUserLogin.UserID, LogContent, "tblCustomerBuyList", tblCustomerBuyList.CustomerBuyListID);

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
                tblCustomerBuyList = db.tblCustomerBuyLists.Find(tblCustomerBuyList.CustomerBuyListID);

                if (tblCustomerBuyList == null)
                {
                    FarsiMessagbox.Show(ClsMessage.ErrNotFound, "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
                    return;
                }

                tblCustomerBuyList.CustomerBuyID = frmCostumerBuy.tblCustomerBuy.CustomerBuyID;
                tblCustomerBuyList.CarpetID = BasicInformation.frmCarpets.tblCarpet.CarpetID;
                tblCustomerBuyList.Count = Convert.ToInt32(txtCount_.Value);

                if (chkShur.Checked)
                {
                    if (txtShur_.Text.Trim().Length != 0) tblCustomerBuyList.Shur = Convert.ToDouble(txtShur_.Text);
                    if (txtShurPrice_.Text.Trim().Length != 0) tblCustomerBuyList.ShurPrice = Convert.ToDecimal(txtShurPrice_.Text);
                }
                if (chkDarkesh.Checked)
                {
                    if (txtDarkesh_.Text.Trim().Length != 0) tblCustomerBuyList.Darkesh = Convert.ToDouble(txtDarkesh_.Text);
                    if (txtDarkeshPrice_.Text.Trim().Length != 0) tblCustomerBuyList.DarkeshPrice = Convert.ToDecimal(txtDarkeshPrice_.Text);
                }
                if (chkGayegh.Checked)
                {
                    if (txtGayegh_.Text.Trim().Length != 0) tblCustomerBuyList.Gayegh = Convert.ToDouble(txtGayegh_.Text);
                    if (txtGayeghPrice_.Text.Trim().Length != 0) tblCustomerBuyList.GayeghPrice = Convert.ToDecimal(txtGayeghPrice_.Text);
                }
                if (chkShiraze.Checked)
                {
                    if (txtShiraze_.Text.Trim().Length != 0) tblCustomerBuyList.Shiraze = Convert.ToDouble(txtShiraze_.Text);
                    if (txtShirazePrice_.Text.Trim().Length != 0) tblCustomerBuyList.ShirazePrice = Convert.ToDecimal(txtShirazePrice_.Text);
                }
                if (chkShiraze.Checked)
                {
                    if (txtShiraze_.Text.Trim().Length != 0) tblCustomerBuyList.Shiraze = Convert.ToDouble(txtShiraze_.Text);
                    if (txtShirazePrice_.Text.Trim().Length != 0) tblCustomerBuyList.ShirazePrice = Convert.ToDecimal(txtShirazePrice_.Text);
                }
                if (chkCharm.Checked)
                {
                    if (txtCharm_.Text.Trim().Length != 0) tblCustomerBuyList.Charm = Convert.ToDouble(txtCharm_.Text);
                    if (txtCharmPrice_.Text.Trim().Length != 0) tblCustomerBuyList.CharmPrice = Convert.ToDecimal(txtCharmPrice_.Text);
                }
                if (chkHasiri.Checked)
                {
                    if (txtHasiri_.Text.Trim().Length != 0) tblCustomerBuyList.Hasiri = Convert.ToDouble(txtHasiri_.Text);
                    if (txtHasiriPrice_.Text.Trim().Length != 0) tblCustomerBuyList.HasiriPrice = Convert.ToDecimal(txtHasiriPrice_.Text);
                }
                if (chkGeytani.Checked)
                {
                    if (txtGeytani_.Text.Trim().Length != 0) tblCustomerBuyList.Geytani = Convert.ToDouble(txtGeytani_.Text);
                    if (txtGeytaniPrice_.Text.Trim().Length != 0) tblCustomerBuyList.GeytaniPrice = Convert.ToDecimal(txtGeytaniPrice_.Text);
                }
                if (chkPardakht.Checked)
                {
                    if (txtPardakht_.Text.Trim().Length != 0) tblCustomerBuyList.Pardakht = Convert.ToDouble(txtPardakht_.Text);
                    if (txtPardakhtPrice_.Text.Trim().Length != 0) tblCustomerBuyList.PardakhtPrice = Convert.ToDecimal(txtPardakhtPrice_.Text);
                }

                if (txtDiscount.Text.Trim().Length == 0) tblCustomerBuyList.Discount = 0; else tblCustomerBuyList.Discount = Convert.ToDecimal(txtDiscount.Text);
                tblCustomerBuyList.Discount = txtDiscount.Value;
                tblCustomerBuyList.SumPrice = Convert.ToDecimal(txtSumPrice_.Text);
                tblCustomerBuyList.FactorStatus = 0;
                tblCustomerBuyList.FactorDate = txtFactorDate_.MaskedTextProvider.ToDisplayString();
                tblCustomerBuyList.Description = txtDescription.Text;

                db.Entry(tblCustomerBuyList).State = EntityState.Modified;
                //db.Entry(tblPersonnel).Property(x => x).IsModified = true;        
                db.Entry(tblCustomerBuyList).Property(x => x.RegisterDate).IsModified = false;

                db.SaveChanges();

                LogContent = "CustomerBuyListID = " + tblCustomerBuyList.CustomerBuyListID + " | " + "CustomerBuyID = " + tblCustomerBuyList.CustomerBuyID + " | " +
     "CarpetID = " + tblCustomerBuyList.CarpetID + " | " + "Count = " + tblCustomerBuyList.Count + " | " + "Shur = " + tblCustomerBuyList.Shur + " | " + "Darkesh = " + tblCustomerBuyList.Darkesh + " | " +
     "Gayegh = " + tblCustomerBuyList.Gayegh + " | " + "Shiraze = " + tblCustomerBuyList.Shiraze + " | " + "Charm = " + tblCustomerBuyList.Charm + " | " + "Hasiri = " + tblCustomerBuyList.Hasiri + " | " +
     "Geytani = " + tblCustomerBuyList.Geytani + " | " + "Pardakht = " + tblCustomerBuyList.Pardakht + " | " + "ShurPrice = " + tblCustomerBuyList.ShurPrice + " | " + "DarkeshPrice = " + tblCustomerBuyList.DarkeshPrice + " | " +
     "GayeghPrice = " + tblCustomerBuyList.GayeghPrice + " | " + "ShirazePrice = " + tblCustomerBuyList.ShirazePrice + " | " + "CharmPrice = " + tblCustomerBuyList.CharmPrice + " | " + "HasiriPrice = " + tblCustomerBuyList.HasiriPrice + " | " +
       "GeytaniPrice = " + tblCustomerBuyList.GeytaniPrice + " | " + "PardakhtPrice = " + tblCustomerBuyList.PardakhtPrice + " | " + "FactorDate = " + tblCustomerBuyList.FactorDate + " | " +
    "FactorStatus = " + tblCustomerBuyList.FactorStatus + " | " + "Description = " + tblCustomerBuyList.Description + " | " + "RegisterDate = " + tblCustomerBuyList.RegisterDate + " | ";

                ClsTools.InsertLog(36, Program.tblUserLogin.UserID, LogContent, "tblCustomerBuyList", tblCustomerBuyList.CustomerBuyListID);


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
                tblCustomerBuyList = db.tblCustomerBuyLists.Find(tblCustomerBuyList.CustomerBuyID);

                LogContent = "CustomerBuyListID = " + tblCustomerBuyList.CustomerBuyListID + " | " + "CustomerBuyID = " + tblCustomerBuyList.CustomerBuyID + " | " +
    "CarpetID = " + tblCustomerBuyList.CarpetID + " | " + "Count = " + tblCustomerBuyList.Count + " | " + "Shur = " + tblCustomerBuyList.Shur + " | " + "Darkesh = " + tblCustomerBuyList.Darkesh + " | " +
    "Gayegh = " + tblCustomerBuyList.Gayegh + " | " + "Shiraze = " + tblCustomerBuyList.Shiraze + " | " + "Charm = " + tblCustomerBuyList.Charm + " | " + "Hasiri = " + tblCustomerBuyList.Hasiri + " | " +
    "Geytani = " + tblCustomerBuyList.Geytani + " | " + "Pardakht = " + tblCustomerBuyList.Pardakht + " | " + "ShurPrice = " + tblCustomerBuyList.ShurPrice + " | " + "DarkeshPrice = " + tblCustomerBuyList.DarkeshPrice + " | " +
    "GayeghPrice = " + tblCustomerBuyList.GayeghPrice + " | " + "ShirazePrice = " + tblCustomerBuyList.ShirazePrice + " | " + "CharmPrice = " + tblCustomerBuyList.CharmPrice + " | " + "HasiriPrice = " + tblCustomerBuyList.HasiriPrice + " | " +
      "GeytaniPrice = " + tblCustomerBuyList.GeytaniPrice + " | " + "PardakhtPrice = " + tblCustomerBuyList.PardakhtPrice + " | " + "FactorDate = " + tblCustomerBuyList.FactorDate + " | " +
   "FactorStatus = " + tblCustomerBuyList.FactorStatus + " | " + "Description = " + tblCustomerBuyList.Description + " | " + "RegisterDate = " + tblCustomerBuyList.RegisterDate + " | ";

                db.tblCustomerBuyLists.Remove(tblCustomerBuyList);
                db.SaveChanges();

                ClsTools.InsertLog(37, Program.tblUserLogin.UserID, LogContent, "tblCustomerBuyList", tblCustomerBuyList.CustomerBuyListID);


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
            CarpetCleaningEntities db = new CarpetCleaningEntities();
            tblCustomerBuyList = new tblCustomerBuyList();
            SaveType = 1;
            BindGrid();
            BasicInformation.frmCustomers.tblCustomer = new tblCustomer();
            ClsTools.ClearContent(pnlNewEdit);
            int year = Convert.ToInt32(ClsTools.ShamsiDate().Substring(0, 4));
            tblCarpetPrice tblCarpetPrice = db.tblCarpetPrices.Where(a => a.Year == year).OrderByDescending(a => a.RegisterDate).FirstOrDefault();
            if (tblCarpetPrice != null)
            {
                txtShurPrice_.Text = tblCarpetPrice.Shur.ToString();
                txtDarkeshPrice_.Text = tblCarpetPrice.Darkesh.ToString();
                txtGayeghPrice_.Text = tblCarpetPrice.Gayegh.ToString();
                txtShirazePrice_.Text = tblCarpetPrice.Shiraze.ToString();
                txtCharmPrice_.Text = tblCarpetPrice.Charm.ToString();
                txtHasiriPrice_.Text = tblCarpetPrice.Hasiri.ToString();
                txtGeytaniPrice_.Text = tblCarpetPrice.Geytani.ToString();
                txtPardakhtPrice_.Text = tblCarpetPrice.Pardakht.ToString();
            }
            else
            {
                txtShurPrice_.Text = "0";
                txtDarkeshPrice_.Text = "0";
                txtGayeghPrice_.Text = "0";
                txtShirazePrice_.Text = "0";
                txtCharmPrice_.Text = "0";
                txtHasiriPrice_.Text = "0";
                txtGeytaniPrice_.Text = "0";
                txtPardakhtPrice_.Text = "0";
            }

            lblShur.Text = "0";
            lblDarkesh.Text = "0";
            lblGayegh.Text = "0";
            lblShiraze.Text = "0";
            lblCharm.Text = "0";
            lblHasiri.Text = "0";
            lblGeytani.Text = "0";
            lblPardakht.Text = "0";

            txtFactorDate_.Text = ClsTools.ShamsiDate();
            btnDelete.Enabled = false;
            btnSelect.Enabled = false;
            btnDelete.Visible = true;
            btnSave.Visible = true;
        }
        private void frmCostumerBuyList_Load(object sender, EventArgs e)
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
                if (ClsTools.CheckValidation(pnlNewEdit) == false || frmCostumerBuy.tblCustomerBuy.CustomerBuyID == 0 || BasicInformation.frmCarpets.tblCarpet.CarpetID == 0)
                {
                    FarsiMessagbox.Show(ClsMessage.ErrNotRegEmptyValue, "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
                    return;
                }
                sumText();
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
                tblCustomerBuyList.CustomerBuyListID = Convert.ToDecimal(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
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
            if (tblCustomerBuyList.CustomerBuyID == 0)
            {
                FarsiMessagbox.Show(ClsMessage.Error + "\n" + "رکوردی انتخاب نشده است", "خطا", FMessageBoxButtons.Ok, FMessageBoxIcon.Error);
                return;
            }
            SaveType = 1;
            LoadTypeID = 0;
            this.Close();
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
                txtShur_.Text = BasicInformation.frmCarpets.tblCarpet.Shur.ToString();
                txtDarkesh_.Text = BasicInformation.frmCarpets.tblCarpet.Darkesh.ToString();
                txtGayegh_.Text = BasicInformation.frmCarpets.tblCarpet.Gayegh.ToString();
                txtShiraze_.Text = BasicInformation.frmCarpets.tblCarpet.Shiraze.ToString();
                txtCharm_.Text = BasicInformation.frmCarpets.tblCarpet.Charm.ToString();
                txtHasiri_.Text = BasicInformation.frmCarpets.tblCarpet.Hasiri.ToString();
                txtGeytani_.Text = BasicInformation.frmCarpets.tblCarpet.Geytani.ToString();
                txtPardakht_.Text = BasicInformation.frmCarpets.tblCarpet.Pardakht.ToString();
                BasicInformation.frmCarpets.LoadTypeID = 0;
            }
            catch (Exception)
            {
            }
        }
        private void txtSums_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //txtPrice_.Text = Convert.ToInt32(txtPrice_.Text).ToString("n0");
                sumText();
            }
            catch (Exception)
            {
            }

        }
        private void sumText()
        {
            try
            {
                double Count = 0, Price = 0, Discount = 0;

                if (txtDiscount.Text.Trim().Length != 0) Discount = Convert.ToDouble(txtDiscount.Value);

                if (txtCount_.Text.Trim().Length != 0) Count = Convert.ToDouble(txtCount_.Value);

                double Shur = Convert.ToDouble(lblShur.Text) * Convert.ToDouble(txtShurPrice_.Text);
                double Darkesh = Convert.ToDouble(lblDarkesh.Text) * Convert.ToDouble(txtDarkeshPrice_.Text);
                double Gayegh = Convert.ToDouble(lblGayegh.Text) * Convert.ToDouble(txtGayeghPrice_.Text);
                double Shiraze = Convert.ToDouble(lblShiraze.Text) * Convert.ToDouble(txtShurPrice_.Text);
                double Charm = Convert.ToDouble(lblCharm.Text) * Convert.ToDouble(txtShurPrice_.Text);
                double Hasiri = Convert.ToDouble(lblHasiri.Text) * Convert.ToDouble(txtShurPrice_.Text);
                double Geytani = Convert.ToDouble(lblGeytani.Text) * Convert.ToDouble(txtShurPrice_.Text);
                double Pardakht = Convert.ToDouble(lblPardakht.Text) * Convert.ToDouble(txtShurPrice_.Text);

                Price = Shur + Darkesh + Gayegh + Shiraze + Charm + Hasiri + Geytani + Pardakht;
                string SumPrice = ((Count * Price) - Discount).ToString();
                txtSumPrice_.Text = SumPrice;
            }
            catch (Exception)
            {
            }

        }

        private void chkFactorStatus_CheckedChanged(object sender, EventArgs e)
        {
            BindGrid();

        }

        private void txtNumber__KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"^[0-9.\b]"))
            {
                // Stop the character from being entered into the control since it is illegal.
                e.Handled = true;
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
                    sumText();
                }
            }
            catch (Exception)
            {
            }
        }

        private void txtSumPrice__TextChanged(object sender, EventArgs e)
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

        private void chkShur_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShur.Checked)
            {
                double Shur = 0;
                txtShur_.Enabled = true;
                txtShurPrice_.Enabled = true;
                if (txtShur_.Text.Trim().Length != 0) Shur = Convert.ToDouble(txtShur_.Text);
                lblShur.Text = (Shur * Convert.ToDouble(txtShurPrice_.Text)).ToString();
                sumText();
            }
            else
            {
                txtShur_.Enabled = false;
                txtShurPrice_.Enabled = false;
                lblShur.Text = "0";
                sumText();
            }
        }

        private void chkDarkesh_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDarkesh.Checked)
            {
                double Darkesh = 0;
                txtDarkesh_.Enabled = true;
                txtDarkeshPrice_.Enabled = true;
                if (txtDarkesh_.Text.Trim().Length != 0) Darkesh = Convert.ToDouble(txtDarkesh_.Text);
                lblDarkesh.Text = (Darkesh * Convert.ToDouble(txtDarkeshPrice_.Text)).ToString();
                sumText();
            }
            else
            {
                txtDarkesh_.Enabled = false;
                txtDarkeshPrice_.Enabled = false;
                lblDarkesh.Text = "0";
                sumText();
            }
        }

        private void chkGayegh_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGayegh.Checked)
            {
                double Gayegh = 0;
                txtGayegh_.Enabled = true;
                txtGayeghPrice_.Enabled = true;
                if (txtGayegh_.Text.Trim().Length != 0) Gayegh = Convert.ToDouble(txtGayegh_.Text);
                lblGayegh.Text = (Gayegh * Convert.ToDouble(txtGayeghPrice_.Text)).ToString();
                sumText();
            }
            else
            {
                txtGayegh_.Enabled = false;
                txtGayeghPrice_.Enabled = false;
                lblGayegh.Text = "0";
                sumText();
            }
        }

        private void chkShiraze_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShiraze.Checked)
            {
                double Shiraze = 0;
                txtShiraze_.Enabled = true;
                txtShirazePrice_.Enabled = true;
                if (txtShiraze_.Text.Trim().Length != 0) Shiraze = Convert.ToDouble(txtShiraze_.Text);
                lblShiraze.Text = (Shiraze * Convert.ToDouble(txtShirazePrice_.Text)).ToString();
                sumText();
            }
            else
            {
                txtShiraze_.Enabled = false;
                txtShirazePrice_.Enabled = false;
                lblShiraze.Text = "0";
                sumText();
            }
        }

        private void chkCharm_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCharm.Checked)
            {
                double Charm = 0;
                txtCharm_.Enabled = true;
                txtCharmPrice_.Enabled = true;
                if (txtCharm_.Text.Trim().Length != 0) Charm = Convert.ToDouble(txtCharm_.Text);
                lblCharm.Text = (Charm * Convert.ToDouble(txtCharmPrice_.Text)).ToString();
                sumText();
            }
            else
            {
                txtCharm_.Enabled = false;
                txtCharmPrice_.Enabled = false;
                lblCharm.Text = "0";
                sumText();
            }
        }

        private void chkHasiri_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHasiri.Checked)
            {
                double Hasiri = 0;
                txtHasiri_.Enabled = true;
                txtHasiriPrice_.Enabled = true;
                if (txtHasiri_.Text.Trim().Length != 0) Hasiri = Convert.ToDouble(txtHasiri_.Text);
                lblHasiri.Text = (Hasiri * Convert.ToDouble(txtHasiriPrice_.Text)).ToString();
                sumText();
            }
            else
            {
                txtHasiri_.Enabled = false;
                txtHasiriPrice_.Enabled = false;
                lblHasiri.Text = "0";
                sumText();
            }
        }

        private void chkGeytani_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGeytani.Checked)
            {
                double Geytani = 0;
                txtGeytani_.Enabled = true;
                txtGeytaniPrice_.Enabled = true;
                if (txtGeytani_.Text.Trim().Length != 0) Geytani = Convert.ToDouble(txtGeytani_.Text);
                lblGeytani.Text = (Geytani * Convert.ToDouble(txtGeytaniPrice_.Text)).ToString();
                sumText();
            }
            else
            {
                txtGeytani_.Enabled = false;
                txtGeytaniPrice_.Enabled = false;
                lblGeytani.Text = "0";
                sumText();
            }
        }

        private void chkPardakht_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPardakht.Checked)
            {
                double Pardakht = 0;
                txtPardakht_.Enabled = true;
                txtPardakhtPrice_.Enabled = true;
                if (txtPardakht_.Text.Trim().Length != 0) Pardakht = Convert.ToDouble(txtPardakht_.Text);
                lblPardakht.Text = (Pardakht * Convert.ToDouble(txtPardakhtPrice_.Text)).ToString();
                sumText();
            }
            else
            {
                txtPardakht_.Enabled = false;
                txtPardakhtPrice_.Enabled = false;
                lblPardakht.Text = "0";
                sumText();
            }
        }

        private void txtShur__KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                double Shur = 0;
                if (txtShur_.Text.Trim().Length != 0) Shur = Convert.ToDouble(txtShur_.Text);
                lblShur.Text = (Shur * Convert.ToDouble(txtShurPrice_.Text)).ToString();
                sumText();
            }
            catch (Exception)
            {
            }
        }

        private void txtDarkesh__KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                double Darkesh = 0;
                if (txtDarkesh_.Text.Trim().Length != 0) Darkesh = Convert.ToDouble(txtDarkesh_.Text);
                lblDarkesh.Text = (Darkesh * Convert.ToDouble(txtDarkeshPrice_.Text)).ToString();
                sumText();
            }
            catch (Exception)
            {
            }
        }

        private void txtGayegh__KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                double Gayegh = 0;
                if (txtGayegh_.Text.Trim().Length != 0) Gayegh = Convert.ToDouble(txtGayegh_.Text);
                lblGayegh.Text = (Gayegh * Convert.ToDouble(txtGayeghPrice_.Text)).ToString();
                sumText();
            }
            catch (Exception)
            {
            }
        }

        private void txtShiraze__KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                double Shiraze = 0;
                if (txtShiraze_.Text.Trim().Length != 0) Shiraze = Convert.ToDouble(txtShiraze_.Text);
                lblShiraze.Text = (Shiraze * Convert.ToDouble(txtShirazePrice_.Text)).ToString();
                sumText();
            }
            catch (Exception)
            {
            }
        }

        private void txtCharm__KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                double Charm = 0;
                if (txtCharm_.Text.Trim().Length != 0) Charm = Convert.ToDouble(txtCharm_.Text);
                lblCharm.Text = (Charm * Convert.ToDouble(txtCharmPrice_.Text)).ToString();
                sumText();
            }
            catch (Exception)
            {
            }
        }

        private void txtHasiri__KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                double Charm = 0;
                if (txtCharm_.Text.Trim().Length != 0) Charm = Convert.ToDouble(txtCharm_.Text);
                lblCharm.Text = (Charm * Convert.ToDouble(txtCharmPrice_.Text)).ToString();
                sumText();
            }
            catch (Exception)
            {
            }
        }

        private void txtGeytani__KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                double Geytani = 0;
                if (txtGeytani_.Text.Trim().Length != 0) Geytani = Convert.ToDouble(txtGeytani_.Text);
                lblGeytani.Text = (Geytani * Convert.ToDouble(txtGeytaniPrice_.Text)).ToString();
                sumText();
            }
            catch (Exception)
            {
            }
        }

        private void txtPardakht__KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                double Pardakht = 0;
                if (txtPardakht_.Text.Trim().Length != 0) Pardakht = Convert.ToDouble(txtPardakht_.Text);
                lblPardakht.Text = (Pardakht * Convert.ToDouble(txtPardakhtPrice_.Text)).ToString();
                sumText();
            }
            catch (Exception)
            {
            }
        }

        private void txtSum__KeyUp(object sender, KeyEventArgs e)
        {
            sumText();
        }


    }
}

