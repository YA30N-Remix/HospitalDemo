namespace Hospital.Forms.Operations
{
    partial class frmDocuments
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
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pnlNewEdit = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.txtTitle_ = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.txtPrice_ = new System.Windows.Forms.TextBox();
            this.txtCheck = new System.Windows.Forms.TextBox();
            this.lblinfoCheck = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbChecks = new System.Windows.Forms.RadioButton();
            this.rdbHandly = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDocumentDate_ = new System.Windows.Forms.MaskedTextBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbSend = new System.Windows.Forms.RadioButton();
            this.rdbRecive = new System.Windows.Forms.RadioButton();
            this.lblCheckStar = new System.Windows.Forms.Label();
            this.lblCheck = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnSelectCustomers = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlNewEdit.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlGrid
            // 
            this.pnlGrid.BackColor = System.Drawing.Color.LightSalmon;
            this.pnlGrid.Controls.Add(this.label8);
            this.pnlGrid.Controls.Add(this.txtSearch);
            this.pnlGrid.Controls.Add(this.dgv);
            this.pnlGrid.Location = new System.Drawing.Point(2, 239);
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
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Location = new System.Drawing.Point(2, 191);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(857, 45);
            this.panel1.TabIndex = 22;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(786, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "تاریخ سند";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(7, 148);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDescription.Size = new System.Drawing.Size(407, 29);
            this.txtDescription.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(764, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(16, 22);
            this.label10.TabIndex = 21;
            this.label10.Text = "*";
            // 
            // pnlNewEdit
            // 
            this.pnlNewEdit.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pnlNewEdit.Controls.Add(this.label15);
            this.pnlNewEdit.Controls.Add(this.txtTitle_);
            this.pnlNewEdit.Controls.Add(this.label9);
            this.pnlNewEdit.Controls.Add(this.txtDiscount);
            this.pnlNewEdit.Controls.Add(this.txtPrice_);
            this.pnlNewEdit.Controls.Add(this.txtCheck);
            this.pnlNewEdit.Controls.Add(this.lblinfoCheck);
            this.pnlNewEdit.Controls.Add(this.txtCustomerName);
            this.pnlNewEdit.Controls.Add(this.label18);
            this.pnlNewEdit.Controls.Add(this.label14);
            this.pnlNewEdit.Controls.Add(this.label13);
            this.pnlNewEdit.Controls.Add(this.label11);
            this.pnlNewEdit.Controls.Add(this.groupBox1);
            this.pnlNewEdit.Controls.Add(this.label5);
            this.pnlNewEdit.Controls.Add(this.label3);
            this.pnlNewEdit.Controls.Add(this.txtDocumentDate_);
            this.pnlNewEdit.Controls.Add(this.btnCheck);
            this.pnlNewEdit.Controls.Add(this.label4);
            this.pnlNewEdit.Controls.Add(this.label1);
            this.pnlNewEdit.Controls.Add(this.groupBox2);
            this.pnlNewEdit.Controls.Add(this.lblCheckStar);
            this.pnlNewEdit.Controls.Add(this.lblCheck);
            this.pnlNewEdit.Controls.Add(this.label12);
            this.pnlNewEdit.Controls.Add(this.btnSelectCustomers);
            this.pnlNewEdit.Controls.Add(this.label7);
            this.pnlNewEdit.Controls.Add(this.label10);
            this.pnlNewEdit.Controls.Add(this.label6);
            this.pnlNewEdit.Controls.Add(this.txtDescription);
            this.pnlNewEdit.Controls.Add(this.label2);
            this.pnlNewEdit.Location = new System.Drawing.Point(2, 2);
            this.pnlNewEdit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pnlNewEdit.Name = "pnlNewEdit";
            this.pnlNewEdit.Size = new System.Drawing.Size(857, 186);
            this.pnlNewEdit.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(786, 121);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(16, 22);
            this.label15.TabIndex = 101;
            this.label15.Text = "*";
            // 
            // txtTitle_
            // 
            this.txtTitle_.Location = new System.Drawing.Point(657, 148);
            this.txtTitle_.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtTitle_.MaxLength = 100;
            this.txtTitle_.Name = "txtTitle_";
            this.txtTitle_.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTitle_.Size = new System.Drawing.Size(191, 29);
            this.txtTitle_.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(810, 121);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 22);
            this.label9.TabIndex = 99;
            this.label9.Text = "عنوان";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(439, 148);
            this.txtDiscount.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDiscount.MaxLength = 50;
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(191, 29);
            this.txtDiscount.TabIndex = 11;
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            this.txtDiscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber__KeyPress);
            // 
            // txtPrice_
            // 
            this.txtPrice_.Location = new System.Drawing.Point(440, 90);
            this.txtPrice_.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtPrice_.MaxLength = 50;
            this.txtPrice_.Name = "txtPrice_";
            this.txtPrice_.Size = new System.Drawing.Size(191, 29);
            this.txtPrice_.TabIndex = 7;
            this.txtPrice_.TextChanged += new System.EventHandler(this.txtPrice__TextChanged);
            this.txtPrice_.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber__KeyPress);
            // 
            // txtCheck
            // 
            this.txtCheck.Location = new System.Drawing.Point(7, 87);
            this.txtCheck.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtCheck.MaxLength = 50;
            this.txtCheck.Name = "txtCheck";
            this.txtCheck.ReadOnly = true;
            this.txtCheck.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCheck.Size = new System.Drawing.Size(191, 29);
            this.txtCheck.TabIndex = 9;
            this.txtCheck.Visible = false;
            // 
            // lblinfoCheck
            // 
            this.lblinfoCheck.AutoSize = true;
            this.lblinfoCheck.Location = new System.Drawing.Point(108, 65);
            this.lblinfoCheck.Name = "lblinfoCheck";
            this.lblinfoCheck.Size = new System.Drawing.Size(89, 22);
            this.lblinfoCheck.TabIndex = 100;
            this.lblinfoCheck.Text = "مشخصات چک";
            this.lblinfoCheck.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblinfoCheck.Visible = false;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(440, 32);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtCustomerName.MaxLength = 50;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCustomerName.Size = new System.Drawing.Size(191, 29);
            this.txtCustomerName.TabIndex = 1;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(563, 8);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(68, 22);
            this.label18.TabIndex = 97;
            this.label18.Text = "نام مشتری";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(584, 121);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 22);
            this.label14.TabIndex = 95;
            this.label14.Text = "تخفیف";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(101, 7);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(16, 22);
            this.label13.TabIndex = 93;
            this.label13.Text = "*";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(123, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 22);
            this.label11.TabIndex = 92;
            this.label11.Text = "نوع پرداخت";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbChecks);
            this.groupBox1.Controls.Add(this.rdbHandly);
            this.groupBox1.Location = new System.Drawing.Point(6, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(191, 40);
            this.groupBox1.TabIndex = 71;
            this.groupBox1.TabStop = false;
            // 
            // rdbChecks
            // 
            this.rdbChecks.AutoSize = true;
            this.rdbChecks.Location = new System.Drawing.Point(21, 12);
            this.rdbChecks.Name = "rdbChecks";
            this.rdbChecks.Size = new System.Drawing.Size(50, 26);
            this.rdbChecks.TabIndex = 5;
            this.rdbChecks.TabStop = true;
            this.rdbChecks.Text = "چک";
            this.rdbChecks.UseVisualStyleBackColor = true;
            this.rdbChecks.CheckedChanged += new System.EventHandler(this.rdbChecks_CheckedChanged);
            // 
            // rdbHandly
            // 
            this.rdbHandly.AutoSize = true;
            this.rdbHandly.Location = new System.Drawing.Point(119, 12);
            this.rdbHandly.Name = "rdbHandly";
            this.rdbHandly.Size = new System.Drawing.Size(55, 26);
            this.rdbHandly.TabIndex = 4;
            this.rdbHandly.TabStop = true;
            this.rdbHandly.Text = "نقدی";
            this.rdbHandly.UseVisualStyleBackColor = true;
            this.rdbHandly.CheckedChanged += new System.EventHandler(this.rdbHandly_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(575, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 22);
            this.label5.TabIndex = 89;
            this.label5.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(597, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 22);
            this.label3.TabIndex = 88;
            this.label3.Text = "مبلغ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDocumentDate_
            // 
            this.txtDocumentDate_.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.txtDocumentDate_.Location = new System.Drawing.Point(657, 89);
            this.txtDocumentDate_.Mask = "0000/00/00";
            this.txtDocumentDate_.Name = "txtDocumentDate_";
            this.txtDocumentDate_.ReadOnly = true;
            this.txtDocumentDate_.Size = new System.Drawing.Size(191, 29);
            this.txtDocumentDate_.TabIndex = 6;
            this.txtDocumentDate_.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt;
            this.txtDocumentDate_.ValidatingType = typeof(System.DateTime);
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(223, 89);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(191, 29);
            this.btnCheck.TabIndex = 8;
            this.btnCheck.Text = "انتخاب چک";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Visible = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(337, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 22);
            this.label4.TabIndex = 74;
            this.label4.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(359, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 22);
            this.label1.TabIndex = 71;
            this.label1.Text = "نوع سند";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbSend);
            this.groupBox2.Controls.Add(this.rdbRecive);
            this.groupBox2.Location = new System.Drawing.Point(223, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(191, 40);
            this.groupBox2.TabIndex = 70;
            this.groupBox2.TabStop = false;
            // 
            // rdbSend
            // 
            this.rdbSend.AutoSize = true;
            this.rdbSend.Location = new System.Drawing.Point(21, 12);
            this.rdbSend.Name = "rdbSend";
            this.rdbSend.Size = new System.Drawing.Size(71, 26);
            this.rdbSend.TabIndex = 3;
            this.rdbSend.TabStop = true;
            this.rdbSend.Text = "پرداختی";
            this.rdbSend.UseVisualStyleBackColor = true;
            // 
            // rdbRecive
            // 
            this.rdbRecive.AutoSize = true;
            this.rdbRecive.Location = new System.Drawing.Point(119, 12);
            this.rdbRecive.Name = "rdbRecive";
            this.rdbRecive.Size = new System.Drawing.Size(67, 26);
            this.rdbRecive.TabIndex = 2;
            this.rdbRecive.TabStop = true;
            this.rdbRecive.Text = "دریافتی";
            this.rdbRecive.UseVisualStyleBackColor = true;
            // 
            // lblCheckStar
            // 
            this.lblCheckStar.AutoSize = true;
            this.lblCheckStar.ForeColor = System.Drawing.Color.Red;
            this.lblCheckStar.Location = new System.Drawing.Point(325, 65);
            this.lblCheckStar.Name = "lblCheckStar";
            this.lblCheckStar.Size = new System.Drawing.Size(16, 22);
            this.lblCheckStar.TabIndex = 69;
            this.lblCheckStar.Text = "*";
            this.lblCheckStar.Visible = false;
            // 
            // lblCheck
            // 
            this.lblCheck.AutoSize = true;
            this.lblCheck.Location = new System.Drawing.Point(342, 65);
            this.lblCheck.Name = "lblCheck";
            this.lblCheck.Size = new System.Drawing.Size(72, 22);
            this.lblCheck.TabIndex = 68;
            this.lblCheck.Text = "انتخاب چک";
            this.lblCheck.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCheck.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(744, 7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(16, 22);
            this.label12.TabIndex = 63;
            this.label12.Text = "*";
            // 
            // btnSelectCustomers
            // 
            this.btnSelectCustomers.Location = new System.Drawing.Point(657, 32);
            this.btnSelectCustomers.Name = "btnSelectCustomers";
            this.btnSelectCustomers.Size = new System.Drawing.Size(191, 29);
            this.btnSelectCustomers.TabIndex = 0;
            this.btnSelectCustomers.Text = "انتخاب مشتری";
            this.btnSelectCustomers.UseVisualStyleBackColor = true;
            this.btnSelectCustomers.Click += new System.EventHandler(this.btnSelectCustomers_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(759, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 22);
            this.label7.TabIndex = 62;
            this.label7.Text = "انتخاب مشتری";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(380, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 22);
            this.label6.TabIndex = 14;
            this.label6.Text = "شرح";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // frmDocuments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 506);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlNewEdit);
            this.Font = new System.Drawing.Font("IRANSansWeb", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.Name = "frmDocuments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مدیریت سند ها";
            this.Load += new System.EventHandler(this.frmDocuments_Load);
            this.pnlGrid.ResumeLayout(false);
            this.pnlGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pnlNewEdit.ResumeLayout(false);
            this.pnlNewEdit.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel pnlNewEdit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSelectCustomers;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblCheckStar;
        private System.Windows.Forms.Label lblCheck;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbSend;
        private System.Windows.Forms.RadioButton rdbRecive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.MaskedTextBox txtDocumentDate_;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbChecks;
        private System.Windows.Forms.RadioButton rdbHandly;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtCheck;
        private System.Windows.Forms.Label lblinfoCheck;
        private System.Windows.Forms.TextBox txtPrice_;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.TextBox txtTitle_;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label15;
    }
}