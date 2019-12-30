using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class AlternativeNameAttribute : Attribute
    {
        public string alternativeName { get; set; }

        public AlternativeNameAttribute(string alternativeName)
        {
            this.alternativeName = alternativeName;
        }
    }
}
