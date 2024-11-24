using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAppTestDatagrid
{
    public class TableRow
    {
        //[DisplayName("Имя")]
        public string Name { get; set; } = "Noname";

        [DisplayName("Количество")]
        public int Count { get; set; }

        [DisplayName("Цена")]
        public decimal Price { get; set; }

        [DisplayName("Активен")]
        public bool Activate { get; set; }


        public string CategoriesText
        {
            get { return Categories == null ? "" : string.Join(", ", Categories); }
        }


        public List<Category> Categories { get; set; }
    }
}
