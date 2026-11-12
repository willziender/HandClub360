using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace HandClub360.core.Models;

public class Equipe
{
    public Guid Id { get; set; }

    public string Nom { get; set; } = "";

    public string Categorie { get; set; } = "";

    public string Sexe { get; set; } = "";

    public int Niveau { get; set; }

    public string Division { get; set; } = "";

    public string Entraineur { get; set; } = "";

    public ICollection<AffectationEquipe> Affectations { get; set; }
        = new List<AffectationEquipe>();

    public ICollection<Match> Matchs { get; set; }
        = new List<Match>();
}