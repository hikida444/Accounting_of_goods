using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Models;

namespace Accounting_of_goods
{
    public partial class WriteOffForm : Form
    {
        public WriteOffForm()
        {
            InitializeComponent();
        }

        private void WriteOffForm_Load(object sender, EventArgs e)
        {
            dgvWriteOff.AllowUserToAddRows = false;
            dgvWriteOff.RowHeadersVisible = false;
            dgvWriteOff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvWriteOff.Columns.Count == 0)
            {
                dgvWriteOff.Columns.Add("Article", "Артикул");
                dgvWriteOff.Columns.Add("Name", "Название");
                dgvWriteOff.Columns.Add("Size", "Размер");
                dgvWriteOff.Columns.Add("Quantity", "Количество");
                dgvWriteOff.Columns.Add("ExpiryDate", "Срок Актуальности");
                dgvWriteOff.Columns.Add("Loss", $"Убыток ({CurrencyConverter.CurrentCurrency})");
            }
            LoadExpiredProducts();
        }

        private void LoadExpiredProducts()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                DateTime today = DateTime.Today.ToUniversalTime();
                var expiredProducts = db.Products
                    .Where(p => p.ExpiryDate != null && p.ExpiryDate < today && p.CurrentStock > 0)
                    .ToList();

                dgvWriteOff.Rows.Clear();

                foreach (var p in expiredProducts)
                {
                    decimal lossInRubles = p.PurchasePrice * p.CurrentStock;
                    decimal displayLoss = CurrencyConverter.ConvertPrice(lossInRubles);

                    dgvWriteOff.Rows.Add(
                        p.Article,
                        p.Name,
                        p.Size,
                        p.CurrentStock,
                        p.ExpiryDate.Value.ToLocalTime().ToShortDateString(),
                        displayLoss
                    );
                }

                UpdateTotalLoss();

                if (dgvWriteOff.Rows.Count == 0)
                {
                    MessageBox.Show("Отличные новости! Просроченных товаров на складе нет.", "Всё чисто", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnConfirm.Enabled = false;
                }
            }
        }

        private void UpdateTotalLoss()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvWriteOff.Rows)
            {
                if (row.Cells["Loss"].Value != null)
                {
                    total += Convert.ToDecimal(row.Cells["Loss"].Value);
                }
            }

            if (txtTotalLoss != null)
            {
                txtTotalLoss.Text = $"{total:N2} {CurrencyConverter.CurrentCurrency}";
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (dgvWriteOff.Rows.Count == 0) return;

            var result = MessageBox.Show("Вы уверены, что хотите списать все эти товары? Их остаток станет равен нулю.",
                                         "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    foreach (DataGridViewRow row in dgvWriteOff.Rows)
                    {
                        string article = row.Cells["Article"].Value.ToString();

                        var product = db.Products.FirstOrDefault(p => p.Article == article);
                        if (product != null)
                        {
                            product.CurrentStock = 0;
                        }
                    }

                    db.SaveChanges();

                    MessageBox.Show("Просроченные товары успешно списаны со склада!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); 
                }
            }
        }
    }
}
