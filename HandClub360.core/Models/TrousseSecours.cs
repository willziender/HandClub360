using System;
using System.Collections.Generic;
using System.Text;

namespace HandClub360.core.Models;

public class TrousseSecours
{
    public Guid Id { get; set; }

    public string Nom { get; set; } = "";

    public string Localisation { get; set; } = "";

    public DateTime DernierControle { get; set; }

    public bool Complete { get; set; }
}