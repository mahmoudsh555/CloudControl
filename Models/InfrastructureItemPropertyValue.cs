namespace CloudControl.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class InfrastructureItemPropertyValue
    {
        public int ID { get; set; }

        public int InfrastructureItemID { get; set; }

        public int PropertyTemplateID { get; set; }

        [StringLength(500)]
        public string PropertyValue { get; set; }

        public int? PropertyTemplateLookupID { get; set; }

        public virtual InfrastructureItem InfrastructureItem { get; set; }

        public virtual PropertyTemplate PropertyTemplate { get; set; }

        public virtual PropertyTemplateLookup PropertyTemplateLookup { get; set; }
    }
}
