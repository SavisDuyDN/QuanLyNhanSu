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
    
    public partial class Employee
    {
        public long EmployeeId { get; set; }
        public string EmployeeCode { get; set; }
        public string Full_name { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public Nullable<short> Gender { get; set; }
        public string PermanentAddress { get; set; }
        public string CurrentAddress { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Province { get; set; }
        public string EducationGrade { get; set; }
        public string Adress { get; set; }
        public Nullable<short> TypeOfEducation { get; set; }
        public string IdentityCardNumber { get; set; }
        public Nullable<System.DateTime> DateIssue { get; set; }
        public string PlaceIssued { get; set; }
        public string Image { get; set; }
        public string Language { get; set; }
        public Nullable<long> OrganizationId { get; set; }
        public Nullable<long> NationId { get; set; }
        public string PhoneNumber { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<long> FamilyRelationshipId { get; set; }
        public Nullable<long> PositionId { get; set; }
        public Nullable<long> AcademicLevelId { get; set; }
        public Nullable<int> Religion { get; set; }
        public string Description { get; set; }
    
        public virtual AcademicLevel AcademicLevel { get; set; }
        public virtual FamilyRelationShip FamilyRelationShip { get; set; }
        public virtual Nation Nation { get; set; }
        public virtual Position Position { get; set; }
    }
}
