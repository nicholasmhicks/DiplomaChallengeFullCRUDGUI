using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudGUI.Models
{
    public class Tour
    {
        public Tour()
        {
            Bookings = new HashSet<Booking>();
            TourEvents = new HashSet<TourEvent>();
        }

        public string TourName { get; set; }

        public string Description { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public virtual ICollection<Booking> Bookings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public virtual ICollection<TourEvent> TourEvents { get; set; }
    }
}
