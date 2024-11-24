using System.Collections.Generic;

namespace WinFormsAppTestDatagrid
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            List<Category> allCategories = TestData.GetSampleCategories();
            List<TableRow> sampleTable = TestData.GetSampleRows(allCategories);

            Application.Run(new FormMain(sampleTable, allCategories));
        }
    }
}