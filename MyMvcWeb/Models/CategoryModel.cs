using System.ComponentModel.DataAnnotations;

namespace MyMvcWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}
