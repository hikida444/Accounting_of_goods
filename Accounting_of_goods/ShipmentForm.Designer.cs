namespace WinFormsApp1
{
    partial class ShipmentForm
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
			lblTitle = new Label();
			cmbProduct = new ComboBox();
			cmbSize = new ComboBox();
			lblAvailableStock = new Label();
			btnAddToCart = new Button();
			dgvCart = new DataGridView();
			btnConfirm = new Button();
			btnCancel = new Button();
			textBox1 = new TextBox();
			label1 = new Label();
			label2 = new Label();
			label3 = new Label();
			label4 = new Label();
			textBox2 = new TextBox();
			label5 = new Label();
			textBox3 = new TextBox();
			((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
			SuspendLayout();
			// 
			// lblTitle
			// 
			lblTitle.AutoSize = true;
			lblTitle.Font = new Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
			lblTitle.Location = new Point(33, 78);
			lblTitle.Margin = new Padding(4, 0, 4, 0);
			lblTitle.Name = "lblTitle";
			lblTitle.Size = new Size(288, 27);
			lblTitle.TabIndex = 0;
			lblTitle.Text = "Формирование отгрузки";
			lblTitle.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// cmbProduct
			// 
			cmbProduct.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			cmbProduct.DropDownStyle = ComboBoxStyle.DropDownList;
			cmbProduct.Font = new Font("Arial", 7.8F);
			cmbProduct.FormattingEnabled = true;
			cmbProduct.Location = new Point(104, 138);
			cmbProduct.Margin = new Padding(4);
			cmbProduct.MaximumSize = new Size(235, 0);
			cmbProduct.Name = "cmbProduct";
			cmbProduct.Size = new Size(195, 24);
			cmbProduct.TabIndex = 1;
			cmbProduct.SelectedIndexChanged += cmbProduct_SelectedIndexChanged;
			// 
			// cmbSize
			// 
			cmbSize.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			cmbSize.DropDownStyle = ComboBoxStyle.DropDownList;
			cmbSize.Font = new Font("Arial", 7.8F);
			cmbSize.FormattingEnabled = true;
			cmbSize.Location = new Point(104, 181);
			cmbSize.Margin = new Padding(4);
			cmbSize.MaximumSize = new Size(235, 0);
			cmbSize.Name = "cmbSize";
			cmbSize.Size = new Size(195, 24);
			cmbSize.TabIndex = 2;
			cmbSize.SelectedIndexChanged += cmbSize_SelectedIndexChanged;
			// 
			// lblAvailableStock
			// 
			lblAvailableStock.AutoSize = true;
			lblAvailableStock.Font = new Font("Arial", 7.8F);
			lblAvailableStock.Location = new Point(57, 279);
			lblAvailableStock.Margin = new Padding(4, 0, 4, 0);
			lblAvailableStock.Name = "lblAvailableStock";
			lblAvailableStock.Size = new Size(131, 16);
			lblAvailableStock.TabIndex = 4;
			lblAvailableStock.Text = "Доступно на складе:";
			// 
			// btnAddToCart
			// 
			btnAddToCart.Font = new Font("Arial", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
			btnAddToCart.Location = new Point(78, 328);
			btnAddToCart.Margin = new Padding(4);
			btnAddToCart.Name = "btnAddToCart";
			btnAddToCart.Size = new Size(204, 38);
			btnAddToCart.TabIndex = 5;
			btnAddToCart.Text = "Добавить в список";
			btnAddToCart.UseVisualStyleBackColor = true;
			btnAddToCart.Click += btnAddToCart_Click;
			// 
			// dgvCart
			// 
			dgvCart.AllowUserToAddRows = false;
			dgvCart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = SystemColors.Window;
			dataGridViewCellStyle1.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
			dgvCart.DefaultCellStyle = dataGridViewCellStyle1;
			dgvCart.Location = new Point(345, 13);
			dgvCart.Margin = new Padding(4);
			dgvCart.Name = "dgvCart";
			dgvCart.ReadOnly = true;
			dgvCart.RowHeadersWidth = 82;
			dgvCart.Size = new Size(569, 446);
			dgvCart.TabIndex = 6;
			dgvCart.CellContentClick += dgvCart_CellContentClick;
			// 
			// btnConfirm
			// 
			btnConfirm.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btnConfirm.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
			btnConfirm.Location = new Point(700, 518);
			btnConfirm.Margin = new Padding(4);
			btnConfirm.Name = "btnConfirm";
			btnConfirm.Size = new Size(186, 47);
			btnConfirm.TabIndex = 7;
			btnConfirm.Text = "Подтвердить отгрузку";
			btnConfirm.UseVisualStyleBackColor = true;
			btnConfirm.Click += btnConfirm_Click;
			// 
			// btnCancel
			// 
			btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btnCancel.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
			btnCancel.Location = new Point(532, 518);
			btnCancel.Margin = new Padding(4);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(132, 47);
			btnCancel.TabIndex = 8;
			btnCancel.Text = "Отмена";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += btnCancel_Click;
			// 
			// textBox1
			// 
			textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			textBox1.Location = new Point(104, 226);
			textBox1.Margin = new Padding(4, 2, 4, 2);
			textBox1.MaximumSize = new Size(235, 0);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(195, 27);
			textBox1.TabIndex = 9;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Arial", 7.8F);
			label1.Location = new Point(57, 140);
			label1.Margin = new Padding(4, 0, 4, 0);
			label1.Name = "label1";
			label1.Size = new Size(41, 16);
			label1.TabIndex = 10;
			label1.Text = "Товар";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Arial", 7.8F);
			label2.Location = new Point(52, 186);
			label2.Margin = new Padding(4, 0, 4, 0);
			label2.Name = "label2";
			label2.Size = new Size(52, 16);
			label2.TabIndex = 11;
			label2.Text = "Размер";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Arial", 7.8F);
			label3.Location = new Point(56, 231);
			label3.Margin = new Padding(4, 0, 4, 0);
			label3.Name = "label3";
			label3.Size = new Size(47, 16);
			label3.TabIndex = 12;
			label3.Text = "Кол-во";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Arial", 7.8F);
			label4.Location = new Point(242, 279);
			label4.Margin = new Padding(4, 0, 4, 0);
			label4.Name = "label4";
			label4.Size = new Size(26, 16);
			label4.TabIndex = 13;
			label4.Text = "шт.";
			// 
			// textBox2
			// 
			textBox2.Location = new Point(194, 273);
			textBox2.Margin = new Padding(4, 2, 4, 2);
			textBox2.Name = "textBox2";
			textBox2.Size = new Size(42, 27);
			textBox2.TabIndex = 14;
			// 
			// label5
			// 
			label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			label5.AutoSize = true;
			label5.Font = new Font("Arial", 7.8F);
			label5.Location = new Point(388, 480);
			label5.Margin = new Padding(4, 0, 4, 0);
			label5.Name = "label5";
			label5.Size = new Size(42, 16);
			label5.TabIndex = 15;
			label5.Text = "Кому:";
			// 
			// textBox3
			// 
			textBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			textBox3.Location = new Point(436, 474);
			textBox3.Margin = new Padding(4, 2, 4, 2);
			textBox3.Name = "textBox3";
			textBox3.Size = new Size(446, 27);
			textBox3.TabIndex = 16;
			// 
			// ShipmentForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(914, 600);
			Controls.Add(textBox3);
			Controls.Add(label5);
			Controls.Add(textBox2);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(textBox1);
			Controls.Add(btnCancel);
			Controls.Add(btnConfirm);
			Controls.Add(dgvCart);
			Controls.Add(btnAddToCart);
			Controls.Add(lblAvailableStock);
			Controls.Add(cmbSize);
			Controls.Add(cmbProduct);
			Controls.Add(lblTitle);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Margin = new Padding(4);
			MaximizeBox = false;
			Name = "ShipmentForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Складской учёт — Оформление отгрузки";
			Load += ShipmentForm_Load;
			((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lblTitle;
        private ComboBox cmbProduct;
        private ComboBox cmbSize;
        private Button btnAddToCart;
        private DataGridView dgvCart;
        private Button btnConfirm;
        private Button btnCancel;
        private TextBox textBox1;
        internal Label lblAvailableStock;
        private Label label1;
        private Label label2;
        private Label label3;
        internal Label label4;
        private TextBox textBox2;
        private Label label5;
        private TextBox textBox3;
    }
}