using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class TextBeforeAppenderDecorator : AbstractDecorator
    {
        private string _text;

        public TextBeforeAppenderDecorator(IComponent component, string text) : base(component)
        {
            _text = text;
        }
        public override string operation()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this._text);
            sb.Append(this._component.operation());
            return sb.ToString();
        }
    }
}
