//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLNS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PayRoll
    {
        public long PayrollId { get; set; }
        public Nullable<decimal> SalaryLevel { get; set; }
        public Nullable<decimal> SalaryBasic { get; set; }
        public Nullable<int> Coefficient { get; set; }
        public Nullable<decimal> Allowance { get; set; }
        public Nullable<long> EmployeeId { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankName { get; set; }
        public Nullable<System.DateTime> ProvidedDate { get; set; }
        public string ProvidedAddress { get; set; }
    }
}
