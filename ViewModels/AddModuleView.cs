// AddModuleViewModel
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
        private Course _course;

        [ObservableProperty] private string moduleName;
        [ObservableProperty] private string moduleDescription;
        public ObservableCollection<ContentItem> ContentItems { get; } = new();

        public AddModuleViewModel(Course course, INavigationService navigationService)
        {
            _course = course;
            _navigationService = navigationService;
            AddContentItemCommand = new RelayCommand(AddContentItem);
            RemoveContentItemCommand = new RelayCommand<ContentItem>(RemoveContentItem);
            SaveCommand = new RelayCommand(OnSave);
        }

        public void Initialize(Course course)
        {
            _course = course;
        }

        public IRelayCommand AddContentItemCommand { get; }
        public IRelayCommand<ContentItem> RemoveContentItemCommand { get; }
        public IRelayCommand SaveCommand { get; }

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

        private async void OnSave()
        {
            if (_course == null)
            {
                // Handle the case when _course is null, e.g., show an error message or navigate back
                Console.WriteLine("Course is null");
                await _navigationService.GoBackAsync();
                return;
            }

            var module = new Module
            {
                Name = ModuleName,
                Description = ModuleDescription,
                ContentItems = new ObservableCollection<ContentItem>(ContentItems)
            };

            _course.Modules.Add(module);
            await _navigationService.GoBackAsync();
        }
    }
}