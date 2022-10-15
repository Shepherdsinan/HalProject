using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrmPosHalYonetim
{
    public class ComboItem
    {
        public object Value { get; set; }
        public string Text { get; set; }
        public override string ToString()
        {
            return this.Text;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            ComboItem item = obj as ComboItem;
            if (item == null)
                return false;
            if (item.Value == this.Value)
                return true;
            else
                return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
