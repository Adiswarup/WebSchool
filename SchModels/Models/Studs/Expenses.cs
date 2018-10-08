using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchMod.Models.Studs
{
    public partial class Expenses
    {
        public int ExpenseId { get; set; }
        public int EmployeeId { get; set; }
        public string ExpenseType { get; set; }
        public string PurposeofExpense { get; set; }
        public decimal? AmountSpent { get; set; }
        public string Description { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DatePurchased { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DateSubmitted { get; set; }
        public decimal? AdvanceAmount { get; set; }
        public string PaymentMethod { get; set; }

        [ScaffoldColumn(false)]
        public string LoginName { get; set; }
        [ScaffoldColumn(false)]
        public int Dormant { get; set; }
        [ScaffoldColumn(false)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ModTime { get; set; }
        [ScaffoldColumn(false)]
        public string CTerminal { get; set; }
        public byte[] UpsizeTs { get; set; }
    }
    public partial class ExpensesEdit
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Action { get; set; }
        public string KeyColumn { get; set; }
        public Expenses Value { get; set; }
    }
}
