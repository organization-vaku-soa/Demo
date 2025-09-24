using Microsoft.AspNetCore.Components;
using System.ComponentModel;

namespace Demo.BlazorApp.Helpers
{
    public abstract class ViewModelComponentBase<TViewModel> : ComponentBase, IDisposable
    where TViewModel : class, INotifyPropertyChanged
    {
        [Inject] public TViewModel Vm { get; set; } = default!;

        private PropertyChangedEventHandler? _handler;

        protected override void OnInitialized()
        {
            // Suscripción global al PropertyChanged del ViewModel
            _handler = async (_, __) => await InvokeAsync(StateHasChanged);
            Vm.PropertyChanged += _handler;
        }

        public void Dispose()
        {
            if (_handler is not null)
                Vm.PropertyChanged -= _handler;
        }
    }
}