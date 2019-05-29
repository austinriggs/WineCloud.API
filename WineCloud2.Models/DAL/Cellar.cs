using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WineCloud2.Models.DAL
{
    public class Cellar
    {
        public Cellar()
        {

        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [StringLength(64)]
        public string Description { get; set; }

        public Guid CreatedById { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedDateTime { get; set; }

        public virtual List<CellarUser> CellarUsers { get; set; }

        public virtual List<Rack> Racks { get; set; }

        public virtual List<Bottle> Bottles { get; set; }

    }
}
