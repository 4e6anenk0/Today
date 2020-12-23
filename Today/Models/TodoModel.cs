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

        public bool IsDone
        {
            get { return _isDone; }
            set { _isDone = value; }
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public string Label
        {
            get { return _label; }
            set { _label = value; }
        }

        public DateTime EndData
        {
            get { return _endData; }
            set { _endData = value; }
        }
    }
}
