using System;
using System.Collections.Generic;
using System.Text;
using WineCloud2.Models.DAL;

namespace WineCloud2.Models.ViewModels
{
    public class CreateBottleTypeVM
    {
        public CreateBottleTypeVM() { }

        public string Color { get; set; }

        public int? YearVintage { get; set; }

        public string Winery { get; set; }

        public string Varietal { get; set; }

        public string Vinyard { get; set; }

        public string Name { get; set; }

        public DateTime? PurchaseDate { get; set; }

        public double? PurchasePrice { get; set; }

        public Guid CellarId { get; set; }

        public Guid? RackId { get; set; }

        public Guid? ZoneId { get; set; }

        public Guid? RackRowId { get; set; }

        public DateTime? StorageDate { get; set; }

        public double? StorageTemparature { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public string CreatedById { get; set; }

        public DateTime? OpenedDate { get; set; }

        public string Notes { get; set; }

        public int NewBottleCount { get; set; }
    }
}
