using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileVersionDifferenceChecker.Core
{
    public class Difference
    {
        private string fileName;

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        private string version1;

        public string Version1
        {
            get { return version1; }
            set { version1 = value; }
        }

        private string version2;

        public string Version2
        {
            get { return version2; }
            set { version2 = value; }
        }

    }
}
