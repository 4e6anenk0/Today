using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Today.Infrastructure.Commands;
using Today.ViewModels.Base;

namespace Today.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        #region Команды

        #region
        public ICommand CloseAppCommand { get; }

        private void OnCloseAppCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }

        private bool CanCloseAppCommandExecuted(object p) => true;
        #endregion

        #endregion

        public MainWindowViewModel()
        {
            #region Команды

            CloseAppCommand = new LambdaCommand(OnCloseAppCommandExecuted, CanCloseAppCommandExecuted);

            #endregion
        }

    }
}
