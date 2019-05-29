using System;
using System.Collections.Generic;
using System.Text;
using WineCloud2.Models.DAL;

namespace WineCloud2.Models.ViewModels
{
    public class ZoneVM
    {
        public ZoneVM() { }

        public Guid Id { get; set; }

        public Guid RackId { get; set; }

        public string Description { get; set; }

        public Double? Temperature { get; set; }

        public bool? StaggeredRows { get; set; }

        public virtual List<RackRow> RackRows { get; set; }

        public virtual List<Bottle> Bottles { get; set; }
    }
}
