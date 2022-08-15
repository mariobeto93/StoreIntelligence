using StoreIntelligence.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreIntelligence.Infraestructure.Services
{
    public class LogService
    {
        public void SaveLog(string origin)
        {
            var insert = new StoreIntelligence.Data.Models.LogEjecucione()
            {
                FechaHora = DateTime.Now,
                Origen = origin,
                Equipo = Environment.MachineName
            };

            using (StoreIntelligenceContext db = new StoreIntelligenceContext())
            {
                db.LogEjecuciones.Add(insert);
                db.SaveChanges();
            }

            
        }

        public List<LogEjecuciones> GetLog()
        {
            using (StoreIntelligenceContext db = new StoreIntelligenceContext())
            {
                return ( from l in db.LogEjecuciones
                         select new LogEjecuciones()
                         {
                             Id = l.Id, 
                             FechaHora = l.FechaHora,
                             Origen = l.Origen,
                             Equipo = l.Equipo
                         }).ToList();

            }

        }
    }

    public class LogEjecuciones
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string Origen { get; set; }
        public string? Equipo { get; set; }
    }
}
