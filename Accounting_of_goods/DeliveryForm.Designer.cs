namespace Accounting_of_goods
{
    partial class DeliveryForm
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
            cmbProduct = new ComboBox();
            cmbSize = new ComboBox();
            numQty = new NumericUpDown();
            numPrice = new NumericUpDown();
            dtpExpiry = new DateTimePicker();
            btnImport = new Button();
            btnCancel = new Button();
            btnConfirmDelivery = new Button();
            dgvPreview = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnAddToList = new Button();
            ((System.ComponentModel.ISupportInitialize)numQty).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPreview).BeginInit();
            SuspendLayout();
            // 
            // cmbProduct
            // 
            cmbProduct.FormattingEnabled = true;
            cmbProduct.Location = new Point(136, 112);
            cmbProduct.Margin = new Padding(3, 4, 3, 4);
            cmbProduct.Name = "cmbProduct";
            cmbProduct.Size = new Size(152, 28);
            cmbProduct.TabIndex = 0;
            cmbProduct.SelectedIndexChanged += cmbProduct_SelectedIndexChanged;
            // 
            // cmbSize
            // 
            cmbSize.FormattingEnabled = true;
            cmbSize.Location = new Point(136, 164);
            cmbSize.Margin = new Padding(3, 4, 3, 4);
            cmbSize.Name = "cmbSize";
            cmbSize.Size = new Size(152, 28);
            cmbSize.TabIndex = 1;
            // 
            // numQty
            // 
            numQty.Location = new Point(136, 222);
            numQty.Margin = new Padding(3, 4, 3, 4);
            numQty.Name = "numQty";
            numQty.Size = new Size(152, 27);
            numQty.TabIndex = 2;
            numQty.ValueChanged += numQty_ValueChanged;
            // 
            // numPrice
            // 
            numPrice.Location = new Point(136, 281);
            numPrice.Margin = new Padding(3, 4, 3, 4);
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(153, 27);
            numPrice.TabIndex = 3;
            // 
            // dtpExpiry
            // 
            dtpExpiry.Location = new Point(136, 338);
            dtpExpiry.Margin = new Padding(3, 4, 3, 4);
            dtpExpiry.Name = "dtpExpiry";
            dtpExpiry.Size = new Size(152, 27);
            dtpExpiry.TabIndex = 4;
            // 
            // btnImport
            // 
            btnImport.Location = new Point(144, 450);
            btnImport.Margin = new Padding(3, 4, 3, 4);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(144, 35);
            btnImport.TabIndex = 5;
            btnImport.Text = "Импорт из файла";
            btnImport.UseVisualStyleBackColor = true;
            btnImport.Click += btnImport_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(863, 552);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(86, 35);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnConfirmDelivery
            // 
            btnConfirmDelivery.Location = new Point(955, 552);
            btnConfirmDelivery.Margin = new Padding(3, 4, 3, 4);
            btnConfirmDelivery.Name = "btnConfirmDelivery";
            btnConfirmDelivery.Size = new Size(131, 35);
            btnConfirmDelivery.TabIndex = 8;
            btnConfirmDelivery.Text = "Оприходовать";
            btnConfirmDelivery.UseVisualStyleBackColor = true;
            btnConfirmDelivery.Click += btnConfirmDelivery_Click;
            // 
            // dgvPreview
            // 
            dgvPreview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPreview.Location = new Point(335, 87);
            dgvPreview.Margin = new Padding(3, 4, 3, 4);
            dgvPreview.Name = "dgvPreview";
            dgvPreview.RowHeadersWidth = 51;
            dgvPreview.Size = new Size(760, 389);
            dgvPreview.TabIndex = 9;
            dgvPreview.CellContentClick += dgvPreview_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 115);
            label1.Name = "label1";
            label1.Size = new Size(51, 20);
            label1.TabIndex = 10;
            label1.Text = "Товар";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 172);
            label2.Name = "label2";
            label2.Size = new Size(60, 20);
            label2.TabIndex = 11;
            label2.Text = "Размер";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 229);
            label3.Name = "label3";
            label3.Size = new Size(58, 20);
            label3.TabIndex = 12;
            label3.Text = "Кол-во";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 288);
            label4.Name = "label4";
            label4.Size = new Size(103, 20);
            label4.TabIndex = 13;
            label4.Text = "Цена закупки";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(26, 343);
            label5.Name = "label5";
            label5.Size = new Size(90, 20);
            label5.TabIndex = 14;
            label5.Text = "Срок акту-и";
            // 
            // btnAddToList
            // 
            btnAddToList.Location = new Point(102, 396);
            btnAddToList.Margin = new Padding(3, 4, 3, 4);
            btnAddToList.Name = "btnAddToList";
            btnAddToList.Size = new Size(187, 35);
            btnAddToList.TabIndex = 16;
            btnAddToList.Text = "Добавить в список";
            btnAddToList.UseVisualStyleBackColor = true;
            btnAddToList.Click += btnAddToList_Click;
            // 
            // DeliveryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1107, 600);
            Controls.Add(btnAddToList);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvPreview);
            Controls.Add(btnConfirmDelivery);
            Controls.Add(btnCancel);
            Controls.Add(btnImport);
            Controls.Add(dtpExpiry);
            Controls.Add(numPrice);
            Controls.Add(numQty);
            Controls.Add(cmbSize);
            Controls.Add(cmbProduct);
            Margin = new Padding(3, 4, 3, 4);
            Name = "DeliveryForm";
            Text = "Складской учет – Поставки";
            Load += DeliveryForm_Load;
            ((System.ComponentModel.ISupportInitialize)numQty).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPreview).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbProduct;
        private ComboBox cmbSize;
        private NumericUpDown numQty;
        private NumericUpDown numPrice;
        private DateTimePicker dtpExpiry;
        private Button btnImport;
        private Button btnCancel;
        private Button btnConfirmDelivery;
        private DataGridView dgvPreview;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnAddToList;
    }
}