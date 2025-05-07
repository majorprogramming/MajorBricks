using MajorBricks.Core.Models;
using MajorBricks.UI.ViewModels;
using Microsoft.Maui.Controls;

namespace MajorBricks.UI;


public partial class MainPage : ContentPage
{
	 private MainPageViewModel ViewModel => (MainPageViewModel)BindingContext;

	public MainPage(MainPageViewModel viewModel)
	{
		InitializeComponent(); 
		BindingContext = viewModel;
	}

	protected override async void OnAppearing()
    {
        base.OnAppearing();
    // Seed, falls leer
    
    await ViewModel.LoadSetsCommand.ExecuteAsync(null);
    }
}

