using System.ComponentModel;
using System.Diagnostics;

namespace WinFormsAppTestDatagrid
{
    public partial class FormMain : Form
    {
        public BindingList<TableRow> Rows { get; set; }
        public List<Category> AllCategories { get; set; }
        public FormMain(List<TableRow> rows, List<Category> allCategories)
        {
            InitializeComponent();

            Rows = new BindingList<TableRow>(rows);
            AllCategories = allCategories;

            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn()
            {
                DataPropertyName = nameof(TableRow.CategoriesText),
                HeaderText = "Категории",
                Name = "EditCategories",
                FillWeight = 200,
            };

            dataGridView1.Columns.Add(buttonColumn);
            dataGridView1.DataSource = Rows;
            dataGridView1.Columns["EditCategories"].DisplayIndex = 4;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            List<string> msgRows = [$"Элементов в таблице: {Rows.Count}"];
            msgRows.AddRange(Rows.Select(i => i.GetInfo()));

            MessageBox.Show(string.Join(Environment.NewLine, msgRows));
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView ?? throw new Exception("DataGridView cast error");
            if (dgv.Columns[e.ColumnIndex] is not DataGridViewButtonColumn)
                return;

            TableRow clickedRow = Rows[e.RowIndex];
            if (clickedRow.Categories == null)
                clickedRow.Categories = new List<Category>();


            FormSelect formSelect = new FormSelect(clickedRow.Categories, AllCategories);
            if (formSelect.ShowDialog() != DialogResult.OK)
                return;

            clickedRow.Categories = formSelect.SelectedCategories;

            this.Refresh();
        }
    }
}
