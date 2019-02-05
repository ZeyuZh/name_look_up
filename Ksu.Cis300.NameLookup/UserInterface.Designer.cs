namespace Ksu.Cis300.NameLookup
{
    partial class UserInterface
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
            this.uxRank = new System.Windows.Forms.TextBox();
            this.uxRankLabel = new System.Windows.Forms.Label();
            this.uxFrequency = new System.Windows.Forms.TextBox();
            this.uxFrequencyLabel = new System.Windows.Forms.Label();
            this.uxLookup = new System.Windows.Forms.Button();
            this.uxName = new System.Windows.Forms.TextBox();
            this.uxNameLabel = new System.Windows.Forms.Label();
            this.uxOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.uxSaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.uxFileMenu = new System.Windows.Forms.MenuStrip();
            this.uxMenuBar = new System.Windows.Forms.ToolStripMenuItem();
            this.uxOpenRawData = new System.Windows.Forms.ToolStripMenuItem();
            this.uxOpenHashTable = new System.Windows.Forms.ToolStripMenuItem();
            this.uxSaveHashTable = new System.Windows.Forms.ToolStripMenuItem();
            this.uxOpenTableDialog = new System.Windows.Forms.OpenFileDialog();
            this.uxFileMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxRank
            // 
            this.uxRank.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxRank.Location = new System.Drawing.Point(76, 153);
            this.uxRank.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uxRank.Name = "uxRank";
            this.uxRank.ReadOnly = true;
            this.uxRank.Size = new System.Drawing.Size(281, 29);
            this.uxRank.TabIndex = 30;
            this.uxRank.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // uxRankLabel
            // 
            this.uxRankLabel.AutoSize = true;
            this.uxRankLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxRankLabel.Location = new System.Drawing.Point(12, 153);
            this.uxRankLabel.Name = "uxRankLabel";
            this.uxRankLabel.Size = new System.Drawing.Size(58, 24);
            this.uxRankLabel.TabIndex = 29;
            this.uxRankLabel.Text = "Rank:";
            // 
            // uxFrequency
            // 
            this.uxFrequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxFrequency.Location = new System.Drawing.Point(123, 117);
            this.uxFrequency.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uxFrequency.Name = "uxFrequency";
            this.uxFrequency.ReadOnly = true;
            this.uxFrequency.Size = new System.Drawing.Size(234, 29);
            this.uxFrequency.TabIndex = 28;
            this.uxFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // uxFrequencyLabel
            // 
            this.uxFrequencyLabel.AutoSize = true;
            this.uxFrequencyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxFrequencyLabel.Location = new System.Drawing.Point(12, 113);
            this.uxFrequencyLabel.Name = "uxFrequencyLabel";
            this.uxFrequencyLabel.Size = new System.Drawing.Size(107, 24);
            this.uxFrequencyLabel.TabIndex = 27;
            this.uxFrequencyLabel.Text = "Frequency:";
            // 
            // uxLookup
            // 
            this.uxLookup.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxLookup.Location = new System.Drawing.Point(16, 62);
            this.uxLookup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uxLookup.Name = "uxLookup";
            this.uxLookup.Size = new System.Drawing.Size(341, 47);
            this.uxLookup.TabIndex = 26;
            this.uxLookup.Text = "Get Statistics";
            this.uxLookup.UseVisualStyleBackColor = true;
            this.uxLookup.Click += new System.EventHandler(this.uxLookup_Click);
            // 
            // uxName
            // 
            this.uxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxName.Location = new System.Drawing.Point(75, 25);
            this.uxName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uxName.Name = "uxName";
            this.uxName.Size = new System.Drawing.Size(282, 29);
            this.uxName.TabIndex = 25;
            // 
            // uxNameLabel
            // 
            this.uxNameLabel.AutoSize = true;
            this.uxNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxNameLabel.Location = new System.Drawing.Point(12, 25);
            this.uxNameLabel.Name = "uxNameLabel";
            this.uxNameLabel.Size = new System.Drawing.Size(66, 24);
            this.uxNameLabel.TabIndex = 24;
            this.uxNameLabel.Text = "Name:";
            // 
            // uxOpenDialog
            // 
            this.uxOpenDialog.Filter = "text files|*.txt|All files|*.*";
            this.uxOpenDialog.Title = "Open Raw Data File";
            // 
            // uxSaveDialog
            // 
            this.uxSaveDialog.Filter = "hash table files|*.ht|All files|*.*";
            this.uxSaveDialog.Title = "Save Hash Table";
            // 
            // uxFileMenu
            // 
            this.uxFileMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxMenuBar});
            this.uxFileMenu.Location = new System.Drawing.Point(0, 0);
            this.uxFileMenu.Name = "uxFileMenu";
            this.uxFileMenu.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.uxFileMenu.Size = new System.Drawing.Size(368, 25);
            this.uxFileMenu.TabIndex = 34;
            this.uxFileMenu.Text = "menuStrip1";
            // 
            // uxMenuBar
            // 
            this.uxMenuBar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxOpenRawData,
            this.uxOpenHashTable,
            this.uxSaveHashTable});
            this.uxMenuBar.Name = "uxMenuBar";
            this.uxMenuBar.Size = new System.Drawing.Size(39, 21);
            this.uxMenuBar.Text = "File";
            // 
            // uxOpenRawData
            // 
            this.uxOpenRawData.Name = "uxOpenRawData";
            this.uxOpenRawData.Size = new System.Drawing.Size(184, 22);
            this.uxOpenRawData.Text = "Open raw data file";
            this.uxOpenRawData.Click += new System.EventHandler(this.uxOpenRawData_Click);
            // 
            // uxOpenHashTable
            // 
            this.uxOpenHashTable.Name = "uxOpenHashTable";
            this.uxOpenHashTable.Size = new System.Drawing.Size(184, 22);
            this.uxOpenHashTable.Text = "Open hash table";
            this.uxOpenHashTable.Click += new System.EventHandler(this.uxOpenHashTable_Click);
            // 
            // uxSaveHashTable
            // 
            this.uxSaveHashTable.Enabled = false;
            this.uxSaveHashTable.Name = "uxSaveHashTable";
            this.uxSaveHashTable.Size = new System.Drawing.Size(184, 22);
            this.uxSaveHashTable.Text = "Save hash table";
            this.uxSaveHashTable.Click += new System.EventHandler(this.uxSaveHashTable_Click);
            // 
            // uxOpenTableDialog
            // 
            this.uxOpenTableDialog.FileName = "openFileDialog1";
            this.uxOpenTableDialog.Filter = "hash table files|*.ht|All files|*.*";
            this.uxOpenTableDialog.Title = "Open Hash Table";
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 215);
            this.Controls.Add(this.uxRank);
            this.Controls.Add(this.uxRankLabel);
            this.Controls.Add(this.uxFrequency);
            this.Controls.Add(this.uxFrequencyLabel);
            this.Controls.Add(this.uxLookup);
            this.Controls.Add(this.uxName);
            this.Controls.Add(this.uxNameLabel);
            this.Controls.Add(this.uxFileMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.uxFileMenu;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "UserInterface";
            this.Text = "Name Lookup";
            this.uxFileMenu.ResumeLayout(false);
            this.uxFileMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox uxRank;
        private System.Windows.Forms.Label uxRankLabel;
        private System.Windows.Forms.TextBox uxFrequency;
        private System.Windows.Forms.Label uxFrequencyLabel;
        private System.Windows.Forms.Button uxLookup;
        private System.Windows.Forms.TextBox uxName;
        private System.Windows.Forms.Label uxNameLabel;
        private System.Windows.Forms.OpenFileDialog uxOpenDialog;
        private System.Windows.Forms.SaveFileDialog uxSaveDialog;
        private System.Windows.Forms.MenuStrip uxFileMenu;
        private System.Windows.Forms.ToolStripMenuItem uxMenuBar;
        private System.Windows.Forms.ToolStripMenuItem uxOpenRawData;
        private System.Windows.Forms.ToolStripMenuItem uxOpenHashTable;
        private System.Windows.Forms.ToolStripMenuItem uxSaveHashTable;
        private System.Windows.Forms.OpenFileDialog uxOpenTableDialog;
    }
}

