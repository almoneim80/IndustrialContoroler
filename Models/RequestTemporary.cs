using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndustrialContoroler.Models
{
    public class RequestTemporary
    {
        [Key]
        public int Id { get; set; }
        [Column("Cel_1")]
        public string? Cel1 { get; set; }
        [Column("Cel_2")]
        public string? Cel2 { get; set; }
        [Column("Cel_3")]
        public string? Cel3 { get; set; }
        [Column("Cel_4")]
        public string? Cel4 { get; set; }
        [Column("Cel_5")]
        public string? Cel5 { get; set; }
    }
}
