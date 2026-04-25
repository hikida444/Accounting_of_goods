
using System.Data;
using WinFormsApp1.Models;      
using System.Text.Json;

namespace Accounting_of_goods
{
    public partial class DeliveryForm : Form
    {
        public DeliveryForm()
        {
            InitializeComponent();
        }

        private void DeliveryForm_Load(object sender, EventArgs e)
        {
            if (dgvPreview.Columns.Count == 0)
            {
                dgvPreview.Columns.Add("Article", "Артикул");
                dgvPreview.Columns.Add("Name", "Название");
                dgvPreview.Columns.Add("Size", "Размер");
                dgvPreview.Columns.Add("Quantity", "Кол-во");
                dgvPreview.Columns.Add("PurchasePrice", $"Цена закупки ({CurrencyConverter.CurrentCurrency})");
                dgvPreview.Columns.Add("SellingPrice", $"Цена продажи ({CurrencyConverter.CurrentCurrency})");
                dgvPreview.Columns.Add("ExpiryDate", "Срок годности");

                DataGridViewButtonColumn deleteCol = new DataGridViewButtonColumn();
                deleteCol.Name = "Delete";
                deleteCol.HeaderText = "";
                deleteCol.Text = "🗑️";
                deleteCol.UseColumnTextForButtonValue = true;
                deleteCol.Width = 40;
                dgvPreview.Columns.Add(deleteCol);
            }

            dgvPreview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPreview.AllowUserToAddRows = false;
            dgvPreview.RowHeadersVisible = false;

            LoadProducts();
        }
        private void LoadProducts()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var products = db.Products.Select(p => p.Name).Distinct().ToList();
                products.Insert(0, "— Выберите товар —");
                cmbProduct.DataSource = products;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void numQty_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedIndex <= 0)
            {
                cmbSize.DataSource = null;
                return;
            }

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var sizes = db.Products
                              .Where(p => p.Name == cmbProduct.Text)
                              .Select(p => new { p.Article, p.Size })
                              .ToList();

                cmbSize.DataSource = sizes;
                cmbSize.DisplayMember = "Size";
                cmbSize.ValueMember = "Article";
            }
        }

        private void btnConfirmDelivery_Click(object sender, EventArgs e)
        {
            if (dgvPreview.Rows.Count == 0)
            {
                MessageBox.Show("Список поставок пуст!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (DataGridViewRow row in dgvPreview.Rows)
                        {
                            string article = row.Cells["Article"].Value.ToString();
                            int qty = Convert.ToInt32(row.Cells["Quantity"].Value);
                            decimal purchasePrice = Convert.ToDecimal(row.Cells["PurchasePrice"].Value);
                            decimal sellingPrice = Convert.ToDecimal(row.Cells["SellingPrice"].Value);

                            DateTime expiry = Convert.ToDateTime(row.Cells["ExpiryDate"].Value).ToUniversalTime();

                            var product = db.Products.FirstOrDefault(p => p.Article == article);

                            if (product != null)
                            {
                                product.CurrentStock += qty;
                                product.PurchasePrice = purchasePrice; 
                                product.SellingPrice = sellingPrice;  
                                product.ExpiryDate = expiry;
                            }
                            else
                            {
                                throw new Exception($"Товар с артикулом {article} не найден в справочнике. Добавьте его через главное меню.");
                            }
                        }

                        db.SaveChanges();
                        transaction.Commit();

                        MessageBox.Show("Поставка успешно оприходована! Остатки обновлены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Ошибка при сохранении: " + ex.Message, "Отмена операции", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedIndex <= 0 || cmbSize.SelectedItem == null)
            {
                MessageBox.Show("Выберите товар и размер!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numQty.Value <= 0 || numPrice.Value <= 0 || numSellingPrice.Value <= 0)
            {
                MessageBox.Show("Количество и цены должны быть больше 0!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpExpiry.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Нельзя добавить товар с истекшим сроком годности!", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string article = cmbSize.SelectedValue.ToString();
            string name = cmbProduct.Text;
            string size = cmbSize.Text;
            int qty = (int)numQty.Value;
            decimal purchasePrice = numPrice.Value;
            decimal sellingPrice = numSellingPrice.Value;
            string expiry = dtpExpiry.Value.ToShortDateString();

            dgvPreview.Rows.Add(article, name, size, qty, purchasePrice, sellingPrice, expiry);

            numQty.Value = 0;
            numPrice.Value = 0;
            numSellingPrice.Value = 0;
        }

        private void dgvPreview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvPreview.Columns[e.ColumnIndex].Name == "Delete")
            {
                dgvPreview.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JSON файлы (*.json)|*.json|Все файлы (*.*)|*.*" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string jsonString = File.ReadAllText(ofd.FileName);
                        var importedItems = JsonSerializer.Deserialize<List<ImportItem>>(jsonString);

                        if (importedItems != null)
                        {
                            foreach (var item in importedItems)
                            {
                                decimal displayPrice = CurrencyConverter.ConvertPrice(item.Price);
                                dgvPreview.Rows.Add(item.Article, item.Name, item.Size, item.Quantity, item.PurchasePrice, item.SellingPrice, item.ExpiryDate);
                            }
                            MessageBox.Show("Данные успешно загружены в таблицу.", "Импорт завершен", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при чтении или обработке JSON файла: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }

    public class ImportItem
    {
        public string Article { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string ExpiryDate { get; set; }

        public decimal PurchasePrice { get; set; } 
        public decimal SellingPrice { get; set; }
    }
}
