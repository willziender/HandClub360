namespace HandClub360.core.Models;

public class AffectationEquipe
{
    public Guid Id { get; set; }

    public Guid LicencieId { get; set; }

    public Guid EquipeId { get; set; }

    public bool EquipePrincipale { get; set; }

    public bool PeutEtreConvoque { get; set; }

    public string Commentaire { get; set; } = "";

    public Licencie? Licencie { get; set; }

    public Equipe? Equipe { get; set; }

    public string Motif { get; set; } = "";
}