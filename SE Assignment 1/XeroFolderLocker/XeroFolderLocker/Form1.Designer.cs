using System.Windows.Forms;

namespace XeroFolderLocker
{
    partial class frmHome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHome));
            this.folderBrowseDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.fileBrowseDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnLockFolders = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLock = new System.Windows.Forms.Button();
            this.btnUnlockALl = new System.Windows.Forms.Button();
            this.btnUnlock = new System.Windows.Forms.Button();
            this.btnAddFile = new System.Windows.Forms.Button();
            this.btnAddFolder = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenu = new System.Windows.Forms.ContextMenu();
            this.open = new System.Windows.Forms.MenuItem();
            this.about = new System.Windows.Forms.MenuItem();
            this.changePassword = new System.Windows.Forms.MenuItem();
            this.exit = new System.Windows.Forms.MenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.btnLockFolders);
            this.groupBox1.Location = new System.Drawing.Point(-3, 84);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 378);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::XeroFolderLocker.Properties.Resources.Capture3;
            this.pictureBox2.Location = new System.Drawing.Point(2, 208);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(227, 160);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button4.Location = new System.Drawing.Point(0, 139);
            this.button4.Margin = new System.Windows.Forms.Padding(0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(227, 69);
            this.button4.TabIndex = 2;
            this.button4.Text = "Secure Backup";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button3.Location = new System.Drawing.Point(0, 70);
            this.button3.Margin = new System.Windows.Forms.Padding(0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(227, 69);
            this.button3.TabIndex = 1;
            this.button3.Text = "Encrypt Files";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnLockFolders
            // 
            this.btnLockFolders.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnLockFolders.Location = new System.Drawing.Point(0, 7);
            this.btnLockFolders.Margin = new System.Windows.Forms.Padding(0);
            this.btnLockFolders.Name = "btnLockFolders";
            this.btnLockFolders.Size = new System.Drawing.Size(227, 63);
            this.btnLockFolders.TabIndex = 0;
            this.btnLockFolders.Text = "Lock Folders";
            this.btnLockFolders.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnLock);
            this.groupBox2.Controls.Add(this.btnUnlockALl);
            this.groupBox2.Controls.Add(this.btnUnlock);
            this.groupBox2.Controls.Add(this.btnAddFile);
            this.groupBox2.Controls.Add(this.btnAddFolder);
            this.groupBox2.Location = new System.Drawing.Point(230, 84);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(504, 70);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // btnLock
            // 
            this.btnLock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLock.Location = new System.Drawing.Point(346, 7);
            this.btnLock.Margin = new System.Windows.Forms.Padding(0);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(159, 63);
            this.btnLock.TabIndex = 4;
            this.btnLock.Text = "Lock";
            this.btnLock.UseVisualStyleBackColor = true;
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
            // 
            // btnUnlockALl
            // 
            this.btnUnlockALl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnlockALl.Location = new System.Drawing.Point(258, 7);
            this.btnUnlockALl.Margin = new System.Windows.Forms.Padding(0);
            this.btnUnlockALl.Name = "btnUnlockALl";
            this.btnUnlockALl.Size = new System.Drawing.Size(88, 63);
            this.btnUnlockALl.TabIndex = 3;
            this.btnUnlockALl.Text = "   Unlock      All";
            this.btnUnlockALl.UseVisualStyleBackColor = true;
            this.btnUnlockALl.Click += new System.EventHandler(this.btnUnlockALl_Click);
            // 
            // btnUnlock
            // 
            this.btnUnlock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnlock.Location = new System.Drawing.Point(170, 7);
            this.btnUnlock.Margin = new System.Windows.Forms.Padding(0);
            this.btnUnlock.Name = "btnUnlock";
            this.btnUnlock.Size = new System.Drawing.Size(88, 63);
            this.btnUnlock.TabIndex = 2;
            this.btnUnlock.Text = "Unlock";
            this.btnUnlock.UseVisualStyleBackColor = true;
            this.btnUnlock.Click += new System.EventHandler(this.btnUnlock_Click);
            // 
            // btnAddFile
            // 
            this.btnAddFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFile.Location = new System.Drawing.Point(82, 7);
            this.btnAddFile.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(88, 63);
            this.btnAddFile.TabIndex = 1;
            this.btnAddFile.Text = "Add Files To Lock";
            this.btnAddFile.UseVisualStyleBackColor = true;
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // btnAddFolder
            // 
            this.btnAddFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFolder.Location = new System.Drawing.Point(0, 7);
            this.btnAddFolder.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddFolder.Name = "btnAddFolder";
            this.btnAddFolder.Size = new System.Drawing.Size(82, 63);
            this.btnAddFolder.TabIndex = 0;
            this.btnAddFolder.Text = "Add Folders";
            this.btnAddFolder.UseVisualStyleBackColor = true;
            this.btnAddFolder.Click += new System.EventHandler(this.btnLockItems_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeight = 30;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView1.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.dataGridView1.Location = new System.Drawing.Point(230, 158);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 50;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.RowTemplate.ReadOnly = true;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.Size = new System.Drawing.Size(504, 294);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragEnter);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Items";
            this.Column1.Name = "Column1";
            this.Column1.Width = 320;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Status";
            this.Column2.Name = "Column2";
            this.Column2.Width = 132;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::XeroFolderLocker.Properties.Resources.Capture;
            this.pictureBox1.Location = new System.Drawing.Point(-3, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(738, 79);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Lock your files and folders in seconds.";
            this.notifyIcon1.BalloonTipTitle = "Xero Folder Locker";
            this.notifyIcon1.ContextMenu = this.contextMenu;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Xero Folder Lock";
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenu
            // 
            this.contextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.open,
            this.about,
            this.changePassword,
            this.exit});
            // 
            // open
            // 
            this.open.Index = 0;
            this.open.Text = "Open";
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // about
            // 
            this.about.Index = 1;
            this.about.Text = "About";
            this.about.Click += new System.EventHandler(this.about_Click);
            // 
            // changePassword
            // 
            this.changePassword.Index = 2;
            this.changePassword.Text = "Change Password";
            this.changePassword.Click += new System.EventHandler(this.changePassword_Click);
            // 
            // exit
            // 
            this.exit.Index = 3;
            this.exit.Text = "Exit";
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // frmHome
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 452);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Folder Locker";
            this.Resize += new System.EventHandler(this.frmHome_Resize);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenu contextMenu;
        private System.Windows.Forms.MenuItem open;
        private System.Windows.Forms.MenuItem about;
        private System.Windows.Forms.MenuItem exit;
        private System.Windows.Forms.MenuItem changePassword;
        private System.Windows.Forms.FolderBrowserDialog folderBrowseDialog1;
        private System.Windows.Forms.OpenFileDialog fileBrowseDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnLockFolders;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnLock;
        private System.Windows.Forms.Button btnUnlockALl;
        private System.Windows.Forms.Button btnUnlock;
        private System.Windows.Forms.Button btnAddFile;
        private System.Windows.Forms.Button btnAddFolder;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        public System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

