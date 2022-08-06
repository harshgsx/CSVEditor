
namespace CSVEditor
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ofdLoadFile = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbLoading = new System.Windows.Forms.PictureBox();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.cbDropdown = new System.Windows.Forms.ComboBox();
            this.btnStringReplace = new System.Windows.Forms.Button();
            this.lblFileName = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoadfile = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ofdLoadFile
            // 
            this.ofdLoadFile.FileName = "ofdLoadFile";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(985, 450);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.pbLoading);
            this.panel2.Controls.Add(this.btnSaveAs);
            this.panel2.Controls.Add(this.cbDropdown);
            this.panel2.Controls.Add(this.btnStringReplace);
            this.panel2.Controls.Add(this.lblFileName);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnLoadfile);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(985, 450);
            this.panel2.TabIndex = 0;
            // 
            // pbLoading
            // 
            this.pbLoading.Image = global::CSVEditor.Properties.Resources.loading;
            this.pbLoading.Location = new System.Drawing.Point(319, 176);
            this.pbLoading.Name = "pbLoading";
            this.pbLoading.Size = new System.Drawing.Size(382, 250);
            this.pbLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLoading.TabIndex = 7;
            this.pbLoading.TabStop = false;
            this.pbLoading.Visible = false;
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAs.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSaveAs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSaveAs.Location = new System.Drawing.Point(869, 56);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(104, 44);
            this.btnSaveAs.TabIndex = 6;
            this.btnSaveAs.Text = "Save As";
            this.btnSaveAs.UseVisualStyleBackColor = true;
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // cbDropdown
            // 
            this.cbDropdown.FormattingEnabled = true;
            this.cbDropdown.Location = new System.Drawing.Point(13, 73);
            this.cbDropdown.Name = "cbDropdown";
            this.cbDropdown.Size = new System.Drawing.Size(215, 24);
            this.cbDropdown.TabIndex = 5;
            // 
            // btnStringReplace
            // 
            this.btnStringReplace.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnStringReplace.Location = new System.Drawing.Point(369, 67);
            this.btnStringReplace.Name = "btnStringReplace";
            this.btnStringReplace.Size = new System.Drawing.Size(300, 35);
            this.btnStringReplace.TabIndex = 4;
            this.btnStringReplace.Text = "Replace \'a\' with \'@\' on selected cell(s)";
            this.btnStringReplace.UseVisualStyleBackColor = true;
            this.btnStringReplace.Click += new System.EventHandler(this.btnStringReplace_Click);
            // 
            // lblFileName
            // 
            this.lblFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(407, 22);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(42, 17);
            this.lblFileName.TabIndex = 3;
            this.lblFileName.Text = "File : ";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.BackgroundImage = global::CSVEditor.Properties.Resources.save;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.Location = new System.Drawing.Point(815, 56);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(48, 46);
            this.btnSave.TabIndex = 2;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSaveCliked);
            // 
            // btnLoadfile
            // 
            this.btnLoadfile.BackgroundImage = global::CSVEditor.Properties.Resources.open;
            this.btnLoadfile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLoadfile.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnLoadfile.Location = new System.Drawing.Point(12, 12);
            this.btnLoadfile.Name = "btnLoadfile";
            this.btnLoadfile.Size = new System.Drawing.Size(43, 38);
            this.btnLoadfile.TabIndex = 1;
            this.btnLoadfile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadfile.UseVisualStyleBackColor = true;
            this.btnLoadfile.Click += new System.EventHandler(this.btnLoadfile_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 117);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(985, 333);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.VirtualMode = true;
            this.dataGridView1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellMouseEnter);
            this.dataGridView1.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellMouseEnter);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 450);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "CSVEditor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdLoadFile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbDropdown;
        private System.Windows.Forms.Button btnStringReplace;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoadfile;
        private System.Windows.Forms.Button btnSaveAs;
        private System.Windows.Forms.PictureBox pbLoading;
        public System.Windows.Forms.DataGridView dataGridView1;
    }
}

