using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WineCloud2.Models.DAL
{
    public class Zone
    {
        public Zone() { }

        public Guid Id { get; set; }

        public Guid RackId { get; set; }

        public string Description { get; set; }

        public Double? Temperature { get; set; }

        public bool? StaggeredRows { get; set; }

        public Guid CreatedById { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedDateTime { get; set; }

        public virtual List<RackRow> RackRows { get; set; }

        public virtual List<Bottle> Bottles { get; set; }
    }
}
