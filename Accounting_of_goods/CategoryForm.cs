using WinFormsApp1.Models;

namespace WinFormsApp1
{
    public partial class dgvCategories : Form
    {
        public dgvCategories()
        {
            InitializeComponent();
        }

        private void dgvCategories_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowHeadersVisible = false; 

            LoadCategories(); 
        }
        private void LoadCategories()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var categories = db.Categories
                    .Select(c => new
                    {
                        ID = c.Id,
                        Название = c.Name
                    })
                    .ToList();

                dataGridView1.DataSource = categories;

                if (dataGridView1.Columns["EditCol"] == null)
                {
                    DataGridViewButtonColumn editCol = new DataGridViewButtonColumn();
                    editCol.HeaderText = "";
                    editCol.Name = "EditCol";
                    editCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    editCol.Text = "✏️";
                    editCol.UseColumnTextForButtonValue = true;
                    editCol.Width = 40;
                    editCol.FlatStyle = FlatStyle.Flat;
                    editCol.DefaultCellStyle.SelectionBackColor = Color.White;
                    dataGridView1.Columns.Add(editCol);
                }

                if (dataGridView1.Columns["DeleteCol"] == null)
                {
                    DataGridViewButtonColumn delCol = new DataGridViewButtonColumn();
                    delCol.Name = "DeleteCol";
                    delCol.HeaderText = "";
                    delCol.Text = "🗑️";
                    delCol.UseColumnTextForButtonValue = true;
                    delCol.Width = 40;
                    delCol.FlatStyle = FlatStyle.Flat;
                    delCol.DefaultCellStyle.SelectionBackColor = Color.White;
                    dataGridView1.Columns.Add(delCol);
                }
            }
        }

        private void btnCreateCategory_Click(object sender, EventArgs e)
        {
            string categoryName = txtNewCategory.Text.Trim();

            if (string.IsNullOrEmpty(categoryName))
            {
                MessageBox.Show("Пожалуйста, введите название новой категории!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                bool exists = db.Categories.Any(c => c.Name.ToLower() == categoryName.ToLower());

                if (exists)
                {
                    MessageBox.Show("Такая категория уже существует в справочнике!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Category newCategory = new Category
                {
                    Name = categoryName
                };

                db.Categories.Add(newCategory);
                db.SaveChanges();

                MessageBox.Show("Категория успешно добавлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtNewCategory.Clear(); 
                LoadCategories();       
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int categoryId = (int)dataGridView1.Rows[e.RowIndex].Cells["ID"].Value;
            string currentName = dataGridView1.Rows[e.RowIndex].Cells["Название"].Value.ToString();

            if (dataGridView1.Columns[e.ColumnIndex].Name == "DeleteCol")
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    bool hasProducts = db.Products.Any(p => p.CategoryId == categoryId);

                    if (hasProducts)
                    {
                        MessageBox.Show($"Нельзя удалить категорию «{currentName}», так как на складе есть товары из этой категории!\n\nСначала удалите эти товары или измените их категорию.",
                                        "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var result = MessageBox.Show($"Вы уверены, что хотите удалить категорию «{currentName}»?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        var cat = db.Categories.Find(categoryId);
                        if (cat != null)
                        {
                            db.Categories.Remove(cat);
                            db.SaveChanges();
                            LoadCategories(); 
                        }
                    }
                }
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "EditCol")
            {
                Form prompt = new Form()
                {
                    Width = 350,
                    Height = 150,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = "Изменить название категории",
                    StartPosition = FormStartPosition.CenterParent,
                    MaximizeBox = false
                };

                TextBox textName = new TextBox() { Left = 20, Top = 20, Width = 290, Text = currentName };
                Button confirmation = new Button() { Text = "Сохранить", Left = 210, Top = 60, Width = 100, DialogResult = DialogResult.OK };

                prompt.Controls.Add(textName);
                prompt.Controls.Add(confirmation);
                prompt.AcceptButton = confirmation;

                if (prompt.ShowDialog() == DialogResult.OK)
                {
                    string newName = textName.Text.Trim();
                    if (!string.IsNullOrEmpty(newName) && newName != currentName)
                    {
                        using (ApplicationDbContext db = new ApplicationDbContext())
                        {
                            var cat = db.Categories.Find(categoryId);
                            if (cat != null)
                            {
                                cat.Name = newName;
                                db.SaveChanges();
                                LoadCategories(); 
                            }
                        }
                    }
                }
            }
        }
    }
}
