using SteroidMerchApp.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SteroidMerchApp.Models
{
    public class Shirt
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [EnumDataType(typeof(Size))]
        [Required(ErrorMessage = "Размера е задължителен")]
        public Size Size { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
        public bool Status { get; set; }
    }
}
