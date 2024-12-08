

using AppListaDeTareasPablo.MVVM.Models;
using AppListaDeTareasPablo.MVVM.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppListaDeTareasPablo.MVVM.ViewModels
{
    public class MainPageView : INotifyPropertyChanged
    {
        public ObservableCollection<Tarea> Tareas { get; }
       
        public ICommand ComandoAgregarTarea { get; }
        public ICommand ComandoEliminarTarea { get; }


        public MainPageView()
        {
            Tareas = new ObservableCollection<Tarea>
            {
                new Tarea { nombre = "Estudiar AD", completada = false },
                new Tarea { nombre = "Estudiar PSP", completada = true },
                new Tarea { nombre = "Estudiar Moviles", completada = false },
                new Tarea { nombre = "Estudiar Empresa", completada = true },
                new Tarea { nombre = "Estudiar SGE", completada = false }
            };

           
            ComandoAgregarTarea = new Command(AgregarTarea);
            ComandoEliminarTarea = new Command<Tarea>(EliminarTarea);

        }
      

       private async void AgregarTarea()
        {
            
            var nuevaTarea = new Tarea
            {
                nombre = "",
                completada = false
            };
            bool nuevo =true;

            var pantallaDetalle = new PantallaDetalle(nuevaTarea, nuevo);

            pantallaDetalle.TareaActualizada += (sender, tareaModificada) =>
            {
               
                Tareas.Add(tareaModificada);
                 
            };

            await Application.Current.MainPage.Navigation.PushAsync(pantallaDetalle);
        }

         private void EliminarTarea(Tarea tarea)
        { 
            Tareas.Remove(tarea);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

