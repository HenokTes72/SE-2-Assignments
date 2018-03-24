/************************/
/* Author Henok Tesfaye */
/*  Xero Folder Locker  */
/************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
using System.Windows.Forms;

namespace XeroFolderLocker
{
    public partial class frmHome : Form
    {
        internal List<FileItem> selectedItems = new List<FileItem>();

        public frmHome() {
            InitializeComponent();
        }

        private void dataGridView1_DragEnter(object sender, DragEventArgs e) {
            string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            string status = "";
            foreach (string name in FileList) {
                if (!IsChoosedItemPreviouslySelected(name)) {
                    status = GetStatus(name);
                    this.selectedItems.Add(new FileItem(name, status));

                    if (status.Equals("locked")) {
                        RestrictPermission(name, AccessControlType.Allow);
                    }
                }
            }
            ResetAndUpdateEntry();
        }

        private void btnLockItems_Click(object sender, EventArgs e) {

            if(folderBrowseDialog1.ShowDialog() == DialogResult.OK) {
                DirectoryInfo d = new DirectoryInfo(folderBrowseDialog1.SelectedPath);
                string selectedPath = d.FullName;
                string status = "";
                if (!IsChoosedItemPreviouslySelected(selectedPath)) {
                    status = GetStatus(selectedPath);
                    this.selectedItems.Add(new FileItem(selectedPath, status));
                }
                ResetAndUpdateEntry();
            }

        }

        private void UpdateDataGridViewEntry() {
            foreach (FileItem fileItem in selectedItems) {
                this.dataGridView1.Rows.Add(fileItem.PathName, fileItem.Status);
            }
        }
        
        private void ResetEntryRows() {
            this.dataGridView1.Rows.Clear();
            this.dataGridView1.Refresh();
        }

        public void ResetAndUpdateEntry() {
            ResetEntryRows();
            UpdateDataGridViewEntry();
        }

        public bool IsChoosedItemPreviouslySelected(string pathName) {
            bool result = false;
            foreach(FileItem file in selectedItems) {
                if (file.PathName.Equals(pathName)) {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public string GetStatus(string pName) {
            string[] words = pName.Split('.');
            string status = (words[words.Length - 1].Equals("lock")) ? "locked" : "unlocked";
            return status;
        }

        /*private void btnSelectAll_Click(object sender, EventArgs e) {
            this.dataGridView1.SelectAll();
        }*/

        private void btnAddFile_Click(object sender, EventArgs e) {
            if (fileBrowseDialog1.ShowDialog() == DialogResult.OK) {
                DirectoryInfo d = new DirectoryInfo(fileBrowseDialog1.FileName);
                string selectedPath = d.FullName;
                string status = "";
                if (!IsChoosedItemPreviouslySelected(selectedPath)) {
                    status = GetStatus(selectedPath);
                    this.selectedItems.Add(new FileItem(selectedPath, status));
                }
                ResetAndUpdateEntry();
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e) {
            ShowAndFocus();
        }

        private void ShowAndFocus() {
            this.Show();
        }

        private void frmHome_Resize(object sender, EventArgs e) {
            if(FormWindowState.Minimized == this.WindowState) {
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(1000);
                this.Hide();
            }
            else if(FormWindowState.Normal == this.WindowState) {
                notifyIcon1.Visible = false;
            }
        }

        private void open_Click(object sender, EventArgs e) {
            ShowAndFocus();
        }

        private void about_Click(object sender, EventArgs e) {
            About about = new About();
            about.Show();
        }

        private void exit_Click(object sender, EventArgs e) {
            Application.Exit();
            notifyIcon1.Visible = false;
        }

        private void changePassword_Click(object sender, EventArgs e) {
            ChangePassword changePassword = new ChangePassword();
            changePassword.Show();
        }

        private void btnLock_Click(object sender, EventArgs e) {
            try {
                DataGridViewSelectedRowCollection selectedRows = this.dataGridView1.SelectedRows;
                int selectedRowNumber = selectedRows.Count;
                string path = "";
                string message = "";
                ArrayList array = new ArrayList();
                if(selectedRowNumber != 0) {
                    for(int i = 0; i < selectedRows.Count; i++) {
                        path = this.dataGridView1.Rows[selectedRows[i].Index].Cells[0].Value.ToString();
                        if (this.dataGridView1.Rows[selectedRows[i].Index].Cells[1].Value.ToString().Equals("unlocked")) {
                            string newFileName = path + ".lock";
                            RenameFile(path,newFileName,false);
                            message = "File Locked";
                            RestrictPermission(newFileName,AccessControlType.Deny);
                            array.Add(i);
                        }
                        else {
                            message = "Already Locked";
                        }
                    }
                    DeleteRowsFromThePreviouslySelectedFiles(array);
                    ResetAndUpdateEntry();
                    MessageBox.Show(message, "show message", MessageBoxButtons.OK);
                }
            }
            catch(Exception ex) {
                MessageBox.Show("Please select a full row","check index",MessageBoxButtons.OK);
            }
        }
        private string GetExtenstion(string pathName) {
            return Path.GetExtension(pathName);
        }

        private string ChangeFileExtenstion(string pathName,string ext) {
            FileInfo f = new FileInfo(pathName);
            f.MoveTo(Path.ChangeExtension(pathName, ext));
            return ext;
        }
        private void RestrictPermission(string pName,AccessControlType access) {
            FileSecurity fileSecurity = File.GetAccessControl(pName);
            if(access == AccessControlType.Deny) {
                fileSecurity.AddAccessRule(new FileSystemAccessRule(Environment.UserName, FileSystemRights.FullControl, AccessControlType.Deny));
            }
            else if(access == AccessControlType.Allow){
                fileSecurity.RemoveAccessRule(new FileSystemAccessRule(Environment.UserName, FileSystemRights.FullControl, AccessControlType.Deny));
            }
            File.SetAccessControl(pName, fileSecurity);
        }
        private void RenameFile(string pathName,string newFileName,bool concat) {
            string dest = "";
            if (concat) {
                dest = pathName + newFileName;
            }
            else {
                dest = newFileName;
            }
            System.IO.File.Move(pathName, dest);
        }

        private void btnUnlock_Click(object sender, EventArgs e) {
            try {
                DataGridViewSelectedRowCollection selectedRows = this.dataGridView1.SelectedRows;
                int selectedRowNumber = selectedRows.Count;
                string path = "";
                string message = "";
                ArrayList array = new ArrayList();
                if (selectedRowNumber != 0) {
                    for (int i = 0; i < selectedRows.Count; i++) {
                        path = this.dataGridView1.Rows[selectedRows[i].Index].Cells[0].Value.ToString();
                        if (this.dataGridView1.Rows[selectedRows[i].Index].Cells[1].Value.ToString().Equals("locked")) {
                            RestrictPermission(path, AccessControlType.Allow);
                            string[] oldFileTokens = path.Split('\\');
                            string oldFileNameTokens = oldFileTokens[oldFileTokens.Length - 1];
                            string fileName = path.Substring(0,path.Length-(oldFileTokens[oldFileTokens.Length-1].Length))+ oldFileNameTokens.Substring(0,oldFileNameTokens.Length-(".lock".Length));
                            array.Add(i);
                            RenameFile(path, fileName,false);
                            message = selectedRowNumber + "File unlocked";
                        }
                        else {
                            message = "File already unlocked";
                        }
                        //this is not a better way, since the order does not keep the previous values.
                        //this.selectedItems.RemoveAt(i);
                        //this.dataGridView1.Rows
                    }
                    DeleteRowsFromThePreviouslySelectedFiles(array);
                    ResetAndUpdateEntry();
                    MessageBox.Show(message, "show message", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "check index", MessageBoxButtons.OK);
            }
        }

        private void DeleteRowsFromThePreviouslySelectedFiles(ArrayList arrayList) {
            int deleteRowCounter = 0;
            for(int j = 0; j < arrayList.Count; j++) {
                this.selectedItems.RemoveAt((int)arrayList[j] - deleteRowCounter);
                deleteRowCounter += 1;
            }
        }

        private void btnUnlockALl_Click(object sender, EventArgs e) {
            try {
                DataGridViewSelectedRowCollection selectedRows = this.dataGridView1.SelectedRows;
                int selectedRowNumber = selectedRows.Count;
                string path = "";
                string message = "";
                ArrayList array = new ArrayList();
                if(selectedRowNumber != 0) {
                    for(int i = 0; i < selectedRows.Count; i++) {
                        path = this.dataGridView1.Rows[selectedRows[i].Index].Cells[0].Value.ToString();
                        if (this.dataGridView1.Rows[selectedRows[i].Index].Cells[1].Value.ToString().Equals("unlocked")) {
                            string newFileName = path+ ".{5ea4f148-308c-46d7-98a9-49041b1dd468}";
                            //RenameFile(path,newFileName,false);
                            message = "File Locked";
                            RenameDirectory(path, newFileName);
                            //ChangeFolderPermssion(newFileName,AccessControlType.Deny);
                            //array.Add(i);
                        }
                        else {
                            message = "Already Locked";
                        }
                    }
                   // DeleteRowsFromThePreviouslySelectedFiles(array);
                   // ResetAndUpdateEntry();
                    MessageBox.Show(message, "show message", MessageBoxButtons.OK);
                }
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message,"check index",MessageBoxButtons.OK);
            }
        }
        private void RenameDirectory(string src,string dest) {
            Directory.Move(src, dest);
        }
        private void ChangeFolderPermssion(string path,AccessControlType access) {
            DirectoryInfo dinfo = new DirectoryInfo(path);
            DirectorySecurity dSecurity = dinfo.GetAccessControl();
            if(access == AccessControlType.Deny) {
                dSecurity.AddAccessRule(new FileSystemAccessRule(Environment.UserName, FileSystemRights.FullControl, AccessControlType.Deny));
            }
            else if(access == AccessControlType.Allow) {
                dSecurity.RemoveAccessRule(new FileSystemAccessRule(Environment.UserName, FileSystemRights.FullControl, AccessControlType.Deny));
            }
            dinfo.SetAccessControl(dSecurity);
        }
    }
}
