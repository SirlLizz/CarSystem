using CarSystemClient.ViewModels;
using ReactiveUI;
using System.Reactive;

namespace CarSystemClient
{
    public class EquipmentWindowBase : ReactiveWindow<EquipmentViewModel>
    {
    }
    public partial class EquipmentWindow : EquipmentWindowBase
    {
        public EquipmentWindow()
        {
            InitializeComponent();

            _ = this.WhenActivated(cd =>
            {
                if (ViewModel is null)
                    return;

                cd.Add(ViewModel.Close.RegisterHandler(interaction =>
                {
                    Tag = interaction.Input;
                    interaction.SetOutput(Unit.Default);
                    Close();
                }));
            });
        }
    }
}
