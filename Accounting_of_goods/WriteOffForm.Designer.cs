namespace Accounting_of_goods
{
    partial class WriteOffForm
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
            dgvWriteOff = new DataGridView();
            btnCancel = new Button();
            txtTotalLoss = new TextBox();
            btnConfirm = new Button();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvWriteOff).BeginInit();
            SuspendLayout();
            // 
            // dgvWriteOff
            // 
            dgvWriteOff.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvWriteOff.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvWriteOff.Location = new Point(-3, 68);
            dgvWriteOff.Name = "dgvWriteOff";
            dgvWriteOff.RowHeadersWidth = 51;
            dgvWriteOff.Size = new Size(799, 373);
            dgvWriteOff.TabIndex = 0;
            dgvWriteOff.CellContentClick += dgvWriteOff_CellContentClick;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCancel.Font = new Font("Arial", 10.8F);
            btnCancel.Location = new Point(12, 540);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(130, 65);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txtTotalLoss
            // 
            txtTotalLoss.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtTotalLoss.Font = new Font("Arial", 10.8F);
            txtTotalLoss.Location = new Point(449, 578);
            txtTotalLoss.Name = "txtTotalLoss";
            txtTotalLoss.ReadOnly = true;
            txtTotalLoss.Size = new Size(143, 28);
            txtTotalLoss.TabIndex = 2;
            // 
            // btnConfirm
            // 
            btnConfirm.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnConfirm.Font = new Font("Arial", 10.8F);
            btnConfirm.Location = new Point(618, 540);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(170, 65);
            btnConfirm.TabIndex = 3;
            btnConfirm.Text = "Подтвердить списание";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.Font = new Font("Arial", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(304, 24);
            label1.Name = "label1";
            label1.Size = new Size(226, 24);
            label1.TabIndex = 4;
            label1.Text = "Товары к списанию";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 10.8F);
            label2.Location = new Point(449, 540);
            label2.Name = "label2";
            label2.Size = new Size(137, 21);
            label2.TabIndex = 5;
            label2.Text = "Общий убыток:";
            label2.TextAlign = ContentAlignment.BottomCenter;
            // 
            // WriteOffForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 617);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnConfirm);
            Controls.Add(txtTotalLoss);
            Controls.Add(btnCancel);
            Controls.Add(dgvWriteOff);
            Name = "WriteOffForm";
            Text = "Складской учёт – Списание";
            ((System.ComponentModel.ISupportInitialize)dgvWriteOff).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvWriteOff;
        private Button btnCancel;
        private TextBox txtTotalLoss;
        private Button btnConfirm;
        private Label label1;
        private Label label2;
    }
}