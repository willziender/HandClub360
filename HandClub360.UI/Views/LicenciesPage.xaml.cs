using HandClub360.core.Models;
using HandClub360.data.Services;

namespace HandClub360.UI.Views;


public partial class LicenciesPage : ContentPage
{
    private string? _photoPath;

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
        object? sender,
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
         ?? "",

            PhotoPath =
            !string.IsNullOrWhiteSpace(_photoPath)
    ? _photoPath
    :
    SexePicker.SelectedItem?.ToString() == "F"
        ? "default_female.png"
        : "default_male.png",

            // NOUVEAUX RÔLES
            EstJoueur = JoueurCheckBox.IsChecked,
            EstEntraineur = EntraineurCheckBox.IsChecked,
            EstDirigeant = DirigeantCheckBox.IsChecked,
            EstMembreCA = MembreCACheckBox.IsChecked,
            EstArbitre = ArbitreCheckBox.IsChecked,
            EstOfficielTable = OfficielTableCheckBox.IsChecked,
            EstBenevole = BenevoleCheckBox.IsChecked
        };

        await _service.AjouterAsync(licencie);

        // Réinitialisation du formulaire
        NomEntry.Text = "";
        PrenomEntry.Text = "";
        EmailEntry.Text = "";
        TelephoneEntry.Text = "";
        AdresseEntry.Text = "";
        CodePostalEntry.Text = "";
        VilleEntry.Text = "";

        JoueurCheckBox.IsChecked = false;
        EntraineurCheckBox.IsChecked = false;
        DirigeantCheckBox.IsChecked = false;
        MembreCACheckBox.IsChecked = false;
        ArbitreCheckBox.IsChecked = false;
        OfficielTableCheckBox.IsChecked = false;
        BenevoleCheckBox.IsChecked = false;

        SexePicker.SelectedItem = null;

        DateNaissancePicker.Date = DateTime.Today;

        _photoPath = null;

        CategorieLabel.Text = "Catégorie : non calculée";

        TuteurLayout.IsVisible = false;

        NomTuteurEntry.Text = "";
        PrenomTuteurEntry.Text = "";
        EmailTuteurEntry.Text = "";
        TelephoneTuteurEntry.Text = "";

        await ChargerLicencies();
    }
            private async void OnChoisirPhotoClicked(object? sender, EventArgs e)
    {
        try
        {
            var result = await FilePicker.Default.PickAsync(
                new PickOptions
                {
                    PickerTitle = "Choisir une photo"
                });

            if (result != null)
            {
                _photoPath = result.FullPath;

                await DisplayAlert(
                    "Photo",
                    "Photo sélectionnée avec succès",
                    "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert(
                "Erreur",
                ex.Message,
                "OK");
        }
    }


}
