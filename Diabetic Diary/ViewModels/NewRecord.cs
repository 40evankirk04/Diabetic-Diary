using Diabetic_Diary.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Diabetic_Diary.Models.Record_Data;
using Diabetic_Diary.Models.Database;
using Diabetic_Diary.Views;

namespace Diabetic_Diary.ViewModels
{
    class NewRecord : INotifyPropertyChanged
    {
        private string? _date;
        public string Date
        {
            get => _date;

            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }

        private string? _time;
        public string Time
        {
            get => _time;

            set
            {
                _time = value;
                OnPropertyChanged();
            }
        }

        private string? _sugarValue;
        public string SugarValue
        {
            get => _sugarValue;

            set
            {
                _sugarValue = value;
                OnPropertyChanged();
            }
        }

        private string? _eatenBreadUnits;
        public string EatenBreadUnits
        {
            get => _eatenBreadUnits;

            set
            {
                _eatenBreadUnits = value;
                OnPropertyChanged();
            }
        }

        private string? _deliveredInsulinUnits;
        public string DeliveredInsulinUnits
        {
            get => _deliveredInsulinUnits;

            set
            {
                _deliveredInsulinUnits = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand? _saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return _saveCommand ??= new RelayCommand(obj => 
                {
                    var inputedData = new InputedData(Date, Time, SugarValue, EatenBreadUnits, DeliveredInsulinUnits);

                    if (inputedData.IsCorrect)
                    {
                        var convertedData = new ConvertedData(inputedData);
                        var record = new Record();

                        record.SetValues(convertedData);

                        Task.Factory.StartNew(() =>
                        {
                            using (var db = new ApplicationContext())
                            {
                                db.Records.Add(record);
                                db.SaveChanges();
                            }
                        });
                    }

                    else
                    {
                        new ErrorValues().ShowDialog();
                    }

                }, (obj) => Date is not null);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
