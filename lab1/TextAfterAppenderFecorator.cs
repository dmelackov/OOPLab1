using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class TextAfterAppenderFecorator : AbstractDecorator
    {
        private string _text;

        public TextAfterAppenderFecorator(IComponent component, string text) : base(component)
        {
            _text = text;
        }
        public override string operation()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this._component.operation());
            sb.Append(this._text);
            return sb.ToString();
        }
    }
}
