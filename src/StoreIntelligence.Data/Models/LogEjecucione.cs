using System;
using System.Collections.Generic;

#nullable disable

namespace StoreIntelligence.Data.Models
{
    public partial class LogEjecucione
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string Origen { get; set; }
        public string? Equipo { get; set; }
    }
}
