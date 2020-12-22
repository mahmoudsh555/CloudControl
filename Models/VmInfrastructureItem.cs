using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudControl.ViewModels
{
    public class VmInfrastructureItem
    {
        public int InfrastructureID { get; set; }
        public int ItemTemplateID { get; set; }
                public string Notes { get; set; }
        public List<VmInfrastructureItemPropertyValue> vwInfrastructureItemPropertyValues { get; set; }
    }
}
