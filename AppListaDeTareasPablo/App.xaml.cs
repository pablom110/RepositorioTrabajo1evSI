using AppListaDeTareasPablo.MVVM.Views;

namespace AppListaDeTareasPablo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage()); 
        }
    }
}
