using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebDriverIntro
{
    class StatusWriter
    {
        public void WriteStatus(string ID, string name, string status)
        {
            //StreamReader filereader = new StreamReader(@"D:\testResults.txt");
            string path = @"D:\testResults.txt";
            string text = "";
            text = String.Format("Test ID - {0}; Name - {1}; Status - {2}", ID, name, status);

            if (File.Exists(path))
            {
                File.WriteAllText(path, text);
            }
        }

        public void CleanFile()
        {
            
        }
    }
}
