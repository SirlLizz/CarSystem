using ReactiveUI;
using System;
using System.Reactive;
using System.Text.RegularExpressions;

namespace CarSystemClient.ViewModels
{
    public sealed class EngineViewModel
    {
        public string NameInput { get; set; } = string.Empty;
        public string PowerInput { get; set; } = string.Empty;
        public string SizeInput { get; set; } = string.Empty;
        public ReactiveCommand<Unit, Unit> Add { get; }
        public ReactiveCommand<Unit, Unit> Cancel { get; }
        public Interaction<Unit?, Unit> Close { get; } = new(RxApp.MainThreadScheduler);
        private readonly CarSystemRepository _carSystemRepository = new();

        public EngineViewModel()
        {
            Add = ReactiveCommand.CreateFromObservable(AddImpl);
            Cancel = ReactiveCommand.CreateFromObservable(CancelImpl);
        }

        private IObservable<Unit> AddImpl()
        {
            if (!new Regex("[^0-9,]+").IsMatch(PowerInput) && PowerInput != "" && !new Regex("[^0-9,]+").IsMatch(SizeInput) && SizeInput != "")
            {
                _carSystemRepository.AddEngine(new Engine() { Name = NameInput, Power = double.Parse(PowerInput), Size = double.Parse(SizeInput) });
            }
            return Close.Handle(null);
        }

        private IObservable<Unit> CancelImpl()
        {
            return Close.Handle(null);
        }
    }
}
