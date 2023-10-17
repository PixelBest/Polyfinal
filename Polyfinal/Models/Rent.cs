using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Polyfinal.Models
{
    [Table("Rent")]
    public class Rent
    {
        [Key]
        [Column("Id")]
        public int? Id { get; set; }
        [Column("Lat")]
        public double? Lat { get; set; }
        [Column("Long")]
        public double? Long { get; set; }
        [Column("Radius")]
        public double? Radius { get; set; }
        [Column("Type")]
        public string? Type { get; set; }
        [Column("UserId")]
        public int? UserId { get; set; }
        [Column("TransportId")]
        public int? TransportId { get; set; }
    }
}
