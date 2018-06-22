namespace API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Booking
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BookingId { get; set; }

        public int? ClientId { get; set; }

        [StringLength(100)]
        public string TourName { get; set; }

        [StringLength(100)]
        public string EventMonth { get; set; }

        [StringLength(100)]
        public string EventDay { get; set; }

        [StringLength(100)]
        public string EventYear { get; set; }

        [Column(TypeName = "money")]
        public decimal? Payment { get; set; }

        [StringLength(100)]
        public string DateBooked { get; set; }

        public virtual Client Client { get; set; }

        public virtual Tour Tour { get; set; }

        public virtual TourEvent TourEvent { get; set; }
    }
}
