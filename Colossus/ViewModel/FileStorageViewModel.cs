using Colossus.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colossus.ViewModel
{
    public class FileStorageViewModel
    {
        //string _FilePath;

        public int Id { get; set; }
        public string FolderName { get; set; }
        public string ParentFolderName { get; set; }
        public string FilePath { get; set; }        
        public DateTime FileCreationDate { get; set; }
    }
}
