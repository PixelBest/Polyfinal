using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Polyfinal.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        [Column("Id")]
        public int? Id { get; set; }
        [Column("Username")]
        public string? Username { get; set; }
        [Column("Password")]
        public string? Password { get; set; }
        [Column("Balance")]
        public double? Balance { get; set; }
        [Column("isAdmin")]
        public bool? isAdmin { get; set; }
    }
}
