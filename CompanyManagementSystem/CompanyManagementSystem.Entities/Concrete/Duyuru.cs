namespace CompanyManagementSystem.Entities.Concrete
{
    using CompanyManagementSystem.Entities.Abstract;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Duyuru")]
    public partial class Duyuru : IEntity
    {
        public int DuyuruId { get; set; }

        [Required]
        [StringLength(200)]
        public string Duyurucontext { get; set; }

        public int? UserId { get; set; }

        public bool Durum { get; set; }

        public virtual User User { get; set; }
    }
}
