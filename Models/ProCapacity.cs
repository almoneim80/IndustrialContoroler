using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IndustrialContoroler.Models
{
    [Table("proCapacity")]
    public partial class ProCapacity
    {
        [Key]
        [Column("pc_productId")]
        public int PcProductId { get; set; }


        [Column("pc_productName")]
        [StringLength(100)]
        //[Required(ErrorMessage = "يرجى إدخال اسم المنتج")]
        [MinLength(2, ErrorMessage = "يجب ان لايقل اسم المنتج عن حرفين")]
        public string PcProductName { get; set; } = null!;



        [Column("pc_yearQuantity")]
        [StringLength(100)]
        //[Required(ErrorMessage = "يرجى إدخال الكمية السنوية")]
        [MinLength(2, ErrorMessage = "يجب ان لايقل اسم الكمية عن حرفين")]
        public string PcYearQuantity { get; set; } = null!;


        [Column("pc_measruingUnit")]
        [StringLength(100)]
        //[Required(ErrorMessage = "يرجى إدخال اسم وحدة القياس ")]
        [MinLength(2, ErrorMessage = "يجب ان لايقل اسم وحدة القياس عن حرفين")]
        public string PcMeasruingUnit { get; set; } = null!;


        [Column("pc_Notes")]
        public string? PcNotes { get; set; }


        [Column("fa_Id")]
        public int FaId { get; set; }


        [Column("Is_Deleted")]
        public bool IsDeleted { get; set; }


        [ForeignKey("FaId")]
        [InverseProperty("ProCapacities")]
        public virtual Facility Fa { get; set; } = null!;
    }
}
