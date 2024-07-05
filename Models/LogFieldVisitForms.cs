using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndustrialContoroler.Models
{
    public class LogFieldVisitForms
    {
        //public LogFieldVisitForms()
        //{
        //    Notifications = new HashSet<Notification>();
        //}

        [Key]
        
        public int LogId { get; set; }
        public string Action { get; set; } = null!;
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        
        public int FaId { get; set; }

        
        public bool IsDeleted { get; set; }

        [ForeignKey("FaId")]
       
        public  Facility facility { get; set; } = null!;
       
        
    }
}
