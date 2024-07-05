using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IndustrialContoroler.Models
{
    [Table("Building")]
    public partial class Building
    {
        [Key]
        [Column("bu_Id")]
        public int BuId { get; set; }


        [Column("bu_Ownership")]
        [StringLength(100)]
        //[Required(ErrorMessage = "يرجى تحديد ملكية المبنى")]
        public string BuOwnership { get; set; } = null!;



        [Column("bu_Description")]
        //[Required(ErrorMessage = "يرجى إدخال وصف المبنى")]
        [MinLength(3, ErrorMessage = "يجب ان لايقل الوصف عن ثلاثة حروف")]
        public string BuDescription { get; set; } = null!;



        [Column("bu_Location")]
        [StringLength(100)]
        //[Required(ErrorMessage = "يرجى إدخال موقع المبنى")]
        [MinLength(2, ErrorMessage = "يجب ان لايقل اسم الموقع عن حرفين")]
        public string BuLocation { get; set; } = null!;



        [Column("bu_Type")]
        [StringLength(100)]
        //[Required(ErrorMessage = "يرجى إدخال نوعية البناء")]
        [MinLength(2, ErrorMessage = "يجب ان لايقل اسم النوع عن حرفين")]
        public string BuType { get; set; } = null!;



        [Column("bu_Length")]
        //[Required(ErrorMessage = "يرجى إدخال طول المبنى")]
        [Range(1, int.MaxValue, ErrorMessage = "يرجى إدخال طول صحيح")]
        public int? BuLength { get; set; }



        [Column("bu_Width")]
        //[Required(ErrorMessage = "يرجى إدخال عرض المبنى")]
        [Range(1, int.MaxValue, ErrorMessage = "يرجى إدخال عرض صحيح")]
        public int? BuWidth { get; set; } 



        [Column("bu_High")]
        //[Required(ErrorMessage = "يرجى إدخال ارتفاع المبنى")]
        [Range(1, int.MaxValue, ErrorMessage = "يرجى إدخال ارتفاع صحيح")]
        public int? BuHigh { get; set; }



        [Column("bu_Area")]
        //[Required(ErrorMessage = "يرجى إدخال مساحة المبنى")]
        [StringLength(100)]
        public string BuArea { get; set; } = null!;



        [Column("bu_Notes")]
        public string? BuNotes { get; set; }


        [Column("fa_Id")]
        //[Required(ErrorMessage = "يرجى إدخال رقم المنشأة")]
        [Range(1, int.MaxValue, ErrorMessage = "يرجى إدخال رقم صحيح")]
        public int? FaId { get; set; }



        [Column("Is_Deleted")]
        public bool IsDeleted { get; set; }



        [ForeignKey("FaId")]
        [InverseProperty("Buildings")]
        public virtual Facility Fa { get; set; } = null!;
    }
}
