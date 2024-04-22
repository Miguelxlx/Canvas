using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class ContentItem
    {
        [Key]
        public int ContentItemId { get; set; } // Primary key
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
