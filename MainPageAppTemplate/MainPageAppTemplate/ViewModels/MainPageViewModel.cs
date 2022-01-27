using System;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using NoteTakingApp.Views;

namespace NoteTakingApp.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<string> AllNotes { get; set; }
        string theNote;
        string selectedNote;

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

            SelectedNoteChangedCommand = new Command(async () =>
            {
                var detailVM = new DetailPageViewModel(SelectedNote);
                var detailPage = new DetailPage();
                detailPage.BindingContext = detailVM;

                await Application.Current.MainPage.Navigation.PushModalAsync(detailPage);
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

        public string SelectedNote
        {
            get => selectedNote;
            set
            {
                selectedNote = value;

                var args = new PropertyChangedEventArgs(nameof(SelectedNote));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public Command SaveCommand { get; }
        public Command DeleteCommand { get; }

        public Command SelectedNoteChangedCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}