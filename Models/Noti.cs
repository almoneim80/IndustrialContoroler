

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndustrialContoroler.Models
{
    public class Noti
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "يرجى إدخال عنوان الأشعار")]
        public string Title { get; set; } = null!;
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "يرجى إدخال وصف الأشعار")]
        public string Description { get; set; } = null!;

        public string Sender { get; set; } = null!;
        public string? ImageSender { get; set; }
        public string Receiver { get; set; } = null!;
        public int? FaId { get; set; }

        [ForeignKey("FaId")]

        public Facility facility { get; set; } = null!;
        public bool IsRead { get; set; }
        public bool IsDeleted { get; set; }
    }
}
