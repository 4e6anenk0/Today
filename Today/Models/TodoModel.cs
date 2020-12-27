using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Today.Models
{
    public class Todo
    {
        public int TodoId { get; set; }

        public DateTime DataCreation { get; set; } = DateTime.Now;

        public bool IsDone { get; set; }

        [StringLength(200)]
        public string Text { get; set; }

        public DateTime? EndData { get; set; }

        public int? LabelId { get; set; }

        public Label Label { get; set; }

        public int? ColorDataId { get; set; }

        public ColorData ColorData { get; set; }

    }

    public class Label
    {
        public int LabelId { get; set; }

        [StringLength(30)]
        public string LabelText { get; set; }

        public int Prority { get; set; }

        public virtual ICollection<Todo> Todos { get; set; }

        public Label()
        {
            Todos = new List<Todo>();
        }
    }


    public class ColorData
    {
        public int ColorDataId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Todo> Todos { get; set; }

        public ColorData()
        {
            Todos = new List<Todo>();
        }

        public Int32 Argb
        {
            get
            {
                return Color.ToArgb();
            }
            set
            {
                Color = Color.FromArgb(value);
            }
        }

        [NotMapped]
        public Color Color { get; set; }
    }
}
