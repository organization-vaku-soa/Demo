using Demo.Core.ViewModels;

namespace Demo.AppMaui;

public partial class NotesPage : ContentPage
{
	public NotesPage(NotesViewModel Vm)
	{
		InitializeComponent();
		BindingContext = Vm;
    }
}