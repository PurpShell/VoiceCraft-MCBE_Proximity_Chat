using VoiceCraft.Maui.ViewModels;

namespace VoiceCraft.Maui.Views.Desktop;

public partial class Settings : ContentPage
{
    readonly SettingsViewModel viewModel;
	public Settings()
	{
		InitializeComponent();

        viewModel = (SettingsViewModel)BindingContext;
    }

    private void ClientEntryUnfocused(object sender, FocusEventArgs e)
    {
        if (sender is Entry entry)
        {
            var valid = int.TryParse(entry.Text, out var result);
            if (!valid)
            {
                var cleaned = new string(entry.Text.Where(char.IsDigit).ToArray());
                if (int.TryParse(cleaned, out var res))
                {
                    var clamped = Math.Clamp(res, 1025, 65535);
                    viewModel.Settings.ClientPort = clamped;
                    entry.Text = clamped.ToString();
                }
                else
                {
                    viewModel.Settings.ClientPort = 1025;
                }
            }
            else if (result > 65535 || result < 1025)
            {
                var clamped = Math.Clamp(result, 1025, 65535);
                viewModel.Settings.ClientPort = clamped;
            }
        }
    }

    protected override void OnDisappearing()
    {
        viewModel.SaveSettingsCommand.Execute(this);
        base.OnDisappearing();
    }
}