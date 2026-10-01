using System;
using System.Data;
using System.Windows.Forms;

namespace BillingSystem
{
    public partial class Form1 : Form
    {
        // 2.1 Define Delegates
        public delegate bool ValidateItemDelegate(string productName, int quantity, double price);
        public Func<double, double> DiscountCalculator;
        public Action<string> LogWriter;

        // 2.2 Define Events
        public event Action<string, int, double> OnItemAdded;
        public event Action<double, double, double> OnBillCalculated;
        public event Action OnBillCleared;

        private BillingLogger logger;
        private DataTable billDataTable;

        public Form1()
        {
            InitializeComponent();
            InitializeCustomComponents();
            SetupDelegatesAndEvents();
            SubscribeToEvents();

            // Connect button click events
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            this.btnCalculateTotal.Click += new System.EventHandler(this.btnCalculateTotal_Click);
            this.btnRemoveSelected.Click += new System.EventHandler(this.btnRemoveSelected_Click);
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // Connect KeyPress events
            this.txtProductName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProductName_KeyPress);
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
        }

        private void InitializeCustomComponents()
        {
            // Initialize DataTable for DataGridView
            billDataTable = new DataTable();
            billDataTable.Columns.Add("Product", typeof(string));
            billDataTable.Columns.Add("Qty", typeof(int));
            billDataTable.Columns.Add("Price", typeof(double));
            billDataTable.Columns.Add("Item Total", typeof(double));

            dataGridViewBill.DataSource = billDataTable;

            // Configure DataGridView appearance
            dataGridViewBill.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewBill.AllowUserToAddRows = false;

            // Set up discount calculator (10% discount)
            DiscountCalculator = subtotal => subtotal * 0.9;
        }

        private void SetupDelegatesAndEvents()
        {
            // Setup LogWriter delegate
            LogWriter = (message) => AddToLog(message);

            // Initialize logger
            logger = new BillingLogger(LogWriter);
        }

        private void SubscribeToEvents()
        {
            // Standard event subscription
            this.OnItemAdded += logger.OnItemAddedHandler;
            this.OnBillCalculated += logger.OnBillCalculatedHandler;
            this.OnBillCleared += logger.OnBillClearedHandler;

            // Multicast delegate - adding second subscriber (lambda)
            this.OnItemAdded += (name, qty, total) =>
            {
                // Update status label as second subscriber
                lblStatus.Text = $"Last added: {name} - {total:C}";
            };

            // Another multicast subscriber for BillCalculated (anonymous method)
            this.OnBillCalculated += delegate (double subtotal, double discount, double finalTotal)
            {
                // Update form title with total
                this.Text = $"Billing System - Total: {finalTotal:C}";
            };

            // Lambda subscription for BillCleared
            this.OnBillCleared += () =>
            {
                lblStatus.Text = "Ready - Bill cleared";
                this.Text = "Billing System";
            };
        }

        private void AddToLog(string message)
        {
            if (listBoxLog.InvokeRequired)
            {
                listBoxLog.Invoke(new Action(() => listBoxLog.Items.Add(message)));
            }
            else
            {
                listBoxLog.Items.Add(message);
            }
            // Auto-scroll to bottom
            if (listBoxLog.Items.Count > 0)
                listBoxLog.SelectedIndex = listBoxLog.Items.Count - 1;
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            string productName = txtProductName.Text.Trim();
            int quantity;
            double price;

            // Validate inputs using delegate
            ValidateItemDelegate validator = ValidateItem;

            if (!int.TryParse(txtQuantity.Text, out quantity))
            {
                MessageBox.Show("Invalid quantity! Please enter a valid number.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(txtPrice.Text, out price))
            {
                MessageBox.Show("Invalid price! Please enter a valid number.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!validator(productName, quantity, price))
            {
                return; // Validation failed, message already shown
            }

            // Calculate item total
            double itemTotal = quantity * price;

            // Add to DataGridView
            billDataTable.Rows.Add(productName, quantity, price, itemTotal);

            // Fire event
            OnItemAdded?.Invoke(productName, quantity, itemTotal);

            // Clear input fields
            txtProductName.Clear();
            txtQuantity.Clear();
            txtPrice.Clear();
            txtProductName.Focus();
        }

        private bool ValidateItem(string productName, int quantity, double price)
        {
            if (string.IsNullOrWhiteSpace(productName))
            {
                MessageBox.Show("Product name cannot be empty!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (quantity <= 0)
            {
                MessageBox.Show("Quantity must be greater than 0!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (price <= 0)
            {
                MessageBox.Show("Price must be greater than 0!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnCalculateTotal_Click(object sender, EventArgs e)
        {
            if (billDataTable.Rows.Count == 0)
            {
                MessageBox.Show("No items to calculate! Please add items first.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Calculate subtotal
            double subtotal = 0;
            foreach (DataRow row in billDataTable.Rows)
            {
                subtotal += Convert.ToDouble(row["Item Total"]);
            }

            // Apply discount using Func delegate
            double discountedTotal = DiscountCalculator(subtotal);
            double discountAmount = subtotal - discountedTotal;

            // Display totals
            lblTotalAmount.Text = $"{subtotal:C}";
            lblDiscountedTotal.Text = $"{discountedTotal:C}";
            lblDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            // Fire event
            OnBillCalculated?.Invoke(subtotal, discountAmount, discountedTotal);

            // Show discount info in a message box
            MessageBox.Show($"Subtotal: {subtotal:C}\nDiscount: {discountAmount:C}\nFinal Total: {discountedTotal:C}",
                "Bill Calculated", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRemoveSelected_Click(object sender, EventArgs e)
        {
            if (dataGridViewBill.CurrentRow == null)
            {
                MessageBox.Show("Please select an item to remove!", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the product name for logging
            string productName = dataGridViewBill.CurrentRow.Cells["Product"].Value.ToString();

            // Remove the row
            billDataTable.Rows.RemoveAt(dataGridViewBill.CurrentRow.Index);

            AddToLog($"[{DateTime.Now:HH:mm:ss}] Removed item: {productName}");

            // Reset totals if no items left
            if (billDataTable.Rows.Count == 0)
            {
                lblTotalAmount.Text = "$0.00";
                lblDiscountedTotal.Text = "$0.00";
                lblDateTime.Text = "";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear DataGridView
            billDataTable.Clear();

            // Clear textboxes
            txtProductName.Clear();
            txtQuantity.Clear();
            txtPrice.Clear();

            // Reset labels
            lblTotalAmount.Text = "$0.00";
            lblDiscountedTotal.Text = "$0.00";
            lblDateTime.Text = "";

            // Fire event
            OnBillCleared?.Invoke();
        }

        private void txtProductName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtQuantity.Focus();
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtPrice.Focus();
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnAddItem.PerformClick();
            }
        }
    }
}