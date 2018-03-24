using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XeroFolderLocker
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args) {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmHome frm = new frmHome();

            string status = "";
            foreach(string pathName in args) {
                if (!frm.IsChoosedItemPreviouslySelected(pathName)) {
                    status = frm.GetStatus(pathName);
                    frm.selectedItems.Add(new FileItem(pathName, status));
                }
            }
            frm.ResetAndUpdateEntry();
            Application.Run(frm);
            //Application.Run(new );
        }
    }
}
