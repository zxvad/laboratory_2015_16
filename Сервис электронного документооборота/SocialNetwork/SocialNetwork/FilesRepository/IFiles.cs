using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.FilesRepository
{
    interface IFiles
    {
        void AddFile(int id_file);
        void DeleteFile(int id_file);
        void AutoFileDocx(int id_file);

      
    }
}
