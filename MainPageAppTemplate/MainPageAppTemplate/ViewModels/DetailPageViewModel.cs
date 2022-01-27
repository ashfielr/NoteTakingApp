using System;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NoteTakingApp.ViewModels
{
    internal class DetailPageViewModel : INotifyPropertyChanged
    {
        string noteText;

        public string NoteText
        {
            get => noteText;
            set
            {
                if(noteText != value)
                {
                    noteText = value;
                }
            }
        }

        public DetailPageViewModel(string _noteText)
        {
            NoteText = _noteText;

            DismissPageCommand = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PopModalAsync();
            });
        }
        
        public Command DismissPageCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
