namespace CompanyManagementSystem.Entities.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Log")]
    public partial class Log
    {
        public int LogId { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string IPAddress { get; set; }

        [Required]
        [StringLength(50)]
        public string UrlAccessed { get; set; }

        [Required]
        [StringLength(50)]
        public string Data { get; set; }

        public DateTime OperationDate { get; set; }

        public virtual User User { get; set; }
    }
}
