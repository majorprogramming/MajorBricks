namespace MajorBricks.UI.ViewModels;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MajorBricks.Core.Models;
using MajorBricks.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

public partial class MainPageViewModel : ObservableObject
{
    public ISetRepository Repository { get; }

    private readonly ISetRepository _repository;

    public ObservableCollection<Set> Sets { get; } = new();

    public IAsyncRelayCommand LoadSetsCommand { get; }

    public MainPageViewModel(ISetRepository repository)
    {
        _repository = repository;
        LoadSetsCommand = new AsyncRelayCommand(LoadSetsAsync);
    }

    private async Task LoadSetsAsync()
    {
        var all = await _repository.GetAllSetsAsync();
        Sets.Clear();
        foreach (var set in all)
            Sets.Add(set);
    }
}
