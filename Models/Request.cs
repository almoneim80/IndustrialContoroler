using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IndustrialContoroler.Models.requestsViewModels;
using Microsoft.EntityFrameworkCore;

namespace IndustrialContoroler.Models
{
    [Table("Request")]
    [Index("ReSuemNo", Name = "UQ__Request__44C63773E9ED83A5", IsUnique = true)]
    [Index("ReFormNo", Name = "UQ__Request__8E607984A59FDB18", IsUnique = true)]
    public partial class Request
    {
        public Request()
        {
            Attachments = new HashSet<Attachment>();
            RequestTraffics = new HashSet<RequestTraffic>();
        }

        [Key]
        [Column("re_Id")]
        public int ReId { get; set; }

        public bool IsRead { get; set; }

        public String? UserId { get; set; }
        public String? RoleId { get; set; }
        //[Required(ErrorMessage = "يرجى تحديد نوع الطلب")]
        [Column("re_Type")]
        [StringLength(100)]
        public string ReType { get; set; } = null!;


        [Column("re_Date", TypeName = "date")]
        //[Required(ErrorMessage = "يرجى إدخال تاريخ الطلب")]
        public DateTime? ReDate { get; set; } = null!;



        [Column("re_formNo")]
        //[Required(ErrorMessage = "يرجى إدخال رقم إستمارة الطلب")]
        [Range(1,int.MaxValue,ErrorMessage ="يرجى إدخال رقم إستمارة طلب صحيح")]
        public int? ReFormNo { get; set; }


        [Column("re_suemNo")]
        //[Required(ErrorMessage = "يرجى إدخال رقم سند الطلب")]
        [Range(1,int.MaxValue, ErrorMessage = "يرجى إدخال رقم سند صحيح")]
        public int? ReSuemNo { get; set; }


        [Column("re_Applicant")]
        [StringLength(100)]
        //[Required(ErrorMessage = "يرجى إدخال اسم مقدم الطلب")]
        [MinLength(2, ErrorMessage = "يجب ان لا يقل اسم مقدم الطلب عن حرفين")]
        public string ReApplicant { get; set; } = null!;



        [Column("re_requestState")]
        public int ReRequestState { get; set; }


        [Column("Is_Deleted")]
        public bool IsDeleted { get; set; }

        public virtual Facility? Facility { get; set; }
        [InverseProperty("Re")]
        public virtual ICollection<Attachment> Attachments { get; set; }
        [InverseProperty("Re")]
        public virtual ICollection<RequestTraffic> RequestTraffics { get; set; }
    }
}
