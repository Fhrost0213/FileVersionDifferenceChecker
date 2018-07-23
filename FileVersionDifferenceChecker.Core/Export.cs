using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;

namespace FileVersionDifferenceChecker.Core
{
    public class Export
    {
        public async void ExportDifferences(ObservableCollection<Difference> differences)
        {
            SaveFileDialog dialog = new SaveFileDialog()
            {
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*", 
                Title = "Save differences"
            };

            if (dialog.ShowDialog() == true)
            {
                using (StreamWriter sw = new StreamWriter(dialog.FileName))
                {
                    foreach (var difference in differences)
                    {
                        await sw.WriteLineAsync(difference.FileName + " - Version 1: " + difference.Version1);
                        await sw.WriteLineAsync(difference.FileName + " - Version 2: " + difference.Version2);
                    }
                }
            }
        }
    }
}
