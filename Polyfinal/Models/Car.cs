using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Polyfinal.Models
{
    [Table("Car")]
    public class Car
    {
        [Key]
        [Column("Id")]
        public int? Id { get; set; }
        [Column("CanBeRented")]
        public bool? CanBeRented { get; set; }
        [Column("TransportType")]
        public string? TransportType { get; set; }
        [Column("Model")]
        public string? Model { get; set; }
        [Column("Color")]
        public string? Color { get; set; }
        [Column("Identifier")]
        public string? Identifier { get; set; }
        [Column("Description")]
        public string? Description { get; set; }
        [Column("Latitude")]
        public double? Latitude { get; set; }
        [Column("Longitude")]
        public double? Longitude { get; set; }
        [Column("MinutePrice")]
        public double? MinutePrice { get; set; }
        [Column("DayPrice")]
        public double? DayPrice { get; set; }
    }
}
