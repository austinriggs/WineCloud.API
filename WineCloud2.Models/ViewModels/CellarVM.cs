using System;
using System.Collections.Generic;
using System.Text;

namespace WineCloud2.Models.DAL
{
    public class CellarVM
    {
        public CellarVM() { }

        public Guid Id { get; set; }

        public string Description { get; set; }

        public virtual List<Rack> Racks { get; set; }

        public virtual List<Bottle> Bottles { get; set; }
    }
}
