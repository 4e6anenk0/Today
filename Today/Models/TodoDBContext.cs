using System;
using System.Data.Entity;
using System.Linq;

namespace Today.Models
{
    public class TodoDBContext : DbContext
    {
       
        public TodoDBContext()
            : base("name=TodoDBContext")
        {
        }

        public virtual DbSet<Todo> Todos { get; set; }
        public virtual DbSet<Label> Labels { get; set; }
        public virtual DbSet<ColorData> Colors { get; set; }

    }
}