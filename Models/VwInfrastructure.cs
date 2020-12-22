namespace CloudControl.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VwInfrastructure")]
    public partial class VwInfrastructure
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public int InfrastructureID { get; set; }
        public string InfrastructureName { get; set; }
        public int ItemTemplateID { get; set; }
        public string ItemTemplateName { get; set; }
        public Nullable<int> PropertyTemplateID { get; set; }
        public string PropertyTemplateName { get; set; }
        public string PropertyTemplateValue { get; set; }
        public Nullable<int> InfrastructerParentID { get; set; }
        public string InfrastructerParentName { get; set; }
        public Nullable<int> ItemTemplateParentID { get; set; }
        public string ItemTemplateParentName { get; set; }
    }
}
