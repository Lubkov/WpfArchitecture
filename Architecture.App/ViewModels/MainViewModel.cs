using Architecture.App.Models;
using Architecture.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Architecture.App.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly IMapService _mapService;

        public ObservableCollection<MapModel> Maps { get; set; } = new();

        [ObservableProperty]
        private MapModel? _currentMap;

        [ObservableProperty]
        private bool _isMapSelectionPanelVisible;

        [ObservableProperty]
        private string _newMapName = string.Empty;

        public MainViewModel(IMapService mapService)
        {
            _mapService = mapService;

            _ = LoadMaps();        
        }

        private async Task LoadMaps()
        {
            Maps.Clear();
            var maps = await _mapService.GetMapsAsync();
            foreach (var item in maps)
                Maps.Add(new MapModel(item));
        }

        [RelayCommand]
        private async Task AddMap()
        {
            if (!string.IsNullOrWhiteSpace(NewMapName))
            {
                await _mapService.AddMapAsync(NewMapName);
                await LoadMaps(); 
                NewMapName = string.Empty;
            }
        }

        [RelayCommand]
        private void ToggleMapSelectionPanel()
        {
            IsMapSelectionPanelVisible = !IsMapSelectionPanelVisible;
        }

        [RelayCommand]
        private void ItemSelected(MapModel? map)
        {         
            IsMapSelectionPanelVisible = false;
            MessageBox.Show($"Selected map: #{map?.Id} {map?.Name}");
        }
    }
}
