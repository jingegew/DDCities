//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DDCities.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class RideRequest
    {
        public long RideRequstId { get; set; }
        public long FromAddressId { get; set; }
        public long ToAddressId { get; set; }
        public long UserId { get; set; }
        public System.DateTime LeaveAfter { get; set; }
        public System.DateTime LeaveBefore { get; set; }
        public Nullable<int> NumberOfRider { get; set; }
        public string Comment { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> LastUpdateOn { get; set; }
    
        public virtual Address Address { get; set; }
        public virtual Address Address1 { get; set; }
        public virtual User User { get; set; }
    }
}
