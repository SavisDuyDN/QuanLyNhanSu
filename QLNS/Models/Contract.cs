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
    
    public partial class Contract
    {
        public long ContractId { get; set; }
        public string Name { get; set; }
        public Nullable<long> EmployeeId { get; set; }
        public Nullable<int> DecisionNumber { get; set; }
        public Nullable<System.DateTime> EffectiveStartDate { get; set; }
        public Nullable<System.DateTime> EffectiveEndDate { get; set; }
        public Nullable<int> ContractType { get; set; }
        public string Description { get; set; }
    }
}
