using System.Collections.ObjectModel;

namespace CanvasRemake.Models
{
    public class Module
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ObservableCollection<ContentItem> ContentItems { get; set; }

        public Module()
        {
            ContentItems = new ObservableCollection<ContentItem>();
        }
    }
}
