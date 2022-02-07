using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleA.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        private string _title = "Hello from View A ViewModel";

        public string Title 
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private bool _canExecute = false;

        public  DelegateCommand ClickCommand { get; private set; }
        public bool CanExecute
        {
            get { return _canExecute; }
            set { SetProperty(ref _canExecute, value); }
        }
        public ViewAViewModel()
        {
            ClickCommand = new DelegateCommand(Click, CanClick)
                .ObservesProperty(() => CanExecute);
        }

        private bool CanClick()
        {
            return CanExecute;
        }

        private void Click()
        {
            Title = "You clicked me";
        }
    }
}
