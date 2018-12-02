using System;
using System.Collections.Generic;

namespace SchDataApi.Models.Studs
{
    public partial class Expenses
    {
        public int ExpenseId { get; set; }
        public int? EmployeeId { get; set; }
        public string ExpenseType { get; set; }
        public string PurposeofExpense { get; set; }
        public decimal? AmountSpent { get; set; }
        public string Description { get; set; }
        public DateTime? DatePurchased { get; set; }
        public DateTime? DateSubmitted { get; set; }
        public decimal? AdvanceAmount { get; set; }
        public string PaymentMethod { get; set; }
        public string LoginName { get; set; }
        public int? Dormant { get; set; }
        public double? ModTime { get; set; }
        public string CTerminal { get; set; }
        public byte[] UpsizeTs { get; set; }
    }
}
