using System.Collections.ObjectModel;

namespace CanvasRemake.Models
{
    public class Module
    {
        public string? Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public ObservableCollection<ContentItem> ContentItems { get; set; }

        public Module()
        {
            ContentItems = new ObservableCollection<ContentItem>();
        }

        public Module(string name, string description)
        {
            Name = name;
            Description = description;
            ContentItems = new ObservableCollection<ContentItem>();
        }
    }
}
