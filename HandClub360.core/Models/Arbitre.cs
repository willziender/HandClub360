using System;
using System.Collections.Generic;
using System.Text;

namespace HandClub360.core.Models;

public class Arbitre
{
    public Guid Id { get; set; }
    public string Nom { get; set; } = "";
    public string Niveau { get; set; } = "";
    public bool Disponible { get; set; }
}