using ReactiveUI;
using System;
using System.Reactive;
using System.Text.RegularExpressions;

namespace CarSystemClient.ViewModels
{
    public sealed class EquipmentViewModel
    {
        public string NameInput { get; set; } = string.Empty;
        public string MaterialInput { get; set; } = string.Empty;
        public bool CondicionerInput { get; set; } = false;
        public string RDiscInput { get; set; } = string.Empty;
        public ReactiveCommand<Unit, Unit> Add { get; }
        public ReactiveCommand<Unit, Unit> Cancel { get; }
        public Interaction<Unit?, Unit> Close { get; } = new(RxApp.MainThreadScheduler);
        private readonly CarSystemRepository _carSystemRepository = new();

        public EquipmentViewModel()
        {
            Add = ReactiveCommand.CreateFromObservable(AddImpl);
            Cancel = ReactiveCommand.CreateFromObservable(CancelImpl);
        }

        private IObservable<Unit> AddImpl()
        {
            if (!new Regex("[^0-9]+").IsMatch(RDiscInput) && RDiscInput != "")
            {
                _carSystemRepository.AddEquipment(new Equipment() { Name = NameInput, Material = MaterialInput, RDisc = int.Parse(RDiscInput), Conditioner = CondicionerInput});
            }
            return Close.Handle(null);
        }

        private IObservable<Unit> CancelImpl()
        {
            return Close.Handle(null);
        }
    }
}
