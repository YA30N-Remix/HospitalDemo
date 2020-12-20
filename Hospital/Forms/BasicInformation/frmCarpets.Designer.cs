namespace Hospital.Forms.BasicInformation
{
    partial class frmCarpets
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pnlNewEdit = new System.Windows.Forms.Panel();
            this.txtSum = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPardakht = new System.Windows.Forms.TextBox();
            this.txtGeytani = new System.Windows.Forms.TextBox();
            this.txtHasiri = new System.Windows.Forms.TextBox();
            this.txtCharm = new System.Windows.Forms.TextBox();
            this.txtShiraze = new System.Windows.Forms.TextBox();
            this.txtGayegh = new System.Windows.Forms.TextBox();
            this.txtDarkesh = new System.Windows.Forms.TextBox();
            this.txtShur = new System.Windows.Forms.TextBox();
            this.txtArea_ = new System.Windows.Forms.TextBox();
            this.txtHight_ = new System.Windows.Forms.TextBox();
            this.txtWidth_ = new System.Windows.Forms.TextBox();
            this.txtTitle_ = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlNewEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlGrid
            // 
            this.pnlGrid.BackColor = System.Drawing.Color.LightSalmon;
            this.pnlGrid.Controls.Add(this.label8);
            this.pnlGrid.Controls.Add(this.txtSearch);
            this.pnlGrid.Controls.Add(this.dgv);
            this.pnlGrid.Location = new System.Drawing.Point(2, 245);
            this.pnlGrid.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(857, 264);
            this.pnlGrid.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(764, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 22);
            this.label8.TabIndex = 18;
            this.label8.Text = "جستجوی سریع";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(567, 6);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtSearch.MaxLength = 50;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSearch.Size = new System.Drawing.Size(191, 29);
            this.txtSearch.TabIndex = 31;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dgv.Location = new System.Drawing.Point(3, 42);
            this.dgv.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgv.Size = new System.Drawing.Size(851, 217);
            this.dgv.TabIndex = 41;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Controls.Add(this.btnSelect);
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Location = new System.Drawing.Point(2, 198);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(857, 45);
            this.panel1.TabIndex = 22;
            // 
            // btnSelect
            // 
            this.btnSelect.Enabled = false;
            this.btnSelect.Image = global::Hospital.Properties.Resources.check1;
            this.btnSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelect.Location = new System.Drawing.Point(273, 5);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(88, 35);
            this.btnSelect.TabIndex = 26;
            this.btnSelect.Text = "انتخاب";
            this.btnSelect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Visible = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnNew
            // 
            this.btnNew.Image = global::Hospital.Properties.Resources.plus;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.Location = new System.Drawing.Point(555, 5);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(88, 35);
            this.btnNew.TabIndex = 21;
            this.btnNew.Text = "جدید";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Hospital.Properties.Resources.memorycard;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(461, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(88, 35);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "ذخیره";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Image = global::Hospital.Properties.Resources.Delete1;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.Location = new System.Drawing.Point(367, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(88, 35);
            this.btnDelete.TabIndex = 23;
            this.btnDelete.Text = "حذف";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(810, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "عنوان";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(598, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "طول";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(7, 155);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDescription.Size = new System.Drawing.Size(624, 29);
            this.txtDescription.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(597, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 22);
            this.label6.TabIndex = 14;
            this.label6.Text = "شرح";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(788, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(16, 22);
            this.label9.TabIndex = 20;
            this.label9.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(576, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(16, 22);
            this.label10.TabIndex = 21;
            this.label10.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(379, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 22);
            this.label3.TabIndex = 30;
            this.label3.Text = "عرض";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(363, 8);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(16, 22);
            this.label11.TabIndex = 31;
            this.label11.Text = "*";
            // 
            // pnlNewEdit
            // 
            this.pnlNewEdit.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pnlNewEdit.Controls.Add(this.txtSum);
            this.pnlNewEdit.Controls.Add(this.label7);
            this.pnlNewEdit.Controls.Add(this.txtPardakht);
            this.pnlNewEdit.Controls.Add(this.txtGeytani);
            this.pnlNewEdit.Controls.Add(this.txtHasiri);
            this.pnlNewEdit.Controls.Add(this.txtCharm);
            this.pnlNewEdit.Controls.Add(this.txtShiraze);
            this.pnlNewEdit.Controls.Add(this.txtGayegh);
            this.pnlNewEdit.Controls.Add(this.txtDarkesh);
            this.pnlNewEdit.Controls.Add(this.txtShur);
            this.pnlNewEdit.Controls.Add(this.txtArea_);
            this.pnlNewEdit.Controls.Add(this.txtHight_);
            this.pnlNewEdit.Controls.Add(this.txtWidth_);
            this.pnlNewEdit.Controls.Add(this.txtTitle_);
            this.pnlNewEdit.Controls.Add(this.label24);
            this.pnlNewEdit.Controls.Add(this.label26);
            this.pnlNewEdit.Controls.Add(this.label20);
            this.pnlNewEdit.Controls.Add(this.label22);
            this.pnlNewEdit.Controls.Add(this.label16);
            this.pnlNewEdit.Controls.Add(this.label18);
            this.pnlNewEdit.Controls.Add(this.label13);
            this.pnlNewEdit.Controls.Add(this.label12);
            this.pnlNewEdit.Controls.Add(this.label4);
            this.pnlNewEdit.Controls.Add(this.label5);
            this.pnlNewEdit.Controls.Add(this.label11);
            this.pnlNewEdit.Controls.Add(this.label3);
            this.pnlNewEdit.Controls.Add(this.label10);
            this.pnlNewEdit.Controls.Add(this.label9);
            this.pnlNewEdit.Controls.Add(this.label6);
            this.pnlNewEdit.Controls.Add(this.txtDescription);
            this.pnlNewEdit.Controls.Add(this.label2);
            this.pnlNewEdit.Controls.Add(this.label1);
            this.pnlNewEdit.Location = new System.Drawing.Point(2, 2);
            this.pnlNewEdit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pnlNewEdit.Name = "pnlNewEdit";
            this.pnlNewEdit.Size = new System.Drawing.Size(857, 192);
            this.pnlNewEdit.TabIndex = 0;
            // 
            // txtSum
            // 
            this.txtSum.Location = new System.Drawing.Point(657, 155);
            this.txtSum.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtSum.MaxLength = 50;
            this.txtSum.Name = "txtSum";
            this.txtSum.ReadOnly = true;
            this.txtSum.Size = new System.Drawing.Size(191, 29);
            this.txtSum.TabIndex = 71;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(814, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 22);
            this.label7.TabIndex = 70;
            this.label7.Text = "جمع";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPardakht
            // 
            this.txtPardakht.Location = new System.Drawing.Point(7, 96);
            this.txtPardakht.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtPardakht.MaxLength = 50;
            this.txtPardakht.Name = "txtPardakht";
            this.txtPardakht.Size = new System.Drawing.Size(80, 29);
            this.txtPardakht.TabIndex = 12;
            this.txtPardakht.TextChanged += new System.EventHandler(this.txtSums_TextChanged);
            this.txtPardakht.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber__KeyPress);
            // 
            // txtGeytani
            // 
            this.txtGeytani.Location = new System.Drawing.Point(118, 96);
            this.txtGeytani.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtGeytani.MaxLength = 50;
            this.txtGeytani.Name = "txtGeytani";
            this.txtGeytani.Size = new System.Drawing.Size(80, 29);
            this.txtGeytani.TabIndex = 11;
            this.txtGeytani.TextChanged += new System.EventHandler(this.txtSums_TextChanged);
            this.txtGeytani.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber__KeyPress);
            // 
            // txtHasiri
            // 
            this.txtHasiri.Location = new System.Drawing.Point(222, 96);
            this.txtHasiri.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtHasiri.MaxLength = 50;
            this.txtHasiri.Name = "txtHasiri";
            this.txtHasiri.Size = new System.Drawing.Size(80, 29);
            this.txtHasiri.TabIndex = 10;
            this.txtHasiri.TextChanged += new System.EventHandler(this.txtSums_TextChanged);
            this.txtHasiri.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber__KeyPress);
            // 
            // txtCharm
            // 
            this.txtCharm.Location = new System.Drawing.Point(333, 96);
            this.txtCharm.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtCharm.MaxLength = 50;
            this.txtCharm.Name = "txtCharm";
            this.txtCharm.Size = new System.Drawing.Size(80, 29);
            this.txtCharm.TabIndex = 9;
            this.txtCharm.TextChanged += new System.EventHandler(this.txtSums_TextChanged);
            this.txtCharm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber__KeyPress);
            // 
            // txtShiraze
            // 
            this.txtShiraze.Location = new System.Drawing.Point(440, 96);
            this.txtShiraze.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtShiraze.MaxLength = 50;
            this.txtShiraze.Name = "txtShiraze";
            this.txtShiraze.Size = new System.Drawing.Size(80, 29);
            this.txtShiraze.TabIndex = 8;
            this.txtShiraze.TextChanged += new System.EventHandler(this.txtSums_TextChanged);
            this.txtShiraze.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber__KeyPress);
            // 
            // txtGayegh
            // 
            this.txtGayegh.Location = new System.Drawing.Point(551, 96);
            this.txtGayegh.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtGayegh.MaxLength = 50;
            this.txtGayegh.Name = "txtGayegh";
            this.txtGayegh.Size = new System.Drawing.Size(80, 29);
            this.txtGayegh.TabIndex = 7;
            this.txtGayegh.TextChanged += new System.EventHandler(this.txtSums_TextChanged);
            this.txtGayegh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber__KeyPress);
            // 
            // txtDarkesh
            // 
            this.txtDarkesh.Location = new System.Drawing.Point(657, 96);
            this.txtDarkesh.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDarkesh.MaxLength = 50;
            this.txtDarkesh.Name = "txtDarkesh";
            this.txtDarkesh.Size = new System.Drawing.Size(80, 29);
            this.txtDarkesh.TabIndex = 6;
            this.txtDarkesh.TextChanged += new System.EventHandler(this.txtSums_TextChanged);
            this.txtDarkesh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber__KeyPress);
            // 
            // txtShur
            // 
            this.txtShur.Location = new System.Drawing.Point(768, 96);
            this.txtShur.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtShur.MaxLength = 50;
            this.txtShur.Name = "txtShur";
            this.txtShur.Size = new System.Drawing.Size(80, 29);
            this.txtShur.TabIndex = 5;
            this.txtShur.TextChanged += new System.EventHandler(this.txtSums_TextChanged);
            this.txtShur.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber__KeyPress);
            // 
            // txtArea_
            // 
            this.txtArea_.Location = new System.Drawing.Point(7, 34);
            this.txtArea_.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtArea_.MaxLength = 50;
            this.txtArea_.Name = "txtArea_";
            this.txtArea_.Size = new System.Drawing.Size(191, 29);
            this.txtArea_.TabIndex = 4;
            this.txtArea_.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber__KeyPress);
            // 
            // txtHight_
            // 
            this.txtHight_.Location = new System.Drawing.Point(222, 34);
            this.txtHight_.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtHight_.MaxLength = 50;
            this.txtHight_.Name = "txtHight_";
            this.txtHight_.Size = new System.Drawing.Size(191, 29);
            this.txtHight_.TabIndex = 3;
            this.txtHight_.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber__KeyPress);
            // 
            // txtWidth_
            // 
            this.txtWidth_.Location = new System.Drawing.Point(440, 34);
            this.txtWidth_.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtWidth_.MaxLength = 50;
            this.txtWidth_.Name = "txtWidth_";
            this.txtWidth_.Size = new System.Drawing.Size(191, 29);
            this.txtWidth_.TabIndex = 2;
            this.txtWidth_.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber__KeyPress);
            // 
            // txtTitle_
            // 
            this.txtTitle_.Location = new System.Drawing.Point(657, 34);
            this.txtTitle_.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtTitle_.MaxLength = 50;
            this.txtTitle_.Name = "txtTitle_";
            this.txtTitle_.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTitle_.Size = new System.Drawing.Size(191, 29);
            this.txtTitle_.TabIndex = 1;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(36, 68);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(51, 22);
            this.label24.TabIndex = 57;
            this.label24.Text = "پرداخت";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(151, 68);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(47, 22);
            this.label26.TabIndex = 54;
            this.label26.Text = "قیطانی";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(251, 68);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(51, 22);
            this.label20.TabIndex = 51;
            this.label20.Text = "حصیری";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(380, 68);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(31, 22);
            this.label22.TabIndex = 48;
            this.label22.Text = "چرم";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(478, 68);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(42, 22);
            this.label16.TabIndex = 45;
            this.label16.Text = "شیرازه";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(598, 68);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(33, 22);
            this.label18.TabIndex = 42;
            this.label18.Text = "قایق";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(688, 68);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 22);
            this.label13.TabIndex = 39;
            this.label13.Text = "دارکشی";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(815, 68);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 22);
            this.label12.TabIndex = 36;
            this.label12.Text = "شور";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(129, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 22);
            this.label4.TabIndex = 34;
            this.label4.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(145, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 22);
            this.label5.TabIndex = 33;
            this.label5.Text = "مساحت";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "ویرایش";
            this.dataGridViewImageColumn1.Image = global::Hospital.Properties.Resources.compose1;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "حذف";
            this.dataGridViewImageColumn2.Image = global::Hospital.Properties.Resources.Delete;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // frmCarpets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 511);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlNewEdit);
            this.Font = new System.Drawing.Font("IRANSansWeb", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.Name = "frmCarpets";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مدیریت فرش ها";
            this.Load += new System.EventHandler(this.frmCarpets_Load);
            this.pnlGrid.ResumeLayout(false);
            this.pnlGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pnlNewEdit.ResumeLayout(false);
            this.pnlNewEdit.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel pnlNewEdit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtTitle_;
        private System.Windows.Forms.TextBox txtWidth_;
        private System.Windows.Forms.TextBox txtHight_;
        private System.Windows.Forms.TextBox txtArea_;
        private System.Windows.Forms.TextBox txtShur;
        private System.Windows.Forms.TextBox txtDarkesh;
        private System.Windows.Forms.TextBox txtGayegh;
        private System.Windows.Forms.TextBox txtShiraze;
        private System.Windows.Forms.TextBox txtCharm;
        private System.Windows.Forms.TextBox txtHasiri;
        private System.Windows.Forms.TextBox txtPardakht;
        private System.Windows.Forms.TextBox txtGeytani;
        private System.Windows.Forms.TextBox txtSum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSelect;
    }
}