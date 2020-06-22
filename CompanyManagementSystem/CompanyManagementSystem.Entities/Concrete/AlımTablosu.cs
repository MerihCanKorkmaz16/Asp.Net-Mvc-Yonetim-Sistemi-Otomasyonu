namespace CompanyManagementSystem.Entities.Concrete
{
    using CompanyManagementSystem.Entities.Abstract;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AlımTablosu:IEntity
    {
        [Key]
        public int SatısId { get; set; }

        public int FaturaId { get; set; }

        public DateTime IslemTarihi { get; set; }

        [Column(TypeName = "money")]
        public decimal Tutar { get; set; }

        [StringLength(50)]
        public string Urün { get; set; }

        [StringLength(50)]
        public string FirmaAdi { get; set; }

        public int UserId { get; set; }

        public virtual Faturalar Faturalar { get; set; }


        public virtual User User { get; set; }
    }
}
