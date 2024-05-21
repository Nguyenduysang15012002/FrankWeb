using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Model.Common
{
    public class CustomDisplayNameAttribute : Attribute
    {
        private string text;
        public CustomDisplayNameAttribute(string text)
        {
            this.Text = text;
        }

        public string Text
        {
            get { return this.text; }
            set { this.text = value; }
        }
    }
}
