namespace FileBackApp
{
    partial class mainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.tlp_UI = new System.Windows.Forms.TableLayoutPanel();
            this.nud_Frequency = new System.Windows.Forms.NumericUpDown();
            this.lbl_Frequency = new System.Windows.Forms.Label();
            this.tb_From = new System.Windows.Forms.TextBox();
            this.tb_To = new System.Windows.Forms.TextBox();
            this.nud_Time = new System.Windows.Forms.NumericUpDown();
            this.btn_SearchFrom = new System.Windows.Forms.Button();
            this.btn_SearchTo = new System.Windows.Forms.Button();
            this.btn_Start = new System.Windows.Forms.Button();
            this.lbl_Time = new System.Windows.Forms.Label();
            this.lbl_To = new System.Windows.Forms.Label();
            this.lbl_From = new System.Windows.Forms.Label();
            this.pb_CopyTime = new System.Windows.Forms.ProgressBar();
            this.cb_Always = new System.Windows.Forms.CheckBox();
            this.cb_Units = new System.Windows.Forms.ComboBox();
            this.lbl_Units = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.tlp_UI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Frequency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Time)).BeginInit();
            this.SuspendLayout();
            // 
            // tlp_UI
            // 
            this.tlp_UI.ColumnCount = 5;
            this.tlp_UI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlp_UI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.74047F));
            this.tlp_UI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.51926F));
            this.tlp_UI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.74027F));
            this.tlp_UI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tlp_UI.Controls.Add(this.nud_Frequency, 2, 5);
            this.tlp_UI.Controls.Add(this.lbl_Frequency, 1, 5);
            this.tlp_UI.Controls.Add(this.tb_From, 2, 1);
            this.tlp_UI.Controls.Add(this.tb_To, 2, 2);
            this.tlp_UI.Controls.Add(this.nud_Time, 2, 4);
            this.tlp_UI.Controls.Add(this.btn_SearchFrom, 3, 1);
            this.tlp_UI.Controls.Add(this.btn_SearchTo, 3, 2);
            this.tlp_UI.Controls.Add(this.btn_Start, 1, 7);
            this.tlp_UI.Controls.Add(this.lbl_Time, 1, 4);
            this.tlp_UI.Controls.Add(this.lbl_To, 1, 2);
            this.tlp_UI.Controls.Add(this.lbl_From, 1, 1);
            this.tlp_UI.Controls.Add(this.pb_CopyTime, 2, 7);
            this.tlp_UI.Controls.Add(this.cb_Always, 1, 6);
            this.tlp_UI.Controls.Add(this.cb_Units, 2, 3);
            this.tlp_UI.Controls.Add(this.lbl_Units, 1, 3);
            this.tlp_UI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_UI.Location = new System.Drawing.Point(0, 0);
            this.tlp_UI.Name = "tlp_UI";
            this.tlp_UI.RowCount = 9;
            this.tlp_UI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlp_UI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tlp_UI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tlp_UI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tlp_UI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tlp_UI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tlp_UI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tlp_UI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28816F));
            this.tlp_UI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlp_UI.Size = new System.Drawing.Size(518, 218);
            this.tlp_UI.TabIndex = 0;
            // 
            // nud_Frequency
            // 
            this.nud_Frequency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nud_Frequency.Location = new System.Drawing.Point(102, 124);
            this.nud_Frequency.Name = "nud_Frequency";
            this.nud_Frequency.Size = new System.Drawing.Size(348, 20);
            this.nud_Frequency.TabIndex = 11;
            this.nud_Frequency.ValueChanged += new System.EventHandler(this.value_Changed);
            // 
            // lbl_Frequency
            // 
            this.lbl_Frequency.AutoSize = true;
            this.lbl_Frequency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Frequency.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lbl_Frequency.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_Frequency.Location = new System.Drawing.Point(8, 121);
            this.lbl_Frequency.Name = "lbl_Frequency";
            this.lbl_Frequency.Size = new System.Drawing.Size(88, 29);
            this.lbl_Frequency.TabIndex = 10;
            this.lbl_Frequency.Text = "Frequency";
            this.lbl_Frequency.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_From
            // 
            this.tb_From.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_From.Location = new System.Drawing.Point(102, 8);
            this.tb_From.Name = "tb_From";
            this.tb_From.Size = new System.Drawing.Size(348, 20);
            this.tb_From.TabIndex = 4;
            this.tb_From.WordWrap = false;
            this.tb_From.TextChanged += new System.EventHandler(this.value_Changed);
            // 
            // tb_To
            // 
            this.tb_To.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_To.Location = new System.Drawing.Point(102, 37);
            this.tb_To.Name = "tb_To";
            this.tb_To.Size = new System.Drawing.Size(348, 20);
            this.tb_To.TabIndex = 5;
            this.tb_To.WordWrap = false;
            this.tb_To.TextChanged += new System.EventHandler(this.value_Changed);
            // 
            // nud_Time
            // 
            this.nud_Time.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nud_Time.Location = new System.Drawing.Point(102, 95);
            this.nud_Time.Name = "nud_Time";
            this.nud_Time.Size = new System.Drawing.Size(348, 20);
            this.nud_Time.TabIndex = 2;
            this.nud_Time.ValueChanged += new System.EventHandler(this.value_Changed);
            // 
            // btn_SearchFrom
            // 
            this.btn_SearchFrom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_SearchFrom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SearchFrom.Location = new System.Drawing.Point(456, 8);
            this.btn_SearchFrom.Name = "btn_SearchFrom";
            this.btn_SearchFrom.Size = new System.Drawing.Size(48, 23);
            this.btn_SearchFrom.TabIndex = 0;
            this.btn_SearchFrom.Text = "···";
            this.btn_SearchFrom.UseVisualStyleBackColor = true;
            this.btn_SearchFrom.Click += new System.EventHandler(this.btn_SearchFrom_Click);
            // 
            // btn_SearchTo
            // 
            this.btn_SearchTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_SearchTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SearchTo.Location = new System.Drawing.Point(456, 37);
            this.btn_SearchTo.Name = "btn_SearchTo";
            this.btn_SearchTo.Size = new System.Drawing.Size(48, 23);
            this.btn_SearchTo.TabIndex = 1;
            this.btn_SearchTo.Text = "···";
            this.btn_SearchTo.UseVisualStyleBackColor = true;
            this.btn_SearchTo.Click += new System.EventHandler(this.btn_SearchTo_Click);
            // 
            // btn_Start
            // 
            this.btn_Start.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Start.Enabled = false;
            this.btn_Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Start.Location = new System.Drawing.Point(8, 182);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(88, 23);
            this.btn_Start.TabIndex = 6;
            this.btn_Start.Text = "Start loop";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // lbl_Time
            // 
            this.lbl_Time.AutoSize = true;
            this.lbl_Time.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Time.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lbl_Time.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_Time.Location = new System.Drawing.Point(8, 92);
            this.lbl_Time.Name = "lbl_Time";
            this.lbl_Time.Size = new System.Drawing.Size(88, 29);
            this.lbl_Time.TabIndex = 3;
            this.lbl_Time.Text = "Time";
            this.lbl_Time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_To
            // 
            this.lbl_To.AutoSize = true;
            this.lbl_To.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_To.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lbl_To.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_To.Location = new System.Drawing.Point(8, 34);
            this.lbl_To.Name = "lbl_To";
            this.lbl_To.Size = new System.Drawing.Size(88, 29);
            this.lbl_To.TabIndex = 8;
            this.lbl_To.Text = "Copy to:";
            this.lbl_To.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_From
            // 
            this.lbl_From.AutoSize = true;
            this.lbl_From.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_From.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lbl_From.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_From.Location = new System.Drawing.Point(8, 5);
            this.lbl_From.Name = "lbl_From";
            this.lbl_From.Size = new System.Drawing.Size(88, 29);
            this.lbl_From.TabIndex = 7;
            this.lbl_From.Text = "Directory";
            this.lbl_From.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pb_CopyTime
            // 
            this.tlp_UI.SetColumnSpan(this.pb_CopyTime, 2);
            this.pb_CopyTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_CopyTime.Location = new System.Drawing.Point(102, 182);
            this.pb_CopyTime.Name = "pb_CopyTime";
            this.pb_CopyTime.Size = new System.Drawing.Size(402, 23);
            this.pb_CopyTime.Step = 1;
            this.pb_CopyTime.TabIndex = 9;
            // 
            // cb_Always
            // 
            this.cb_Always.AutoSize = true;
            this.cb_Always.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_Always.Location = new System.Drawing.Point(8, 153);
            this.cb_Always.Name = "cb_Always";
            this.cb_Always.Size = new System.Drawing.Size(88, 23);
            this.cb_Always.TabIndex = 12;
            this.cb_Always.Text = "Do always";
            this.cb_Always.UseVisualStyleBackColor = true;
            this.cb_Always.CheckedChanged += new System.EventHandler(this.cb_Always_CheckedChanged);
            // 
            // cb_Units
            // 
            this.cb_Units.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_Units.FormattingEnabled = true;
            this.cb_Units.Items.AddRange(new object[] {
            "Seconds",
            "Minutes",
            "Hours"});
            this.cb_Units.Location = new System.Drawing.Point(102, 66);
            this.cb_Units.Name = "cb_Units";
            this.cb_Units.Size = new System.Drawing.Size(348, 21);
            this.cb_Units.TabIndex = 13;
            this.cb_Units.Tag = "";
            this.cb_Units.TextChanged += new System.EventHandler(this.value_Changed);
            // 
            // lbl_Units
            // 
            this.lbl_Units.AutoSize = true;
            this.lbl_Units.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Units.Location = new System.Drawing.Point(8, 63);
            this.lbl_Units.Name = "lbl_Units";
            this.lbl_Units.Size = new System.Drawing.Size(88, 29);
            this.lbl_Units.TabIndex = 14;
            this.lbl_Units.Text = "Units";
            this.lbl_Units.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 218);
            this.Controls.Add(this.tlp_UI);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mainForm";
            this.Text = "Backapp";
            this.tlp_UI.ResumeLayout(false);
            this.tlp_UI.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Frequency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Time)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp_UI;
        private System.Windows.Forms.Button btn_SearchFrom;
        private System.Windows.Forms.Button btn_SearchTo;
        private System.Windows.Forms.NumericUpDown nud_Time;
        private System.Windows.Forms.Label lbl_Time;
        private System.Windows.Forms.TextBox tb_From;
        private System.Windows.Forms.TextBox tb_To;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Label lbl_From;
        private System.Windows.Forms.Label lbl_To;
        private System.Windows.Forms.ProgressBar pb_CopyTime;
        private System.Windows.Forms.NumericUpDown nud_Frequency;
        private System.Windows.Forms.Label lbl_Frequency;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.CheckBox cb_Always;
        private System.Windows.Forms.ComboBox cb_Units;
        private System.Windows.Forms.Label lbl_Units;
    }
}