using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CanvasRemake.Models;
using CanvasRemake.Services;
using System.Collections.ObjectModel;

namespace CanvasRemake.ViewModels
{
    public partial class AddModuleViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly ApiService _apiService;
        private string _courseCode;

        [ObservableProperty]
        private string moduleName;

        [ObservableProperty]
        private string moduleDescription;

        public ObservableCollection<ContentItem> ContentItems { get; } = new();

        public AddModuleViewModel(INavigationService navigationService, ApiService apiService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            AddContentItemCommand = new RelayCommand(AddContentItem);
            RemoveContentItemCommand = new RelayCommand<ContentItem>(RemoveContentItem);
            SaveCommand = new AsyncRelayCommand(OnSaveAsync);
        }

        public void Initialize(string courseCode)
        {
            _courseCode = courseCode;
        }

        public IRelayCommand AddContentItemCommand { get; }
        public IRelayCommand<ContentItem> RemoveContentItemCommand { get; }
        public IAsyncRelayCommand SaveCommand { get; }

        private void AddContentItem()
        {
            ContentItems.Add(new ContentItem());
        }

        private void RemoveContentItem(ContentItem contentItem)
        {
            if (contentItem != null)
            {
                ContentItems.Remove(contentItem);
            }
        }

        private async Task OnSaveAsync()
        {
            var module = new Module
            {
                Name = ModuleName,
                Description = ModuleDescription,
                ContentItems = new ObservableCollection<ContentItem>(ContentItems)
            };

            await _apiService.AddModuleToCourseAsync(_courseCode, module);
            await _navigationService.GoBackAsync();
        }
    }
}