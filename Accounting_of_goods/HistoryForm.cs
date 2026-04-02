using System.Data;
using Microsoft.EntityFrameworkCore;
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

				var history = query
					.OrderByDescending(s => s.ShipmentDate)
					.Select(s => new
					{
						Дата = s.ShipmentDate.ToLocalTime(),
						Сотрудник = s.User.Login,
						Бренд = s.Product.Brand,
						Товар = s.Product.Name,
						Размер = s.Product.Size,
						Кол_во = s.Quantity,
						Получатель = s.Recipient
					})
					.ToList();

				dgvHistory.DataSource = history;
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
	}
}