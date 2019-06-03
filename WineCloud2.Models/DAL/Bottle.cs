﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WineCloud2.Models.DAL
{
    public class Bottle
    {
        public Bottle()
        {
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid BottleTypeId { get; set; }

        [StringLength(16)]
        public string Color { get; set; }

        public int? YearVintage { get; set; }

        [StringLength(64)]
        public string Winery { get; set; }

        [StringLength(64)]
        public string Varietal { get; set; }

        [StringLength(64)]
        public string Vinyard { get; set; }

        [StringLength(64)]
        public string Name { get; set; }

        public DateTime? PurchaseDate { get; set; }

        public double? PurchasePrice { get; set; }

        public Guid CellarId { get; set; }

        public Guid? RackId { get; set; }

        public Guid? ZoneId { get; set; }

        public Guid? RackRowId { get; set; }

        public Guid? RackColumnId { get; set; }

        public DateTime? StorageDate { get; set; }

        public double? StorageTemparature { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedDateTime { get; set; }

        [StringLength(64)]
        public string CreatedById { get; set; }

        public DateTime? OpenedDate { get; set; }

        [StringLength(256)]
        public string Notes { get; set; }

        public virtual User User { get; set; }

        public virtual BottleType BottleType { get; set; }

        public virtual Cellar Cellar { get; set; }
    }
}
