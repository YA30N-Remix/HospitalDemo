namespace Hospital.Forms.Operations
{
    partial class frmPersonnelFunction
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
            this.btnChangeStatus = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pnlNewEdit = new System.Windows.Forms.Panel();
            this.txtPersonnel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCarpet = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbMonth_ = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnSelectCarpets = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnSelectPersonnels = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtWorkDay_ = new System.Windows.Forms.TextBox();
            this.txtCount_ = new System.Windows.Forms.TextBox();
            this.txtMeters_ = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
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
            this.pnlGrid.Location = new System.Drawing.Point(2, 237);
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
            this.panel1.Controls.Add(this.btnChangeStatus);
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Location = new System.Drawing.Point(2, 189);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(857, 45);
            this.panel1.TabIndex = 22;
            // 
            // btnChangeStatus
            // 
            this.btnChangeStatus.Enabled = false;
            this.btnChangeStatus.Image = global::Hospital.Properties.Resources.compass;
            this.btnChangeStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnChangeStatus.Location = new System.Drawing.Point(273, 5);
            this.btnChangeStatus.Name = "btnChangeStatus";
            this.btnChangeStatus.Size = new System.Drawing.Size(88, 35);
            this.btnChangeStatus.TabIndex = 70;
            this.btnChangeStatus.Text = "تایید";
            this.btnChangeStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChangeStatus.UseVisualStyleBackColor = true;
            this.btnChangeStatus.Visible = false;
            this.btnChangeStatus.Click += new System.EventHandler(this.btnChangeStatus_Click);
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
            this.label2.Location = new System.Drawing.Point(598, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "متراژ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(7, 148);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDescription.Size = new System.Drawing.Size(841, 29);
            this.txtDescription.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(576, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(16, 22);
            this.label10.TabIndex = 21;
            this.label10.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(380, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 22);
            this.label3.TabIndex = 30;
            this.label3.Text = "تعداد";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(364, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(16, 22);
            this.label11.TabIndex = 31;
            this.label11.Text = "*";
            // 
            // pnlNewEdit
            // 
            this.pnlNewEdit.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pnlNewEdit.Controls.Add(this.txtPersonnel);
            this.pnlNewEdit.Controls.Add(this.label1);
            this.pnlNewEdit.Controls.Add(this.txtCarpet);
            this.pnlNewEdit.Controls.Add(this.label9);
            this.pnlNewEdit.Controls.Add(this.label15);
            this.pnlNewEdit.Controls.Add(this.label16);
            this.pnlNewEdit.Controls.Add(this.cmbMonth_);
            this.pnlNewEdit.Controls.Add(this.label13);
            this.pnlNewEdit.Controls.Add(this.btnSelectCarpets);
            this.pnlNewEdit.Controls.Add(this.label14);
            this.pnlNewEdit.Controls.Add(this.label12);
            this.pnlNewEdit.Controls.Add(this.btnSelectPersonnels);
            this.pnlNewEdit.Controls.Add(this.label7);
            this.pnlNewEdit.Controls.Add(this.txtWorkDay_);
            this.pnlNewEdit.Controls.Add(this.txtCount_);
            this.pnlNewEdit.Controls.Add(this.txtMeters_);
            this.pnlNewEdit.Controls.Add(this.label4);
            this.pnlNewEdit.Controls.Add(this.label5);
            this.pnlNewEdit.Controls.Add(this.label11);
            this.pnlNewEdit.Controls.Add(this.label3);
            this.pnlNewEdit.Controls.Add(this.label10);
            this.pnlNewEdit.Controls.Add(this.label6);
            this.pnlNewEdit.Controls.Add(this.txtDescription);
            this.pnlNewEdit.Controls.Add(this.label2);
            this.pnlNewEdit.Location = new System.Drawing.Point(2, 2);
            this.pnlNewEdit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pnlNewEdit.Name = "pnlNewEdit";
            this.pnlNewEdit.Size = new System.Drawing.Size(857, 184);
            this.pnlNewEdit.TabIndex = 0;
            // 
            // txtPersonnel
            // 
            this.txtPersonnel.Location = new System.Drawing.Point(440, 30);
            this.txtPersonnel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtPersonnel.MaxLength = 50;
            this.txtPersonnel.Name = "txtPersonnel";
            this.txtPersonnel.ReadOnly = true;
            this.txtPersonnel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPersonnel.Size = new System.Drawing.Size(191, 29);
            this.txtPersonnel.TabIndex = 91;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(570, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 22);
            this.label1.TabIndex = 92;
            this.label1.Text = "نام پرسنل";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCarpet
            // 
            this.txtCarpet.Location = new System.Drawing.Point(5, 32);
            this.txtCarpet.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtCarpet.MaxLength = 50;
            this.txtCarpet.Name = "txtCarpet";
            this.txtCarpet.ReadOnly = true;
            this.txtCarpet.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCarpet.Size = new System.Drawing.Size(191, 29);
            this.txtCarpet.TabIndex = 89;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(142, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 22);
            this.label9.TabIndex = 90;
            this.label9.Text = "نام فرش";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(798, 65);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(16, 22);
            this.label15.TabIndex = 69;
            this.label15.Text = "*";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(821, 65);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(27, 22);
            this.label16.TabIndex = 68;
            this.label16.Text = "ماه";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbMonth_
            // 
            this.cmbMonth_.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonth_.FormattingEnabled = true;
            this.cmbMonth_.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cmbMonth_.Location = new System.Drawing.Point(657, 89);
            this.cmbMonth_.Name = "cmbMonth_";
            this.cmbMonth_.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbMonth_.Size = new System.Drawing.Size(191, 30);
            this.cmbMonth_.TabIndex = 67;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(310, 7);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(16, 22);
            this.label13.TabIndex = 66;
            this.label13.Text = "*";
            // 
            // btnSelectCarpets
            // 
            this.btnSelectCarpets.Location = new System.Drawing.Point(223, 32);
            this.btnSelectCarpets.Name = "btnSelectCarpets";
            this.btnSelectCarpets.Size = new System.Drawing.Size(191, 29);
            this.btnSelectCarpets.TabIndex = 64;
            this.btnSelectCarpets.Text = "انتخاب فرش";
            this.btnSelectCarpets.UseVisualStyleBackColor = true;
            this.btnSelectCarpets.Click += new System.EventHandler(this.btnSelectCarpets_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(332, 7);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 22);
            this.label14.TabIndex = 65;
            this.label14.Text = "انتخاب فرش";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // btnSelectPersonnels
            // 
            this.btnSelectPersonnels.Location = new System.Drawing.Point(657, 32);
            this.btnSelectPersonnels.Name = "btnSelectPersonnels";
            this.btnSelectPersonnels.Size = new System.Drawing.Size(191, 29);
            this.btnSelectPersonnels.TabIndex = 1;
            this.btnSelectPersonnels.Text = "انتخاب پرسنل";
            this.btnSelectPersonnels.UseVisualStyleBackColor = true;
            this.btnSelectPersonnels.Click += new System.EventHandler(this.btnSelectPersonnels_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(766, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 22);
            this.label7.TabIndex = 62;
            this.label7.Text = "انتخاب پرسنل";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtWorkDay_
            // 
            this.txtWorkDay_.Location = new System.Drawing.Point(5, 90);
            this.txtWorkDay_.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtWorkDay_.MaxLength = 50;
            this.txtWorkDay_.Name = "txtWorkDay_";
            this.txtWorkDay_.Size = new System.Drawing.Size(191, 29);
            this.txtWorkDay_.TabIndex = 61;
            // 
            // txtCount_
            // 
            this.txtCount_.Location = new System.Drawing.Point(223, 90);
            this.txtCount_.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtCount_.MaxLength = 50;
            this.txtCount_.Name = "txtCount_";
            this.txtCount_.Size = new System.Drawing.Size(191, 29);
            this.txtCount_.TabIndex = 60;
            // 
            // txtMeters_
            // 
            this.txtMeters_.Location = new System.Drawing.Point(440, 90);
            this.txtMeters_.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtMeters_.MaxLength = 50;
            this.txtMeters_.Name = "txtMeters_";
            this.txtMeters_.Size = new System.Drawing.Size(191, 29);
            this.txtMeters_.TabIndex = 59;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(129, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 22);
            this.label4.TabIndex = 34;
            this.label4.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(143, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 22);
            this.label5.TabIndex = 33;
            this.label5.Text = "روز کاری";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(814, 121);
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
            // frmPersonnelFunction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 503);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlNewEdit);
            this.Font = new System.Drawing.Font("IRANSansWeb", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.Name = "frmPersonnelFunction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "کارکرد کارکنان";
            this.Load += new System.EventHandler(this.frmPersonnelFunction_Load);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel pnlNewEdit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMeters_;
        private System.Windows.Forms.TextBox txtCount_;
        private System.Windows.Forms.TextBox txtWorkDay_;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSelectPersonnels;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnSelectCarpets;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbMonth_;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnChangeStatus;
        private System.Windows.Forms.TextBox txtCarpet;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPersonnel;
        private System.Windows.Forms.Label label1;
    }
}