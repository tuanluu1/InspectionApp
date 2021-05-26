using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace InspectionApp.Models
{
    public partial class VehicleInspection
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RowId { get; set; }
        [Required(ErrorMessage = "VIN is mandatory", AllowEmptyStrings = false)]
        public string Vin { get; set; }
        [Display(Name = "Vehicle Maker")]
        [Required(ErrorMessage = "Vehicle Maker is mandatory", AllowEmptyStrings = false)]
        public int VehicleMaker { get; set; }

        [Display(Name = "Vehicle Year")]
        [Required(ErrorMessage = "Vehicle Year is mandatory", AllowEmptyStrings = false)]
        public int VehicleYear { get; set; }
        [Display(Name = "Vehicle Model")]
        [Required(ErrorMessage = "Vehicle Model is mandatory", AllowEmptyStrings = false)]
        public string VehicleModel { get; set; }
        [Display(Name = "Inspection Date")]
        [Required(ErrorMessage = "Inspection Date is mandatory", AllowEmptyStrings = false)]
        public DateTime InspectionDate { get; set; }
        [Display(Name = "Inspector Name")]
        [Required(ErrorMessage = "Inspector Name is mandatory", AllowEmptyStrings = false)]
        public string InspectorName { get; set; }
        [Display(Name = "Inspection Location")]
        [Required(ErrorMessage = "Inspection Location is mandatory", AllowEmptyStrings = false)]
        public string InspectionLocation { get; set; }
        [Display(Name = "Pass or Fail")]
        public bool PassFail { get; set; }
        public string Notes { get; set; }

        public virtual VehicleMaker VehicleMakerNavigation { get; set; }
    }
}
