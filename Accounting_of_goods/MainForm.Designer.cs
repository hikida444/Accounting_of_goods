namespace WinFormsApp1
{
    partial class MainForm
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
            label1 = new Label();
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            сменитьАккаунтToolStripMenuItem = new ToolStripMenuItem();
            выходToolStripMenuItem = new ToolStripMenuItem();
            btnManageCategories = new ToolStripMenuItem();
            категорииToolStripMenuItem1 = new ToolStripMenuItem();
            btnShipment = new Button();
            btnHistory = new Button();
            txtSearch = new TextBox();
            dgvProducts = new DataGridView();
            btnAddProduct = new Button();
            btnSupply = new Button();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 11.25F);
            label1.Location = new Point(384, 69);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(0, 22);
            label1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            menuStrip1.Dock = DockStyle.None;
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, btnManageCategories });
            menuStrip1.Location = new Point(9, 9);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(185, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { сменитьАккаунтToolStripMenuItem, выходToolStripMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(59, 24);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // сменитьАккаунтToolStripMenuItem
            // 
            сменитьАккаунтToolStripMenuItem.Name = "сменитьАккаунтToolStripMenuItem";
            сменитьАккаунтToolStripMenuItem.Size = new Size(208, 26);
            сменитьАккаунтToolStripMenuItem.Text = "Сменить аккаунт";
            сменитьАккаунтToolStripMenuItem.Click += сменитьАккаунтToolStripMenuItem_Click;
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            выходToolStripMenuItem.Size = new Size(208, 26);
            выходToolStripMenuItem.Text = "Выход";
            выходToolStripMenuItem.Click += выходToolStripMenuItem_Click;
            // 
            // btnManageCategories
            // 
            btnManageCategories.DropDownItems.AddRange(new ToolStripItem[] { категорииToolStripMenuItem1 });
            btnManageCategories.Name = "btnManageCategories";
            btnManageCategories.Size = new Size(117, 24);
            btnManageCategories.Text = "Справочники";
            // 
            // категорииToolStripMenuItem1
            // 
            категорииToolStripMenuItem1.Name = "категорииToolStripMenuItem1";
            категорииToolStripMenuItem1.Size = new Size(165, 26);
            категорииToolStripMenuItem1.Text = "Категории";
            категорииToolStripMenuItem1.Click += категорииToolStripMenuItem1_Click;
            // 
            // btnShipment
            // 
            btnShipment.FlatAppearance.BorderColor = Color.Black;
            btnShipment.Font = new Font("Arial", 11.25F);
            btnShipment.Location = new Point(577, 64);
            btnShipment.Margin = new Padding(4);
            btnShipment.Name = "btnShipment";
            btnShipment.Size = new Size(158, 34);
            btnShipment.TabIndex = 3;
            btnShipment.Text = "Оформить отгрузку";
            btnShipment.UseVisualStyleBackColor = true;
            btnShipment.Click += btnShipment_Click;
            // 
            // btnHistory
            // 
            btnHistory.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnHistory.FlatAppearance.BorderColor = Color.Black;
            btnHistory.Font = new Font("Arial", 11.25F);
            btnHistory.Location = new Point(743, 98);
            btnHistory.Margin = new Padding(4);
            btnHistory.Name = "btnHistory";
            btnHistory.Size = new Size(158, 34);
            btnHistory.TabIndex = 4;
            btnHistory.Text = "История отгрузок";
            btnHistory.UseVisualStyleBackColor = true;
            btnHistory.Click += btnHistory_Click;
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Arial", 11.25F);
            txtSearch.Location = new Point(28, 69);
            txtSearch.Margin = new Padding(4);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Поиск по артикулу, бренду или названию";
            txtSearch.Size = new Size(439, 29);
            txtSearch.TabIndex = 5;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvProducts.DefaultCellStyle = dataGridViewCellStyle1;
            dgvProducts.Location = new Point(0, 172);
            dgvProducts.Margin = new Padding(4);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersWidth = 82;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(914, 492);
            dgvProducts.TabIndex = 6;
            dgvProducts.CellContentClick += dgvProducts_CellContentClick;
            // 
            // btnAddProduct
            // 
            btnAddProduct.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddProduct.FlatAppearance.BorderColor = Color.Black;
            btnAddProduct.Font = new Font("Arial", 11.25F);
            btnAddProduct.Location = new Point(743, 54);
            btnAddProduct.Margin = new Padding(4);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(158, 34);
            btnAddProduct.TabIndex = 7;
            btnAddProduct.Text = "Добавить товар";
            btnAddProduct.UseVisualStyleBackColor = true;
            btnAddProduct.Click += btnAddProduct_Click;
            // 
            // btnSupply
            // 
            btnSupply.FlatAppearance.BorderColor = Color.Black;
            btnSupply.Font = new Font("Arial", 11.25F);
            btnSupply.Location = new Point(577, 54);
            btnSupply.Margin = new Padding(4);
            btnSupply.Name = "btnSupply";
            btnSupply.Size = new Size(158, 34);
            btnSupply.TabIndex = 8;
            btnSupply.Text = "Поставки";
            btnSupply.UseVisualStyleBackColor = true;
            btnSupply.Click += btnSupply_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(btnSupply);
            Controls.Add(btnAddProduct);
            Controls.Add(dgvProducts);
            Controls.Add(txtSearch);
            Controls.Add(btnHistory);
            Controls.Add(btnShipment);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Складской учёт  — Главный экран";
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private Button btnShipment;
        private Button btnHistory;
        private TextBox txtSearch;
        private DataGridView dgvProducts;
        private ToolStripMenuItem сменитьАккаунтToolStripMenuItem;
        private ToolStripMenuItem выходToolStripMenuItem;
        private ToolStripMenuItem btnManageCategories;
        private ToolStripMenuItem категорииToolStripMenuItem1;
        private Button btnAddProduct;
        private Button btnSupply;
    }
}