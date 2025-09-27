namespace FileBackApp
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tlp_UI = new System.Windows.Forms.TableLayoutPanel();
            this.nud_Time = new System.Windows.Forms.NumericUpDown();
            this.btn_SearchFrom = new System.Windows.Forms.Button();
            this.btn_SearchTo = new System.Windows.Forms.Button();
            this.lbl_To = new System.Windows.Forms.Label();
            this.lbl_From = new System.Windows.Forms.Label();
            this.cb_Units = new System.Windows.Forms.ComboBox();
            this.lbl_Time = new System.Windows.Forms.Label();
            this.cb_Overwrite = new System.Windows.Forms.CheckBox();
            this.rtb_Logs = new System.Windows.Forms.RichTextBox();
            this.pb_CopyTime = new System.Windows.Forms.ProgressBar();
            this.btn_Start = new System.Windows.Forms.Button();
            this.cb_Source = new System.Windows.Forms.ComboBox();
            this.cb_Directory = new System.Windows.Forms.ComboBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.t_File = new System.Windows.Forms.Timer(this.components);
            this.t_Progress = new System.Windows.Forms.Timer(this.components);
            this.tlp_UI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Time)).BeginInit();
            this.SuspendLayout();
            // 
            // tlp_UI
            // 
            this.tlp_UI.ColumnCount = 6;
            this.tlp_UI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlp_UI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlp_UI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlp_UI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlp_UI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlp_UI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 7F));
            this.tlp_UI.Controls.Add(this.nud_Time, 2, 3);
            this.tlp_UI.Controls.Add(this.btn_SearchFrom, 4, 1);
            this.tlp_UI.Controls.Add(this.btn_SearchTo, 4, 2);
            this.tlp_UI.Controls.Add(this.lbl_To, 1, 2);
            this.tlp_UI.Controls.Add(this.lbl_From, 1, 1);
            this.tlp_UI.Controls.Add(this.cb_Units, 3, 3);
            this.tlp_UI.Controls.Add(this.lbl_Time, 1, 3);
            this.tlp_UI.Controls.Add(this.cb_Overwrite, 1, 4);
            this.tlp_UI.Controls.Add(this.rtb_Logs, 2, 4);
            this.tlp_UI.Controls.Add(this.pb_CopyTime, 2, 6);
            this.tlp_UI.Controls.Add(this.btn_Start, 1, 6);
            this.tlp_UI.Controls.Add(this.cb_Source, 2, 1);
            this.tlp_UI.Controls.Add(this.cb_Directory, 2, 2);
            this.tlp_UI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_UI.Location = new System.Drawing.Point(0, 0);
            this.tlp_UI.Name = "tlp_UI";
            this.tlp_UI.RowCount = 8;
            this.tlp_UI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlp_UI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlp_UI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlp_UI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlp_UI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlp_UI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlp_UI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlp_UI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlp_UI.Size = new System.Drawing.Size(501, 186);
            this.tlp_UI.TabIndex = 0;
            // 
            // nud_Time
            // 
            this.nud_Time.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nud_Time.Location = new System.Drawing.Point(105, 66);
            this.nud_Time.Name = "nud_Time";
            this.nud_Time.Size = new System.Drawing.Size(165, 20);
            this.nud_Time.TabIndex = 4;
            this.nud_Time.ValueChanged += new System.EventHandler(this.value_Changed);
            // 
            // btn_SearchFrom
            // 
            this.btn_SearchFrom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_SearchFrom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SearchFrom.Location = new System.Drawing.Point(447, 8);
            this.btn_SearchFrom.Name = "btn_SearchFrom";
            this.btn_SearchFrom.Size = new System.Drawing.Size(42, 23);
            this.btn_SearchFrom.TabIndex = 1;
            this.btn_SearchFrom.Text = "···";
            this.btn_SearchFrom.UseVisualStyleBackColor = true;
            this.btn_SearchFrom.Click += new System.EventHandler(this.btn_SearchFrom_Click);
            // 
            // btn_SearchTo
            // 
            this.btn_SearchTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_SearchTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SearchTo.Location = new System.Drawing.Point(447, 37);
            this.btn_SearchTo.Name = "btn_SearchTo";
            this.btn_SearchTo.Size = new System.Drawing.Size(42, 23);
            this.btn_SearchTo.TabIndex = 3;
            this.btn_SearchTo.Text = "···";
            this.btn_SearchTo.UseVisualStyleBackColor = true;
            this.btn_SearchTo.Click += new System.EventHandler(this.btn_SearchTo_Click);
            // 
            // lbl_To
            // 
            this.lbl_To.AutoSize = true;
            this.lbl_To.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_To.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lbl_To.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_To.Location = new System.Drawing.Point(8, 34);
            this.lbl_To.Name = "lbl_To";
            this.lbl_To.Size = new System.Drawing.Size(91, 29);
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
            this.lbl_From.Size = new System.Drawing.Size(91, 29);
            this.lbl_From.TabIndex = 7;
            this.lbl_From.Text = "Directory";
            this.lbl_From.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cb_Units
            // 
            this.cb_Units.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_Units.FormattingEnabled = true;
            this.cb_Units.Items.AddRange(new object[] {
            "Seconds",
            "Minutes",
            "Hours"});
            this.cb_Units.Location = new System.Drawing.Point(276, 66);
            this.cb_Units.Name = "cb_Units";
            this.cb_Units.Size = new System.Drawing.Size(165, 21);
            this.cb_Units.TabIndex = 5;
            this.cb_Units.Tag = "";
            this.cb_Units.SelectedIndexChanged += new System.EventHandler(this.cb_Units_SelectedIndexChanged);
            this.cb_Units.TextChanged += new System.EventHandler(this.value_Changed);
            // 
            // lbl_Time
            // 
            this.lbl_Time.AutoSize = true;
            this.lbl_Time.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Time.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lbl_Time.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_Time.Location = new System.Drawing.Point(8, 63);
            this.lbl_Time.Name = "lbl_Time";
            this.lbl_Time.Size = new System.Drawing.Size(91, 29);
            this.lbl_Time.TabIndex = 3;
            this.lbl_Time.Text = "Time";
            this.lbl_Time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cb_Overwrite
            // 
            this.cb_Overwrite.AutoSize = true;
            this.cb_Overwrite.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cb_Overwrite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_Overwrite.Location = new System.Drawing.Point(8, 95);
            this.cb_Overwrite.Name = "cb_Overwrite";
            this.cb_Overwrite.Size = new System.Drawing.Size(91, 23);
            this.cb_Overwrite.TabIndex = 6;
            this.cb_Overwrite.Text = "Overwrite files";
            this.cb_Overwrite.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cb_Overwrite.UseVisualStyleBackColor = true;
            // 
            // rtb_Logs
            // 
            this.rtb_Logs.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tlp_UI.SetColumnSpan(this.rtb_Logs, 3);
            this.rtb_Logs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_Logs.Location = new System.Drawing.Point(105, 95);
            this.rtb_Logs.Name = "rtb_Logs";
            this.rtb_Logs.ReadOnly = true;
            this.tlp_UI.SetRowSpan(this.rtb_Logs, 2);
            this.rtb_Logs.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtb_Logs.Size = new System.Drawing.Size(384, 52);
            this.rtb_Logs.TabIndex = 15;
            this.rtb_Logs.Text = "";
            this.rtb_Logs.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtb_Logs_LinkClicked);
            // 
            // pb_CopyTime
            // 
            this.tlp_UI.SetColumnSpan(this.pb_CopyTime, 3);
            this.pb_CopyTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_CopyTime.Location = new System.Drawing.Point(105, 153);
            this.pb_CopyTime.Name = "pb_CopyTime";
            this.pb_CopyTime.Size = new System.Drawing.Size(384, 23);
            this.pb_CopyTime.Step = 1;
            this.pb_CopyTime.TabIndex = 9;
            // 
            // btn_Start
            // 
            this.btn_Start.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Start.Enabled = false;
            this.btn_Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Start.Location = new System.Drawing.Point(8, 153);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(91, 23);
            this.btn_Start.TabIndex = 7;
            this.btn_Start.Text = "Start loop";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // cb_Source
            // 
            this.tlp_UI.SetColumnSpan(this.cb_Source, 2);
            this.cb_Source.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_Source.FormattingEnabled = true;
            this.cb_Source.Location = new System.Drawing.Point(105, 8);
            this.cb_Source.Name = "cb_Source";
            this.cb_Source.Size = new System.Drawing.Size(336, 21);
            this.cb_Source.TabIndex = 0;
            // 
            // cb_Directory
            // 
            this.tlp_UI.SetColumnSpan(this.cb_Directory, 2);
            this.cb_Directory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_Directory.FormattingEnabled = true;
            this.cb_Directory.Location = new System.Drawing.Point(105, 37);
            this.cb_Directory.Name = "cb_Directory";
            this.cb_Directory.Size = new System.Drawing.Size(336, 21);
            this.cb_Directory.TabIndex = 2;
            // 
            // t_File
            // 
            this.t_File.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // t_Progress
            // 
            this.t_Progress.Interval = 1000;
            this.t_Progress.Tick += new System.EventHandler(this.t_Progress_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 186);
            this.Controls.Add(this.tlp_UI);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Backapp";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.tlp_UI.ResumeLayout(false);
            this.tlp_UI.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Time)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp_UI;
        private System.Windows.Forms.Button btn_SearchFrom;
        private System.Windows.Forms.Button btn_SearchTo;
        private System.Windows.Forms.NumericUpDown nud_Time;
        private System.Windows.Forms.Label lbl_Time;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Label lbl_From;
        private System.Windows.Forms.Label lbl_To;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Timer t_File;
        private System.Windows.Forms.RichTextBox rtb_Logs;
        private System.Windows.Forms.ProgressBar pb_CopyTime;
        private System.Windows.Forms.CheckBox cb_Overwrite;
        private System.Windows.Forms.Timer t_Progress;
        private System.Windows.Forms.ComboBox cb_Units;
        private System.Windows.Forms.ComboBox cb_Source;
        private System.Windows.Forms.ComboBox cb_Directory;
    }
}