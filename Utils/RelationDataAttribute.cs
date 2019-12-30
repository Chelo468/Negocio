using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class RelationDataAttribute : Attribute
    {
        //public string Class { get; set; }
        public string Atributte { get; set; }

        public RelationDataAttribute(string atributte)
        {
            //this.Class = nameClass;
            this.Atributte = atributte;
        }
    }
}
