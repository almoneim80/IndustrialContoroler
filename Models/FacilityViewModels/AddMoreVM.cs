using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndustrialContoroler.Models.FacilityViewModels
{
    public class AddMoreVM
    {
        [Required]
        [Column("sr_Reason")]
        [StringLength(100)]
        public string SrReason { get; set; }


        [Column("fa_Id")]
        public int FaId { get; set; }


        public List<AddMoreVM> AddMoreList { get; set; }
    }
}
