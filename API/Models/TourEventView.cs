namespace API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TourEventView")]
    public partial class TourEventView
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string EventMonth { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string EventDay { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(100)]
        public string EventYear { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(100)]
        public string TourName { get; set; }

        [Column(TypeName = "money")]
        public decimal? Fee { get; set; }
    }
}
