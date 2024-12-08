using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AppListaDeTareasPablo.MVVM.Models
{
    public class Tarea : INotifyPropertyChanged
    {
        private string _nombre;
        private bool _completada;

        public string nombre
        {
            get => _nombre;
            set
            {
                if (_nombre != value)
                {
                    _nombre = value;
                    OnPropertyChanged(nameof(nombre));
                }
            }
        }

        public bool completada
        {
            get => _completada;
            set
            {
                if (_completada != value)
                {
                    _completada = value;
                    OnPropertyChanged(nameof(completada));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
