using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace CarSystemClient.ViewModels
{
    public sealed class CarViewModel
    {
        public ObservableCollection<ComboBoxItem> SourceEngine { get; set; } = new();
        public ObservableCollection<ComboBoxItem> SourceEquipment { get; set; } = new();
        public ComboBoxItem SelectEngine { get; set; } = new();
        public ComboBoxItem SelectEquipment { get; set; } = new();
        public string ModelInput { get; set; } = string.Empty;
        public string ColorInput { get; set; } = string.Empty;
        public string PriceInput { get; set; } = string.Empty;
        public ReactiveCommand<Unit, Unit> Add { get; }
        public ReactiveCommand<Unit, Unit> Cancel { get; }
        public Interaction<Unit?, Unit> Close { get; } = new(RxApp.MainThreadScheduler);
        private readonly CarSystemRepository _carSystemRepository = new();

        public CarViewModel()
        {
            Add = ReactiveCommand.CreateFromObservable(AddImpl);
            Cancel = ReactiveCommand.CreateFromObservable(CancelImpl);
            UpdateEnginesItems();
            UpdateEquipmentsItems();
        }

        private IObservable<Unit> AddImpl()
        {
            if (!new Regex("[^0-9,]+").IsMatch(PriceInput) && PriceInput != "" && ModelInput != "" && ColorInput != "")
            {
                _carSystemRepository.AddCar(new Car() { Model = ModelInput, Color = ColorInput, Price = double.Parse(PriceInput), Engine = SelectEngine.DataContext.ToString(), Equipment = SelectEquipment.DataContext.ToString() });
            }
            return Close.Handle(null);
        }

        private IObservable<Unit> CancelImpl()
        {
            return Close.Handle(null);
        }

        private void UpdateEnginesItems()
        {
            var reply = _carSystemRepository.GetAllEngines();
            foreach (var item in reply.Result)
            {
                SourceEngine.Add(new ComboBoxItem() { DataContext = item.Name, Content = item.Name });
            }
        }

        private void UpdateEquipmentsItems()
        {
            var reply = _carSystemRepository.GetAllEquipments();
            foreach (var item in reply.Result)
            {
                SourceEquipment.Add(new ComboBoxItem() { DataContext = item.Name, Content = item.Name });
            }
        }
    }
}
