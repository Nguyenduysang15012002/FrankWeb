using System;

namespace Frank.Model.Entities
{
    internal class TableAttribute : Attribute
    {
        private string v;

        public TableAttribute(string v)
        {
            this.v = v;
        }
    }
}