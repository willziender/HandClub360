using System;
using System.Collections.Generic;
using System.Text;

namespace HandClub360.core.Models;

public class Convocation
{
    public Guid Id { get; set; }

    public Guid MatchId { get; set; }

    public Guid LicencieId { get; set; }

    public DateTime DateConvocation { get; set; }

    public string Statut { get; set; } = "";

    public Match? Match { get; set; }

    public Licencie? Licencie { get; set; }
}