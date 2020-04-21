using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaIntegrator
{
    class FileWatch
    {
        public void fileWatch(string folderPath)
        {
            FileSystemWatcher fw = new FileSystemWatcher();
            fw.Path = folderPath;
            fw.Filter = "*.txt";
            fw.NotifyFilter = NotifyFilters.LastWrite;
            fw.Created += new FileSystemEventHandler(fileUpdate);
            fw.Changed += new FileSystemEventHandler(fileUpdate);
            fw.EnableRaisingEvents = true;

        }

        private void fileUpdate(object s, FileSystemEventArgs e)
        {
            Console.WriteLine("yes!");
        }
    }
}
