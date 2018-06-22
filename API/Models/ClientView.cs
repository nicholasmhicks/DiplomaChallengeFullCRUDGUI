namespace API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ClientView")]
    public partial class ClientView
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ClientId { get; set; }

        [StringLength(100)]
        public string Surname { get; set; }

        [StringLength(100)]
        public string GivenName { get; set; }

        [StringLength(100)]
        public string Gender { get; set; }
    }
}
