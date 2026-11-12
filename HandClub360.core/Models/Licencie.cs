using HandClub360.core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HandClub360.core.Models;

public class Licencie
{
    public Guid Id { get; set; }

    // Etat civil
    public string Nom { get; set; } = "";
    public string Prenom { get; set; } = "";
    public DateTime DateNaissance { get; set; }
    public string Sexe { get; set; } = "";
    public string TailleMaillot { get; set; } = "";
    public string TailleShort { get; set; } = "";

    // Coordonnées
    public string Email { get; set; } = "";
    public string Telephone { get; set; } = "";
    public string Adresse { get; set; } = "";
    public string CodePostal { get; set; } = "";
    public string Ville { get; set; } = "";

    // FFHB
    public string NumeroLicence { get; set; } = "";
    public bool CotisationPayee { get; set; }
    public bool Mutation { get; set; }
    public bool QualificationValidee { get; set; }
    public DateTime DateInscriptionClub { get; set; }

    // Santé
    public bool CertificatMedicalValide { get; set; }
    public string Allergies { get; set; } = "";
    public string Observations { get; set; } = "";

    // Autorisations
    public bool AutorisationParentale { get; set; }
    public bool AutorisationTransport { get; set; }

    // Trombinoscope
    public string PhotoPath { get; set; } = "";

    // Categorie
    public string Categorie
    {
        get
        {
            int age = DateTime.Today.Year - DateNaissance.Year;

            if (DateNaissance.Date > DateTime.Today.AddYears(-age))
                age--;

            return age switch
            {
                <= 8 => "Baby Hand",
                <= 10 => "U11",
                <= 12 => "U13",
                <= 14 => "U15",
                <= 17 => "U18",
                _ => "Senior"
            };
        }
    }


    // Equipe principale
    public Guid? EquipePrincipaleId { get; set; }

    // Navigation EF
    public Equipe? EquipePrincipale { get; set; }

    public ICollection<AffectationEquipe> Affectations { get; set; }
        = new List<AffectationEquipe>();

    public ICollection<Convocation> Convocations { get; set; }
        = new List<Convocation>();
}
