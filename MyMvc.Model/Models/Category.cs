using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyMvc.Model.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Category Name")]
        [MaxLength(20)]
        public required string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="Range should be between 1 and 100")]
        public int DisplayOrder { get; set; }
    }
}
