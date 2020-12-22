using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Today.Models
{
    class TodoModel
    {
        private bool _isDone;
        private string _text;

        public DateTime DataCreation { get; set; } = DateTime.Now;

        public bool isDone
        {
            get { return _isDone; }
            set { _isDone = value; }
        }

        public string text
        {
            get { return _text; }
            set { _text = value; }
        }
    }
}
