namespace CloudControl.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ItemTemplateProperty")]
    public partial class ItemTemplateProperty
    {
        public int ID { get; set; }

        public int ItemTemplateID { get; set; }

        public int PropertyTemplateID { get; set; }

        public bool? IsRequired { get; set; }

        public virtual ItemTemplate ItemTemplate { get; set; }

        public virtual PropertyTemplate PropertyTemplate { get; set; }
    }
}
