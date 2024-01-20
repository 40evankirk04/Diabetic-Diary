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
                return _openNewRecordWindowCommand ??= new RelayCommand(obj =>
                {
                    var newRecordWindow = new Views.NewRecord()
                    {
                        Owner = App.Current.MainWindow
                    };

                    newRecordWindow.ShowDialog();
                });
            }
        }

        private RelayCommand? _openHistoryWindowCommand;
        public RelayCommand OpenHistoryWindowCommand
        {
            get
            {
                return _openHistoryWindowCommand ??= new RelayCommand(obj =>
                {
                    var historyWindow = new Views.History()
                    {
                        Owner = App.Current.MainWindow
                    };

                    historyWindow.ShowDialog();
                });
            }
        }
    }
}
