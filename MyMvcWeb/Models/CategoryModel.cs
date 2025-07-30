using System.ComponentModel.DataAnnotations;

namespace MyMvcWeb.Models
{
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}
