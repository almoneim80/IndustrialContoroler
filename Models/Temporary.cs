using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IndustrialContoroler.Models
{
    [Table("Temporary")]
    public partial class Temporary
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
        [Column("Cel_6")]
        public string? Cel6 { get; set; }
        [Column("Cel_7")]
        public string? Cel7 { get; set; }
        [Column("Cel_8")]
        public string? Cel8 { get; set; }
        [Column("Cel_9")]
        public string? Cel9 { get; set; }
        [Column("Cel_10")]
        public string? Cel10 { get; set; }
        [Column("Cel_11")]
        public string? Cel11 { get; set; }
        [Column("Cel_12")]
        public string? Cel12 { get; set; }
        [Column("Cel_13")]
        public string? Cel13 { get; set; }
        [Column("Cel_14")]
        public string? Cel14 { get; set; }
        [Column("Cel_15")]
        public string? Cel15 { get; set; }
        [Column("Cel_16")]
        public string? Cel16 { get; set; }
        [Column("Cel_17")]
        public string? Cel17 { get; set; }
        [Column("Cel_18")]
        public string? Cel18 { get; set; }
        [Column("Cel_19")]
        public string? Cel19 { get; set; }
        [Column("Cel_20")]
        public string? Cel20 { get; set; }
        [Column("Cel_21")]
        public string? Cel21 { get; set; }
        [Column("Cel_22")]
        public string? Cel22 { get; set; }
        [Column("Cel_23")]
        public string? Cel23 { get; set; }
        [Column("Cel_24")]
        public string? Cel24 { get; set; }
        [Column("Cel_25")]
        public string? Cel25 { get; set; }
        [Column("Cel_26")]
        public string? Cel26 { get; set; }
        [Column("Cel_27")]
        public string? Cel27 { get; set; }
        [Column("Cel_28")]
        public string? Cel28 { get; set; }
        [Column("Cel_29")]
        public string? Cel29 { get; set; }
        [Column("Cel_30")]
        public string? Cel30 { get; set; }
        public string? TblDesc { get; set; }
    }
}
