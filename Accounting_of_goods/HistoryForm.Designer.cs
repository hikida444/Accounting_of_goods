namespace WinFormsApp1
{
    partial class HistoryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			label1 = new Label();
			dtpStartDate = new DateTimePicker();
			dtpEndDate = new DateTimePicker();
			txtSearchHistory = new TextBox();
			dgvHistory = new DataGridView();
			label2 = new Label();
			label3 = new Label();
			((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.Anchor = AnchorStyles.Top;
			label1.AutoSize = true;
			label1.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
			label1.Location = new Point(374, 48);
			label1.Margin = new Padding(4, 0, 4, 0);
			label1.Name = "label1";
			label1.Size = new Size(221, 29);
			label1.TabIndex = 0;
			label1.Text = "История отгрузок";
			label1.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// dtpStartDate
			// 
			dtpStartDate.Font = new Font("Arial", 11.25F);
			dtpStartDate.Format = DateTimePickerFormat.Short;
			dtpStartDate.Location = new Point(111, 107);
			dtpStartDate.Margin = new Padding(4);
			dtpStartDate.Name = "dtpStartDate";
			dtpStartDate.Size = new Size(126, 29);
			dtpStartDate.TabIndex = 1;
			dtpStartDate.ValueChanged += dateTimePicker_ValueChanged;
			// 
			// dtpEndDate
			// 
			dtpEndDate.Font = new Font("Arial", 11.25F);
			dtpEndDate.Format = DateTimePickerFormat.Short;
			dtpEndDate.Location = new Point(293, 107);
			dtpEndDate.Margin = new Padding(4);
			dtpEndDate.Name = "dtpEndDate";
			dtpEndDate.Size = new Size(126, 29);
			dtpEndDate.TabIndex = 2;
			dtpEndDate.ValueChanged += dateTimePicker_ValueChanged;
			// 
			// txtSearchHistory
			// 
			txtSearchHistory.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			txtSearchHistory.Font = new Font("Arial", 11.25F);
			txtSearchHistory.Location = new Point(478, 107);
			txtSearchHistory.Margin = new Padding(4);
			txtSearchHistory.Name = "txtSearchHistory";
			txtSearchHistory.PlaceholderText = "Поиск по сотруднику или товару";
			txtSearchHistory.Size = new Size(400, 29);
			txtSearchHistory.TabIndex = 3;
			txtSearchHistory.TextChanged += txtSearchHistory_TextChanged;
			// 
			// dgvHistory
			// 
			dgvHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = SystemColors.Control;
			dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
			dgvHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			dgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.Window;
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
			dgvHistory.DefaultCellStyle = dataGridViewCellStyle2;
			dgvHistory.Location = new Point(1, 146);
			dgvHistory.Margin = new Padding(4);
			dgvHistory.Name = "dgvHistory";
			dgvHistory.ReadOnly = true;
			dgvHistory.RowHeadersWidth = 82;
			dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvHistory.Size = new Size(916, 458);
			dgvHistory.TabIndex = 4;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Arial", 11.25F);
			label2.Location = new Point(12, 110);
			label2.Name = "label2";
			label2.Size = new Size(92, 22);
			label2.TabIndex = 5;
			label2.Text = "Период с";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Arial", 11.25F);
			label3.Location = new Point(256, 110);
			label3.Name = "label3";
			label3.Size = new Size(30, 22);
			label3.TabIndex = 6;
			label3.Text = "по";
			// 
			// HistoryForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(914, 600);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(dgvHistory);
			Controls.Add(txtSearchHistory);
			Controls.Add(dtpEndDate);
			Controls.Add(dtpStartDate);
			Controls.Add(label1);
			Font = new Font("Segoe UI", 9F);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Margin = new Padding(4);
			MaximizeBox = false;
			Name = "HistoryForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Складской учёт — История отгрузок";
			Load += HistoryForm_Load;
			((System.ComponentModel.ISupportInitialize)dgvHistory).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private TextBox txtSearchHistory;
        private DataGridView dgvHistory;
		private Label label2;
		private Label label3;
	}
}