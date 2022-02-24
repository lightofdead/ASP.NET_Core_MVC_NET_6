using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TestAspWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Наименование")]
        public string Name { get; set; }
        [DisplayName("Заказ")]
        [Range(1,50,ErrorMessage ="Интервал от 1 до 50!")]
        public int DisplayOrder { get; set; }

        public DateTime CreateDateTime { get; set; } = DateTime.Now;
    }
}
