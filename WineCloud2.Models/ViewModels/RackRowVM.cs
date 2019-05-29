using System;
using System.Collections.Generic;
using System.Text;
using WineCloud2.Models.DAL;

namespace WineCloud2.Models.ViewModels
{
    public class RackRowVM
    {
        public RackRowVM() { }

        public Guid Id { get; set; }

        public Guid ZoneId { get; set; }

        public string Description { get; set; }

        public virtual List<RackColumn> RackColumns { get; set; }

        public virtual List<Bottle> Bottles { get; set; }
    }
}
