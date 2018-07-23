using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileVersionDifferenceChecker.Core
{
    public static class FileDifferenceChecker
    {
        public static ObservableCollection<Difference> GetFileVersionDifferences(string filePath1, string filePath2)
        {
            Dictionary<string, string> fileVersions1 = new Dictionary<string, string>();
            ObservableCollection<Difference> differences = new ObservableCollection<Difference>();

            //string filePath1 = @"C:\WSO\WSOComponents\Legacy";
            //string filePath2 = @"C:\Git\WSOSoftware\WSOClient\Source\Legacy\WSO11-1\WSO\wsDistribution\Components";

            var files1 = Directory.GetFiles(filePath1);
            var files2 = Directory.GetFiles(filePath2);

            foreach (var file in files1)
            {
                var info = FileVersionInfo.GetVersionInfo(file);
                fileVersions1.Add(Path.GetFileName(info.FileName), info.FileVersion);
            }

            foreach (var file in files2)
            {
                string fileName = Path.GetFileName(file);

                // Compare
                if (fileVersions1.ContainsKey(fileName))
                {
                    var info = FileVersionInfo.GetVersionInfo(file);

                    if (fileVersions1[fileName] != info.FileVersion)
                    {
                        Difference diff = new Difference();
                        diff.FileName = fileName;
                        diff.Version1 = fileVersions1[fileName];
                        diff.Version2 = info.FileVersion;

                        differences.Add(diff);
                    }
                }
            }

            return differences;
        }
    }
}
