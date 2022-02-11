using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// DI 적용
namespace WPF5_UI.Models
{
    class FileInfoStorage
    {
        private FileInfoClass _fileInfo;

        public FileInfoStorage(FileInfoClass fileinfo)
        {
            _fileInfo = fileinfo;
        }
    }
}
