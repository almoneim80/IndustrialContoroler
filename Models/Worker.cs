using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IndustrialContoroler.Models
{
    [Table("Worker")]
    public partial class Worker
    {
        [Key]
        [Column("wo_Id")]
        public int WoId { get; set; }


        [Column("wo_Total")]
        //[Required(ErrorMessage = "يرجى إدخال العدد الاجمالي للعمالة")]
        [Range(1, int.MaxValue, ErrorMessage = "يرجى إدخال عدد صحيح")]
        public int? WoTotal { get; set; }


        [Column("wo_maleNumber")]
        //[Required(ErrorMessage = "يرجى إدخال عدد الذكور ")]
        [Range(0, int.MaxValue, ErrorMessage = "يرجى إدخال عدد صحيح")]
        public int? WoMaleNumber { get; set; }


        [Column("wo_femaleNumber")]
        //[Required(ErrorMessage = "يرجى إدخال عدد الإناث ")]
        [Range(0, int.MaxValue, ErrorMessage = "يرجى إدخال عدد صحيح")]
        public int? WoFemaleNumber { get; set; }


        [Column("wo_eduQualifying")]
        [StringLength(100)]
        //[Required(ErrorMessage = "يرجى تحديد المؤهل التعليمي")]
        public string WoEduQualifying { get; set; } = null!;


        [Column("wo_specialization")]
        [StringLength(100)]
        //[Required(ErrorMessage = "يرجى إدخال اسم التخصص")]
        [MinLength(2, ErrorMessage = "يجب ان لايقل اسم التخصص عن حرفين")]
        public string WoSpecialization { get; set; } = null!;


        [Column("wo_Notes")]
        public string? WoNotes { get; set; }


        [Column("wo_Type")]
        [StringLength(100)]
        //[Required(ErrorMessage = "يرجى إدخال نوعية العمالة")]
        [MinLength(3, ErrorMessage = "يجب ان لايقل اسم النوع عن ثلاثة حروف")]
        public string WoType { get; set; } = null!;


        [Column("wo_Nationality")]
        [StringLength(100)]
        //[Required(ErrorMessage = "يرجى تحديد جنسية العمالة")]
        public string WoNationality { get; set; } = null!;


        [Column("fa_Id")]
        //[Required(ErrorMessage = "يرجى إدخال رقم المنشأة")]
        [Range(1, int.MaxValue, ErrorMessage = "يرجى إدخال رقم صحيح")]
        public int? FaId { get; set; }


        [Column("Is_Deleted")]
        public bool IsDeleted { get; set; }


        [ForeignKey("FaId")]
        [InverseProperty("Workers")]
        public virtual Facility Fa { get; set; } = null!;
    }
}
