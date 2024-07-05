using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IndustrialContoroler.Models.FacilityViewModels
{
    public class MapVM
    {
        [Required(ErrorMessage = "يرجى إدخال خط الطول الذي تقع عليىة المنشأة")]
        public int? Longitude { get; set; }



        [Required(ErrorMessage = "يرجى إدخال دائرة الطول الذي تقع عليىة المنشأة")]
        public int? Latitude
        {
            get; set;
        }
    }
}
