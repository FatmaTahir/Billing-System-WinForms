using System;

namespace BillingSystem
{
    public class BillingLogger
    {
        private Action<string> _logWriter;

        public BillingLogger(Action<string> logWriter)
        {
            _logWriter = logWriter;
        }

        public void OnItemAddedHandler(string itemName, int quantity, double itemTotal)
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            string message = $"[{timestamp}] Item Added: {itemName} x{quantity} = {itemTotal:C}";
            _logWriter?.Invoke(message);
        }

        public void OnBillCalculatedHandler(double subtotal, double discount, double finalTotal)
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            string message = $"[{timestamp}] Bill Calculated: Subtotal = {subtotal:C}, Discount = {discount:C}, Total = {finalTotal:C}";
            _logWriter?.Invoke(message);
        }

        public void OnBillClearedHandler()
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            string message = $"[{timestamp}] Bill Cleared: All items removed";
            _logWriter?.Invoke(message);
        }
    }
}