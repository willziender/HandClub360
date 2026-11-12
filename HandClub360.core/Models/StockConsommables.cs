using System;
using System.Collections.Generic;
using System.Text;

namespace HandClub360.core.Models;

public class StockConsommables
{
    public Guid Id { get; set; }

    public string Nom { get; set; } = "";

    public int QuantiteStock { get; set; }

    public int SeuilAlerte { get; set; }

    public DateTime? DatePeremption { get; set; }
}