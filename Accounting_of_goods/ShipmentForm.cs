using Accounting_of_goods;
using System.Data;
using WinFormsApp1.Models;

namespace WinFormsApp1
{
    public partial class ShipmentForm : Form
    {
        private string _article;
        private int _userId;

        public ShipmentForm(string article, int userId)
        {
            InitializeComponent();
            _article = article;
            _userId = userId;
        }

        public ShipmentForm()
        {
            InitializeComponent();
        }

        private void ShipmentForm_Load(object sender, EventArgs e)
        {
            if (dgvCart.Columns.Count == 0)
            {
                dgvCart.Columns.Add("ProductId", "ID");
                dgvCart.Columns["ProductId"].Visible = false;
                dgvCart.Columns.Add("Article", "Артикул");
                dgvCart.Columns.Add("ProductName", "Название");
                dgvCart.Columns.Add("Size", "Размер");
                dgvCart.Columns.Add("Quantity", "Кол-во");
                dgvCart.Columns.Add("Price", $"Цена ({CurrencyConverter.CurrentCurrency})");
                dgvCart.Columns.Add("Sum", $"Сумма ({CurrencyConverter.CurrentCurrency})");
                dgvCart.Columns.Add("Expiry", "Срок акт-сти");
                dgvCart.Columns["ProductName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvCart.RowHeadersVisible = false;
                dgvCart.AllowUserToAddRows = false;

                DataGridViewButtonColumn deleteCol = new DataGridViewButtonColumn();
                deleteCol.Name = "Delete";
                deleteCol.HeaderText = "";
                deleteCol.Text = "✖";
                deleteCol.UseColumnTextForButtonValue = true;
                deleteCol.Width = 40;
                dgvCart.Columns.Add(deleteCol);
            }

            textBox2.ReadOnly = true;
            textBox2.BackColor = SystemColors.ControlLight;
            textBox2.Text = "0";

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var uniqueNames = db.Products
                    .Where(p => p.Name != null && p.Name != "")
                    .Select(p => p.Name)
                    .Distinct()
                    .ToList();

                if (uniqueNames.Count > 0)
                {
                    var list = new System.Collections.Generic.List<string>();
                    list.Add("— Выберите товар —");
                    list.AddRange(uniqueNames);

                    cmbProduct.DataSource = list;
                    cmbProduct.DropDownStyle = ComboBoxStyle.DropDownList;
                    cmbProduct.SelectedIndex = 0;

                    if (!string.IsNullOrEmpty(_article))
                    {
                        var product = db.Products.FirstOrDefault(p => p.Article == _article);
                        if (product != null && uniqueNames.Contains(product.Name))
                        {
                            int index = list.IndexOf(product.Name);
                            if (index > 0)
                            {
                                cmbProduct.SelectedIndex = 0;
                            }
                        }
                    }
                }
            }
        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedItem == null ||
                cmbProduct.SelectedItem.ToString() == "— Выберите товар —")
            {
                cmbSize.DataSource = null;
                textBox2.Text = "0";
                return;
            }

            string selectedProductName = cmbProduct.SelectedItem.ToString();

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var rawSizes = db.Products
                    .Where(p => p.Name == selectedProductName)
                    .Select(p => new { p.Id, p.Size, p.CurrentStock, p.Article, p.SellingPrice, p.ExpiryDate })
                    .ToList();

                var availableSizes = rawSizes.Select(p => new
                {
                    p.Id,
                    p.Size,
                    p.CurrentStock,
                    p.Article,
                    SellingPrice = CurrencyConverter.ConvertPrice(p.SellingPrice),
                    ExpiryStr = p.ExpiryDate.HasValue ? p.ExpiryDate.Value.ToLocalTime().ToShortDateString() : "-"
                }).ToList();

                cmbSize.DataSource = availableSizes;
                cmbSize.DisplayMember = "Size";
                cmbSize.ValueMember = "Id";
                cmbSize.DropDownStyle = ComboBoxStyle.DropDownList;

                if (availableSizes.Count > 0)
                {
                    cmbSize.SelectedIndex = 0;
                    var firstSize = availableSizes[0];
                    textBox2.Text = firstSize.CurrentStock.ToString();
                }
                else
                {
                    textBox2.Text = "0";
                }
            }
        }

        private void cmbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSize.SelectedItem == null)
            {
                textBox2.Text = "0";
                return;
            }

            dynamic selected = cmbSize.SelectedItem;
            textBox2.Text = selected.CurrentStock.ToString();
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedItem == null ||
                cmbProduct.SelectedItem.ToString() == "— Выберите товар —")
            {
                MessageBox.Show("Выберите товар, размер и кол-во!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbSize.SelectedItem == null || cmbSize.SelectedValue == null)
            {
                MessageBox.Show("Выберите размер товара!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(textBox1.Text, out int qty) || qty <= 0)
            {
                MessageBox.Show("Введите количество товара!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Clear();
                textBox1.Focus();
                return;
            }

            if (!int.TryParse(textBox2.Text, out int available))
            {
                MessageBox.Show("Ошибка получения данных о наличии!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (qty > available)
            {
                MessageBox.Show($"На складе недостаточно товара! Доступно: {available} шт.", "Нехватка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Clear();
                textBox1.Focus();
                return;
            }

            dynamic selected = cmbSize.SelectedItem;
            int productId = selected.Id;
            string article = selected.Article;
            string productName = cmbProduct.Text;
            string size = selected.Size;
            decimal price = selected.SellingPrice;
            string expiry = selected.ExpiryStr;
            decimal sum = price * qty;

            bool exists = false;
            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                if (row.Cells["ProductId"].Value != null &&
                    (int)row.Cells["ProductId"].Value == productId)
                {
                    exists = true;
                    break;
                }
            }

            if (exists)
            {
                DialogResult result = MessageBox.Show("Этот товар уже добавлен в список. Добавить еще?",
                    "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    textBox1.Clear();
                    textBox1.Focus();
                    return;
                }
            }

            dgvCart.Rows.Add(productId, article, productName, size, qty, price, sum, expiry);
            textBox1.Clear();
            textBox1.Focus();

            int newAvailable = available - qty;
            textBox2.Text = newAvailable.ToString();
            UpdateTotalSum();
        }

        private void dgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCart.Columns[e.ColumnIndex].Name == "Delete")
            {
                int qtyToReturn = (int)dgvCart.Rows[e.RowIndex].Cells["Quantity"].Value;
                int currentAvailable = int.Parse(textBox2.Text);
                textBox2.Text = (currentAvailable + qtyToReturn).ToString();
                dgvCart.Rows.RemoveAt(e.RowIndex);
            }
            UpdateTotalSum();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (dgvCart.Rows.Count == 0)
            {
                MessageBox.Show("Список отгрузки пуст! Добавьте товары.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string recipient = textBox3.Text.Trim();
            if (string.IsNullOrEmpty(recipient))
            {
                MessageBox.Show("Укажите получателя товара!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Focus();
                return;
            }

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (DataGridViewRow row in dgvCart.Rows)
                        {
                            if (row.IsNewRow) continue;

                            int productId = (int)row.Cells["ProductId"].Value;
                            int qty = (int)row.Cells["Quantity"].Value;

                            var product = db.Products.Find(productId);
                            if (product != null)
                            {
                                if (product.CurrentStock < qty)
                                {
                                    throw new Exception($"Товар \"{product.Name}\" (размер {product.Size}) " +
                                        $"закончился! Доступно: {product.CurrentStock} шт.");
                                }

                                product.CurrentStock -= qty;

                                Shipment newShipment = new Shipment
                                {
                                    ShipmentDate = DateTime.UtcNow,
                                    Quantity = qty,
                                    ProductId = product.Id,
                                    UserId = _userId,
                                    Recipient = recipient,
                                    SellingPriceAtShipment = product.SellingPrice,
                                    CurrencyAtShipment = CurrencyConverter.CurrentCurrency,
                                    RateAtShipment = CurrencyConverter.CurrentRate
                                };
                                db.Shipments.Add(newShipment);
                            }
                        }

                        db.SaveChanges();
                        transaction.Commit();

                        MessageBox.Show("Отгрузка успешно оформлена!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Отменить оформление отгрузки?",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
        private void UpdateTotalSum()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                if (row.Cells["Sum"].Value != null)
                {
                    total += Convert.ToDecimal(row.Cells["Sum"].Value);
                }
            }
            var sumBox = this.Controls.Find("txtTotalSum", true).FirstOrDefault() as TextBox;
            if (sumBox != null)
            {
                sumBox.Text = $"{total:N2} {CurrencyConverter.CurrentCurrency}";
            }
        }

    }
}