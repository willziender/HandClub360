using System;
using System.Collections.Generic;
using System.Text;

namespace HandClub360.core.Models
{
    public class TuteurLegal
    {
        public Guid Id { get; set; }

        public Guid LicencieId { get; set; }

        public string Nom { get; set; } = "";

        public string Prenom { get; set; } = "";

        public string Email { get; set; } = "";

        public string Telephone { get; set; } = "";

        public string LienParente { get; set; } = "";

        public Licencie? Licencie { get; set; }
    }
}