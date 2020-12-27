using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
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

        private void GetAllTodos()
        {
            _todos = DataFactory.GetAllTodos();
        }

        private void UpdateCollection()
        {
            ObservableCollection<Todo> updateTodoCollection = DataFactory.GetAllTodos();
            _todos.Clear();
        }
       

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
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
            //Todos.Add(blankTodo);
            DataFactory.AddTodo(blankTodo);
            
            
        }

        private bool CanAddBlankTodoCommandExecute(object p)
        {
            return true;
        }

        #endregion

        #endregion
        // -----------------------------------------------------------------------------------------------------

        public MainWindowViewModel()
        {
            using (TodoDBContext context = new TodoDBContext())
            {
                //Todo todo1 = new Todo();
                //ColorData green = new ColorData();
                //green.Color = Color.Green;
                //todo1.ColorData = green;
                //todo1.EndData = DateTime.Now;
                //todo1.IsDone = true;
                //todo1.Text = "Cдать C#";
                //Label newL = new Label();
                //newL.LabelText = "Вуз";
                //newL.Prority = 1;
                //todo1.Label = newL;

                //context.Todos.Add(todo1);
                //context.SaveChanges();
            }

            this.GetAllTodos();

            // -----------------------------------------------------------------------------------------------------
            #region Команды

            CloseAppCommand = new LambdaCommand(OnCloseAppCommandExecuted, CanCloseAppCommandExecute);
            DeleteTodoCommand = new LambdaCommand(OnDeleteTodoCommandExecuted, CanDeleteTodoCommandExecute);
            AddBlankTodoCommand = new LambdaCommand(OnAddBlankTodoCommandExecuted, CanAddBlankTodoCommandExecute);
            #endregion
            // -----------------------------------------------------------------------------------------------------
        }

    }
}
