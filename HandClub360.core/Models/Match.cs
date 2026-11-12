using System;
using System.Collections.Generic;
using System.Text;

namespace HandClub360.core.Models;

public class Match
{
    public Guid Id { get; set; }

    public Guid EquipeId { get; set; }

    public DateTime DateMatch { get; set; }

    public string Adversaire { get; set; } = "";

    public bool Domicile { get; set; }

    public string Lieu { get; set; } = "";

    public Equipe? Equipe { get; set; }

    public ICollection<Convocation> Convocations { get; set; }
        = new List<Convocation>();
}