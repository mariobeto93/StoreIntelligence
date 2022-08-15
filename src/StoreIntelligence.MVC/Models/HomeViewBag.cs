using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreIntelligence.MVC.Models

{
    public class HomeViewBag
    {
        public List<Infraestructure.Services.LogEjecuciones> LogEjecuciones { get; set; }
        public bool viewLog { get; set; }
    }
}
