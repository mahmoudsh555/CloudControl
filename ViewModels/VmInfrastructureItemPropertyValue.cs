using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CloudControl.ViewModels
{
    public class VmInfrastructureItemPropertyValue
    {
        public int PropertyTemplateID { get; set; }

        [StringLength(500)]
        public string PropertyValue { get; set; }

        public int? PropertyTemplateLookupID { get; set; }
    }
}
