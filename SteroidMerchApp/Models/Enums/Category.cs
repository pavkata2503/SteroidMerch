using System.ComponentModel.DataAnnotations;

namespace SteroidMerchApp.Models.Enums
{
    public enum Category
    {
        [Display(Name = "Инжекционни")]
        injectable,
        [Display(Name = "Орални")]
        oral
    }
}
