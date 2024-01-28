using Diabetic_Diary.Models;

namespace Diabetic_Diary.ViewModels
{
    internal class Menu
    {
        private RelayCommand? _openNewRecordWindowCommand;
        public RelayCommand OpenNewRecordWindowCommand
        {
            get
            {
                return _openNewRecordWindowCommand ??= new RelayCommand(obj => OpenNewRecordWindow());
            }
        }

        private RelayCommand? _openHistoryWindowCommand;
        public RelayCommand OpenHistoryWindowCommand
        {
            get
            {
                return _openHistoryWindowCommand ??= new RelayCommand(obj => OpenHistoryWindowAsync());
            }
        }

        private async void OpenHistoryWindowAsync()
        {
            History historyVM = new();

            await Task.Run(historyVM.GetRecordsFromDBAsync);

            var historyWindow = new Views.History()
            {
                Owner = App.Current.MainWindow,
                DataContext = historyVM
            };

            historyWindow.ShowDialog();
        }

        private void OpenNewRecordWindow()
        {
            var newRecordWindow = new Views.NewRecord()
            {
                Owner = App.Current.MainWindow
            };

            newRecordWindow.ShowDialog();
        }
    }
}
