using HandClub360.UI.Views;

namespace HandClub360.UI;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(
            nameof(LicenciesPage),
            typeof(LicenciesPage));
    }
}