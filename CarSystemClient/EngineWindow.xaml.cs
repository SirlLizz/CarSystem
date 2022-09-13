using CarSystemClient.ViewModels;
using ReactiveUI;
using System.Reactive;


namespace CarSystemClient
{
    public class EngineWindowBase : ReactiveWindow<EngineViewModel>
    {
    }
    public partial class EngineWindow : EngineWindowBase
    {
        public EngineWindow()
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
