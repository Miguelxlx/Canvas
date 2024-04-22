using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Module
    {
        [Key]
        public int ModuleId { get; set; } // Primary key
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // Changed ObservableCollection to List for EF Core compatibility
        public List<ContentItem> ContentItems { get; set; } = new List<ContentItem>();
    }
}
