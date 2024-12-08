using AppListaDeTareasPablo.MVVM.Models;
using AppListaDeTareasPablo.MVVM.ViewModels;

namespace AppListaDeTareasPablo.MVVM.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		BindingContext = new MainPageView();
	}
    private async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Tarea tareaSeleccionada)
        {
            var pantallaDetalle = new PantallaDetalle(tareaSeleccionada);

            await Navigation.PushAsync(pantallaDetalle);

            ((CollectionView)sender).SelectedItem = null;
        }
    }

}
