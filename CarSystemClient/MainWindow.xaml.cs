﻿
using CarSystemClient.ViewModels;
using ReactiveUI;
using System.Reactive.Linq;

namespace CarSystemClient
{
    public class MainWindowBase : ReactiveWindow<MainWindowViewModel>
    {
    }

    public partial class MainWindow : MainWindowBase
    {
        public MainWindow()
        {
            InitializeComponent();

            _ = this.WhenActivated(cd =>
            {
                if (ViewModel is null)
                    return;

                cd.Add(ViewModel.CreateEngine.RegisterHandler(interaction =>
                {
                    var engineViewModel = new EngineViewModel();
                    var engineWindow = new EngineWindow
                    {
                        Owner = this,
                        ViewModel = engineViewModel
                    };

                    return Observable.Start(() =>
                    {
                        _ = engineWindow.ShowDialog();
                    }, RxApp.MainThreadScheduler);
                }));
                
                cd.Add(ViewModel.CreateEquipment.RegisterHandler(interaction =>
                {
                    var equipmentViewModel = new EquipmentViewModel();
                    var equipmentWindow = new EquipmentWindow
                    {
                        Owner = this,
                        ViewModel = equipmentViewModel
                    };

                    return Observable.Start(() =>
                    {
                        _ = equipmentWindow.ShowDialog();
                    }, RxApp.MainThreadScheduler);
                }));
                /*
                cd.Add(ViewModel.CreateProduct.RegisterHandler(interaction =>
                {
                    var productViewModel = new AddProductViewModel();
                    var productWindow = new AddProductWindow
                    {
                        Owner = this,
                        ViewModel = productViewModel
                    };

                    return Observable.Start(() =>
                    {
                        _ = productWindow.ShowDialog();
                    }, RxApp.MainThreadScheduler);
                }));*/
            });
        }
    }
}
