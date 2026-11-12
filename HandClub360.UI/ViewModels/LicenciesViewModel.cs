using CommunityToolkit.Mvvm.ComponentModel;
using HandClub360.core.Models;
using HandClub360.data.Services;
using System.Collections.ObjectModel;

namespace HandClub360.UI.ViewModels;

public partial class LicenciesViewModel
    : ObservableObject
{
    private readonly LicencieService _service =
        new();

    public ObservableCollection<Licencie>
        Licencies
    { get; }
        = new();

    public async Task ChargerAsync()
    {
        Licencies.Clear();

        var liste =
            await _service.GetAllAsync();

        foreach (var licencie in liste)
        {
            Licencies.Add(licencie);
        }
    }
}