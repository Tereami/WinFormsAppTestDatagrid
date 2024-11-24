using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WinFormsAppTestDatagrid
{
    public static class TestData
    {
        public static List<TableRow> GetSampleRows(List<Category> allCategories)
        {
            List<TableRow> list =
            [
                new TableRow { Name = "Оси и уровни", Count = 1, Price = 10, Categories = [ allCategories[0], allCategories[1] ] },
                new TableRow { Name = "Полы", Count = 11, Categories = [ allCategories[2] ] },
                new TableRow { Name = "Конструкции", Count = 111, Price = 1000, Categories = [ allCategories[3], allCategories[4] ] },
            ];
            return list;
        }

        public static List<Category> GetSampleCategories()
        {
            List<Category> list =
            [
                new Category("OST_Levels", "Уровни"),
                new Category("OST_Grids", "Оси"),
                new Category("OST_Floors", "Плиты"),
                new Category("OST_Walls", "Стены"),
                new Category("OST_Roofs", "Крыши"),
                new Category("OST_Columns", "Колонны"),
                new Category("OST_Beams", "Балки"),
                new Category("OST_Doors", "Двери"),
                new Category("OST_Windows", "Окна"),
            ];

            return list;
        }

        public static string GetInfo(this TableRow row)
        {
            string active = row.Activate ? "вкл" : "выкл";
            string cats = string.Join(" + ", row.Categories);
            string msg = $"{row.Name}, {row.Count}шт, {row.Price}р., {active}, категорий: {row.Categories.Count} ({cats})";
            return msg;
        }

    }
}
