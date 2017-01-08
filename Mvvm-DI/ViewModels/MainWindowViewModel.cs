using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

// ReSharper disable once CheckNamespace
namespace MvvmDI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _currentViewModel;
        private readonly FirstViewModel _firstViewModel;
        private readonly SecondViewModel _secondViewModel;
        private readonly ThirdViewModel _thirdViewModel;
        private readonly IMessenger _messenger;

        public RelayCommand ShowFirstViewCommand { get; set; }
        public RelayCommand ShowSecondViewCommand { get; set; }
        public RelayCommand ShowThirdViewCommand { get; set; }

        public ViewModelBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set { Set(ref _currentViewModel, value); }
        }

        public MainWindowViewModel(
            FirstViewModel firstViewModel,
            SecondViewModel secondViewModel,
            ThirdViewModel thirdViewModel,
            IMessenger messenger)
        {
            _firstViewModel = firstViewModel;
            _secondViewModel = secondViewModel;
            _thirdViewModel = thirdViewModel;
            _messenger = messenger;

            messenger.Register<ChangePageMessage>(this, ChangePage);
            ShowFirstViewCommand = new RelayCommand(ShowFirstView);
            ShowSecondViewCommand = new RelayCommand(ShowSecondView);
            ShowThirdViewCommand = new RelayCommand(ShowThirdView);
        }

        private void ChangePage(ChangePageMessage message)
        {
            CurrentViewModel = message.ViewModel;
        }

        private void ShowFirstView()
        {
            _messenger.Send(new ChangePageMessage(_firstViewModel));
        }

        private void ShowSecondView()
        {
            _messenger.Send(new ChangePageMessage(_secondViewModel));
        }

        private void ShowThirdView()
        {
            _messenger.Send(new ChangePageMessage(_thirdViewModel));
        }
    }

    public class ChangePageMessage
    {
        public ChangePageMessage(ViewModelBase viewModel)
        {
            ViewModel = viewModel;
        }

        public ViewModelBase ViewModel { get; set; }
    }
}
