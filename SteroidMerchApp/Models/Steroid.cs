using SteroidMerchApp.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace SteroidMerchApp.Models
{
    public class Steroid
    {
        [Key]
        public int Id { get; set; }
        public string URL { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        [EnumDataType(typeof(Category))]
        [Required(ErrorMessage = "Категорията е задължителен")]
        public Category Category { get; set; }
        public bool Status { get; set; }
    }
}
