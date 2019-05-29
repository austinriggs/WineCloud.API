using System;
using System.Collections.Generic;
using System.Text;
using WineCloud2.Models.DAL;

namespace WineCloud2.Models.ViewModels
{
    public class RackColumnVM
    {
        public RackColumnVM() { }

        public Guid Id { get; set; }

        public Guid RackRowId { get; set; }

        public Guid? BottleId { get; set; }

        public virtual Bottle Bottle { get; set; }
    }
}
