using System;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MainPageAppTemplate.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<string> AllNotes { get; set; }
        string theNote;

        public MainPageViewModel()
        {
            AllNotes = new ObservableCollection<string>();

            DeleteCommand = new Command(() =>
            {
                TheNote = string.Empty;
            });

            SaveCommand = new Command((value) =>
            {
                AllNotes.Add(TheNote);

                TheNote = string.Empty;
            });
        }

        public string TheNote
        {
            get => theNote;
            set
            {
                theNote = value;

                var args = new PropertyChangedEventArgs(nameof(TheNote));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public Command SaveCommand { get; }
        public Command DeleteCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}