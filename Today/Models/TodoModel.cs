using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Today.Models
{
    internal class TodoModel
    {
        private bool _isDone;
        private string _text;
        private string _label;
        private DateTime _endData;

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

        public string label
        {
            get { return _label; }
            set { _label = value; }
        }

        public DateTime endData
        {
            get { return _endData; }
            set { _endData = value; }
        }
    }
}
