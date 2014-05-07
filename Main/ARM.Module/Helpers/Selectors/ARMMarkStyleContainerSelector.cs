using System.Windows;
using System.Windows.Controls;
using ARM.Data.Models;

namespace ARM.Module.Helpers.Selectors
{
    public class ARMMarkStyleContainerSelector :  StyleSelector
    {

        public Style Normal { get; set; }

        public Style Certification { get; set; }


        public override Style SelectStyle(object item, DependencyObject container)
        {
            var mark = item as Mark;
            if (mark == null)
                return Normal;
            return mark.Type != MarkType.Certification ? Normal : Certification;
        }
    }
}