namespace VideoTimer
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
            this.btnParseList1 = new System.Windows.Forms.Button();
            this.dataGridPlaylist1 = new System.Windows.Forms.DataGridView();
            this.openPlaylistDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnSelectPlaylist1 = new System.Windows.Forms.Button();
            this.textBoxPlaylist1File = new System.Windows.Forms.TextBox();
            this.groupBoxPlaylist1 = new System.Windows.Forms.GroupBox();
            this.groupBoxPlaylist2 = new System.Windows.Forms.GroupBox();
            this.dataGridPlaylist2 = new System.Windows.Forms.DataGridView();
            this.textBoxPlaylist2File = new System.Windows.Forms.TextBox();
            this.btnSelectPlaylist2 = new System.Windows.Forms.Button();
            this.btnParseList2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPlaylist1)).BeginInit();
            this.groupBoxPlaylist1.SuspendLayout();
            this.groupBoxPlaylist2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPlaylist2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnParseList1
            // 
            this.btnParseList1.Location = new System.Drawing.Point(99, 38);
            this.btnParseList1.Name = "btnParseList1";
            this.btnParseList1.Size = new System.Drawing.Size(96, 23);
            this.btnParseList1.TabIndex = 0;
            this.btnParseList1.Text = "Parse playlist 1";
            this.btnParseList1.UseVisualStyleBackColor = true;
            this.btnParseList1.Click += new System.EventHandler(this.btnParseList1_Click);
            // 
            // dataGridPlaylist1
            // 
            this.dataGridPlaylist1.AllowUserToAddRows = false;
            this.dataGridPlaylist1.AllowUserToDeleteRows = false;
            this.dataGridPlaylist1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPlaylist1.Location = new System.Drawing.Point(6, 19);
            this.dataGridPlaylist1.Name = "dataGridPlaylist1";
            this.dataGridPlaylist1.ReadOnly = true;
            this.dataGridPlaylist1.Size = new System.Drawing.Size(769, 601);
            this.dataGridPlaylist1.TabIndex = 1;
            // 
            // openPlaylistDialog
            // 
            this.openPlaylistDialog.FileName = "openFileDialog1";
            // 
            // btnSelectPlaylist1
            // 
            this.btnSelectPlaylist1.Location = new System.Drawing.Point(18, 38);
            this.btnSelectPlaylist1.Name = "btnSelectPlaylist1";
            this.btnSelectPlaylist1.Size = new System.Drawing.Size(75, 23);
            this.btnSelectPlaylist1.TabIndex = 2;
            this.btnSelectPlaylist1.Text = "Select File";
            this.btnSelectPlaylist1.UseVisualStyleBackColor = true;
            this.btnSelectPlaylist1.Click += new System.EventHandler(this.btnSelectPlaylist1_Click);
            // 
            // textBoxPlaylist1File
            // 
            this.textBoxPlaylist1File.Location = new System.Drawing.Point(12, 12);
            this.textBoxPlaylist1File.Name = "textBoxPlaylist1File";
            this.textBoxPlaylist1File.Size = new System.Drawing.Size(368, 20);
            this.textBoxPlaylist1File.TabIndex = 3;
            // 
            // groupBoxPlaylist1
            // 
            this.groupBoxPlaylist1.Controls.Add(this.dataGridPlaylist1);
            this.groupBoxPlaylist1.Location = new System.Drawing.Point(12, 67);
            this.groupBoxPlaylist1.Name = "groupBoxPlaylist1";
            this.groupBoxPlaylist1.Size = new System.Drawing.Size(781, 626);
            this.groupBoxPlaylist1.TabIndex = 4;
            this.groupBoxPlaylist1.TabStop = false;
            this.groupBoxPlaylist1.Text = "Playlist 1";
            // 
            // groupBoxPlaylist2
            // 
            this.groupBoxPlaylist2.Controls.Add(this.dataGridPlaylist2);
            this.groupBoxPlaylist2.Location = new System.Drawing.Point(817, 67);
            this.groupBoxPlaylist2.Name = "groupBoxPlaylist2";
            this.groupBoxPlaylist2.Size = new System.Drawing.Size(780, 626);
            this.groupBoxPlaylist2.TabIndex = 8;
            this.groupBoxPlaylist2.TabStop = false;
            this.groupBoxPlaylist2.Text = "Playlist 2";
            // 
            // dataGridPlaylist2
            // 
            this.dataGridPlaylist2.AllowUserToAddRows = false;
            this.dataGridPlaylist2.AllowUserToDeleteRows = false;
            this.dataGridPlaylist2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPlaylist2.Location = new System.Drawing.Point(12, 15);
            this.dataGridPlaylist2.Name = "dataGridPlaylist2";
            this.dataGridPlaylist2.ReadOnly = true;
            this.dataGridPlaylist2.Size = new System.Drawing.Size(762, 605);
            this.dataGridPlaylist2.TabIndex = 1;
            // 
            // textBoxPlaylist2File
            // 
            this.textBoxPlaylist2File.Location = new System.Drawing.Point(829, 12);
            this.textBoxPlaylist2File.Name = "textBoxPlaylist2File";
            this.textBoxPlaylist2File.Size = new System.Drawing.Size(368, 20);
            this.textBoxPlaylist2File.TabIndex = 7;
            // 
            // btnSelectPlaylist2
            // 
            this.btnSelectPlaylist2.Location = new System.Drawing.Point(829, 38);
            this.btnSelectPlaylist2.Name = "btnSelectPlaylist2";
            this.btnSelectPlaylist2.Size = new System.Drawing.Size(75, 23);
            this.btnSelectPlaylist2.TabIndex = 6;
            this.btnSelectPlaylist2.Text = "Select File";
            this.btnSelectPlaylist2.UseVisualStyleBackColor = true;
            this.btnSelectPlaylist2.Click += new System.EventHandler(this.btnSelectPlaylist2_Click);
            // 
            // btnParseList2
            // 
            this.btnParseList2.Location = new System.Drawing.Point(910, 38);
            this.btnParseList2.Name = "btnParseList2";
            this.btnParseList2.Size = new System.Drawing.Size(96, 23);
            this.btnParseList2.TabIndex = 5;
            this.btnParseList2.Text = "Parse playlist 2";
            this.btnParseList2.UseVisualStyleBackColor = true;
            this.btnParseList2.Click += new System.EventHandler(this.btnParseList2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1609, 705);
            this.Controls.Add(this.groupBoxPlaylist2);
            this.Controls.Add(this.textBoxPlaylist2File);
            this.Controls.Add(this.btnSelectPlaylist2);
            this.Controls.Add(this.btnParseList2);
            this.Controls.Add(this.groupBoxPlaylist1);
            this.Controls.Add(this.textBoxPlaylist1File);
            this.Controls.Add(this.btnSelectPlaylist1);
            this.Controls.Add(this.btnParseList1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPlaylist1)).EndInit();
            this.groupBoxPlaylist1.ResumeLayout(false);
            this.groupBoxPlaylist2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPlaylist2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnParseList1;
        private System.Windows.Forms.DataGridView dataGridPlaylist1;
        private System.Windows.Forms.OpenFileDialog openPlaylistDialog;
        private System.Windows.Forms.Button btnSelectPlaylist1;
        private System.Windows.Forms.TextBox textBoxPlaylist1File;
        private System.Windows.Forms.GroupBox groupBoxPlaylist1;
        private System.Windows.Forms.GroupBox groupBoxPlaylist2;
        private System.Windows.Forms.DataGridView dataGridPlaylist2;
        private System.Windows.Forms.TextBox textBoxPlaylist2File;
        private System.Windows.Forms.Button btnSelectPlaylist2;
        private System.Windows.Forms.Button btnParseList2;
    }
}

