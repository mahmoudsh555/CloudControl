namespace CloudControl.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PropertyTemplateLookup")]
    public partial class PropertyTemplateLookup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PropertyTemplateLookup()
        {
            InfrastructureItemPropertyValues = new HashSet<InfrastructureItemPropertyValue>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Notes { get; set; }

        public int PropertyTemplateID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InfrastructureItemPropertyValue> InfrastructureItemPropertyValues { get; set; }

        public virtual PropertyTemplate PropertyTemplate { get; set; }
    }
}
