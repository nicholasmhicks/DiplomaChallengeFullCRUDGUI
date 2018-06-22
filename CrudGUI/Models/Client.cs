using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudGUI.Models
{
    public class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            Bookings = new HashSet<Booking>();
        }

        public int ClientId { get; set; }

        public string Surname { get; set; }

        public string GivenName { get; set; }

        public string Gender { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
