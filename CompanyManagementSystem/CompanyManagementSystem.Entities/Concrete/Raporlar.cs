namespace CompanyManagementSystem.Entities.Concrete
{
    using CompanyManagementSystem.Entities.Abstract;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Raporlar")]
    public partial class Raporlar : IEntity
    {
        [Key]
        public int RaporId { get; set; }

        [Required]
        [StringLength(50)]
        public string RaporName { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
