using Accounting_of_goods;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WinFormsApp1.Models;

namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        private WinFormsApp1.Models.User _loggedInUser;
        public MainForm(WinFormsApp1.Models.User user)
        {
            InitializeComponent();
            _loggedInUser = user;
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            if (_loggedInUser == null) return;

            if (_loggedInUser.RoleId == 1)
            {
                btnShipment.Visible = false;

                btnAddProduct.Visible = true;
                btnHistory.Visible = true;
                btnManageCategories.Visible = true;

                ShowEditDeleteButtons(true);
            }
            else if (_loggedInUser.RoleId == 2)
            {
                btnAddProduct.Visible = false;
                btnHistory.Visible = false;
                btnManageCategories.Visible = false;
                btnShipment.Visible = true;

                ShowEditDeleteButtons(false);
            }
            LoadData();
            AddSearchIcon(txtSearch);
        }

        private void ShowEditDeleteButtons(bool visible)
        {
            if (dgvProducts.Columns["EditColumn"] != null)
            {
                dgvProducts.Columns["EditColumn"].Visible = visible;
            }

            if (dgvProducts.Columns["DeleteColumn"] != null)
            {
                dgvProducts.Columns["DeleteColumn"].Visible = visible;
            }
        }

        private void LoadData(string searchText = "")
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var query = db.Products.Include(p => p.Category).AsQueryable();

                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    searchText = searchText.ToLower();

                    query = query.Where(p =>
                        p.Article.ToLower().Contains(searchText) ||
                        p.Brand.ToLower().Contains(searchText) ||
                        p.Name.ToLower().Contains(searchText) ||
                        p.Category != null && p.Category.Name.ToLower().Contains(searchText)
                    );
                }

                var products = query
                    .Select(p => new
                    {
                        Артикул = p.Article,
                        Бренд = p.Brand,
                        Название = p.Name,
                        Категория = p.Category != null ? p.Category.Name : "Без категории",
                        Размер = p.Size,
                        Цена = p.SellingPrice,
                        Остаток = p.CurrentStock,
                        Срок_Актуальности = p.ExpiryDate.HasValue
                            ? p.ExpiryDate.Value.ToLocalTime().ToShortDateString()
                            : "-"
                    })
                    .ToList();

                dgvProducts.DataSource = products;
                dgvProducts.RowHeadersVisible = false;

                if (dgvProducts.Columns["EditColumn"] == null)
                {
                    DataGridViewButtonColumn editCol = new DataGridViewButtonColumn();
                    editCol.Name = "EditColumn";
                    editCol.HeaderText = "";
                    editCol.Text = "✏️";
                    editCol.UseColumnTextForButtonValue = true;
                    editCol.Width = 35;
                    dgvProducts.Columns.Add(editCol);
                }

                if (dgvProducts.Columns["DeleteColumn"] == null)
                {
                    DataGridViewButtonColumn delCol = new DataGridViewButtonColumn();
                    delCol.Name = "DeleteColumn";
                    delCol.HeaderText = "";
                    delCol.Text = "🗑️";
                    delCol.UseColumnTextForButtonValue = true;
                    delCol.Width = 35;
                    dgvProducts.Columns.Add(delCol);
                }

                if (_loggedInUser != null)
                {
                    bool isAdmin = _loggedInUser.RoleId == 1;
                    ShowEditDeleteButtons(isAdmin);
                }
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            ProductAddForm addForm = new ProductAddForm();

            addForm.ShowDialog();
            LoadData();
        }

        private void btnShipment_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow != null)
            {
                string selectedArticle = dgvProducts.CurrentRow.Cells["Артикул"].Value.ToString();
                ShipmentForm shipForm = new ShipmentForm(selectedArticle, _loggedInUser.Id);
                shipForm.ShowDialog();
                LoadData();
            }
            else
            {
                MessageBox.Show("Сначала выберите товар в таблице!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            HistoryForm history = new HistoryForm();
            history.ShowDialog();
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (_loggedInUser.RoleId != 1)
            {
                return;
            }

            string article = dgvProducts.Rows[e.RowIndex].Cells["Артикул"].Value.ToString();

            if (dgvProducts.Columns[e.ColumnIndex].Name == "DeleteColumn")
            {
                var result = MessageBox.Show($"Вы уверены, что хотите безвозвратно удалить товар с артикулом {article}?",
                                             "Подтверждение удаления",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    using (ApplicationDbContext db = new ApplicationDbContext())
                    {
                        var product = db.Products.FirstOrDefault(p => p.Article == article);
                        if (product != null)
                        {
                            db.Products.Remove(product);
                            db.SaveChanges();
                            LoadData();
                        }
                    }
                }
            }
            else if (dgvProducts.Columns[e.ColumnIndex].Name == "EditColumn")
            {
                ProductEditForm editForm = new ProductEditForm(article);
                editForm.ShowDialog();
                LoadData();
            }
        }

        private void категорииToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dgvCategories categoryForm = new dgvCategories();
            categoryForm.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text);
        }

        private void сменитьАккаунтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите выйти из текущего аккаунта?", "Смена аккаунта", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                Application.Restart();
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите закрыть программу?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void AddSearchIcon(TextBox tb)
        {
            Label searchIcon = new Label();
            searchIcon.Text = "🔍";
            searchIcon.AutoSize = true;
            searchIcon.BackColor = tb.BackColor;
            searchIcon.ForeColor = Color.Gray;
            searchIcon.Cursor = Cursors.IBeam;

            searchIcon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            searchIcon.Location = new Point(tb.Width - 25, 2);
            searchIcon.Click += (s, e) => tb.Focus();
            tb.Controls.Add(searchIcon);
        }

        private void btnSupply_Click(object sender, EventArgs e)
        {
            DeliveryForm deliveryForm = new DeliveryForm();
            deliveryForm.ShowDialog();
            LoadData();
        }
    }
}