namespace API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TourEvent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TourEvent()
        {
            Bookings = new HashSet<Booking>();
        }

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

        [Required]
        [StringLength(100)]
        public string TourName { get; set; }

        [Column(TypeName = "money")]
        public decimal? Fee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Bookings { get; set; }

        public virtual Tour Tour { get; set; }
    }
}
