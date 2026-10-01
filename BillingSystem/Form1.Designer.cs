using System.Windows.Forms;

namespace BillingSystem
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblProductName;
        private Label lblQuantity;
        private Label lblPrice;
        private TextBox txtProductName;
        private TextBox txtQuantity;
        private TextBox txtPrice;
        private Button btnAddItem;
        private Button btnCalculateTotal;
        private Button btnClear;
        private Button btnRemoveSelected;
        private DataGridView dataGridViewBill;
        private Label lblTotal;
        private Label lblTotalAmount;
        private Label lblDiscounted;
        private Label lblDiscountedTotal;
        private Label lblDateTimeLabel;
        private Label lblDateTime;
        private Label lblLog;
        private ListBox listBoxLog;
        private Label lblStatus;
        private GroupBox grpInput;
        private GroupBox grpBill;
        private GroupBox grpLog;
        private GroupBox grpTotals;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.grpInput = new GroupBox();
            this.lblProductName = new Label();
            this.txtProductName = new TextBox();
            this.lblQuantity = new Label();
            this.txtQuantity = new TextBox();
            this.lblPrice = new Label();
            this.txtPrice = new TextBox();
            this.btnAddItem = new Button();
            this.grpBill = new GroupBox();
            this.dataGridViewBill = new DataGridView();
            this.btnRemoveSelected = new Button();
            this.btnClear = new Button();
            this.grpTotals = new GroupBox();
            this.lblTotal = new Label();
            this.lblTotalAmount = new Label();
            this.lblDiscounted = new Label();
            this.lblDiscountedTotal = new Label();
            this.lblDateTimeLabel = new Label();
            this.lblDateTime = new Label();
            this.btnCalculateTotal = new Button();
            this.grpLog = new GroupBox();
            this.listBoxLog = new ListBox();
            this.lblLog = new Label();
            this.lblStatus = new Label();
            this.grpInput.SuspendLayout();
            this.grpBill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBill)).BeginInit();
            this.grpTotals.SuspendLayout();
            this.grpLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpInput
            // 
            this.grpInput.Controls.Add(this.lblProductName);
            this.grpInput.Controls.Add(this.txtProductName);
            this.grpInput.Controls.Add(this.lblQuantity);
            this.grpInput.Controls.Add(this.txtQuantity);
            this.grpInput.Controls.Add(this.lblPrice);
            this.grpInput.Controls.Add(this.txtPrice);
            this.grpInput.Controls.Add(this.btnAddItem);
            this.grpInput.Location = new System.Drawing.Point(12, 12);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(400, 150);
            this.grpInput.TabIndex = 0;
            this.grpInput.TabStop = false;
            this.grpInput.Text = "Add Product";
            // 
            // lblProductName
            // 
            this.lblProductName.Location = new System.Drawing.Point(20, 30);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(100, 23);
            this.lblProductName.TabIndex = 0;
            this.lblProductName.Text = "Product Name:";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(120, 27);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(250, 23);
            this.txtProductName.TabIndex = 1;
            // 
            // lblQuantity
            // 
            this.lblQuantity.Location = new System.Drawing.Point(20, 60);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(100, 23);
            this.lblQuantity.TabIndex = 2;
            this.lblQuantity.Text = "Quantity:";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(120, 57);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(250, 23);
            this.txtQuantity.TabIndex = 3;
            // 
            // lblPrice
            // 
            this.lblPrice.Location = new System.Drawing.Point(20, 90);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(100, 23);
            this.lblPrice.TabIndex = 4;
            this.lblPrice.Text = "Price ($):";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(120, 87);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(250, 23);
            this.txtPrice.TabIndex = 5;
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(150, 116);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(100, 28);
            this.btnAddItem.TabIndex = 6;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.UseVisualStyleBackColor = true;
            // 
            // grpBill
            // 
            this.grpBill.Controls.Add(this.dataGridViewBill);
            this.grpBill.Controls.Add(this.btnRemoveSelected);
            this.grpBill.Controls.Add(this.btnClear);
            this.grpBill.Location = new System.Drawing.Point(12, 168);
            this.grpBill.Name = "grpBill";
            this.grpBill.Size = new System.Drawing.Size(400, 300);
            this.grpBill.TabIndex = 1;
            this.grpBill.TabStop = false;
            this.grpBill.Text = "Bill Items";
            // 
            // dataGridViewBill
            // 
            this.dataGridViewBill.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBill.Location = new System.Drawing.Point(10, 22);
            this.dataGridViewBill.Name = "dataGridViewBill";
            this.dataGridViewBill.Size = new System.Drawing.Size(380, 235);
            this.dataGridViewBill.TabIndex = 0;
            // 
            // btnRemoveSelected
            // 
            this.btnRemoveSelected.Location = new System.Drawing.Point(10, 263);
            this.btnRemoveSelected.Name = "btnRemoveSelected";
            this.btnRemoveSelected.Size = new System.Drawing.Size(120, 28);
            this.btnRemoveSelected.TabIndex = 1;
            this.btnRemoveSelected.Text = "Remove Selected";
            this.btnRemoveSelected.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(140, 263);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 28);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear All";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // grpTotals
            // 
            this.grpTotals.Controls.Add(this.lblTotal);
            this.grpTotals.Controls.Add(this.lblTotalAmount);
            this.grpTotals.Controls.Add(this.lblDiscounted);
            this.grpTotals.Controls.Add(this.lblDiscountedTotal);
            this.grpTotals.Controls.Add(this.lblDateTimeLabel);
            this.grpTotals.Controls.Add(this.lblDateTime);
            this.grpTotals.Controls.Add(this.btnCalculateTotal);
            this.grpTotals.Location = new System.Drawing.Point(418, 12);
            this.grpTotals.Name = "grpTotals";
            this.grpTotals.Size = new System.Drawing.Size(350, 200);
            this.grpTotals.TabIndex = 2;
            this.grpTotals.TabStop = false;
            this.grpTotals.Text = "Bill Summary";
            // 
            // lblTotal
            // 
            this.lblTotal.Location = new System.Drawing.Point(20, 30);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(100, 23);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "Subtotal:";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.Location = new System.Drawing.Point(130, 30);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(200, 23);
            this.lblTotalAmount.TabIndex = 1;
            this.lblTotalAmount.Text = "$0.00";
            // 
            // lblDiscounted
            // 
            this.lblDiscounted.Location = new System.Drawing.Point(20, 60);
            this.lblDiscounted.Name = "lblDiscounted";
            this.lblDiscounted.Size = new System.Drawing.Size(100, 23);
            this.lblDiscounted.TabIndex = 2;
            this.lblDiscounted.Text = "Final Total:";
            // 
            // lblDiscountedTotal
            // 
            this.lblDiscountedTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDiscountedTotal.ForeColor = System.Drawing.Color.Green;
            this.lblDiscountedTotal.Location = new System.Drawing.Point(130, 60);
            this.lblDiscountedTotal.Name = "lblDiscountedTotal";
            this.lblDiscountedTotal.Size = new System.Drawing.Size(200, 23);
            this.lblDiscountedTotal.TabIndex = 3;
            this.lblDiscountedTotal.Text = "$0.00";
            // 
            // lblDateTimeLabel
            // 
            this.lblDateTimeLabel.Location = new System.Drawing.Point(20, 90);
            this.lblDateTimeLabel.Name = "lblDateTimeLabel";
            this.lblDateTimeLabel.Size = new System.Drawing.Size(100, 23);
            this.lblDateTimeLabel.TabIndex = 4;
            this.lblDateTimeLabel.Text = "Bill Date & Time:";
            // 
            // lblDateTime
            // 
            this.lblDateTime.Location = new System.Drawing.Point(130, 90);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(200, 40);
            this.lblDateTime.TabIndex = 5;
            this.lblDateTime.Text = "";
            // 
            // btnCalculateTotal
            // 
            this.btnCalculateTotal.Location = new System.Drawing.Point(110, 140);
            this.btnCalculateTotal.Name = "btnCalculateTotal";
            this.btnCalculateTotal.Size = new System.Drawing.Size(140, 40);
            this.btnCalculateTotal.TabIndex = 6;
            this.btnCalculateTotal.Text = "Calculate Total (10% off)";
            this.btnCalculateTotal.UseVisualStyleBackColor = true;
            // 
            // grpLog
            // 
            this.grpLog.Controls.Add(this.listBoxLog);
            this.grpLog.Controls.Add(this.lblLog);
            this.grpLog.Location = new System.Drawing.Point(418, 218);
            this.grpLog.Name = "grpLog";
            this.grpLog.Size = new System.Drawing.Size(350, 200);
            this.grpLog.TabIndex = 3;
            this.grpLog.TabStop = false;
            this.grpLog.Text = "Activity Log";
            // 
            // listBoxLog
            // 
            this.listBoxLog.Location = new System.Drawing.Point(10, 55);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(330, 130);
            this.listBoxLog.TabIndex = 1;
            // 
            // lblLog
            // 
            this.lblLog.Location = new System.Drawing.Point(10, 25);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(330, 23);
            this.lblLog.TabIndex = 0;
            this.lblLog.Text = "Events will appear here:";
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.LightGray;
            this.lblStatus.Location = new System.Drawing.Point(12, 475);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(756, 30);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Ready";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 511);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.grpLog);
            this.Controls.Add(this.grpTotals);
            this.Controls.Add(this.grpBill);
            this.Controls.Add(this.grpInput);
            this.Name = "Form1";
            this.Text = "Billing System";
            this.ResumeLayout(false);
        }
    }
}