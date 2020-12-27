using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Today.Models;

namespace Today.Services
{
    public class DataFactory
    {
        // Crud + другие запросы к БД

        public static ObservableCollection<Todo> GetAllTodos()
        {
            using (var context = new TodoDBContext())
            {
                return new ObservableCollection<Todo>(context.Todos.ToList());
            }
        }


        public static void AddTodo(Todo todo)
        {
            using (var context = new TodoDBContext())
            {
                context.Todos.Add(todo);
                context.SaveChanges();
            }
        }

        public static void DeleteTodo(Todo todo)
        {
            using (var context = new TodoDBContext())
            {
                context.Entry(todo).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public static void UpdateTodo(Todo todo)
        {
            using (var context = new TodoDBContext())
            {
                var todoToUpdate = context.Todos.Find(todo.TodoId);
                todoToUpdate.Text = todo.Text;
                todoToUpdate.IsDone = todo.IsDone;
                todoToUpdate.Label = todo.Label;
                todoToUpdate.ColorData = todo.ColorData;
                todoToUpdate.EndData = todo.EndData;
                context.SaveChanges();
            }
        }

    }
}
