using System.ComponentModel;
using System.Runtime.CompilerServices;
using Diabetic_Diary.Models.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace Diabetic_Diary.ViewModels
{
    internal class History : INotifyPropertyChanged
    {
        private ObservableCollection<Record>? _records;
        public ObservableCollection<Record>? Records
        {
            get => _records;

            private set
            {
                _records = value;
                OnPropertyChanged();
            }
        }

        public async Task GetRecordsFromDBAsync()
        {
            using (ApplicationContext db = new())
            {
                await db.Records.LoadAsync();

                Records = db.Records.Local.ToObservableCollection();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
