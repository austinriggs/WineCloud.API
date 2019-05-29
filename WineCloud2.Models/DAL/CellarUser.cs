using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WineCloud2.Models.DAL
{
    public class CellarUser
    {
        public CellarUser()
        {

        }

        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid CellarId { get; set; }

        public Guid CreatedById { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedDateTime { get; set; }

        public virtual User User { get; set; }

        public virtual Cellar Cellar { get; set; }
    }
}
