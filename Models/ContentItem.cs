using System.Collections.ObjectModel;

namespace CanvasRemake.Models
{
    public class ContentItem
    {
        public string? Name { get; set; }
        public string? Description { get; set; }

        public ContentItem()
        {
            Name = string.Empty;
            Description = string.Empty;
        }

        public ContentItem(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }

}