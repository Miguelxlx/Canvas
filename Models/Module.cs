namespace CanvasRemake.Models
{
    public class Module
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<ContentItem> ContentItems { get; set; }

        public Module()
        {
            ContentItems = new List<ContentItem>();
        }
    }
}