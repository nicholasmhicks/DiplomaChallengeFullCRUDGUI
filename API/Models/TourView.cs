namespace API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TourView")]
    public partial class TourView
    {
        [Key]
        [StringLength(100)]
        public string TourName { get; set; }

        [StringLength(100)]
        public string Description { get; set; }
    }
}
