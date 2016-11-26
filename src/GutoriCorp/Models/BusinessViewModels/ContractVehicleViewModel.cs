using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GutoriCorp.Models.BusinessViewModels
{
    public class ContractVehicleViewModel
    {
        [Required]
        [Display(Name = "Contract")]
        public short contract_id { get; set; }

        [Required]
        [Display(Name = "Vehicle")]
        public short vehicle_id { get; set; }

        [Display(Name = "Contract Number")]
        public string ContractNumber { get; set; }

        [Display(Name = "Assigned Vehicle")]
        public string VehicleDisplayName { get; set; }

        public IEnumerable<SelectListItem> AvailableVehicles { get; set; }
    }
}
