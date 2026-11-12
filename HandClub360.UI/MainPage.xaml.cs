using HandClub360.UI.Views;

namespace HandClub360.UI;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnLicenciesClicked(
    object? sender,
    EventArgs e)
    {
        await Shell.Current.GoToAsync(
            nameof(LicenciesPage));
    }
}