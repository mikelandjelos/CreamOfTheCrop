using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SoftverskiProjekat
{
    class DirectoryInfo
    {
        private static DirectoryInfo instance;
        public string currentPath;
        public string directoryName;
        public string[] currentFiles;

        private DirectoryInfo()
        {
            currentPath = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            directoryName = Path.GetDirectoryName(currentPath);
            currentFiles = Directory.GetFiles(directoryName, "*.xml");
            for (int i = 0; i < currentFiles.Length; i++) {
                currentFiles[i] = Path.GetFileName(currentFiles[i]);
            }
        }

        public static DirectoryInfo Instance() {
            if (instance == null)
                instance = new DirectoryInfo();
            return instance;
        }
    }
}
