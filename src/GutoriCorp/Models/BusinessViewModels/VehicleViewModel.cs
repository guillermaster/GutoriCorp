using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GutoriCorp.Models.BusinessViewModels
{
    public class VehicleViewModel
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string vin_code { get; set; }

        [Required]
        [StringLength(4)]
        public string year { get; set; }

        [Required]
        [Display(Name = "Make")]
        public short make_id { get; set; }

        [Required]
        [Display(Name = "Model")]
        public short model_id { get; set; }

        [Required]
        [Display(Name = "Body Hull")]
        public short body_hull_id { get; set; }

        [Required]
        [StringLength(10)]
        public string tlc_plate { get; set; }

        [StringLength(10)]
        public string document_num { get; set; }

        [Required]
        [Display(Name = "Color")]
        public short color_id { get; set; }

        [Required]
        [Display(Name = "Weight STS Length")]
        public decimal? wt_sts_lgth { get; set; }

        [Required]
        [Display(Name = "Number of Seats")]
        public byte seats { get; set; }

        [Required]
        [Display(Name = "Fuel")]
        public short fuel_id { get; set; }

        [Required]
        [Display(Name = "Cyl")]
        public decimal cyl_prop { get; set; }

        [Required]
        [Display(Name = "Is New?")]
        public bool is_new { get; set; }

        [Required]
        [StringLength(20)]
        public string type_title { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_issued { get; set; }

        [Required]
        [Display(Name = "Reading Miles")]
        public decimal reading_miles { get; set; }

        public DateTime created_on { get; set; }

        public short created_by { get; set; }

        public DateTime modified_on { get; set; }

        public short modified_by { get; set; }

        //public virtual GeneralCatalogValue GeneralCatalogValue { get; set; }

        //public virtual GeneralCatalogValue GeneralCatalogValue1 { get; set; }

        //public virtual GeneralCatalogValue GeneralCatalogValue2 { get; set; }

        //public virtual SystemUser SystemUser { get; set; }

        //public virtual SystemUser SystemUser1 { get; set; }

        //public virtual VehicleMake VehicleMake { get; set; }

        //public virtual VehicleMakeModel VehicleMakeModel { get; set; }

        public IEnumerable<SelectListItem> Makes { get; set; }
        public IEnumerable<SelectListItem> Models { get; set; }
    }
}
