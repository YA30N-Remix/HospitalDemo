namespace Hospital.Forms.BasicInformation
{
    partial class frmCarpetPrice
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
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pnlNewEdit = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPardakht_ = new System.Windows.Forms.TextBox();
            this.txtGeytani_ = new System.Windows.Forms.TextBox();
            this.txtHasiri_ = new System.Windows.Forms.TextBox();
            this.txtCharm_ = new System.Windows.Forms.TextBox();
            this.txtShiraze_ = new System.Windows.Forms.TextBox();
            this.txtGayegh_ = new System.Windows.Forms.TextBox();
            this.txtDarkesh_ = new System.Windows.Forms.TextBox();
            this.txtShur_ = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtYear_ = new System.Windows.Forms.NumericUpDown();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlNewEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtYear_)).BeginInit();
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
            this.label1.Location = new System.Drawing.Point(817, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "سال";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(7, 155);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDescription.Size = new System.Drawing.Size(624, 29);
            this.txtDescription.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(598, 130);
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
            this.label9.Location = new System.Drawing.Point(798, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(16, 22);
            this.label9.TabIndex = 20;
            this.label9.Text = "*";
            // 
            // pnlNewEdit
            // 
            this.pnlNewEdit.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pnlNewEdit.Controls.Add(this.label14);
            this.pnlNewEdit.Controls.Add(this.label11);
            this.pnlNewEdit.Controls.Add(this.label10);
            this.pnlNewEdit.Controls.Add(this.label7);
            this.pnlNewEdit.Controls.Add(this.label5);
            this.pnlNewEdit.Controls.Add(this.label4);
            this.pnlNewEdit.Controls.Add(this.label3);
            this.pnlNewEdit.Controls.Add(this.label2);
            this.pnlNewEdit.Controls.Add(this.txtPardakht_);
            this.pnlNewEdit.Controls.Add(this.txtGeytani_);
            this.pnlNewEdit.Controls.Add(this.txtHasiri_);
            this.pnlNewEdit.Controls.Add(this.txtCharm_);
            this.pnlNewEdit.Controls.Add(this.txtShiraze_);
            this.pnlNewEdit.Controls.Add(this.txtGayegh_);
            this.pnlNewEdit.Controls.Add(this.txtDarkesh_);
            this.pnlNewEdit.Controls.Add(this.txtShur_);
            this.pnlNewEdit.Controls.Add(this.label24);
            this.pnlNewEdit.Controls.Add(this.label26);
            this.pnlNewEdit.Controls.Add(this.label20);
            this.pnlNewEdit.Controls.Add(this.label22);
            this.pnlNewEdit.Controls.Add(this.label16);
            this.pnlNewEdit.Controls.Add(this.label18);
            this.pnlNewEdit.Controls.Add(this.label13);
            this.pnlNewEdit.Controls.Add(this.label12);
            this.pnlNewEdit.Controls.Add(this.txtYear_);
            this.pnlNewEdit.Controls.Add(this.label9);
            this.pnlNewEdit.Controls.Add(this.label6);
            this.pnlNewEdit.Controls.Add(this.txtDescription);
            this.pnlNewEdit.Controls.Add(this.label1);
            this.pnlNewEdit.Location = new System.Drawing.Point(2, 2);
            this.pnlNewEdit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pnlNewEdit.Name = "pnlNewEdit";
            this.pnlNewEdit.Size = new System.Drawing.Size(857, 192);
            this.pnlNewEdit.TabIndex = 0;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(776, 130);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(16, 22);
            this.label14.TabIndex = 81;
            this.label14.Text = "*";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(127, 66);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(16, 22);
            this.label11.TabIndex = 80;
            this.label11.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(345, 66);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(16, 22);
            this.label10.TabIndex = 79;
            this.label10.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(576, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 22);
            this.label7.TabIndex = 78;
            this.label7.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(784, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 22);
            this.label5.TabIndex = 77;
            this.label5.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(149, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 22);
            this.label4.TabIndex = 76;
            this.label4.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(345, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 22);
            this.label3.TabIndex = 75;
            this.label3.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(576, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 22);
            this.label2.TabIndex = 74;
            this.label2.Text = "*";
            // 
            // txtPardakht_
            // 
            this.txtPardakht_.Location = new System.Drawing.Point(657, 155);
            this.txtPardakht_.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtPardakht_.MaxLength = 50;
            this.txtPardakht_.Name = "txtPardakht_";
            this.txtPardakht_.Size = new System.Drawing.Size(191, 29);
            this.txtPardakht_.TabIndex = 8;
            this.txtPardakht_.TextChanged += new System.EventHandler(this.txtMoney__TextChanged);
            this.txtPardakht_.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber__KeyPress);
            // 
            // txtGeytani_
            // 
            this.txtGeytani_.Location = new System.Drawing.Point(7, 94);
            this.txtGeytani_.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtGeytani_.MaxLength = 50;
            this.txtGeytani_.Name = "txtGeytani_";
            this.txtGeytani_.Size = new System.Drawing.Size(190, 29);
            this.txtGeytani_.TabIndex = 7;
            this.txtGeytani_.TextChanged += new System.EventHandler(this.txtMoney__TextChanged);
            this.txtGeytani_.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber__KeyPress);
            // 
            // txtHasiri_
            // 
            this.txtHasiri_.Location = new System.Drawing.Point(223, 94);
            this.txtHasiri_.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtHasiri_.MaxLength = 50;
            this.txtHasiri_.Name = "txtHasiri_";
            this.txtHasiri_.Size = new System.Drawing.Size(191, 29);
            this.txtHasiri_.TabIndex = 6;
            this.txtHasiri_.TextChanged += new System.EventHandler(this.txtMoney__TextChanged);
            this.txtHasiri_.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber__KeyPress);
            // 
            // txtCharm_
            // 
            this.txtCharm_.Location = new System.Drawing.Point(441, 94);
            this.txtCharm_.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtCharm_.MaxLength = 50;
            this.txtCharm_.Name = "txtCharm_";
            this.txtCharm_.Size = new System.Drawing.Size(190, 29);
            this.txtCharm_.TabIndex = 5;
            this.txtCharm_.TextChanged += new System.EventHandler(this.txtMoney__TextChanged);
            this.txtCharm_.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber__KeyPress);
            // 
            // txtShiraze_
            // 
            this.txtShiraze_.Location = new System.Drawing.Point(657, 96);
            this.txtShiraze_.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtShiraze_.MaxLength = 50;
            this.txtShiraze_.Name = "txtShiraze_";
            this.txtShiraze_.Size = new System.Drawing.Size(191, 29);
            this.txtShiraze_.TabIndex = 4;
            this.txtShiraze_.TextChanged += new System.EventHandler(this.txtMoney__TextChanged);
            this.txtShiraze_.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber__KeyPress);
            // 
            // txtGayegh_
            // 
            this.txtGayegh_.Location = new System.Drawing.Point(7, 32);
            this.txtGayegh_.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtGayegh_.MaxLength = 50;
            this.txtGayegh_.Name = "txtGayegh_";
            this.txtGayegh_.Size = new System.Drawing.Size(189, 29);
            this.txtGayegh_.TabIndex = 3;
            this.txtGayegh_.TextChanged += new System.EventHandler(this.txtMoney__TextChanged);
            this.txtGayegh_.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber__KeyPress);
            // 
            // txtDarkesh_
            // 
            this.txtDarkesh_.Location = new System.Drawing.Point(223, 33);
            this.txtDarkesh_.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDarkesh_.MaxLength = 50;
            this.txtDarkesh_.Name = "txtDarkesh_";
            this.txtDarkesh_.Size = new System.Drawing.Size(191, 29);
            this.txtDarkesh_.TabIndex = 2;
            this.txtDarkesh_.TextChanged += new System.EventHandler(this.txtMoney__TextChanged);
            this.txtDarkesh_.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber__KeyPress);
            // 
            // txtShur_
            // 
            this.txtShur_.Location = new System.Drawing.Point(441, 34);
            this.txtShur_.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtShur_.MaxLength = 50;
            this.txtShur_.Name = "txtShur_";
            this.txtShur_.Size = new System.Drawing.Size(190, 29);
            this.txtShur_.TabIndex = 1;
            this.txtShur_.TextChanged += new System.EventHandler(this.txtMoney__TextChanged);
            this.txtShur_.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber__KeyPress);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(798, 130);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(51, 22);
            this.label24.TabIndex = 73;
            this.label24.Text = "پرداخت";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(149, 67);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(47, 22);
            this.label26.TabIndex = 72;
            this.label26.Text = "قیطانی";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(366, 66);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(51, 22);
            this.label20.TabIndex = 71;
            this.label20.Text = "حصیری";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(601, 66);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(31, 22);
            this.label22.TabIndex = 70;
            this.label22.Text = "چرم";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(806, 66);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(42, 22);
            this.label16.TabIndex = 69;
            this.label16.Text = "شیرازه";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(163, 6);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(33, 22);
            this.label18.TabIndex = 68;
            this.label18.Text = "قایق";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(370, 5);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 22);
            this.label13.TabIndex = 67;
            this.label13.Text = "دارکشی";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(598, 6);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 22);
            this.label12.TabIndex = 66;
            this.label12.Text = "شور";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtYear_
            // 
            this.txtYear_.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtYear_.Location = new System.Drawing.Point(657, 34);
            this.txtYear_.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.txtYear_.Minimum = new decimal(new int[] {
            1300,
            0,
            0,
            0});
            this.txtYear_.Name = "txtYear_";
            this.txtYear_.Size = new System.Drawing.Size(191, 29);
            this.txtYear_.TabIndex = 0;
            this.txtYear_.Value = new decimal(new int[] {
            1398,
            0,
            0,
            0});
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
            // frmCarpetPrice
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
            this.Name = "frmCarpetPrice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مدیریت فی فرش ها";
            this.Load += new System.EventHandler(this.frmCarpetPrice_Load);
            this.pnlGrid.ResumeLayout(false);
            this.pnlGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pnlNewEdit.ResumeLayout(false);
            this.pnlNewEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtYear_)).EndInit();
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
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel pnlNewEdit;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.NumericUpDown txtYear_;
        private System.Windows.Forms.TextBox txtPardakht_;
        private System.Windows.Forms.TextBox txtGeytani_;
        private System.Windows.Forms.TextBox txtHasiri_;
        private System.Windows.Forms.TextBox txtCharm_;
        private System.Windows.Forms.TextBox txtShiraze_;
        private System.Windows.Forms.TextBox txtGayegh_;
        private System.Windows.Forms.TextBox txtDarkesh_;
        private System.Windows.Forms.TextBox txtShur_;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}