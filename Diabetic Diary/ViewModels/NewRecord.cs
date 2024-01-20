using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Diabetic_Diary.ViewModels
{
    class NewRecord : INotifyPropertyChanged
    {



        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
