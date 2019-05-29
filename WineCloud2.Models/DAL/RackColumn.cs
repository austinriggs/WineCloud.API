using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WineCloud2.Models.DAL
{
    public class RackColumn
    {
        public RackColumn() { }

        public Guid Id { get; set; }

        public Guid RackRowId { get; set; }

        public Guid? BottleId { get; set; }

        public Guid CreatedById { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedDateTime { get; set; }

        public virtual Bottle Bottle { get; set; }
    }
}
