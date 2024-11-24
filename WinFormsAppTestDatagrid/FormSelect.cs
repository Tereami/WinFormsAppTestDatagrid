using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsAppTestDatagrid
{
    public partial class FormSelect : Form
    {
        BindingList<Category> Categories;
        public List<Category> SelectedCategories = new List<Category>();
        
        public FormSelect(List<Category> selectedCategories, List<Category> allCategories)
        {
            InitializeComponent();

            Categories = new BindingList<Category>(allCategories);

            listBox1.DataSource = Categories;

            listBox1.SelectedItems.Clear();

            for (int i = 0; i < allCategories.Count; i++)
            {
                Category item = allCategories[i];
                if (selectedCategories.Contains(item))
                {
                    listBox1.SetSelected(i, true);
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            SelectedCategories = listBox1.SelectedItems.Cast<Category>().ToList();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
