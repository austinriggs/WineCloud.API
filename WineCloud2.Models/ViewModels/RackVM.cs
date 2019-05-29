using System;
using System.Collections.Generic;
using WineCloud2.Models.DAL;

namespace WineCloud2.Models.ViewModels
{
    public class RackVM
    {
        public Guid Id { get; set; }

        public Guid? CellarId { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public virtual List<Zone> Zones { get; set; }

        public virtual List<Bottle> Bottles { get; set; }
    }
}
