using AppListaDeTareasPablo.MVVM.Models;
using AppListaDeTareasPablo.MVVM.ViewModels;

namespace AppListaDeTareasPablo.MVVM.Views;

public partial class PantallaDetalle : ContentPage
{
    public event EventHandler<Tarea> TareaActualizada;
    private Tarea _tareuca;
    private bool _Nueva;

    public PantallaDetalle(Tarea tarea, bool nueva = false)
    {
        InitializeComponent();

        _tareuca = tarea;
        _Nueva = nueva;

        BindingContext = new PantallaDetalleView
        {
            Nombre = tarea.nombre,
            Completada = tarea.completada
        };
    }
    private void OnSaveButtonClicked(object sender, EventArgs e)
    {    
        var viewModel = (PantallaDetalleView)BindingContext;
        _tareuca.nombre = viewModel.Nombre;
        _tareuca.completada = viewModel.Completada;
        
        TareaActualizada?.Invoke(this, _tareuca);

        Navigation.PopAsync();
    }
}

