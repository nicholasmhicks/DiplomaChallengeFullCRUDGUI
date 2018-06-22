using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudGUI.Models
{
    public class Booking
    {
        public int BookingId { get; set; }

        public int ClientId { get; set; }

        public string TourName { get; set; }

        public string EventMonth { get; set; }
        public string EventDay { get; set; }

        public string EventYear { get; set; }

        public decimal? Payment { get; set; }

        public string DateBooked { get; set; }

        public virtual Client Client { get; set; }

        public virtual Tour Tour { get; set; }

        public virtual TourEvent TourEvent { get; set; }
    }
}
