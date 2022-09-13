using CarSystemClient.ViewModels;
using ReactiveUI;
using System.Reactive;

namespace CarSystemClient
{
    public class CarWindowBase : ReactiveWindow<CarViewModel>
    {
    }
    public partial class CarWindow : CarWindowBase
    {
        public CarWindow()
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
