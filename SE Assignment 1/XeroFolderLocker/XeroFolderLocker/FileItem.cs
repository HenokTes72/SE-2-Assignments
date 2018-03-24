using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeroFolderLocker
{
    class FileItem
    {
        public string PathName { get; set; }
        public string Status { get; set; }

        public FileItem (string pName,string stat) {
            this.PathName = pName;
            this.Status = stat;
        }
    }
}
