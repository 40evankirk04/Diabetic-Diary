using Diabetic_Diary.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Diabetic_Diary.Models.Record_Data;
using Diabetic_Diary.Models.Database;
using Diabetic_Diary.Views;
using System.Windows.Controls;

namespace Diabetic_Diary.ViewModels
{
    internal class NewRecord : INotifyPropertyChanged
    {
        private string? _date;
        public string? Date
        {
            get => _date;

            set
            {
                if (value == "")
                    _date = null;
                else
                    _date = value;

                OnPropertyChanged();
            }
        }

        private TextBox? _dateTB;
        public TextBox? DateTB
        {
            get => _dateTB;

            set
            {
                _dateTB = value;
                OnPropertyChanged();
            }
        }

        private string? _time;
        public string? Time
        {
            get => _time;

            set
            {
                if (value == "")
                    _time = null;
                else
                    _time = value;

                OnPropertyChanged();
            }
        }

        private string? _sugarValue;
        public string? SugarValue
        {
            get => _sugarValue;

            set
            {
                if (value == "")
                    _sugarValue = null;
                else
                    _sugarValue = value;

                OnPropertyChanged();
            }
        }

        private string? _eatenBreadUnits;
        public string? EatenBreadUnits
        {
            get => _eatenBreadUnits;

            set
            {   
                if (value == "")
                    _eatenBreadUnits = null;
                else
                    _eatenBreadUnits = value;

                OnPropertyChanged();
            }
        }

        private string? _deliveredInsulinUnits;
        public string? DeliveredInsulinUnits
        {
            get => _deliveredInsulinUnits;

            set
            {
                if (value == "")
                    _deliveredInsulinUnits = null;
                else
                    _deliveredInsulinUnits = value;

                OnPropertyChanged();
            }
        }

        private RelayCommand? _saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return _saveCommand ??= new RelayCommand(obj => SaveRecord(), obj => CheckPropertiesNull());
            }
        }

        private void SaveRecord()
        {
            
            var inputedData = new InputedData(Date, Time, SugarValue, EatenBreadUnits, DeliveredInsulinUnits);

            if (inputedData.IsCorrect)
            {
                var convertedData = new ConvertedData(inputedData);
                var record = new Record();
                var success = new Success();

                record.SetValues(convertedData);

                Task.Run(() =>
                {
                    using (var db = new ApplicationContext())
                    {
                        db.Records.Add(record);
                        db.SaveChanges();
                    }
                });

                ClearValues();
                success.ShowDialog();
            }

            else
            {
                new ErrorValues().ShowDialog();
            }
        }

        private bool CheckPropertiesNull()
        {
            return (

                Date is not null
                && Time is not null
                && SugarValue is not null
                && EatenBreadUnits is not null
                && DeliveredInsulinUnits is not null
            );
        }

        private void ClearValues()
        {
            Date = null;
            Time = null;
            SugarValue = null;
            EatenBreadUnits = null;
            DeliveredInsulinUnits = null;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
