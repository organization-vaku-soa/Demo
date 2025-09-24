using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Demo.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Core.ViewModels
{
    public partial class NotesViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddNoteCommand))] 
        private string? newNote;

        [ObservableProperty] private string lastAction = "Sin acciones aún.";
        public ObservableCollection<NoteItem> Notes { get; } = new();

        [RelayCommand(CanExecute = nameof(CanAddNote))]
        private void AddNote()
        {
            if (!string.IsNullOrWhiteSpace(NewNote))
            {
                var note = new NoteItem { Title = NewNote.Trim() };
                Notes.Add(note);
                LastAction = $"Nota agregada: \"{note.Title}\" a las {note.CreatedAt:T}";
                NewNote = string.Empty;
            }
        }
        private bool CanAddNote() => !string.IsNullOrWhiteSpace(NewNote);


        [RelayCommand]
        private void RemoveNote(NoteItem note)
        {
            if (Notes.Contains(note))
            {
                Notes.Remove(note);
                LastAction = $"Nota eliminada: \"{note.Title}\" a las {DateTime.Now:T}";
            }
        }
    }
}
    
