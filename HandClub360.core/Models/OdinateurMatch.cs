using System;
using System.Collections.Generic;
using System.Text;

namespace HandClub360.core.Models;

public class OrdinateurMatch
{
    public Guid Id { get; set; }

    public string Nom { get; set; } = "";

    public string NumeroSerie { get; set; } = "";

    public string Dirigeant { get; set; } = "";

    public bool Disponible { get; set; }

    public DateTime DerniereVerification { get; set; }
}