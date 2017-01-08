using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using MvvmDI.ViewModels;
using MvvmDI.Views;
using SimpleInjector;

namespace MvvmDI
{
    public partial class App : Application
    {
        private readonly Container _container = new Container();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _container.Register<FirstViewModel>();
            _container.Register<SecondViewModel>();
            _container.Register<ThirdViewModel>();
            _container.Register<MainWindowViewModel>();
            _container.Register<MainWindow>();
            _container.Register<IMessenger, Messenger>();

            var window = _container.GetInstance<MainWindow>();
            window.Show();
        }
    }
}
