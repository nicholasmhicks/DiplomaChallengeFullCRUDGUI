using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudGUI.Models
{
    public class TourEvent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TourEvent()
        {
            Bookings = new HashSet<Booking>();
        }

        public string EventMonth { get; set; }

        public string EventDay { get; set; }

        public string EventYear { get; set; }

        public string TourName { get; set; }

        public decimal? Fee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Bookings { get; set; }

        public virtual Tour Tour { get; set; }
    }
}
