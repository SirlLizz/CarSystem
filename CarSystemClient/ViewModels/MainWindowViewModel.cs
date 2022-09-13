using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace CarSystemClient.ViewModels
{
    public sealed class MainWindowViewModel
    {
        public Engine SelectedEngine { get; set; } = new();
        public Car SelectedCar { get; set; } = new();
        public Equipment SelectedEquipment { get; set; } = new();
        public ObservableCollection<Engine> SourceEngine { get; set; } = new();
        public ObservableCollection<Car> SourceCar { get; set; } = new();
        public ObservableCollection<Equipment> SourceEquipment { get; set; } = new();
        public ReactiveCommand<Unit, Unit> AddEngine { get; }
        public ReactiveCommand<Unit, Unit> AddEquipment { get; }
        public ReactiveCommand<Unit, Unit> AddCar { get; }
        public ReactiveCommand<Unit, Unit> DeleteEngine { get; }
        public ReactiveCommand<Unit, Unit> DeleteEquipment { get; }
        public ReactiveCommand<Unit, Unit> DeleteCar { get; }
        public ReactiveCommand<Unit, Unit> UpdateTable { get; }
        public Interaction<Unit, Unit> CreateEngine { get; } = new();
        public Interaction<Unit, Unit> CreateEquipment { get; } = new();
        public Interaction<Unit, Unit> CreateCar { get; } = new();
        private CarSystemRepository _carSystemRepository = new();

        public MainWindowViewModel()
        {
            AddEngine = ReactiveCommand.CreateFromTask(AddEngineImpl);
            DeleteEngine = ReactiveCommand.Create(DeleteEngineImpl);
            AddCar = ReactiveCommand.CreateFromTask(AddCarImpl);
            DeleteCar = ReactiveCommand.Create(DeleteCarImpl);
            AddEquipment = ReactiveCommand.CreateFromTask(AddEquipmentImpl);
            DeleteEquipment = ReactiveCommand.Create(DeleteEquipmentImpl);
            UpdateTable = ReactiveCommand.Create(UpdateTableImpl);

            UpdateTableImpl();
        }

        private async Task AddEngineImpl()
        {
            await CreateEngine.Handle(Unit.Default);
        }

        private void DeleteEngineImpl()
        {
            _carSystemRepository.DeleteEngine(SelectedEngine.Name);
            UpdateEngineTable();
        }

        private async Task AddCarImpl()
        {
            await CreateCar.Handle(Unit.Default);
        }

        private void DeleteCarImpl()
        {
            _carSystemRepository.DeleteCar(SelectedCar.Model);
            UpdateCarTable();
        }

        private async Task AddEquipmentImpl()
        {
            await CreateEquipment.Handle(Unit.Default);
        }

        private void DeleteEquipmentImpl()
        {
            _carSystemRepository.DeleteEquipment(SelectedEquipment.Name);
            UpdateEquipmentTable();
        }

        private void UpdateTableImpl()
        {
            UpdateEngineTable();
            UpdateCarTable();
            UpdateEquipmentTable();
        }

        private void UpdateEngineTable()
        {
            var engines = _carSystemRepository.GetAllEngines();
            SourceEngine.Clear();
            foreach (var engine in engines.Result)
            {
                SourceEngine.Add(new Engine() { Name = engine.Name, Power = engine.Power, Size = engine.Size});
            }
        }

        private void UpdateCarTable()
        {
            var cars = _carSystemRepository.GetAllCars();
            SourceCar.Clear();
            foreach (var car in cars.Result)
            {
                SourceCar.Add(new Car() { Color = car.Color, Engine = car.Engine, Equipment = car.Equipment, Model = car.Model, Price = car.Price});
            }
        }

        private void UpdateEquipmentTable()
        {
            var equipments = _carSystemRepository.GetAllEquipments();
            SourceEquipment.Clear();
            foreach (var equipment in equipments.Result)
            {
                SourceEquipment.Add(new Equipment() { Conditioner = equipment.Conditioner, Material = equipment.Material, Name = equipment.Name, RDisc = equipment.RDisc});
            }
        }
    }
}
