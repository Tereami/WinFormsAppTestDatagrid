using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAppTestDatagrid
{
    public class Category
    {
        public string InternalName { get; set; } = string.Empty;

        public string DisplayName { get; set; } = string.Empty;

        public Category(string internalName, string displayName)
        {
            InternalName = internalName;
            DisplayName = displayName;
        }

        public override string ToString()
        {
            return DisplayName;
        }
    }
}
