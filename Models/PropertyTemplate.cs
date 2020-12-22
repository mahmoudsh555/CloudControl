namespace CloudControl.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PropertyTemplate")]
    public partial class PropertyTemplate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PropertyTemplate()
        {
            InfrastructureItemPropertyValues = new HashSet<InfrastructureItemPropertyValue>();
            ItemTemplateProperties = new HashSet<ItemTemplateProperty>();
            PropertyTemplateLookups = new HashSet<PropertyTemplateLookup>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(500)]
        public string Notes { get; set; }

        public int PropertyTypeID { get; set; }

        public bool IsList { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InfrastructureItemPropertyValue> InfrastructureItemPropertyValues { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemTemplateProperty> ItemTemplateProperties { get; set; }

        public virtual PropertyType PropertyType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PropertyTemplateLookup> PropertyTemplateLookups { get; set; }
    }
}
