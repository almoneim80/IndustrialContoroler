using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace IndustrialContoroler.Models.requestsViewModels
{
    public class RequestAttVM
    {
        [Key]
        public int Id { get; set; }


        [NotMapped]
        [Required(ErrorMessage = "يرجى إدراج ملف المرفق")]
        public IFormFile AtUrl { get; set; }


        [Required(ErrorMessage = "يرجى إدخال نوع المرفق")]
        public int AttId { get; set; }



        public int ReId { get; set; }
    }
}
