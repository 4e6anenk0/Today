using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using Today.Infrastructure.Commands;
using Today.Models;
using Today.Services;
using Today.ViewModels.Base;

namespace Today.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private string _title = "Today";
       
        private ObservableCollection<Todo> _todos;
        
        private Todo _selectedTodo;

        public ObservableCollection<Todo> Todos
        {
            get { return _todos; }
            set { Set(ref _todos, value); }
        }

        public Todo SelectedTodo
        {
            get { return _selectedTodo; }
            set
            {
                Set(ref _selectedTodo, value);
            }
        }

    

        //private void GetAllTodos()
        //{
        //    _todos = DataFactory.GetAllTodos();
        //}


        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        private string _text;
        public string Text
        {
            get { return _text; }
            set
            {
                if(_selectedTodo.Text != value) { 
                Set(ref _text, value);
                }
            }
        }

        

        private bool _isDone;
        public bool IsDone
        {
            get { return _isDone; }
            set { Set(ref _isDone, value); }
        }


        private DateTime _dataCreation;
        public DateTime DataCreation
        {
            get { return _dataCreation; }
            set { Set(ref _dataCreation, value); }
        }




        // -----------------------------------------------------------------------------------------------------
        #region Команды

        #region CloseAppCommand
        public ICommand CloseAppCommand { get; }

        private void OnCloseAppCommandExecuted(object p)
        {
            
            Application.Current.Shutdown();
        }

        private bool CanCloseAppCommandExecute(object p) => true;
        #endregion

        #region DeleteTodoCommand
        public ICommand DeleteTodoCommand { get; }
        //public DelegateCommand _deleteTaskCmd;
       
        private void OnDeleteTodoCommandExecuted(object p)
        {
            DataFactory.DeleteTodo(_selectedTodo);
            Todos.Remove(_selectedTodo);
        }

        private bool CanDeleteTodoCommandExecute(object p)
        {
            return (_selectedTodo as Todo) != null;
        }

        #endregion

        #region AddBlankTodocommand

        public ICommand AddBlankTodoCommand { get; }

        private void OnAddBlankTodoCommandExecuted(object p)
        {
            var blankTodo = new Todo();
            Todos.Add(blankTodo);
            DataFactory.AddTodo(blankTodo);
        }

        private bool CanAddBlankTodoCommandExecute(object p)
        {
            return true;
        }

        #endregion

        //#region TextBoxIsChangedCommand

        //public ICommand TextBoxIsChangedCommand { get; }

        //private void OnTextBoxIsChangedCommandExecuted(object p)
        //{
        //    DataFactory.Update(_isChangedTodo);
        //}

        //private bool CanTextBoxIsChangedCommandExecute(object p)
        //{
        //   return (_text as string) != "";
        //}

        #region SaveTodoCommand

        public ICommand SaveTodoCommand { get; }

        private void OnSaveTodoCommandExecuted(object p)
        {
            DataFactory.UpdateTodo(_selectedTodo);
            
        }

        private bool CanSaveTodoCommandExecute(object p)
        {
            return true;
        }

        #endregion


        //#endregion

        #endregion
        // -----------------------------------------------------------------------------------------------------

        public MainWindowViewModel()
        {
           

            var db = new TodoDBContext();
            db.Todos.Load();

            //this.GetAllTodos();

            this.Todos = db.Todos.Local;

            // -----------------------------------------------------------------------------------------------------
            #region Команды

            CloseAppCommand = new LambdaCommand(OnCloseAppCommandExecuted, CanCloseAppCommandExecute);
            DeleteTodoCommand = new LambdaCommand(OnDeleteTodoCommandExecuted, CanDeleteTodoCommandExecute);
            AddBlankTodoCommand = new LambdaCommand(OnAddBlankTodoCommandExecuted, CanAddBlankTodoCommandExecute);
            //TextBoxIsChangedCommand = new LambdaCommand(OnTextBoxIsChangedCommandExecuted, CanTextBoxIsChangedCommandExecute);
            SaveTodoCommand = new LambdaCommand(OnSaveTodoCommandExecuted, CanSaveTodoCommandExecute);
            #endregion
            // -----------------------------------------------------------------------------------------------------
        }

    }
}
