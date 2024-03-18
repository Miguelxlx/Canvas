using System;
using CanvasRemake.Models;

namespace CanvasRemake.Views
{
    public partial class AddModuleView : ContentPage
    {
        private Module _module;

        public AddModuleView(Module module)
        {
            InitializeComponent();
            _module = module;
            BindingContext = _module;

            ModuleNameEntry.Text = _module.Name;
            ModuleDescriptionEditor.Text = _module.Description;
        }

        private async void OnAddContentItemClicked(object sender, EventArgs e)
        {
            var contentItem = new ContentItem
            {
                Name = ContentItemNameEntry.Text,
                Description = ContentItemDescriptionEditor.Text
            };

            _module.ContentItems.Add(contentItem);

            ContentItemNameEntry.Text = string.Empty;
            ContentItemDescriptionEditor.Text = string.Empty;
        }
        private void OnRemoveContentItemClicked(object sender, EventArgs e)
        {
            var contentItem = (ContentItem)((Button)sender).CommandParameter;
            _module.ContentItems.Remove(contentItem);
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            _module.Name = ModuleNameEntry.Text;
            _module.Description = ModuleDescriptionEditor.Text;

            MessagingCenter.Send(this, "ModuleAdded");

            await Navigation.PopAsync(true);
        }
    }
}