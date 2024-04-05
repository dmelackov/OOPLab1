using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class EuropaTime : IComponent
    {
        private CultureInfo culture;
        public EuropaTime()
        {
            culture = new CultureInfo("es-ES");
        }
        public string operation()
        {
            return DateTime.Now.ToString(this.culture);
        }
    }
}
