namespace CloudControl.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VwTemplate
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ItemTemplateID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string ItemTemplateName { get; set; }

        public int? PropertyTemplateID { get; set; }

        [StringLength(50)]
        public string PropertyTemplateName { get; set; }

        public int? PropertyTemplateLookupID { get; set; }

        [StringLength(50)]
        public string PropertyTemplateLookupName { get; set; }

        public int? PropertyTypeID { get; set; }

        [StringLength(50)]
        public string PropertyTypeName { get; set; }
    }
}
