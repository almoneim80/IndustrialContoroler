using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IndustrialContoroler.Models
{
    [Table("Machine")]
    public partial class Machine
    {
        [Key]
        [Column("ma_Id")]
        public int MaId { get; set; }


        [Column("ma_Name")]
        [StringLength(100)]
        //[Required(ErrorMessage = "يرجى إدخال اسم الآلة")]
        [MinLength(2, ErrorMessage = "يجب ان لايقل اسم الآلة عن حرفين")]
        public string MaName { get; set; } = null!;


        [Column("ma_number")]
        //[Required(ErrorMessage = "يرجى إدخال عدد الآلات")]
        [Range(1, int.MaxValue, ErrorMessage = "يرجى إدخال عدد صحيح")]
        public int? MaNumber { get; set; }


        [Column("ma_Uses")]
        //[Required(ErrorMessage = "يرجى إدخال إستخدامات الآلة")]
        [MinLength(3, ErrorMessage = "يجب ان لايقل اسم الاستخدام عن ثلاثة حروف")]
        public string MaUses { get; set; } = null!;


        [Column("ma_countryManufacture")]
        [StringLength(100)]
        //[Required(ErrorMessage = "يرجى إدخال بلد الصنع ")]
        [MinLength(3, ErrorMessage = "يجب ان لايقل اسم البلد عن ثلاثة حروف")]
        public string MaCountryManufacture { get; set; } = null!;


        [Column("ma_measruingUnit")]
        [StringLength(100)]
        //[Required(ErrorMessage = "يرجى إدخال وحدة القياس ")]
        [MinLength(2, ErrorMessage = "يجب ان لايقل اسم وحدة القياس عن حرفين")]
        public string MaMeasruingUnit { get; set; } = null!;



        [Column("ma_Ability")]
        //[Required(ErrorMessage = "يرجى إدخال القدرة")]
        public string MaAbility { get; set; } = null!;


        [Column("ma_Source")]
        [StringLength(100)]
        //[Required(ErrorMessage = "يرجى تحديد مصدر الآلة ")]
        public string MaSource { get; set; } = null!;


        [Column("ma_sourceAddress")]
        [StringLength(100)]
        //[Required(ErrorMessage = "يرجى إدخال عنوان المصدر ")]
        [MinLength(3, ErrorMessage = "يجب ان لايقل اسم العنوان عن ثلاثة حروف")]
        public string MaSourceAddress { get; set; } = null!;



        [Column("ma_Notes")]
        public string? MaNotes { get; set; }


        [Column("fa_Id")]
        //[Required(ErrorMessage = "يرجى إدخال رقم المنشأة")]
        [Range(1, int.MaxValue, ErrorMessage = "يرجى إدخال رقم صحيح")]
        public int FaId { get; set; }



        [Column("Is_Deleted")]
        public bool IsDeleted { get; set; }



        [ForeignKey("FaId")]
        [InverseProperty("Machines")]
        public virtual Facility Fa { get; set; } = null!;
    }
}
