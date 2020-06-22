namespace CompanyManagementSystem.Entities.Concrete
{
    using CompanyManagementSystem.Entities.Abstract;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Faturalar")]
    public partial class Faturalar : IEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Faturalar()
        {
            AlımTablosu = new HashSet<AlımTablosu>();
        }

        [Key]
        public int FaturaId { get; set; }

        [Required]
        public byte[] Fatura { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AlımTablosu> AlımTablosu { get; set; }
    }
}
