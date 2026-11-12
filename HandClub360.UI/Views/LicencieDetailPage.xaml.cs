using HandClub360.core.Models;

namespace HandClub360.UI.Views;

public partial class LicencieDetailPage : ContentPage
{
    private readonly Licencie _licencie;

    public LicencieDetailPage(Licencie licencie)
    {
        InitializeComponent();

        _licencie = licencie;

        ChargerDonnees();
    }

    private void ChargerDonnees()
    {
        PhotoImage.Source = _licencie.PhotoPath;

        NomLabel.Text = _licencie.Nom;
        PrenomLabel.Text = _licencie.Prenom;
        CategorieLabel.Text = _licencie.Categorie;
        EmailLabel.Text = _licencie.Email;
        TelephoneLabel.Text = _licencie.Telephone;
    }
        private void RechercheTextChanged(
    object? sender,
    TextChangedEventArgs e)
    {
        // Recherche à développer plus tard
    }
}
