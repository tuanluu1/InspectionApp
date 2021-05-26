using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace InspectionApp.Models
{
    public partial class VehicleMaker
    {
        public VehicleMaker()
        {
            VehicleInspections = new HashSet<VehicleInspection>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Vehicle Maker Id")]
        public int MakerId { get; set; }
        public string Maker { get; set; }

        public virtual ICollection<VehicleInspection> VehicleInspections { get; set; }
    }
}
