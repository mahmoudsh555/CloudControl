namespace CloudControl.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InfrastructureItem")]
    public partial class InfrastructureItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InfrastructureItem()
        {
            InfrastructureItemPropertyValues = new HashSet<InfrastructureItemPropertyValue>();
        }

        public int ID { get; set; }

        public int InfrastructureID { get; set; }

        public int ItemTemplateID { get; set; }

        [StringLength(500)]
        public string Notes { get; set; }

        public virtual Infrastructure Infrastructure { get; set; }

        public virtual ItemTemplate ItemTemplate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InfrastructureItemPropertyValue> InfrastructureItemPropertyValues { get; set; }
    }
}
