using System.Windows;
using MvvmDI.ViewModels;

namespace MvvmDI.Views
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainWindowViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
