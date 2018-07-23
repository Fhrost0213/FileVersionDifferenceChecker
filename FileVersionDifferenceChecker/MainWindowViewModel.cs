using FileVersionDifferenceChecker.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FileVersionDifferenceChecker
{
    public class MainWindowViewModel
    {
        private ObservableCollection<Difference> _differences;

        public ObservableCollection<Difference> Differences
        {
            get { return _differences; }
            set
            {
                _differences = value;
            }
        }


        private string filePath1;

        public string FilePath1
        {
            get { return filePath1; }
            set { filePath1 = value; }
        }

        private string filePath2;

        public string FilePath2
        {
            get { return filePath2; }
            set { filePath2 = value; }
        }

        private ICommand _getDifferencesCommand;

        public ICommand GetDifferencesCommand
        {
            get { return _getDifferencesCommand; }
            set { _getDifferencesCommand = value; }
        }

        private ICommand _exportDifferencesCommand;

        public ICommand ExportDifferencesCommand
        {
            get { return _exportDifferencesCommand; }
            set { _exportDifferencesCommand = value; }
        }

        private void ExportDifferencesCommandExecuted(object obj)
        {
            Export export = new Export();
            export.ExportDifferences(Differences);
        }

        private void GetDifferencesCommandExecuted(object obj)
        {
            Differences.Clear();
            var differences = FileDifferenceChecker.GetFileVersionDifferences(FilePath1, FilePath2);

            foreach (var difference in differences)
            {
                Differences.Add(difference);
            }
        }


        public MainWindowViewModel()
        {
            GetDifferencesCommand = new RelayCommand(GetDifferencesCommandExecuted);
            ExportDifferencesCommand = new RelayCommand(ExportDifferencesCommandExecuted);

            Differences = new ObservableCollection<Difference>();
        }
    }
}
