using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WineCloud2.Models.DAL
{
    public class RackRow
    {
        public RackRow() { }

        public Guid Id { get; set; }

        public Guid ZoneId { get; set; }

        public string Description { get; set; }

        public Guid CreatedById { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedDateTime { get; set; }

        public virtual List<RackColumn> RackColumns { get; set; }

        public virtual List<Bottle> Bottles { get; set; }
    }
}
