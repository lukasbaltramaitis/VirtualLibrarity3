//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VirtualLibrarity.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Copy
    {
        public long Id { get; set; }
        public Nullable<System.DateTime> ReturnDate { get; set; }
        public string BookQRCode { get; set; }
        public Nullable<long> UserId { get; set; }
    }
}
