using System;
using System.Collections.Generic;
using System.Text;

namespace HandClub360.core.Models;

public class Materiel
{
    public Guid Id { get; set; }

    public string Nom { get; set; } = "";

    public string Categorie { get; set; } = "";

    public int Quantite { get; set; }

    public string Etat { get; set; } = "Bon";

    public string Localisation { get; set; } = "";

    public DateTime DateAchat { get; set; }

    public string Commentaire { get; set; } = "";
}