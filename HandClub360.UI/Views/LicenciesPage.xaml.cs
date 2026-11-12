using HandClub360.core.Models;
using HandClub360.data.Services;

namespace HandClub360.UI.Views;

public partial class LicenciesPage : ContentPage
{
    private readonly LicencieService _service =
        new();

    public LicenciesPage()
    {
        InitializeComponent();

        DateNaissancePicker.DateSelected +=
            DateNaissancePicker_DateSelected;
    }
    private void DateNaissancePicker_DateSelected(
    object? sender,
    DateChangedEventArgs e)
    {
        DateTime dateNaissance = e.NewDate ?? DateTime.Today;

        int age =
            DateTime.Today.Year -
            dateNaissance.Year;

        if (dateNaissance >
            DateTime.Today.AddYears(-age))
        {
            age--;
        }

        string categorie;

        if (age <= 8)
            categorie = "Baby Hand";
        else if (age <= 10)
            categorie = "U11";
        else if (age <= 12)
            categorie = "U13";
        else if (age <= 14)
            categorie = "U15";
        else if (age <= 17)
            categorie = "U18";
        else
            categorie = "Senior";

        bool estMineur = age < 18;

        TuteurLayout.IsVisible = estMineur;

        if (estMineur)
        {
            TelephoneEntry.Placeholder =
                "Téléphone du licencié (optionnel)";

            EmailEntry.Placeholder =
                "Email du licencié (optionnel)";
        }
        else
        {
            TelephoneEntry.Placeholder =
                "Téléphone";

            EmailEntry.Placeholder =
                "Email";
        }
                CategorieLabel.Text =
            $"Catégorie : {categorie}";
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await ChargerLicencies();
    }

    private async Task ChargerLicencies()
    {
        LicenciesCollection.ItemsSource =
            await _service.GetAllAsync();
    }

    private async void OnAjouterClicked(
        object sender,
        EventArgs e)
    {
        var licencie = new Licencie
        {
            Nom = NomEntry.Text ?? "",
            Prenom = PrenomEntry.Text ?? "",

            Email = EmailEntry.Text ?? "",
            Telephone = TelephoneEntry.Text ?? "",

            Adresse = AdresseEntry.Text ?? "",
            CodePostal = CodePostalEntry.Text ?? "",
            Ville = VilleEntry.Text ?? "",

            DateNaissance = DateNaissancePicker.Date ?? DateTime.Today,

            Sexe =
         SexePicker.SelectedItem?.ToString()
         ?? ""
        };

        await _service.AjouterAsync(licencie);

        NomEntry.Text = "";
        PrenomEntry.Text = "";
        EmailEntry.Text = "";

        await ChargerLicencies();
    }
}