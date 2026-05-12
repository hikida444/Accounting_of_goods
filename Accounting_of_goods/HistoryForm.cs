using Accounting_of_goods;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.IO;
using System.Text;
using WinFormsApp1.Models;

namespace WinFormsApp1
{
    public partial class HistoryForm : Form
    {
        public HistoryForm()
        {
            InitializeComponent();
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistory.RowHeadersVisible = false;

            dtpStartDate.MaxDate = DateTime.Today;
            dtpEndDate.MaxDate = DateTime.Today;

            dtpStartDate.MinDate = new DateTime(2020, 1, 1);
            dtpEndDate.MinDate = new DateTime(2020, 1, 1);

            dtpStartDate.Value = DateTime.Today.AddMonths(-1);
            dtpEndDate.Value = DateTime.Today;

            LoadHistory();
            AddSearchIcon(txtSearchHistory);
        }

        private void LoadHistory()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                DateTime start = dtpStartDate.Value.Date.ToUniversalTime();
                DateTime end = dtpEndDate.Value.Date.AddDays(1).AddTicks(-1).ToUniversalTime();

                string searchText = txtSearchHistory.Text.Trim().ToLower();

                var query = db.Shipments
                    .Include(s => s.Product)
                    .Include(s => s.User)
                    .Where(s => s.ShipmentDate >= start && s.ShipmentDate <= end)
                    .AsQueryable();

                if (!string.IsNullOrEmpty(searchText))
                {
                    query = query.Where(s =>
                        s.User.Login.ToLower().Contains(searchText) ||
                        s.Product.Name.ToLower().Contains(searchText) ||
                        s.Product.Brand.ToLower().Contains(searchText)
                    );
                }

                var rawHistory = query
                    .OrderByDescending(s => s.ShipmentDate)
                    .ToList();

                var history = rawHistory
                    .OrderByDescending(s => s.ShipmentDate)
                    .Select(s => new
                    {
                        Дата = s.ShipmentDate.ToLocalTime(),
                        Сотрудник = s.User.Login,
                        Бренд = s.Product.Brand,
                        Товар = s.Product.Name,
                        Размер = s.Product.Size,
                        Кол_во = s.Quantity,
                        Получатель = s.Recipient,
                        Сумма = Math.Round(s.SellingPriceAtShipment * s.RateAtShipment * s.Quantity, 2),
                        Прибыль = Math.Round((s.SellingPriceAtShipment - s.Product.PurchasePrice) * s.Quantity * s.RateAtShipment, 2),
                        Валюта = s.CurrencyAtShipment
                    })
                    .ToList();
                dgvHistory.DataSource = null;
                dgvHistory.Columns.Clear();
                dgvHistory.AutoGenerateColumns = true;
                dgvHistory.DataSource = history;

                if (dgvHistory.Columns["Кол_во"] != null) dgvHistory.Columns["Кол_во"].HeaderText = "Кол-во";
                if (dgvHistory.Columns["Сумма"] != null) dgvHistory.Columns["Сумма"].HeaderText = $"Сумма ({CurrencyConverter.CurrentCurrency})";
                if (dgvHistory.Columns["Прибыль"] != null) dgvHistory.Columns["Прибыль"].HeaderText = $"Прибыль ({CurrencyConverter.CurrentCurrency})";

                decimal totalRevenue = history.Sum(h => h.Сумма);
                decimal totalProfit = history.Sum(h => h.Прибыль);

                lblTotalRevenue.Text = $"{totalRevenue:N2} {CurrencyConverter.CurrentCurrency}";
                lblTotalProfit.Text = $"{totalProfit:N2} {CurrencyConverter.CurrentCurrency}";
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

        private void txtSearchHistory_TextChanged(object sender, EventArgs e)
        {
            LoadHistory();
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpStartDate.Value > DateTime.Today)
            {
                dtpStartDate.Value = DateTime.Today;
            }

            if (dtpStartDate.Value > dtpEndDate.Value)
            {
                dtpEndDate.Value = dtpStartDate.Value;
            }

            LoadHistory();
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpEndDate.Value > DateTime.Today)
            {
                dtpEndDate.Value = DateTime.Today;
            }

            if (dtpEndDate.Value < dtpStartDate.Value)
            {
                dtpStartDate.Value = dtpEndDate.Value;
            }

            LoadHistory();
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (sender == dtpStartDate)
            {
                if (dtpStartDate.Value > DateTime.Today)
                    dtpStartDate.Value = DateTime.Today;

                if (dtpStartDate.Value > dtpEndDate.Value)
                    dtpEndDate.Value = dtpStartDate.Value;
            }
            else if (sender == dtpEndDate)
            {
                if (dtpEndDate.Value > DateTime.Today)
                    dtpEndDate.Value = DateTime.Today;

                if (dtpEndDate.Value < dtpStartDate.Value)
                    dtpStartDate.Value = dtpEndDate.Value;
            }

            LoadHistory();
        }

        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            if (dgvHistory.Rows.Count == 0 || dgvHistory.Rows[0].IsNewRow)
            {
                MessageBox.Show("Нет данных для экспорта!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV файл (*.csv)|*.csv";
            sfd.FileName = $"История_отгрузок_{DateTime.Now:dd_MM_yyyy}.csv";
            sfd.Title = "Сохранить отчет как...";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName, false, new UTF8Encoding(true)))
                    {
                        string[] headers = new string[dgvHistory.Columns.Count];
                        for (int i = 0; i < dgvHistory.Columns.Count; i++)
                        {
                            headers[i] = dgvHistory.Columns[i].HeaderText;
                        }
                        sw.WriteLine(string.Join(";", headers));
                        foreach (DataGridViewRow row in dgvHistory.Rows)
                        {
                            if (row.IsNewRow) continue;

                            string[] cells = new string[dgvHistory.Columns.Count];
                            for (int i = 0; i < dgvHistory.Columns.Count; i++)
                            {
                                string cellValue = row.Cells[i].Value?.ToString() ?? "";
                                cells[i] = cellValue.Replace(";", ",");
                            }
                            sw.WriteLine(string.Join(";", cells));
                        }
                    }

                    MessageBox.Show("Данные успешно экспортированы!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}