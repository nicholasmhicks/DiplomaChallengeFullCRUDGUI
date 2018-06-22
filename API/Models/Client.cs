namespace API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            Bookings = new HashSet<Booking>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ClientId { get; set; }

        [StringLength(100)]
        public string Surname { get; set; }

        [StringLength(100)]
        public string GivenName { get; set; }

        [StringLength(100)]
        public string Gender { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
